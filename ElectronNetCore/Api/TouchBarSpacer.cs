using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarSpacer_Ctor(int requestId, int id, TouchBarSpacerConstructorOptions options);

		Task TouchBarSpacer_Size_Get(int requestId, int id);
		Task TouchBarSpacer_Size_Set(int requestId, int id, string value);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarSpacer : ElectronDisposable<TouchBarSpacer>, ITouchBarComponent {
		public static Task<TouchBarSpacer> CreateAsync(TouchBarSpacerConstructorOptions options) =>
			Electron.FuncAsync<TouchBarSpacer, int, TouchBarSpacerConstructorOptions>(x => x.TouchBarSpacer_Ctor, 0, options);

		internal TouchBarSpacer(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private ElectronInstanceProperty<string> size;
		public ElectronInstanceProperty<string> Size {
			get {
				if (this.size == null) {
					this.size = new(this.InternalId, x => x.TouchBarSpacer_Size_Get,
						x => x.TouchBarSpacer_Size_Set);
				}
				return this.size;
			}
		}
	}
}
