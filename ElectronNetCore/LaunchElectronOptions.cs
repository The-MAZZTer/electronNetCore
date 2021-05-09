using MZZT.ElectronNetCore.Api;
using System.Collections.Generic;

namespace MZZT.ElectronNetCore {
	public class LaunchElectronOptions {
		public bool SingleInstance { get; set; } = true;
		public string[] SecondInstanceArgv { get; set; }
		public string[] ElectronCommandLineFlags { get; set; }
		public Dictionary<string, string> ElectronEnvironment { get; set; }
		public Dictionary<string, string> ChromiumCommandLineFlags { get; set; }
		public Dictionary<string, string> Paths { get; set; }
		public bool HardwareAcceleration { get; set; } = true;
		public bool UnstableDomainBlockingFor3dApis { get; set; } = true;
		public bool ForceSandbox { get; set; }
		public CustomScheme[] PrivilegedSchemes { get; set; }
		public CrashReporterStartOptions CrashReporterOptions { get; set; }
		public string InitScriptPath { get; set; }
	}
}