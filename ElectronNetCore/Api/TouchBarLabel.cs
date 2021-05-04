using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarLabel_Ctor(int requestId, int id, TouchBarLabelConstructorOptions options);

		Task TouchBarLabel_Label_Get(int requestId, int id);
		Task TouchBarLabel_Label_Set(int requestId, int id, string value);
		Task TouchBarLabel_AccessibilityLabel_Get(int requestId, int id);
		Task TouchBarLabel_AccessibilityLabel_Set(int requestId, int id, string value);
		Task TouchBarLabel_TextColor_Get(int requestId, int id);
		Task TouchBarLabel_TextColor_Set(int requestId, int id, string value);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarLabel : ElectronDisposable<TouchBarLabel>, ITouchBarComponent {
		public static Task<TouchBarLabel> CreateAsync(TouchBarLabelConstructorOptions options) =>
			Electron.FuncAsync<TouchBarLabel, int, TouchBarLabelConstructorOptions>(x => x.TouchBarLabel_Ctor, 0, options);

		internal TouchBarLabel(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private ElectronInstanceProperty<string> label;
		public ElectronInstanceProperty<string> Label {
			get {
				if (this.label == null) {
					this.label = new(this.InternalId, x => x.TouchBarLabel_Label_Get,
						x => x.TouchBarLabel_Label_Set);
				}
				return this.label;
			}
		}
		private ElectronInstanceProperty<string> accessibilityLabel;
		public ElectronInstanceProperty<string> AccessibilityLabel {
			get {
				if (this.accessibilityLabel == null) {
					this.accessibilityLabel = new(this.InternalId, x => x.TouchBarLabel_AccessibilityLabel_Get,
						x => x.TouchBarLabel_AccessibilityLabel_Set);
				}
				return this.accessibilityLabel;
			}
		}
		private ElectronInstanceProperty<string> textColor;
		public ElectronInstanceProperty<string> TextColor {
			get {
				if (this.textColor == null) {
					this.textColor = new(this.InternalId, x => x.TouchBarLabel_TextColor_Get,
						x => x.TouchBarLabel_TextColor_Set);
				}
				return this.textColor;
			}
		}
	}
}
