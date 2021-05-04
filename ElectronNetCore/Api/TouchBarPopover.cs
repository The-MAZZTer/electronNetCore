using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarPopover_Ctor(int requestId, int id, TouchBarPopoverConstructorOptionsDto options);

		Task TouchBarPopover_Label_Get(int requestId, int id);
		Task TouchBarPopover_Label_Set(int requestId, int id, string value);
		Task TouchBarPopover_Icon_Get(int requestId, int id);
		Task TouchBarPopover_Icon_Set(int requestId, int id, int value);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarPopover : ElectronDisposable<TouchBarPopover>, ITouchBarComponent {
		public static Task<TouchBarPopover> CreateAsync(TouchBarPopoverConstructorOptions options) =>
			Electron.FuncAsync<TouchBarPopover, int, TouchBarPopoverConstructorOptionsDto>(x => x.TouchBarPopover_Ctor, 0, options?.ToTouchBarPopoverConstructorOptionsDto());

		internal TouchBarPopover(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private ElectronInstanceProperty<string> label;
		public ElectronInstanceProperty<string> Label {
			get {
				if (this.label == null) {
					this.label = new(this.InternalId, x => x.TouchBarPopover_Label_Get,
						x => x.TouchBarPopover_Label_Set);
				}
				return this.label;
			}
		}
		private ElectronInstanceProperty<NativeImage> icon;
		public ElectronInstanceProperty<NativeImage> Icon {
			get {
				if (this.icon == null) {
					this.icon = new(this.InternalId, x => x.TouchBarPopover_Icon_Get,
						x => (requestId, id, y) => x.TouchBarPopover_Icon_Set(requestId, id, y?.InternalId ?? 0));
				}
				return this.icon;
			}
		}
	}
}
