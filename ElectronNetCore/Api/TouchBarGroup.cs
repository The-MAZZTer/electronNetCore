using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarGroup_Ctor(int requestId, int id, TouchBarGroupConstructorOptionsDto options);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarGroup : ElectronDisposable<TouchBarGroup>, ITouchBarComponent {
		public static Task<TouchBarGroup> CreateAsync(TouchBarGroupConstructorOptions options) =>
			Electron.FuncAsync<TouchBarGroup, int, TouchBarGroupConstructorOptionsDto>(x => x.TouchBarGroup_Ctor, 0, options?.ToTouchBarGroupConstructorOptionsDto());

		internal TouchBarGroup(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;
	}
}
