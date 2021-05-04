using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarButton_Ctor(int requestId, int id, TouchBarButtonConstructorOptionsDto options);

		Task TouchBarButton_AccessibilityLabel_Get(int requestId, int id);
		Task TouchBarButton_AccessibilityLabel_Set(int requestId, int id, string value);
		Task TouchBarButton_Label_Get(int requestId, int id);
		Task TouchBarButton_Label_Set(int requestId, int id, string value);
		Task TouchBarButton_BackgroundColor_Get(int requestId, int id);
		Task TouchBarButton_BackgroundColor_Set(int requestId, int id, string value);
		Task TouchBarButton_Icon_Get(int requestId, int id);
		Task TouchBarButton_Icon_Set(int requestId, int id, int value);
		Task TouchBarButton_IconPosition_Get(int requestId, int id);
		Task TouchBarButton_IconPosition_Set(int requestId, int id, string value);
		Task TouchBarButton_Enabled_Get(int requestId, int id);
		Task TouchBarButton_Enabled_Set(int requestId, int id, bool value);
	}

	internal partial class ElectronHub {
		public Task TouchBarButton_Ctor_Click(int id) =>
			TouchBarButton.OnClick(id);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarButton : ElectronDisposable<TouchBarButton>, ITouchBarComponent {
		public static async Task<TouchBarButton> CreateAsync(TouchBarButtonConstructorOptions options) {
			int id = Electron.NextRequestId;
			TouchBarButton button = await Electron.FuncAsync<TouchBarButton, int, TouchBarButtonConstructorOptionsDto>(id, x => x.TouchBarButton_Ctor, 0, options?.ToTouchBarButtonConstructorOptionsDto());
			if (options?.Click != null) {
				button.click = options.Click;
				buttons[id] = button;
			}
			return button;
		}

		private static readonly Dictionary<int, TouchBarButton> buttons = new();
		internal static Task OnClick(int id) {
			TouchBarButton button = buttons.GetValueOrDefault(id);
			button?.click?.Invoke();
			return Task.CompletedTask;
		}

		internal TouchBarButton(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private Action click;

		private ElectronInstanceProperty<string> accessibilityLabel;
		public ElectronInstanceProperty<string> AccessibilityLabel {
			get {
				if (this.accessibilityLabel == null) {
					this.accessibilityLabel = new(this.InternalId, x => x.TouchBarButton_AccessibilityLabel_Get,
						x => x.TouchBarButton_AccessibilityLabel_Set);
				}
				return this.accessibilityLabel;
			}
		}
		private ElectronInstanceProperty<string> label;
		public ElectronInstanceProperty<string> Label {
			get {
				if (this.label == null) {
					this.label = new(this.InternalId, x => x.TouchBarButton_Label_Get,
						x => x.TouchBarButton_Label_Set);
				}
				return this.label;
			}
		}
		private ElectronInstanceProperty<string> backgroundColor;
		public ElectronInstanceProperty<string> BackgroundColor {
			get {
				if (this.backgroundColor == null) {
					this.backgroundColor = new(this.InternalId, x => x.TouchBarButton_BackgroundColor_Get,
						x => x.TouchBarButton_BackgroundColor_Set);
				}
				return this.backgroundColor;
			}
		}
		private ElectronInstanceProperty<NativeImage> icon;
		public ElectronInstanceProperty<NativeImage> Icon {
			get {
				if (this.icon == null) {
					this.icon = new(this.InternalId, x => x.TouchBarButton_Icon_Get,
						x => (requestId, id, y) => x.TouchBarButton_Icon_Set(requestId, id, y?.InternalId ?? 0));
				}
				return this.icon;
			}
		}
		private ElectronInstanceProperty<string> iconPosition;
		public ElectronInstanceProperty<string> IconPosition {
			get {
				if (this.iconPosition == null) {
					this.iconPosition = new(this.InternalId, x => x.TouchBarButton_IconPosition_Get,
						x => x.TouchBarButton_IconPosition_Set);
				}
				return this.iconPosition;
			}
		}
		private ElectronInstanceProperty<bool> enabled;
		public ElectronInstanceProperty<bool> Enabled {
			get {
				if (this.enabled == null) {
					this.enabled = new(this.InternalId, x => x.TouchBarButton_Enabled_Get,
						x => x.TouchBarButton_Enabled_Set);
				}
				return this.enabled;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				int id = buttons.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					buttons.Remove(id);
				}
			}

			base.Dispose(disposing);
		}

		protected override ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				int id = buttons.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					buttons.Remove(id);
				}
			}

			return base.DisposeAsyncCore();
		}
	}
}
