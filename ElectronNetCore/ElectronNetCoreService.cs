﻿using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MZZT.ElectronNetCore.Api;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	internal class ElectronNetCoreService : IHostedService {
		private Process electron;
		private readonly ILogger<ElectronNetCoreService> logger;
		private readonly IOptions<LaunchElectronOptions> options;
		private readonly IServer server;
		private string tempFile;
		internal static Uri BaseUri { get; private set; }

		public ElectronNetCoreService(IServer server, ILogger<ElectronNetCoreService> logger,
			ILoggerFactory logFactory, IOptions<LaunchElectronOptions> options) {

			this.logger = logger;
			this.options = options;
			this.server = server;
			Electron.Log = logFactory.CreateLogger(typeof(Electron).FullName);
		}


		public Task StartAsync(CancellationToken cancellationToken) {
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.options.Value.ElectronFolder);
			this.electron = new Process();
			this.electron.StartInfo.FileName = Path.Combine(path, "electronnetcoreproxy");
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				this.electron.StartInfo.FileName += ".exe";
			}
			if (!File.Exists(this.electron.StartInfo.FileName)) {
				this.electron.StartInfo.FileName = Path.Combine(path, "node_modules", ".bin", "electron");
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
					this.electron.StartInfo.FileName += ".cmd";
				}
			}
			if (!File.Exists(this.electron.StartInfo.FileName)) {
				throw new FileNotFoundException("Can't find electron runtime!");
			}
			this.electron.StartInfo.CreateNoWindow = true;
			//this.electron.StartInfo.RedirectStandardInput = true;
			this.electron.StartInfo.RedirectStandardOutput = true;
			this.electron.StartInfo.RedirectStandardError = true;
			this.electron.StartInfo.UseShellExecute = false;
			this.electron.StartInfo.WorkingDirectory = path;

			if (this.options.Value.ElectronEnvironment != null) {
				foreach ((string key, string value) in this.options.Value.ElectronEnvironment) {
					this.electron.StartInfo.EnvironmentVariables[key] = value;
				}
			}

			if (this.options.Value.ElectronCommandLineFlags != null) {
				foreach (string arg in this.options.Value.ElectronCommandLineFlags) {
					this.electron.StartInfo.ArgumentList.Add(arg);
				}
			}

			this.electron.StartInfo.ArgumentList.Add("--");
			this.electron.StartInfo.ArgumentList.Add(path);

			this.tempFile = Path.GetTempFileName();

			this.electron.StartInfo.ArgumentList.Add(this.tempFile);

			this.electron.StartInfo.ArgumentList.Add(JsonSerializer.Serialize(this.options.Value.ToElectronArgs(), new JsonSerializerOptions() {
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			}));

			this.electron.StartInfo.ArgumentList.Add("--");

			string[] argv = this.options.Value.SecondInstanceArgv;
			if (argv != null) {
				foreach (string arg in argv) {
					this.electron.StartInfo.ArgumentList.Add(arg);
				}
			}

			this.electron.ErrorDataReceived += this.Electron_ErrorDataReceived;
			this.electron.OutputDataReceived += this.Electron_OutputDataReceived;
			this.electron.Exited += this.Electron_Exited;
			this.electron.EnableRaisingEvents = true;
			this.electron.Start();
			this.electron.BeginErrorReadLine();
			this.electron.BeginOutputReadLine();
			//this.electron.StandardInput.AutoFlush = true;

			if (this.electron.HasExited) {
				this.Electron_Exited(this.electron, new EventArgs());
			}

			Task.Run(async () => {
				Regex urlRegex = new(@"^(https?):\/\/(.*?)(:(\d+))?$", RegexOptions.IgnoreCase);
				IServerAddressesFeature serverAddressesFeature = this.server.Features.Get<IServerAddressesFeature>();

				string scheme = "http";
				int port = 0;
				while (port == 0) {
					Match match = serverAddressesFeature.Addresses.Select(x => urlRegex.Match(x)).FirstOrDefault(x => x.Success);
					if (match == null) {
						await Task.Delay(250);
						continue;
					}
					scheme = match.Groups[1].Value;
					if (!match.Groups[4].Success) {
						port = -1;
						break;
					}
					port = int.Parse(match.Groups[4].Value);

					if (port == 0) {
						await Task.Delay(250);
					}
				}

				string address;
				if (port < 0) {
					address = $"{scheme}://127.0.0.1";
				} else {
					address = $"{scheme}://127.0.0.1:{port}";
				}

				BaseUri = new Uri(address);

				string hubPath = this.options.Value.SignalRHubPath;
				if (!hubPath.StartsWith('/')) {
					hubPath = $"/{hubPath}";
				}

				using FileStream stream = new(this.tempFile, FileMode.Create, FileAccess.Write, FileShare.None);
				await stream.WriteAsync(Encoding.UTF8.GetBytes($"{address}{hubPath}"));
			});

			return Task.CompletedTask;
		}

		private void Electron_OutputDataReceived(object sender, DataReceivedEventArgs e) {
			if (string.IsNullOrEmpty(e.Data)) {
				return;
			}
			foreach (string message in e.Data.Replace("\r\n", "\n").Replace("\r", "\n").Trim('\n').Split('\n')) {
				this.logger.LogDebug(message);
			}
		}
		private void Electron_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
			if (string.IsNullOrEmpty(e.Data)) {
				return;
			}
			foreach (string message in e.Data.Replace("\r\n", "\n").Replace("\r", "\n").Trim('\n').Split('\n')) {
				this.logger.LogError(message);
			}
		}

		private void Electron_Exited(object sender, EventArgs e) {
			if (this.tempFile != null && File.Exists(this.tempFile)) {
				File.Delete(this.tempFile);
			}
			this.tempFile = null;

			Electron.OnProcessExited(this.electron.ExitCode);
		}

		public Task StopAsync(CancellationToken cancellationToken) {
			if (this.electron != null) {
				this.electron.EnableRaisingEvents = false;
				if (!this.electron.HasExited) {
					this.electron.Kill();
				}
			}

			if (this.tempFile != null && File.Exists(this.tempFile)) {
				File.Delete(this.tempFile);
			}
			this.tempFile = null;

			return Task.CompletedTask;
		}
	}
}
