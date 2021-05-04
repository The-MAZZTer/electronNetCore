using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarSegmentedControl_Ctor(int requestId, int id, TouchBarSegmentedControlConstructorOptionsDto options);

		Task TouchBarSegmentedControl_SegmentStyle_Get(int requestId, int id);
		Task TouchBarSegmentedControl_SegmentStyle_Set(int requestId, int id, string value);
		Task TouchBarSegmentedControl_Segments_Get(int requestId, int id);
		Task TouchBarSegmentedControl_Segments_Set(int requestId, int id, SegmentedControlSegmentDto[] value);
		Task TouchBarSegmentedControl_SelectedIndex_Get(int requestId, int id);
		Task TouchBarSegmentedControl_SelectedIndex_Set(int requestId, int id, int value);
		Task TouchBarSegmentedControl_Mode_Get(int requestId, int id);
		Task TouchBarSegmentedControl_Mode_Set(int requestId, int id, string value);
	}

	internal partial class ElectronHub {
		public Task TouchBarSegmentedControl_Ctor_Change(int id, int selectedIndex, bool isSelected) =>
			TouchBarSegmentedControl.OnChange(id, selectedIndex, isSelected);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarSegmentedControl : ElectronDisposable<TouchBarSegmentedControl>, ITouchBarComponent {
		public static async Task<TouchBarSegmentedControl> CreateAsync(TouchBarSegmentedControlConstructorOptions options) {
			int id = Electron.NextRequestId;
			TouchBarSegmentedControl control = await Electron.FuncAsync<TouchBarSegmentedControl, int, TouchBarSegmentedControlConstructorOptionsDto>(id, x => x.TouchBarSegmentedControl_Ctor, 0, options?.ToTouchBarSegmentedControlConstructorOptionsDto());
			if (options?.Change != null) {
				control.change = options.Change;
				controls[id] = control;
			}
			return control;
		}

		private static readonly Dictionary<int, TouchBarSegmentedControl> controls = new();
		internal static Task OnChange(int id, int selectedIndex, bool isSelected) {
			TouchBarSegmentedControl control = controls.GetValueOrDefault(id);
			control?.change?.Invoke(selectedIndex, isSelected);
			return Task.CompletedTask;
		}

		internal TouchBarSegmentedControl(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private Action<int, bool> change;

		private ElectronInstanceProperty<string> segmentStyle;
		public ElectronInstanceProperty<string> SegmentStyle {
			get {
				if (this.segmentStyle == null) {
					this.segmentStyle = new(this.InternalId, x => x.TouchBarSegmentedControl_SegmentStyle_Get,
						x => x.TouchBarSegmentedControl_SegmentStyle_Set);
				}
				return this.segmentStyle;
			}
		}
		private ElectronInstanceProperty<SegmentedControlSegment[], SegmentedControlSegmentDto[]> segments;
		public ElectronInstanceProperty<SegmentedControlSegment[], SegmentedControlSegmentDto[]> Segments {
			get {
				if (this.segments == null) {
					this.segments = new(this.InternalId, x => x.TouchBarSegmentedControl_Segments_Get, x => x?.Select(x => x.ToSegmentedControlSegment()).ToArray(),
						x => x.TouchBarSegmentedControl_Segments_Set, x => x?.Select(x => x.ToSegmentedControlSegmentDto()).ToArray());
				}
				return this.segments;
			}
		}
		private ElectronInstanceProperty<int> selectedIndex;
		public ElectronInstanceProperty<int> SelectedIndex {
			get {
				if (this.selectedIndex == null) {
					this.selectedIndex = new(this.InternalId, x => x.TouchBarSegmentedControl_SelectedIndex_Get,
						x => x.TouchBarSegmentedControl_SelectedIndex_Set);
				}
				return this.selectedIndex;
			}
		}
		private ElectronInstanceProperty<string> mode;
		public ElectronInstanceProperty<string> Mode {
			get {
				if (this.mode == null) {
					this.mode = new(this.InternalId, x => x.TouchBarSegmentedControl_Mode_Get,
						x => x.TouchBarSegmentedControl_Mode_Set);
				}
				return this.mode;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				int id = controls.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					controls.Remove(id);
				}
			}

			base.Dispose(disposing);
		}

		protected override ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				int id = controls.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					controls.Remove(id);
				}
			}

			return base.DisposeAsyncCore();
		}
	}
}
