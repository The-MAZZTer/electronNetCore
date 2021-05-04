using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task TouchBarScrubber_Ctor(int requestId, int id, TouchBarScrubberConstructorOptionsDto options);

		Task TouchBarScrubber_Items_Get(int requestId, int id);
		Task TouchBarScrubber_Items_Set(int requestId, int id, ScrubberItemDto[] value);
		Task TouchBarScrubber_SelectedStyle_Get(int requestId, int id);
		Task TouchBarScrubber_SelectedStyle_Set(int requestId, int id, string value);
		Task TouchBarScrubber_OverlayStyle_Get(int requestId, int id);
		Task TouchBarScrubber_OverlayStyle_Set(int requestId, int id, string value);
		Task TouchBarScrubber_ShowArrowButtons_Get(int requestId, int id);
		Task TouchBarScrubber_ShowArrowButtons_Set(int requestId, int id, bool value);
		Task TouchBarScrubber_Mode_Get(int requestId, int id);
		Task TouchBarScrubber_Mode_Set(int requestId, int id, string value);
		Task TouchBarScrubber_Continuous_Get(int requestId, int id);
		Task TouchBarScrubber_Continuous_Set(int requestId, int id, bool value);
	}

	internal partial class ElectronHub {
		public Task TouchBarScrubber_Ctor_Select(int id, int selectedIndex) =>
			TouchBarScrubber.OnSelect(id, selectedIndex);
		public Task TouchBarScrubber_Ctor_Highlight(int id, int highlightedIndex) =>
			TouchBarScrubber.OnHighlight(id, highlightedIndex);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class TouchBarScrubber : ElectronDisposable<TouchBarScrubber>, ITouchBarComponent {
		public static async Task<TouchBarScrubber> CreateAsync(TouchBarScrubberConstructorOptions options) {
			int id = Electron.NextRequestId;
			TouchBarScrubber scrubber = await Electron.FuncAsync<TouchBarScrubber, int, TouchBarScrubberConstructorOptionsDto>(id, x => x.TouchBarScrubber_Ctor, 0, options?.ToTouchBarScrubberConstructorOptionsDto());
			if (options?.Select  != null || options?.Highlight != null) {
				if (options.Select != null) {
					scrubber.select = options.Select;
				}
				if (options.Highlight != null) {
					scrubber.highlight = options.Highlight;
				}
				scrubbers[id] = scrubber;
			}
			return scrubber;
		}

		private static readonly Dictionary<int, TouchBarScrubber> scrubbers = new();
		internal static Task OnSelect(int id, int selectedIndex) {
			TouchBarScrubber scrubber = scrubbers.GetValueOrDefault(id);
			scrubber?.select?.Invoke(selectedIndex);
			return Task.CompletedTask;
		}
		internal static Task OnHighlight(int id, int highlightedIndex) {
			TouchBarScrubber scrubber = scrubbers.GetValueOrDefault(id);
			scrubber?.highlight?.Invoke(highlightedIndex);
			return Task.CompletedTask;
		}

		internal TouchBarScrubber(int id) : base(id) { }

		int ITouchBarComponent.InternalId => this.InternalId;

		private Action<int> select;
		private Action<int> highlight;

		private ElectronInstanceProperty<ScrubberItem[], ScrubberItemDto[]> items;
		public ElectronInstanceProperty<ScrubberItem[], ScrubberItemDto[]> Items {
			get {
				if (this.items == null) {
					this.items = new(this.InternalId, x => x.TouchBarScrubber_Items_Get, x => x?.Select(x => x.ToScrubberItem()).ToArray(),
						x => x.TouchBarScrubber_Items_Set, x => x?.Select(x => x.ToScrubberItemDto()).ToArray());
				}
				return this.items;
			}
		}
		private ElectronInstanceProperty<string> selectedStyle;
		public ElectronInstanceProperty<string> SelectedStyle {
			get {
				if (this.selectedStyle == null) {
					this.selectedStyle = new(this.InternalId, x => x.TouchBarScrubber_SelectedStyle_Get,
						x => x.TouchBarScrubber_SelectedStyle_Set);
				}
				return this.selectedStyle;
			}
		}
		private ElectronInstanceProperty<string> overlayStyle;
		public ElectronInstanceProperty<string> OverlayStyle {
			get {
				if (this.overlayStyle == null) {
					this.overlayStyle = new(this.InternalId, x => x.TouchBarScrubber_OverlayStyle_Get,
						x => x.TouchBarScrubber_OverlayStyle_Set);
				}
				return this.overlayStyle;
			}
		}
		private ElectronInstanceProperty<bool> showArrowButtons;
		public ElectronInstanceProperty<bool> ShowArrowButtons {
			get {
				if (this.showArrowButtons == null) {
					this.showArrowButtons = new(this.InternalId, x => x.TouchBarScrubber_ShowArrowButtons_Get,
						x => x.TouchBarScrubber_ShowArrowButtons_Set);
				}
				return this.showArrowButtons;
			}
		}
		private ElectronInstanceProperty<string> mode;
		public ElectronInstanceProperty<string> Mode {
			get {
				if (this.mode == null) {
					this.mode = new(this.InternalId, x => x.TouchBarScrubber_Mode_Get,
						x => x.TouchBarScrubber_Mode_Set);
				}
				return this.mode;
			}
		}
		private ElectronInstanceProperty<bool> continuous;
		public ElectronInstanceProperty<bool> Continuous {
			get {
				if (this.continuous == null) {
					this.continuous = new(this.InternalId, x => x.TouchBarScrubber_Continuous_Get,
						x => x.TouchBarScrubber_Continuous_Set);
				}
				return this.continuous;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				int id = scrubbers.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					scrubbers.Remove(id);
				}
			}

			base.Dispose(disposing);
		}

		protected override ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				int id = scrubbers.FirstOrDefault(x => x.Value == this).Key;
				if (id > 0) {
					scrubbers.Remove(id);
				}
			}

			return base.DisposeAsyncCore();
		}
	}
}
