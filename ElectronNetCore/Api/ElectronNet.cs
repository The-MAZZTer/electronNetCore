using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Net_IsOnline(int requestId);

		Task Net_Online_Get(int requestId);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronNet {
		internal ElectronNet() { }

		public Task<bool> IsOnlineAsync() =>
			Electron.FuncAsync<bool>(x => x.Net_IsOnline);

		public ElectronReadOnlyProperty<bool> Online { get; } = new(x => x.Net_Online_Get);
	}
}