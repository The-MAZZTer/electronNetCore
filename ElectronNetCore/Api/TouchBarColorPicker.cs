using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarColorPicker_Ctor(int requestId, int id, TouchBarColorPickerConstructorOptionsDto options);

		Task TouchBarColorPicker_AvailableColors_Get(int requestId, int id);
		Task TouchBarColorPicker_AvailableColors_Set(int requestId, int id, string[] value);
		Task TouchBarColorPicker_SelectedColor_Get(int requestId, int id);
		Task TouchBarColorPicker_SelectedColor_Set(int requestId, int id, string value);
	}

	internal partial class ElectronHub {
		public Task TouchBarColorPicker_Ctor_Change(int id, string color) =>
			TouchBarColorPicker.OnChange(id, color);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarColorPicker : ElectronDisposable<TouchBarColorPicker>, ITouchBarComponent {
		public static async Task<TouchBarColorPicker> CreateAsync(TouchBarColorPickerConstructorOptions options) {
			int id = Electron.NextRequestId;
			TouchBarColorPicker picker = await Electron.FuncAsync<TouchBarColorPicker, int, TouchBarColorPickerConstructorOptionsDto>(id, x => x.TouchBarColorPicker_Ctor, 0, options?.ToTouchBarColorPickerConstructorOptionsDto());
			if (options?.Change != null) {
				picker.change = options.Change;
				pickers[id] = picker;
			}
			return picker;
		}

		private static readonly Dictionary<int, TouchBarColorPicker> pickers = new();
		internal static Task OnChange(int id, string color) {
			TouchBarColorPicker picker = pickers.GetValueOrDefault(id);
			picker?.change?.Invoke(color);
			return Task.CompletedTask;
		}

		internal TouchBarColorPicker(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private Action<string> change;

		private ElectronInstanceProperty<string[]> availableColors;
		public ElectronInstanceProperty<string[]> AvailableColors {
			get {
				if (this.availableColors == null) {
					this.availableColors = new(this.InternalId, x => x.TouchBarColorPicker_AvailableColors_Get,
						x => x.TouchBarColorPicker_AvailableColors_Set);
				}
				return this.availableColors;
			}
		}
		private ElectronInstanceProperty<string> selectedColor;
		public ElectronInstanceProperty<string> SelectedColor {
			get {
				if (this.selectedColor == null) {
					this.selectedColor = new(this.InternalId, x => x.TouchBarColorPicker_SelectedColor_Get,
						x => x.TouchBarColorPicker_SelectedColor_Set);
				}
				return this.selectedColor;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				int id = pickers.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					pickers.Remove(id);
				}
			}

			base.Dispose(disposing);
		}

		protected override ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				int id = pickers.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					pickers.Remove(id);
				}
			}

			return base.DisposeAsyncCore();
		}
	}
}
