using MZZT.ElectronNetCore.Api;
using System.Collections.Generic;
using System.IO;

namespace MZZT.ElectronNetCore {
	public class LaunchElectronOptions {
		public string ElectronFolder { get; set; } = "electron";
		public string[] ElectronCommandLineFlags { get; set; }
		public Dictionary<string, string> ElectronEnvironment { get; set; }
		public string[] SecondInstanceArgv { get; set; }
		public string SignalRHubPath { get; set; } = "/electroncorenetproxy";

		public bool SingleInstance { get; set; } = true;
		public Dictionary<string, string> ChromiumCommandLineFlags { get; set; }
		public Dictionary<string, string> Paths { get; set; }
		public bool HardwareAcceleration { get; set; } = true;
		public bool UnstableDomainBlockingFor3dApis { get; set; } = true;
		public bool ForceSandbox { get; set; }
		public CustomScheme[] PrivilegedSchemes { get; set; }
		public CrashReporterStartOptions CrashReporterOptions { get; set; }
		public string InitScriptPath { get; set; }

		internal LaunchElectronOptions ToElectronArgs() => new() {
			ElectronCommandLineFlags = null,
			ElectronEnvironment = null,
			SecondInstanceArgv = null,
			SignalRHubPath = null,
			SingleInstance = this.SingleInstance,
			ChromiumCommandLineFlags = this.ChromiumCommandLineFlags,
			Paths = this.Paths,
			HardwareAcceleration = this.HardwareAcceleration,
			UnstableDomainBlockingFor3dApis = this.UnstableDomainBlockingFor3dApis,
			ForceSandbox = this.ForceSandbox,
			PrivilegedSchemes = this.PrivilegedSchemes,
			CrashReporterOptions = this.CrashReporterOptions,
			InitScriptPath = this.InitScriptPath != null ? Path.Combine("..", this.InitScriptPath) : null
		};
	}
}