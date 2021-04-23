using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class BrowserWindow {
		private static readonly Dictionary<int, BrowserWindow> instances = new();

		public static Task<BrowserWindow> CreateAsync(BrowserWindowConstructorOptions options = null) =>
			Electron.FuncAsync<BrowserWindow, int, BrowserWindowConstructorOptionsDto>(x => x.BrowserWindow_Ctor, 0, options.ToBrowserWindowConstructorOptionsDto());

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

		private ElectronReadOnlyProperty<WebContents> webContents;
		public ElectronReadOnlyProperty<WebContents> WebContents {
			get {
				if (this.webContents == null) {
					this.webContents = new(x => id => x.BrowserWindow_WebContents_Get(id, this.Id));
				}
				return this.webContents;
			}
		}

		private ElectronProperty<bool> autoHideMenuBar;
		public ElectronProperty<bool> AutoHideMenuBar {
			get {
				if (this.autoHideMenuBar == null) {
					this.autoHideMenuBar = new(x => id => x.BrowserWindow_AutoHideMenuBar_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_AutoHideMenuBar_Set(id, this.Id, value));
				}
				return this.autoHideMenuBar;
			}
		}

		private ElectronProperty<bool> simpleFullScreen;
		public ElectronProperty<bool> SimpleFullScreen {
			get {
				if (this.simpleFullScreen == null) {
					this.simpleFullScreen = new(x => id => x.BrowserWindow_SimpleFullScreen_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_SimpleFullScreen_Set(id, this.Id, value));
				}
				return this.simpleFullScreen;
			}
		}

		private ElectronProperty<bool> fullScreen;
		public ElectronProperty<bool> FullScreen {
			get {
				if (this.fullScreen == null) {
					this.fullScreen = new(x => id => x.BrowserWindow_FullScreen_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_FullScreen_Set(id, this.Id, value));
				}
				return this.fullScreen;
			}
		}

		private ElectronProperty<bool> visibleOnAllWorkspaces;
		public ElectronProperty<bool> VisibleOnAllWorkspaces {
			get {
				if (this.visibleOnAllWorkspaces == null) {
					this.visibleOnAllWorkspaces = new(x => id => x.BrowserWindow_VisibleOnAllWorkspaces_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_VisibleOnAllWorkspaces_Set(id, this.Id, value));
				}
				return this.visibleOnAllWorkspaces;
			}
		}

		private ElectronProperty<bool> shadow;
		public ElectronProperty<bool> Shadow {
			get {
				if (this.shadow == null) {
					this.shadow = new(x => id => x.BrowserWindow_Shadow_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Shadow_Set(id, this.Id, value));
				}
				return this.shadow;
			}
		}

		private ElectronProperty<bool> menuBarVisible;
		public ElectronProperty<bool> MenuBarVisible {
			get {
				if (this.menuBarVisible == null) {
					this.menuBarVisible = new(x => id => x.BrowserWindow_MenuBarVisible_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_MenuBarVisible_Set(id, this.Id, value));
				}
				return this.menuBarVisible;
			}
		}

		private ElectronProperty<bool> kiosk;
		public ElectronProperty<bool> Kiosk {
			get {
				if (this.kiosk == null) {
					this.kiosk = new(x => id => x.BrowserWindow_Kiosk_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Kiosk_Set(id, this.Id, value));
				}
				return this.kiosk;
			}
		}

		private ElectronProperty<bool> documentEdited;
		public ElectronProperty<bool> DocumentEdited {
			get {
				if (this.documentEdited == null) {
					this.documentEdited = new(x => id => x.BrowserWindow_DocumentEdited_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_DocumentEdited_Set(id, this.Id, value));
				}
				return this.documentEdited;
			}
		}

		private ElectronProperty<string> representedFilename;
		public ElectronProperty<string> RepresentedFilename {
			get {
				if (this.representedFilename == null) {
					this.representedFilename = new(x => id => x.BrowserWindow_RepresentedFilename_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_RepresentedFilename_Set(id, this.Id, value));
				}
				return this.representedFilename;
			}
		}

		private ElectronProperty<string> title;
		public ElectronProperty<string> Title {
			get {
				if (this.title == null) {
					this.title = new(x => id => x.BrowserWindow_Title_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Title_Set(id, this.Id, value));
				}
				return this.title;
			}
		}

		private ElectronProperty<bool> minimizable;
		public ElectronProperty<bool> Minimizable {
			get {
				if (this.minimizable == null) {
					this.minimizable = new(x => id => x.BrowserWindow_Minimizable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Minimizable_Set(id, this.Id, value));
				}
				return this.minimizable;
			}
		}

		private ElectronProperty<bool> maximizable;
		public ElectronProperty<bool> Maximizable {
			get {
				if (this.maximizable == null) {
					this.maximizable = new(x => id => x.BrowserWindow_Maximizable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Maximizable_Set(id, this.Id, value));
				}
				return this.maximizable;
			}
		}

		private ElectronProperty<bool> fullScreenable;
		public ElectronProperty<bool> FullScreenable {
			get {
				if (this.fullScreenable == null) {
					this.fullScreenable = new(x => id => x.BrowserWindow_FullScreenable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_FullScreenable_Set(id, this.Id, value));
				}
				return this.fullScreenable;
			}
		}

		private ElectronProperty<bool> resizable;
		public ElectronProperty<bool> Resizable {
			get {
				if (this.resizable == null) {
					this.resizable = new(x => id => x.BrowserWindow_Resizable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Resizable_Set(id, this.Id, value));
				}
				return this.resizable;
			}
		}

		private ElectronProperty<bool> closable;
		public ElectronProperty<bool> Closable {
			get {
				if (this.closable == null) {
					this.closable = new(x => id => x.BrowserWindow_Closable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Closable_Set(id, this.Id, value));
				}
				return this.closable;
			}
		}

		private ElectronProperty<bool> movable;
		public ElectronProperty<bool> Movable {
			get {
				if (this.movable == null) {
					this.movable = new(x => id => x.BrowserWindow_Movable_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_Movable_Set(id, this.Id, value));
				}
				return this.movable;
			}
		}

		private ElectronProperty<bool> excludedFromShownWindowsMenu;
		public ElectronProperty<bool> ExcludedFromShownWindowsMenu {
			get {
				if (this.excludedFromShownWindowsMenu == null) {
					this.excludedFromShownWindowsMenu = new(x => id => x.BrowserWindow_ExcludedFromShownWindowsMenu_Get(id, this.Id),
						x => (id, value) => x.BrowserWindow_ExcludedFromShownWindowsMenu_Set(id, this.Id, value));
				}
				return this.excludedFromShownWindowsMenu;
			}
		}

		public Task DestroyAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Destroy, this.Id);
		public Task CloseAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Close, this.Id);
		public Task FocusAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Focus, this.Id);
		public Task BlurAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Blur, this.Id);
		public Task<bool> IsFocusedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsFocused, this.Id);
		public bool IsDestroyed() => this.Id <= 0;
		public Task ShowAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Show, this.Id);
		public Task ShowInactiveAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_ShowInactive, this.Id);
		public Task HideAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Hide, this.Id);
		public Task<bool> IsVisibleAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsVisible, this.Id);
		public Task<bool> IsModalAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsModal, this.Id);
		public Task MaximizeAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Maximize, this.Id);
		public Task UnmaximizeAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Unmaximize, this.Id);
		public Task<bool> IsMaximizedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMaximized, this.Id);
		public Task MinimizeAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Minimize, this.Id);
		public Task RestoreAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Restore, this.Id);
		public Task<bool> IsMinimizedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMinimized, this.Id);
		public Task SetFullScreenAsync(bool flag) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetFullScreen, this.Id, flag);
		public Task<bool> IsFullScreenAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsFullScreen, this.Id);
		public Task SetSimpleFullScreenAsync(bool flag) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetSimpleFullScreen, this.Id, flag);
		public Task<bool> IsSimpleFullScreenAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsSimpleFullScreen, this.Id);
		public Task<bool> IsNormalAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsNormal, this.Id);
		public Task SetAspectRatioAsync(double aspectRatio, Size extraSize = null) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetAspectRatio, this.Id, aspectRatio, extraSize);
		public Task SetBackgroundColorAsync(string backgroundColor) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetBackgroundColor, this.Id, backgroundColor);
		public Task SetBackgroundColorAsync(Color backgroundColor) =>
			this.SetBackgroundColorAsync($"#{backgroundColor.A:X2}{backgroundColor.R:X2}{backgroundColor.G:X2}{backgroundColor.B:X2}");
		public Task PreviewFileAsync(string path, string displayName = null) =>
			Electron.ActionAsync(x => x.BrowserWindow_PreviewFile, this.Id, path, displayName);
		public Task CloseFilePreviewAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_CloseFilePreview, this.Id);
		public Task SetBoundsAsync(PartialRectangle bounds, bool animate = false) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetBounds, this.Id, bounds, animate);
		public Task<Rectangle> GetBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.BrowserWindow_GetBounds, this.Id);
		public Task<string> GetBackgroundColorAsync() =>
			Electron.FuncAsync<string, int>(x => x.BrowserWindow_GetBackgroundColor, this.Id);
		public Task SetContentBoundsAsync(Rectangle bounds, bool animate = false) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetContentBounds, this.Id, bounds, animate);
		public Task<Rectangle> GetContentBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.BrowserWindow_GetContentBounds, this.Id);
		public Task<Rectangle> GetNormalBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.BrowserWindow_GetNormalBounds, this.Id);
		public Task SetEnabledAsync(bool enabled) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetEnabled, this.Id, enabled);
		public Task<bool> IsEnabledAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsEnabled, this.Id);
		public Task SetSizeAsync(int width, int height, bool animate = false) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetSize, this.Id, width, height, animate);
		public Task<int[]> GetSizeAsync() =>
			Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetSize, this.Id);
		public Task SetContentSizeAsync(int width, int height, bool animate = false) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetContentSize, this.Id, width, height, animate);
		public Task<int[]> GetContentSizeAsync() =>
			Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetContentSize, this.Id);
		public Task SetMinimumSizeAsync(int width, int height) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMinimumSize, this.Id, width, height);
		public Task<int[]> GetMinimumSizeAsync() =>
			Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetMinimumSize, this.Id);
		public Task SetMaximumSizeAsync(int width, int height) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMaximumSize, this.Id, width, height);
		public Task<int[]> GetMaximumSizeAsync() =>
			Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetMaximumSize, this.Id);
		public Task SetResizableAsync(bool resizable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetResizable, this.Id, resizable);
		public Task<bool> IsResizableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsResizable, this.Id);
		public Task SetMovableAsync(bool movable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMovable, this.Id, movable);
		public Task<bool> IsMovableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMovable, this.Id);
		public Task SetMinimizableAsync(bool minimizable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMinimizable, this.Id, minimizable);
		public Task<bool> IsMinimizableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMinimizable, this.Id);
		public Task SetMaximizableAsync(bool maximizable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMaximizable, this.Id, maximizable);
		public Task<bool> IsMaximizableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMaximizable, this.Id);
		public Task SetFullScreenableAsync(bool fullscreenable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetFullScreenable, this.Id, fullscreenable);
		public Task<bool> IsFullScreenableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsFullScreenable, this.Id);
		public Task SetClosableAsync(bool closable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetClosable, this.Id, closable);
		public Task<bool> IsClosableAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsClosable, this.Id);
		public Task SetAlwaysOnTopAsync(bool flag, string level = null, int relativeLevel = 0) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetAlwaysOnTop, this.Id, flag, level, relativeLevel);
		public Task<bool> IsAlwaysOnTopAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsAlwaysOnTop, this.Id);
		public Task MoveAboveAsync(string mediaSourceId) =>
			Electron.ActionAsync(x => x.BrowserWindow_MoveAbove, this.Id, mediaSourceId);
		public Task MoveTopAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_MoveTop, this.Id);
		public Task CenterAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Center, this.Id);
		public Task SetPositionAsync(int x, int y, bool animate = false) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetPosition, this.Id, x, y, animate);
		public Task<bool> GetPositionAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_GetPosition, this.Id);
		public Task SetTitleAsync(string title) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetTitle, this.Id, title);
		public Task<string> GetTitleAsync() =>
			Electron.FuncAsync<string, int>(x => x.BrowserWindow_GetTitle, this.Id);
		public Task SetSheetOffsetAsync(double offsetY, double offsetX = 0) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetSheetOffset, this.Id, offsetY, offsetX);
		public Task FlashFrameAsync(bool flag) =>
			Electron.ActionAsync(x => x.BrowserWindow_FlashFrame, this.Id, flag);
		public Task SetSkipTaskbarAsync(bool skip) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetSkipTaskbar, this.Id, skip);
		public Task SetKioskAsync(bool flag) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetKiosk, this.Id, flag);
		public Task<bool> IsKioskAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsKiosk, this.Id);
		public Task<bool> IsTabletModeAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsTabletMode, this.Id);
		public Task<string> GetMediaSourceIdAsync() =>
			Electron.FuncAsync<string, int>(x => x.BrowserWindow_GetMediaSourceId, this.Id);
		public async Task<IntPtr> GetNativeWindowHandleAsync() {
			Buffer buffer = await Electron.FuncAsync<Buffer, int>(x => x.BrowserWindow_GetNativeWindowHandle, this.Id);
			byte[] bytes = buffer.Bytes;
			return bytes.Length switch {
				4 => new IntPtr(BitConverter.ToInt32(bytes)),
				8 => new IntPtr(BitConverter.ToInt64(bytes)),
				_ => throw new InvalidDataException($"Unexpected handle size {bytes.Length}!"),
			};
		}
		private readonly Dictionary<int, List<int>> hookWindowMessageMap = new();
		private readonly Dictionary<int, Action<int, int>> hookWindowMessageCallbacks = new();
		internal Task OnWindowMessage(int requestId, int wParam, int lParam) {
			Action<int, int> callback = this.hookWindowMessageCallbacks.GetValueOrDefault(requestId);
			callback?.Invoke(wParam, lParam);
			return Task.CompletedTask;
		}
		public async Task HookWindowMessageAsync(int message, Action<int, int> callback) {
			int requestId = Electron.NextRequestId;
			List<int> map = this.hookWindowMessageMap.GetValueOrDefault(message);
			if (map == null) {
				this.hookWindowMessageMap[message] = map = new List<int>();
			}
			map.Add(requestId);
			this.hookWindowMessageCallbacks[requestId] = callback;
			await Electron.ActionAsync(x => x.BrowserWindow_HookWindowMessage, this.Id, message);
		}
		public Task<bool> IsWindowMessageHookedAsync(int message) =>
			Electron.FuncAsync<bool, int, int>(x => x.BrowserWindow_IsWindowMessageHooked, this.Id, message);
		public async Task UnhookWindowMessageAsync(int message) {
			await Electron.ActionAsync(x => x.BrowserWindow_UnhookWindowMessage, this.Id, message);
			List<int> list = this.hookWindowMessageMap.GetValueOrDefault(message);
			if (list != null) {
				foreach (int requestId in list) {
					this.hookWindowMessageCallbacks.Remove(requestId);
				}
				this.hookWindowMessageMap.Remove(message);
			}
		}
		public async Task UnhookAllWindowMessagesAsync() {
			await Electron.ActionAsync(x => x.BrowserWindow_UnhookAllWindowMessages, this.Id);
			this.hookWindowMessageCallbacks.Clear();
			this.hookWindowMessageMap.Clear();
		}
		public Task SetRepresentedFilenameAsync(string filename) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetRepresentedFilename, this.Id, filename);
		public Task<string> GetRepresentedFilenameAsync() =>
			Electron.FuncAsync<string, int>(x => x.BrowserWindow_GetRepresentedFilename, this.Id);
		public Task SetDocumentEditedAsync(bool edited) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetDocumentEdited, this.Id, edited);
		public Task<bool> IsDocumentEditedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsDocumentEdited, this.Id);
		public Task FocusOnWebViewAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_FocusOnWebView, this.Id);
		public Task BlurWebViewAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_BlurWebView, this.Id);
		public Task<NativeImage> CapturePageAsync(Rectangle rect = null) =>
			Electron.FuncAsync<NativeImage, int, Rectangle>(x => x.BrowserWindow_CapturePage, this.Id, rect);
		public Task LoadUrlAsync(string url, LoadUrlOptions options = null) {
			url = new Uri(ElectronNetCoreService.BaseUri, url).AbsoluteUri;
			return Electron.ActionAsync(x => x.BrowserWindow_LoadUrl, this.Id, url, options?.ToLoadUrlOptionsDto());
		}
		public Task LoadFileAsync(string filePath, LoadFileOptions options) {
			filePath = Path.Combine(Path.GetDirectoryName(Electron.AppPath), filePath);
			return Electron.ActionAsync(x => x.BrowserWindow_LoadFile, this.Id, filePath, options);
		}
		public Task ReloadAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_Reload, this.Id);
		public Task SetMenuAsync(Menu menu) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMenu, this.Id, menu?.Id ?? 0);
		public Task RemoveMenuAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_RemoveMenu, this.Id);
		public Task SetProgressBarAsync(double progress, ProgressBarOptions options) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetProgressBar, this.Id, progress, options);
		public Task SetOverlayIconAsync(NativeImage overlay, string description) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetOverlayIcon, this.Id, overlay?.Id ?? 0, description);
		public Task SetHasShadowAsync(bool hasShadow) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetHasShadow, this.Id, hasShadow);
		public Task<bool> HasShadowAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_HasShadow, this.Id);
		public Task SetOpacityAsync(double opacity) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetOpacity, this.Id, opacity);
		public Task<double> GetOpacityAsync() =>
			Electron.FuncAsync<double, int>(x => x.BrowserWindow_GetOpacity, this.Id);
		public Task SetShapeAsync(Rectangle[] rects) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetShape, this.Id, rects);
		private Action[] setThumbarButtonsCallbacks;
		internal Task OnThumbarButtonClick(int index) {
			this.setThumbarButtonsCallbacks[index]?.Invoke();
			return Task.CompletedTask;
		}
		public async Task<bool> SetThumbarButtonsAsync(ThumbarButton[] buttons) {
			bool ret = await Electron.FuncAsync<bool, int, ThumbarButtonDto[]>(x => x.BrowserWindow_SetThumbarButtons, this.Id,
				buttons.Select(x => x.ToThumbarButtonDto()).ToArray());
			if (ret) {
				this.setThumbarButtonsCallbacks = buttons.Select(x => x.Click).ToArray();
			}
			return ret;
		}
		public Task SetThumbnailClipAsync(Rectangle region) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetThumbnailClip, this.Id, region);
		public Task SetThumbnailToolTipAsync(string toolTip) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetThumbnailToolTip, this.Id, toolTip);
		public Task SetAppDetailsAsync(AppDetailsOptions options) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetAppDetails, this.Id, options);
		public Task ShowDefinitionForSelectionAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_ShowDefinitionForSelection, this.Id);
		public Task SetIconAsync(NativeImage icon) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetIcon, this.Id, icon?.Id ?? 0);
		public Task SetWindowButtonVisibilityAsync(bool visible) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetWindowButtonVisibility, this.Id, visible);
		public Task SetAutoHideMenuBarAsync(bool hide) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetAutoHideMenuBar, this.Id, hide);
		public Task<bool> IsMenuBarAutoHideAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMenuBarAutoHide, this.Id);
		public Task SetMenuBarVisibilityAsync(bool visible) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetMenuBarVisibility, this.Id, visible);
		public Task<bool> IsMenuBarVisibleAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsMenuBarVisible, this.Id);
		public Task SetVisibleOnAllWorkspacesAsync(bool visible, VisibleOnAllWorkspacesOptions options = null) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetVisibleOnAllWorkspaces, this.Id, visible, options);
		public Task<bool> IsVisibleOnAllWorkspacesAsync() =>
			Electron.FuncAsync<bool, int>(x => x.BrowserWindow_IsVisibleOnAllWorkspaces, this.Id);
		public Task SetIgnoreMouseEventsAsync(bool ignore, IgnoreMouseEventsOptions options = null) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetIgnoreMouseEvents, this.Id, ignore, options);
		public Task SetContentProtectionAsync(bool enable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetContentProtection, this.Id, enable);
		public Task SetFocusableAsync(bool focusable) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetFocusable, this.Id, focusable);
		public Task SetParentWindowAsync(BrowserWindow parent) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetParentWindow, this.Id, parent?.Id ?? 0);
		public Task<BrowserWindow> GetParentWindowAsync() =>
			Electron.FuncAsync<BrowserWindow, int>(x => x.BrowserWindow_GetParentWindow, this.Id);
		public async Task<BrowserWindow[]> GetChildWindowsAsync() =>
			(await Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetChildWindows, this.Id))
			.Select(x => FromId(x)).ToArray();
		public Task SetAutoHideCursorAsync(bool autoHide) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetAutoHideCursor, this.Id, autoHide);
		public Task SelectPreviousTabAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_SelectPreviousTab, this.Id);
		public Task SelectNextTabAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_SelectNextTab, this.Id);
		public Task MergeAllWindowsAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_MergeAllWindows, this.Id);
		public Task MoveTabToNewWindowAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_MoveTabToNewWindow, this.Id);
		public Task ToggleTabBarAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_ToggleTabBar, this.Id);
		public Task AddTabbedWindowAsync(BrowserWindow browserWindow) =>
			Electron.ActionAsync(x => x.BrowserWindow_AddTabbedWindow, this.Id, browserWindow?.Id ?? 0);
		public Task SetVibrancyAsync(string type) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetVibrancy, this.Id, type);
		public Task SetTrafficLightPositionAsync(Point position) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetTrafficLightPosition, this.Id, position);
		public Task<Point> GetTrafficLightPositionAsync() =>
			Electron.FuncAsync<Point, int>(x => x.BrowserWindow_GetTrafficLightPosition, this.Id);
		public Task SetTouchBarAsync(TouchBar touchBar) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetTouchBar, this.Id, touchBar?.Id ?? 0);
		public Task SetBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetBrowserView, this.Id, browserView?.Id ?? 0);
		public Task<BrowserView> GetBrowserViewAsync() =>
			Electron.FuncAsync<BrowserView, int>(x => x.BrowserWindow_GetBrowserView, this.Id);
		public Task AddBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_AddBrowserView, this.Id, browserView?.Id ?? 0);
		public Task RemoveBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_RemoveBrowserView, this.Id, browserView?.Id ?? 0);
		public Task SetTopBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetTopBrowserView, this.Id, browserView?.Id ?? 0);
		public async Task<BrowserView[]> GetBrowserViewsAsync() =>
			(await Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetBrowserViews, this.Id))
			.Select(x => ElectronDisposable.FromId<BrowserView>(x)).ToArray();
	}
}
