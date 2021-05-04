using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task PowerSaveBlocker_Start(int requestId, string type);
		Task PowerSaveBlocker_Stop(int requestId, int id);
		Task PowerSaveBlocker_IsStarted(int requestId, int id);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronPowerSaveBlocker {
		internal ElectronPowerSaveBlocker() { }

		public Task<int> StartAsync(string type) =>
			Electron.FuncAsync<int, string>(x => x.PowerSaveBlocker_Start, type);
		public Task<bool> StopAsync(int id) =>
			Electron.FuncAsync<bool, int>(x => x.PowerSaveBlocker_Stop, id);
		public Task<bool> IsStartedAsync(int id) =>
			Electron.FuncAsync<bool, int>(x => x.PowerSaveBlocker_IsStarted, id);
	}
}