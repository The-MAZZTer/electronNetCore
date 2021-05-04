using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task AppCommandLine_AppendSwitch(int requestId, string @switch, string value);
		Task AppCommandLine_AppendArgument(int requestId, string value);
		Task AppCommandLine_HasSwitch(int requestId, string @switch);
		Task AppCommandLine_GetSwitchValue(int requestId, string @switch);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronAppCommandLine {
		internal ElectronAppCommandLine() { }

		public Task AppendSwitchAsync(string @switch, string value = null) =>
			Electron.ActionAsync(x => x.AppCommandLine_AppendSwitch, @switch, value);
		public Task AppendArgumentAsync(string value) =>
			Electron.ActionAsync(x => x.AppCommandLine_AppendArgument, value);
		public Task<bool> HasSwitchAsync(string @switch) =>
			Electron.FuncAsync<bool, string>(x => x.AppCommandLine_HasSwitch, @switch);
		public Task<string> GetSwitchValueAsync(string @switch) =>
			Electron.FuncAsync<string, string>(x => x.AppCommandLine_GetSwitchValue, @switch);
	}
}
