﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MZZT.ElectronNetCore.Api;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	internal class ElectronNetCoreService : IHostedService {
		public ElectronNetCoreService(ILogger<ElectronNetCoreService> logger) {
			this.logger = logger;
		}

		public Task StartAsync(CancellationToken cancellationToken) {
			return Task.CompletedTask;
		}

		internal void LaunchElectron(IApplicationBuilder app, LaunchElectronOptions options = null) {
			IServerAddressesFeature seeverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "electron");
			this.electron = new Process();
			this.electron.StartInfo.FileName = Path.Combine(path, "node_modules", "electron", "dist", "electron");
			this.electron.StartInfo.CreateNoWindow = true;
			this.electron.StartInfo.RedirectStandardError = true;
			this.electron.StartInfo.RedirectStandardOutput = true;
			this.electron.StartInfo.UseShellExecute = false;
			this.electron.StartInfo.WorkingDirectory = path;

			if (options?.ElectronEnvironment != null) {
				foreach ((string key, string value) in options.ElectronEnvironment) {
					this.electron.StartInfo.EnvironmentVariables[key] = value;
				}
			}

			if (options?.ElectronCommandLineFlags != null ) {
				foreach (string arg in options.ElectronCommandLineFlags) {
					this.electron.StartInfo.ArgumentList.Add(arg);
				}
			}

			this.electron.StartInfo.ArgumentList.Add("--");

			this.electron.StartInfo.ArgumentList.Add(path);

			string address = seeverAddressesFeature.Addresses.First();
			this.electron.StartInfo.ArgumentList.Add(address);

			if (options != null) {
				if (options.InitScriptPath != null) {
					options.ElectronEnvironment = null;
					options.ElectronCommandLineFlags = null;
					options.InitScriptPath = Path.Combine("..", options.InitScriptPath);
				}
				this.electron.StartInfo.ArgumentList.Add(JsonSerializer.Serialize(options, new() {
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				}));
			}

			this.electron.ErrorDataReceived += this.Electron_ErrorDataReceived;
			this.electron.OutputDataReceived += this.Electron_OutputDataReceived;
			this.electron.Exited += this.Electron_Exited;
			this.electron.EnableRaisingEvents = true;
			this.electron.Start();
			this.electron.BeginErrorReadLine();
			this.electron.BeginOutputReadLine();

			if (this.electron.HasExited) {
				this.Electron_Exited(this.electron, new EventArgs());
			}
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
			Electron.OnProcessExited(this.electron.ExitCode);
		}

		private Process electron;
		private readonly ILogger<ElectronNetCoreService> logger;

		public Task StopAsync(CancellationToken cancellationToken) {
			if (this.electron != null) {
				this.electron.EnableRaisingEvents = false;
				if (!this.electron.HasExited) {
					this.electron.Kill();
				}
			}

			return Task.CompletedTask;
		}
	}
}
