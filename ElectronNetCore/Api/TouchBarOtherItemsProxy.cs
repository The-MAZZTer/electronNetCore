using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarOtherItemsProxy_Ctor(int requestId, int id);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarOtherItemsProxy : ElectronDisposable<TouchBarOtherItemsProxy>, ITouchBarComponent {
		public static Task<TouchBarOtherItemsProxy> CreateAsync() =>
			Electron.FuncAsync<TouchBarOtherItemsProxy, int>(x => x.TouchBarOtherItemsProxy_Ctor, 0);

		internal TouchBarOtherItemsProxy(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;
	}
}
