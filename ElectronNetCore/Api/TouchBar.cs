using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBar_Ctor(int requestId, int id, TouchBarConstructorOptionsDto options);

		Task TouchBar_EscapeItem_Get(int requestId, int id);
		Task TouchBar_EscapeItem_Set(int requestId, int id, int value);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBar : ElectronDisposable<TouchBar> {
		public static Task<TouchBar> CreateAsync(TouchBarConstructorOptions options) =>
			Electron.FuncAsync<TouchBar, int, TouchBarConstructorOptionsDto>(x => x.TouchBar_Ctor, 0, options?.ToTouchBarConstructorOptionsDto());

		internal TouchBar(int id) : base(id) { }

		private ElectronInstanceProperty<ITouchBarComponent> escapeItem;
		public ElectronInstanceProperty<ITouchBarComponent> EscapeItem {
			get {
				if (this.escapeItem == null) {
					this.escapeItem = new(this.InternalId, x => x.TouchBar_EscapeItem_Get,
						x => (requestId, id, y) => x.TouchBar_EscapeItem_Set(requestId, id, y?.InternalId ?? 0));
				}
				return this.escapeItem;
			}
		}
	}

	public interface ITouchBarComponent {
		internal int InternalId { get; }
	}
}
