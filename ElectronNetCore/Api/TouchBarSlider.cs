using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarSlider_Ctor(int requestId, int id, TouchBarSliderConstructorOptionsDto options);

		Task TouchBarSlider_Label_Get(int requestId, int id);
		Task TouchBarSlider_Label_Set(int requestId, int id, string value);
		Task TouchBarSlider_Value_Get(int requestId, int id);
		Task TouchBarSlider_Value_Set(int requestId, int id, int value);
		Task TouchBarSlider_MinValue_Get(int requestId, int id);
		Task TouchBarSlider_MinValue_Set(int requestId, int id, int value);
		Task TouchBarSlider_MaxValue_Get(int requestId, int id);
		Task TouchBarSlider_MaxValue_Set(int requestId, int id, int value);
	}

	internal partial class ElectronHub {
		public Task TouchBarSlider_Ctor_Change(int id, int newValue) =>
			TouchBarSlider.OnChange(id, newValue);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarSlider : ElectronDisposable<TouchBarSlider>, ITouchBarComponent {
		public static async Task<TouchBarSlider> CreateAsync(TouchBarSliderConstructorOptions options) {
			int id = Electron.NextRequestId;
			TouchBarSlider slider = await Electron.FuncAsync<TouchBarSlider, int, TouchBarSliderConstructorOptionsDto>(id, x => x.TouchBarSlider_Ctor, 0, options?.ToTouchBarSliderConstructorOptionsDto());
			if (options?.Change != null) {
				slider.change = options.Change;
				sliders[id] = slider;
			}
			return slider;
		}

		private static readonly Dictionary<int, TouchBarSlider> sliders = new();
		internal static Task OnChange(int id, int newValue) {
			TouchBarSlider slider = sliders.GetValueOrDefault(id);
			slider?.change?.Invoke(newValue);
			return Task.CompletedTask;
		}

		internal TouchBarSlider(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private Action<int> change;

		private ElectronInstanceProperty<string> label;
		public ElectronInstanceProperty<string> Label {
			get {
				if (this.label == null) {
					this.label = new(this.InternalId, x => x.TouchBarSlider_Label_Get,
						x => x.TouchBarSlider_Label_Set);
				}
				return this.label;
			}
		}
		private ElectronInstanceProperty<int> value;
		public ElectronInstanceProperty<int> Value {
			get {
				if (this.value == null) {
					this.value = new(this.InternalId, x => x.TouchBarSlider_Value_Get,
						x => x.TouchBarSlider_Value_Set);
				}
				return this.value;
			}
		}
		private ElectronInstanceProperty<int> minValue;
		public ElectronInstanceProperty<int> MinValue {
			get {
				if (this.minValue == null) {
					this.minValue = new(this.InternalId, x => x.TouchBarSlider_MinValue_Get,
						x => x.TouchBarSlider_MinValue_Set);
				}
				return this.minValue;
			}
		}
		private ElectronInstanceProperty<int> maxValue;
		public ElectronInstanceProperty<int> MaxValue {
			get {
				if (this.maxValue == null) {
					this.maxValue = new(this.InternalId, x => x.TouchBarSlider_MaxValue_Get,
						x => x.TouchBarSlider_MaxValue_Set);
				}
				return this.maxValue;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				int id = sliders.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					sliders.Remove(id);
				}
			}

			base.Dispose(disposing);
		}

		protected override ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				int id = sliders.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					sliders.Remove(id);
				}
			}

			return base.DisposeAsyncCore();
		}
	}
}
