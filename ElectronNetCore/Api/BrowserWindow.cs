using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class BrowserWindow {
		private static readonly Dictionary<int, BrowserWindow> instances = new();

		public static IEnumerable<BrowserWindow> GetAllWindows() {
			return instances.Values;
		}
		public static Task<BrowserWindow> GetFocusedWindowAsync() =>
			Electron.FuncAsync<BrowserWindow, int>(x => x.BrowserWindow_GetFocusedWindow, 0);
		public static Task<BrowserWindow> FromWebContentsAsync(WebContents webContents) =>
			Electron.FuncAsync<BrowserWindow, int, int>(x => x.BrowserWindow_FromWebContents, 0, webContents?.Id ?? 0);
		public static Task<BrowserWindow> FromBrowserViewAsync(BrowserView browserView) =>
			Electron.FuncAsync<BrowserWindow, int, int>(x => x.BrowserWindow_FromBrowserView, 0, browserView?.Id ?? 0);
		public static BrowserWindow FromId(int id) {
			return instances.GetValueOrDefault(id);
		}

		internal BrowserWindow(int id) {
			this.Id = id;

			instances[id] = this;
		}
		public int Id { get; }

		private bool blockPageTitleUpdates;
		public bool BlockPageTitleUpdates {
			get => this.blockPageTitleUpdates;
			set {
				if (this.blockPageTitleUpdates == value) {
					return;
				}
				this.blockPageTitleUpdates = value;

				Task.Run(() => ElectronHub.Electron.BrowserWindow_PageTitleUpdated_PreventDefault(0, value));
			}
		}

		public event EventHandler<BrowserWindowPageTitleUpdatedEventArgs> PageTitleUpdated;
		internal Task OnPageTitleUpdated(string title, bool explicitSet) {
			this.PageTitleUpdated?.Invoke(this, new(title, explicitSet));
			return Task.CompletedTask;
		}

		private bool blockClose;
		public bool BlockClose {
			get => this.blockClose;
			set {
				if (this.blockClose == value) {
					return;
				}
				this.blockClose = value;

				Task.Run(() => ElectronHub.Electron.BrowserWindow_Close_PreventDefault(0, value));
			}
		}

		public event EventHandler Close;
		internal Task OnClose() {
			this.Close?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Closed;
		internal Task OnClosed() {
			this.Closed?.Invoke(this, new());
			instances.Remove(this.Id);
			return Task.CompletedTask;
		}

		public event EventHandler SessionEnd;
		internal Task OnSessionEnd() {
			this.SessionEnd?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Unresponsive;
		internal Task OnUnresponsive() {
			this.Unresponsive?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Responsive;
		internal Task OnResponsive() {
			this.Responsive?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Blur;
		internal Task OnBlur() {
			this.Blur?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Focus;
		internal Task OnFocus() {
			this.Focus?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Show;
		internal Task OnShow() {
			this.Show?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Hide;
		internal Task OnHide() {
			this.Hide?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler ReadyToShow;
		internal Task OnReadyToShow() {
			this.ReadyToShow?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Maximize;
		internal Task OnMaximize() {
			this.Maximize?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Unmaximize;
		internal Task OnUnmaximize() {
			this.Unmaximize?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Minimize;
		internal Task OnMinimize() {
			this.Minimize?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Restore;
		internal Task OnRestore() {
			this.Restore?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool blockWillResize;
		public bool BlockWillResize {
			get => this.blockWillResize;
			set {
				if (this.blockWillResize == value) {
					return;
				}
				this.blockWillResize = value;

				Task.Run(() => ElectronHub.Electron.BrowserWindow_WillResize_PreventDefault(0, value));
			}
		}

		public event EventHandler<RectangleEventArgs> WillResize;
		internal Task OnWillResize(Rectangle newBounds) {
			this.WillResize?.Invoke(this, new(newBounds));
			return Task.CompletedTask;
		}

		public event EventHandler Resize;
		internal Task OnResize() {
			this.Resize?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Resized;
		internal Task OnResized() {
			this.Resized?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool blockWillMove;
		public bool BlockWillMove {
			get => this.blockWillMove;
			set {
				if (this.blockWillMove == value) {
					return;
				}
				this.blockWillMove = value;

				Task.Run(() => ElectronHub.Electron.BrowserWindow_WillMove_PreventDefault(0, value));
			}
		}

		public event EventHandler<RectangleEventArgs> WillMove;
		internal Task OnWillMove(Rectangle newBounds) {
			this.WillMove?.Invoke(this, new(newBounds));
			return Task.CompletedTask;
		}

		public event EventHandler Move;
		internal Task OnMove() {
			this.Move?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Moved;
		internal Task OnMoved() {
			this.Moved?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler EnterFullScreen;
		internal Task OnEnterFullScreen() {
			this.EnterFullScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler LeaveFullScreen;
		internal Task OnLeaveFullScreen() {
			this.LeaveFullScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler EnterHtmlFullScreen;
		internal Task OnEnterHtmlFullScreen() {
			this.EnterHtmlFullScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler LeaveHtmlFullScreen;
		internal Task OnLeaveHtmlFullScreen() {
			this.LeaveHtmlFullScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowAlwaysOnTopChangedEventArgs> AlwaysOnTopChanged;
		internal Task OnAlwaysOnTopChanged(bool isAlwaysOnTop) {
			this.AlwaysOnTopChanged?.Invoke(this, new(isAlwaysOnTop));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowAppCommandEventArgs> AppCommand;
		internal Task OnAppCommand(string command) {
			this.AppCommand?.Invoke(this, new(command));
			return Task.CompletedTask;
		}

		public event EventHandler ScrollTouchBegin;
		internal Task OnScrollTouchBegin() {
			this.ScrollTouchBegin?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler ScrollTouchEnd;
		internal Task OnScrollTouchEnd() {
			this.ScrollTouchEnd?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler ScrollTouchEdge;
		internal Task OnScrollTouchEdge() {
			this.ScrollTouchEdge?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowSwipeEventArgs> Swipe;
		internal Task OnSwipe(string direction) {
			this.Swipe?.Invoke(this, new(direction));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowRotateGestureEventArgs> RotateGesture;
		internal Task OnRotateGesture(double rotation) {
			this.RotateGesture?.Invoke(this, new(rotation));
			return Task.CompletedTask;
		}

		public event EventHandler SheetBegin;
		internal Task OnSheetBegin() {
			this.SheetBegin?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler SheetEnd;
		internal Task OnSheetEnd() {
			this.SheetEnd?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler NewWindowForTab;
		internal Task OnNewWindowForTab() {
			this.NewWindowForTab?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool blockSystemContextMenu;
		public bool BlockSystemContextMenu {
			get => this.blockSystemContextMenu;
			set {
				if (this.blockSystemContextMenu == value) {
					return;
				}
				this.blockSystemContextMenu = value;

				Task.Run(() => ElectronHub.Electron.BrowserWindow_SystemContextMenu_PreventDefault(0, value));
			}
		}

		public event EventHandler<PointEventArgs> SystemContextMenu;
		internal Task OnSystemContextMenu(Point point) {
			this.SystemContextMenu?.Invoke(this, new(point));
			return Task.CompletedTask;
		}

	}
}
