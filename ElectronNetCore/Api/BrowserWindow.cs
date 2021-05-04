using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Point = MZZT.ElectronNetCore.Api.Point;
using Rectangle = MZZT.ElectronNetCore.Api.Rectangle;
using Size = MZZT.ElectronNetCore.Api.Size;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task BrowserWindow_Ctor(int requestId, int id, BrowserWindowConstructorOptionsDto options);

		Task BrowserWindow_PageTitleUpdated_PreventDefault(int requestId, bool value);
		Task BrowserWindow_Close_PreventDefault(int requestId, bool value);
		Task BrowserWindow_WillResize_PreventDefault(int requestId, bool value);
		Task BrowserWindow_WillMove_PreventDefault(int requestId, bool value);
		Task BrowserWindow_SystemContextMenu_PreventDefault(int requestId, bool value);

		Task BrowserWindow_GetFocusedWindow(int requestId, int id);
		Task BrowserWindow_FromWebContents(int requestId, int id, int webContents);
		Task BrowserWindow_FromBrowserView(int requestId, int id, int browserView);

		Task BrowserWindow_WebContents_Get(int requestId, int id);
		Task BrowserWindow_AutoHideMenuBar_Get(int requestId, int id);
		Task BrowserWindow_AutoHideMenuBar_Set(int requestId, int id, bool value);
		Task BrowserWindow_SimpleFullScreen_Get(int requestId, int id);
		Task BrowserWindow_SimpleFullScreen_Set(int requestId, int id, bool value);
		Task BrowserWindow_FullScreen_Get(int requestId, int id);
		Task BrowserWindow_FullScreen_Set(int requestId, int id, bool value);
		Task BrowserWindow_VisibleOnAllWorkspaces_Get(int requestId, int id);
		Task BrowserWindow_VisibleOnAllWorkspaces_Set(int requestId, int id, bool value);
		Task BrowserWindow_Shadow_Get(int requestId, int id);
		Task BrowserWindow_Shadow_Set(int requestId, int id, bool value);
		Task BrowserWindow_MenuBarVisible_Get(int requestId, int id);
		Task BrowserWindow_MenuBarVisible_Set(int requestId, int id, bool value);
		Task BrowserWindow_Kiosk_Get(int requestId, int id);
		Task BrowserWindow_Kiosk_Set(int requestId, int id, bool value);
		Task BrowserWindow_DocumentEdited_Get(int requestId, int id);
		Task BrowserWindow_DocumentEdited_Set(int requestId, int id, bool value);
		Task BrowserWindow_RepresentedFilename_Get(int requestId, int id);
		Task BrowserWindow_RepresentedFilename_Set(int requestId, int id, string value);
		Task BrowserWindow_Title_Get(int requestId, int id);
		Task BrowserWindow_Title_Set(int requestId, int id, string value);
		Task BrowserWindow_Minimizable_Get(int requestId, int id);
		Task BrowserWindow_Minimizable_Set(int requestId, int id, bool value);
		Task BrowserWindow_Maximizable_Get(int requestId, int id);
		Task BrowserWindow_Maximizable_Set(int requestId, int id, bool value);
		Task BrowserWindow_FullScreenable_Get(int requestId, int id);
		Task BrowserWindow_FullScreenable_Set(int requestId, int id, bool value);
		Task BrowserWindow_Resizable_Get(int requestId, int id);
		Task BrowserWindow_Resizable_Set(int requestId, int id, bool value);
		Task BrowserWindow_Closable_Get(int requestId, int id);
		Task BrowserWindow_Closable_Set(int requestId, int id, bool value);
		Task BrowserWindow_Movable_Get(int requestId, int id);
		Task BrowserWindow_Movable_Set(int requestId, int id, bool value);
		Task BrowserWindow_ExcludedFromShownWindowsMenu_Get(int requestId, int id);
		Task BrowserWindow_ExcludedFromShownWindowsMenu_Set(int requestId, int id, bool value);

		Task BrowserWindow_Destroy(int requestId, int id);
		Task BrowserWindow_Close(int requestId, int id);
		Task BrowserWindow_Focus(int requestId, int id);
		Task BrowserWindow_Blur(int requestId, int id);
		Task BrowserWindow_IsFocused(int requestId, int id);
		Task BrowserWindow_IsDestroyed(int requestId, int id);
		Task BrowserWindow_Show(int requestId, int id);
		Task BrowserWindow_ShowInactive(int requestId, int id);
		Task BrowserWindow_Hide(int requestId, int id);
		Task BrowserWindow_IsVisible(int requestId, int id);
		Task BrowserWindow_IsModal(int requestId, int id);
		Task BrowserWindow_Maximize(int requestId, int id);
		Task BrowserWindow_Unmaximize(int requestId, int id);
		Task BrowserWindow_IsMaximized(int requestId, int id);
		Task BrowserWindow_Minimize(int requestId, int id);
		Task BrowserWindow_Restore(int requestId, int id);
		Task BrowserWindow_IsMinimized(int requestId, int id);
		Task BrowserWindow_SetFullScreen(int requestId, int id, bool flag);
		Task BrowserWindow_IsFullScreen(int requestId, int id);
		Task BrowserWindow_SetSimpleFullScreen(int requestId, int id, bool flag);
		Task BrowserWindow_IsSimpleFullScreen(int requestId, int id);
		Task BrowserWindow_IsNormal(int requestId, int id);
		Task BrowserWindow_SetAspectRatio(int requestId, int id, double aspectRatio, Size extraSize);
		Task BrowserWindow_SetBackgroundColor(int requestId, int id, string backgroundColor);
		Task BrowserWindow_PreviewFile(int requestId, int id, string path, string displayName);
		Task BrowserWindow_CloseFilePreview(int requestId, int id);
		Task BrowserWindow_SetBounds(int requestId, int id, PartialRectangle bounds, bool animate);
		Task BrowserWindow_GetBounds(int requestId, int id);
		Task BrowserWindow_GetBackgroundColor(int requestId, int id);
		Task BrowserWindow_SetContentBounds(int requestId, int id, Rectangle bounds, bool annimate);
		Task BrowserWindow_GetContentBounds(int requestId, int id);
		Task BrowserWindow_GetNormalBounds(int requestId, int id);
		Task BrowserWindow_SetEnabled(int requestId, int id, bool enabled);
		Task BrowserWindow_IsEnabled(int requestId, int id);
		Task BrowserWindow_SetSize(int requestId, int id, int width, int height, bool animate);
		Task BrowserWindow_GetSize(int requestId, int id);
		Task BrowserWindow_SetContentSize(int requestId, int id, int width, int height, bool animate);
		Task BrowserWindow_GetContentSize(int requestId, int id);
		Task BrowserWindow_SetMinimumSize(int requestId, int id, int width, int height);
		Task BrowserWindow_GetMinimumSize(int requestId, int id);
		Task BrowserWindow_SetMaximumSize(int requestId, int id, int width, int height);
		Task BrowserWindow_GetMaximumSize(int requestId, int id);
		Task BrowserWindow_SetResizable(int requestId, int id, bool resizable);
		Task BrowserWindow_IsResizable(int requestId, int id);
		Task BrowserWindow_SetMovable(int requestId, int id, bool movable);
		Task BrowserWindow_IsMovable(int requestId, int id);
		Task BrowserWindow_SetMinimizable(int requestId, int id, bool minimizable);
		Task BrowserWindow_IsMinimizable(int requestId, int id);
		Task BrowserWindow_SetMaximizable(int requestId, int id, bool maximizable);
		Task BrowserWindow_IsMaximizable(int requestId, int id);
		Task BrowserWindow_SetFullScreenable(int requestId, int id, bool fullscreenable);
		Task BrowserWindow_IsFullScreenable(int requestId, int id);
		Task BrowserWindow_SetClosable(int requestId, int id, bool closable);
		Task BrowserWindow_IsClosable(int requestId, int id);
		Task BrowserWindow_SetAlwaysOnTop(int requestId, int id, bool flag, string level, int relativeLevel);
		Task BrowserWindow_IsAlwaysOnTop(int requestId, int id);
		Task BrowserWindow_MoveAbove(int requestId, int id, string mediaSourceId);
		Task BrowserWindow_MoveTop(int requestId, int id);
		Task BrowserWindow_Center(int requestId, int id);
		Task BrowserWindow_SetPosition(int requestId, int id, int x, int y, bool animate);
		Task BrowserWindow_GetPosition(int requestId, int id);
		Task BrowserWindow_SetTitle(int requestId, int id, string title);
		Task BrowserWindow_GetTitle(int requestId, int id);
		Task BrowserWindow_SetSheetOffset(int requestId, int id, double offsetY, double offsetX);
		Task BrowserWindow_FlashFrame(int requestId, int id, bool flag);
		Task BrowserWindow_SetSkipTaskbar(int requestId, int id, bool skip);
		Task BrowserWindow_SetKiosk(int requestId, int id, bool flag);
		Task BrowserWindow_IsKiosk(int requestId, int id);
		Task BrowserWindow_IsTabletMode(int requestId, int id);
		Task BrowserWindow_GetMediaSourceId(int requestId, int id);
		Task BrowserWindow_GetNativeWindowHandle(int requestId, int id);
		Task BrowserWindow_HookWindowMessage(int requestId, int id, int message);
		Task BrowserWindow_IsWindowMessageHooked(int requestId, int id, int message);
		Task BrowserWindow_UnhookWindowMessage(int requestId, int id, int message);
		Task BrowserWindow_UnhookAllWindowMessages(int requestId, int id);
		Task BrowserWindow_SetRepresentedFilename(int requestId, int id, string filename);
		Task BrowserWindow_GetRepresentedFilename(int requestId, int id);
		Task BrowserWindow_SetDocumentEdited(int requestId, int id, bool edited);
		Task BrowserWindow_IsDocumentEdited(int requestId, int id);
		Task BrowserWindow_FocusOnWebView(int requestId, int id);
		Task BrowserWindow_BlurWebView(int requestId, int id);
		Task BrowserWindow_CapturePage(int requestId, int id, Rectangle rect);
		Task BrowserWindow_LoadUrl(int requestId, int id, string url, LoadUrlOptionsDto options);
		Task BrowserWindow_LoadFile(int requestId, int id, string filePath, LoadFileOptions options);
		Task BrowserWindow_Reload(int requestId, int id);
		Task BrowserWindow_SetMenu(int requestId, int id, int menu);
		Task BrowserWindow_RemoveMenu(int requestId, int id);
		Task BrowserWindow_SetProgressBar(int requestId, int id, double progress, ProgressBarOptions options);
		Task BrowserWindow_SetOverlayIcon(int requestId, int id, int overlay, string description);
		Task BrowserWindow_SetHasShadow(int requestId, int id, bool hasShadow);
		Task BrowserWindow_HasShadow(int requestId, int id);
		Task BrowserWindow_SetOpacity(int requestId, int id, double opacity);
		Task BrowserWindow_GetOpacity(int requestId, int id);
		Task BrowserWindow_SetShape(int requestId, int id, Rectangle[] rects);
		Task BrowserWindow_SetThumbarButtons(int requestId, int id, ThumbarButtonDto[] buttons);
		Task BrowserWindow_SetThumbnailClip(int requestId, int id, Rectangle region);
		Task BrowserWindow_SetThumbnailToolTip(int requestId, int id, string toolTip);
		Task BrowserWindow_SetAppDetails(int requestId, int id, AppDetailsOptions options);
		Task BrowserWindow_ShowDefinitionForSelection(int requestId, int id);
		Task BrowserWindow_SetIcon(int requestId, int id, int icon);
		Task BrowserWindow_SetWindowButtonVisibility(int requestId, int id, bool visible);
		Task BrowserWindow_SetAutoHideMenuBar(int requestId, int id, bool hide);
		Task BrowserWindow_IsMenuBarAutoHide(int requestId, int id);
		Task BrowserWindow_SetMenuBarVisibility(int requestId, int id, bool visible);
		Task BrowserWindow_IsMenuBarVisible(int requestId, int id);
		Task BrowserWindow_SetVisibleOnAllWorkspaces(int requestId, int id, bool visible, VisibleOnAllWorkspacesOptions options);
		Task BrowserWindow_IsVisibleOnAllWorkspaces(int requestId, int id);
		Task BrowserWindow_SetIgnoreMouseEvents(int requestId, int id, bool ignore, IgnoreMouseEventsOptions options);
		Task BrowserWindow_SetContentProtection(int requestId, int id, bool enable);
		Task BrowserWindow_SetFocusable(int requestId, int id, bool focusable);
		Task BrowserWindow_SetParentWindow(int requestId, int id, int parent);
		Task BrowserWindow_GetParentWindow(int requestId, int id);
		Task BrowserWindow_GetChildWindows(int requestId, int id);
		Task BrowserWindow_SetAutoHideCursor(int requestId, int id, bool autoHide);
		Task BrowserWindow_SelectPreviousTab(int requestId, int id);
		Task BrowserWindow_SelectNextTab(int requestId, int id);
		Task BrowserWindow_MergeAllWindows(int requestId, int id);
		Task BrowserWindow_MoveTabToNewWindow(int requestId, int id);
		Task BrowserWindow_ToggleTabBar(int requestId, int id);
		Task BrowserWindow_AddTabbedWindow(int requestId, int id, int browserWindow);
		Task BrowserWindow_SetVibrancy(int requestId, int id, string type);
		Task BrowserWindow_SetTrafficLightPosition(int requestId, int id, Point position);
		Task BrowserWindow_GetTrafficLightPosition(int requestId, int id);
		Task BrowserWindow_SetTouchBar(int requestId, int id, int touchBar);
		Task BrowserWindow_SetBrowserView(int requestId, int id, int browserView);
		Task BrowserWindow_GetBrowserView(int requestId, int id);
		Task BrowserWindow_AddBrowserView(int requestId, int id, int browserView);
		Task BrowserWindow_RemoveBrowserView(int requestId, int id, int browserView);
		Task BrowserWindow_SetTopBrowserView(int requestId, int id, int browserView);
		Task BrowserWindow_GetBrowserViews(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task BrowserWindow_PageTitleUpdated_Event(int id, string title, bool explicitSet) =>
			BrowserWindow.FromId(id)?.OnPageTitleUpdated(title, explicitSet) ?? Task.CompletedTask;
		public Task BrowserWindow_Close_Event(int id) =>
			BrowserWindow.FromId(id)?.OnClose() ?? Task.CompletedTask;
		public Task BrowserWindow_Closed_Event(int id) =>
			BrowserWindow.FromId(id)?.OnClosed() ?? Task.CompletedTask;
		public Task BrowserWindow_SessionEnd_Event(int id) =>
			BrowserWindow.FromId(id)?.OnSessionEnd() ?? Task.CompletedTask;
		public Task BrowserWindow_Unresponsive_Event(int id) =>
			BrowserWindow.FromId(id)?.OnUnresponsive() ?? Task.CompletedTask;
		public Task BrowserWindow_Responsive_Event(int id) =>
			BrowserWindow.FromId(id)?.OnResponsive() ?? Task.CompletedTask;
		public Task BrowserWindow_Blur_Event(int id) =>
			BrowserWindow.FromId(id)?.OnBlur() ?? Task.CompletedTask;
		public Task BrowserWindow_Focus_Event(int id) =>
			BrowserWindow.FromId(id)?.OnFocus() ?? Task.CompletedTask;
		public Task BrowserWindow_Show_Event(int id) =>
			BrowserWindow.FromId(id)?.OnShow() ?? Task.CompletedTask;
		public Task BrowserWindow_Hide_Event(int id) =>
			BrowserWindow.FromId(id)?.OnHide() ?? Task.CompletedTask;
		public Task BrowserWindow_ReadyToShow_Event(int id) =>
			BrowserWindow.FromId(id)?.OnReadyToShow() ?? Task.CompletedTask;
		public Task BrowserWindow_Maximize_Event(int id) =>
			BrowserWindow.FromId(id)?.OnMaximize() ?? Task.CompletedTask;
		public Task BrowserWindow_Unmaximize_Event(int id) =>
			BrowserWindow.FromId(id)?.OnUnmaximize() ?? Task.CompletedTask;
		public Task BrowserWindow_Minimize_Event(int id) =>
			BrowserWindow.FromId(id)?.OnMinimize() ?? Task.CompletedTask;
		public Task BrowserWindow_Restore_Event(int id) =>
			BrowserWindow.FromId(id)?.OnRestore() ?? Task.CompletedTask;
		public Task BrowserWindow_WillResize_Event(int id, Rectangle newBounds) =>
			BrowserWindow.FromId(id)?.OnWillResize(newBounds) ?? Task.CompletedTask;
		public Task BrowserWindow_Resize_Event(int id) =>
			BrowserWindow.FromId(id)?.OnResize() ?? Task.CompletedTask;
		public Task BrowserWindow_Resized_Event(int id) =>
			BrowserWindow.FromId(id)?.OnResized() ?? Task.CompletedTask;
		public Task BrowserWindow_WillMove_Event(int id, Rectangle newBounds) =>
			BrowserWindow.FromId(id)?.OnWillMove(newBounds) ?? Task.CompletedTask;
		public Task BrowserWindow_Move_Event(int id) =>
			BrowserWindow.FromId(id)?.OnMove() ?? Task.CompletedTask;
		public Task BrowserWindow_Moved_Event(int id) =>
			BrowserWindow.FromId(id)?.OnMoved() ?? Task.CompletedTask;
		public Task BrowserWindow_EnterFullScreen_Event(int id) =>
			BrowserWindow.FromId(id)?.OnEnterFullScreen() ?? Task.CompletedTask;
		public Task BrowserWindow_LeaveFullScreen_Event(int id) =>
			BrowserWindow.FromId(id)?.OnLeaveFullScreen() ?? Task.CompletedTask;
		public Task BrowserWindow_EnterHtmlFullScreen_Event(int id) =>
			BrowserWindow.FromId(id)?.OnEnterHtmlFullScreen() ?? Task.CompletedTask;
		public Task BrowserWindow_LeaveHtmlFullScreen_Event(int id) =>
			BrowserWindow.FromId(id)?.OnLeaveHtmlFullScreen() ?? Task.CompletedTask;
		public Task BrowserWindow_AlwaysOnTopChanged_Event(int id, bool isAlwaysOnTop) =>
			BrowserWindow.FromId(id)?.OnAlwaysOnTopChanged(isAlwaysOnTop) ?? Task.CompletedTask;
		public Task BrowserWindow_AppCommand_Event(int id, string command) =>
			BrowserWindow.FromId(id)?.OnAppCommand(command) ?? Task.CompletedTask;
		public Task BrowserWindow_ScrollTouchBegin_Event(int id) =>
			BrowserWindow.FromId(id)?.OnScrollTouchBegin() ?? Task.CompletedTask;
		public Task BrowserWindow_ScrollTouchEnd_Event(int id) =>
			BrowserWindow.FromId(id)?.OnScrollTouchEnd() ?? Task.CompletedTask;
		public Task BrowserWindow_ScrollTouchEdge_Event(int id) =>
			BrowserWindow.FromId(id)?.OnScrollTouchEdge() ?? Task.CompletedTask;
		public Task BrowserWindow_Swipe_Event(int id, string direction) =>
			BrowserWindow.FromId(id)?.OnSwipe(direction) ?? Task.CompletedTask;
		public Task BrowserWindow_RotateGesture_Event(int id, double rotation) =>
			BrowserWindow.FromId(id)?.OnRotateGesture(rotation) ?? Task.CompletedTask;
		public Task BrowserWindow_SheetBegin_Event(int id) =>
			BrowserWindow.FromId(id)?.OnSheetBegin() ?? Task.CompletedTask;
		public Task BrowserWindow_SheetEnd_Event(int id) =>
			BrowserWindow.FromId(id)?.OnSheetEnd() ?? Task.CompletedTask;
		public Task BrowserWindow_NewWindowForTab_Event(int id) =>
			BrowserWindow.FromId(id)?.OnNewWindowForTab() ?? Task.CompletedTask;
		public Task BrowserWindow_SystemContextMenu_Event(int id, Point point) =>
			BrowserWindow.FromId(id)?.OnSystemContextMenu(point) ?? Task.CompletedTask;

		public Task BrowserWindow_HookWindowMessage_Callback(int id, int requestId, int wParam, int lParam) =>
			BrowserWindow.FromId(id)?.OnWindowMessage(requestId, wParam, lParam) ?? Task.CompletedTask;
		public Task BrowserWindow_SetThumbarButtons_Click(int id, int index) =>
			BrowserWindow.FromId(id)?.OnThumbarButtonClick(index) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class BrowserWindow {
		private static readonly Dictionary<int, BrowserWindow> instances = new();

		public static Task<BrowserWindow> CreateAsync(BrowserWindowConstructorOptions options = null) =>
			Electron.FuncAsync<BrowserWindow, int, BrowserWindowConstructorOptionsDto>(x => x.BrowserWindow_Ctor, 0, options.ToBrowserWindowConstructorOptionsDto());

		public static IEnumerable<BrowserWindow> GetAllWindows() =>
			instances.Values;
		public static Task<BrowserWindow> GetFocusedWindowAsync() =>
			Electron.FuncAsync<BrowserWindow, int>(x => x.BrowserWindow_GetFocusedWindow, 0);
		public static Task<BrowserWindow> FromWebContentsAsync(WebContents webContents) =>
			Electron.FuncAsync<BrowserWindow, int, int>(x => x.BrowserWindow_FromWebContents, 0, webContents?.Id ?? 0);
		public static Task<BrowserWindow> FromBrowserViewAsync(BrowserView browserView) =>
			Electron.FuncAsync<BrowserWindow, int, int>(x => x.BrowserWindow_FromBrowserView, 0, browserView?.InternalId ?? 0);
		public static BrowserWindow FromId(int id) =>
			instances.GetValueOrDefault(id);

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

		public event EventHandler<PageTitleUpdatedEventArgs> PageTitleUpdated;
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

		private ElectronInstanceReadOnlyProperty<WebContents> webContents;
		public ElectronInstanceReadOnlyProperty<WebContents> WebContents {
			get {
				if (this.webContents == null) {
					this.webContents = new(this.Id, x => x.BrowserWindow_WebContents_Get);
				}
				return this.webContents;
			}
		}

		private ElectronInstanceProperty<bool> autoHideMenuBar;
		public ElectronInstanceProperty<bool> AutoHideMenuBar {
			get {
				if (this.autoHideMenuBar == null) {
					this.autoHideMenuBar = new(this.Id, x => x.BrowserWindow_AutoHideMenuBar_Get,
						x => x.BrowserWindow_AutoHideMenuBar_Set);
				}
				return this.autoHideMenuBar;
			}
		}

		private ElectronInstanceProperty<bool> simpleFullScreen;
		public ElectronInstanceProperty<bool> SimpleFullScreen {
			get {
				if (this.simpleFullScreen == null) {
					this.simpleFullScreen = new(this.Id, x => x.BrowserWindow_SimpleFullScreen_Get,
						x => x.BrowserWindow_SimpleFullScreen_Set);
				}
				return this.simpleFullScreen;
			}
		}

		private ElectronInstanceProperty<bool> fullScreen;
		public ElectronInstanceProperty<bool> FullScreen {
			get {
				if (this.fullScreen == null) {
					this.fullScreen = new(this.Id, x => x.BrowserWindow_FullScreen_Get,
						x => x.BrowserWindow_FullScreen_Set);
				}
				return this.fullScreen;
			}
		}

		private ElectronInstanceProperty<bool> visibleOnAllWorkspaces;
		public ElectronInstanceProperty<bool> VisibleOnAllWorkspaces {
			get {
				if (this.visibleOnAllWorkspaces == null) {
					this.visibleOnAllWorkspaces = new(this.Id, x => x.BrowserWindow_VisibleOnAllWorkspaces_Get,
						x => x.BrowserWindow_VisibleOnAllWorkspaces_Set);
				}
				return this.visibleOnAllWorkspaces;
			}
		}

		private ElectronInstanceProperty<bool> shadow;
		public ElectronInstanceProperty<bool> Shadow {
			get {
				if (this.shadow == null) {
					this.shadow = new(this.Id, x => x.BrowserWindow_Shadow_Get,
						x => x.BrowserWindow_Shadow_Set);
				}
				return this.shadow;
			}
		}

		private ElectronInstanceProperty<bool> menuBarVisible;
		public ElectronInstanceProperty<bool> MenuBarVisible {
			get {
				if (this.menuBarVisible == null) {
					this.menuBarVisible = new(this.Id, x => x.BrowserWindow_MenuBarVisible_Get,
						x => x.BrowserWindow_MenuBarVisible_Set);
				}
				return this.menuBarVisible;
			}
		}

		private ElectronInstanceProperty<bool> kiosk;
		public ElectronInstanceProperty<bool> Kiosk {
			get {
				if (this.kiosk == null) {
					this.kiosk = new(this.Id, x => x.BrowserWindow_Kiosk_Get,
						x => x.BrowserWindow_Kiosk_Set);
				}
				return this.kiosk;
			}
		}

		private ElectronInstanceProperty<bool> documentEdited;
		public ElectronInstanceProperty<bool> DocumentEdited {
			get {
				if (this.documentEdited == null) {
					this.documentEdited = new(this.Id, x => x.BrowserWindow_DocumentEdited_Get,
						x => x.BrowserWindow_DocumentEdited_Set);
				}
				return this.documentEdited;
			}
		}

		private ElectronInstanceProperty<string> representedFilename;
		public ElectronInstanceProperty<string> RepresentedFilename {
			get {
				if (this.representedFilename == null) {
					this.representedFilename = new(this.Id, x => x.BrowserWindow_RepresentedFilename_Get,
						x => x.BrowserWindow_RepresentedFilename_Set);
				}
				return this.representedFilename;
			}
		}

		private ElectronInstanceProperty<string> title;
		public ElectronInstanceProperty<string> Title {
			get {
				if (this.title == null) {
					this.title = new(this.Id, x => x.BrowserWindow_Title_Get,
						x => x.BrowserWindow_Title_Set);
				}
				return this.title;
			}
		}

		private ElectronInstanceProperty<bool> minimizable;
		public ElectronInstanceProperty<bool> Minimizable {
			get {
				if (this.minimizable == null) {
					this.minimizable = new(this.Id, x => x.BrowserWindow_Minimizable_Get,
						x => x.BrowserWindow_Minimizable_Set);
				}
				return this.minimizable;
			}
		}

		private ElectronInstanceProperty<bool> maximizable;
		public ElectronInstanceProperty<bool> Maximizable {
			get {
				if (this.maximizable == null) {
					this.maximizable = new(this.Id, x => x.BrowserWindow_Maximizable_Get,
						x => x.BrowserWindow_Maximizable_Set);
				}
				return this.maximizable;
			}
		}

		private ElectronInstanceProperty<bool> fullScreenable;
		public ElectronInstanceProperty<bool> FullScreenable {
			get {
				if (this.fullScreenable == null) {
					this.fullScreenable = new(this.Id, x => x.BrowserWindow_FullScreenable_Get,
						x => x.BrowserWindow_FullScreenable_Set);
				}
				return this.fullScreenable;
			}
		}

		private ElectronInstanceProperty<bool> resizable;
		public ElectronInstanceProperty<bool> Resizable {
			get {
				if (this.resizable == null) {
					this.resizable = new(this.Id, x => x.BrowserWindow_Resizable_Get,
						x => x.BrowserWindow_Resizable_Set);
				}
				return this.resizable;
			}
		}

		private ElectronInstanceProperty<bool> closable;
		public ElectronInstanceProperty<bool> Closable {
			get {
				if (this.closable == null) {
					this.closable = new(this.Id, x => x.BrowserWindow_Closable_Get,
						x => x.BrowserWindow_Closable_Set);
				}
				return this.closable;
			}
		}

		private ElectronInstanceProperty<bool> movable;
		public ElectronInstanceProperty<bool> Movable {
			get {
				if (this.movable == null) {
					this.movable = new(this.Id, x => x.BrowserWindow_Movable_Get,
						x => x.BrowserWindow_Movable_Set);
				}
				return this.movable;
			}
		}

		private ElectronInstanceProperty<bool> excludedFromShownWindowsMenu;
		public ElectronInstanceProperty<bool> ExcludedFromShownWindowsMenu {
			get {
				if (this.excludedFromShownWindowsMenu == null) {
					this.excludedFromShownWindowsMenu = new(this.Id, x => x.BrowserWindow_ExcludedFromShownWindowsMenu_Get,
						x => x.BrowserWindow_ExcludedFromShownWindowsMenu_Set);
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
			await Electron.ActionAsync(requestId, x => x.BrowserWindow_HookWindowMessage, this.Id, message);
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
			Electron.ActionAsync(x => x.BrowserWindow_SetMenu, this.Id, menu?.InternalId ?? 0);
		public Task RemoveMenuAsync() =>
			Electron.ActionAsync(x => x.BrowserWindow_RemoveMenu, this.Id);
		public Task SetProgressBarAsync(double progress, ProgressBarOptions options) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetProgressBar, this.Id, progress, options);
		public Task SetOverlayIconAsync(NativeImage overlay, string description) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetOverlayIcon, this.Id, overlay?.InternalId ?? 0, description);
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
			Electron.ActionAsync(x => x.BrowserWindow_SetIcon, this.Id, icon?.InternalId ?? 0);
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
			Electron.ActionAsync(x => x.BrowserWindow_SetTouchBar, this.Id, touchBar?.InternalId ?? 0);
		public Task SetBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetBrowserView, this.Id, browserView?.InternalId ?? 0);
		public Task<BrowserView> GetBrowserViewAsync() =>
			Electron.FuncAsync<BrowserView, int>(x => x.BrowserWindow_GetBrowserView, this.Id);
		public Task AddBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_AddBrowserView, this.Id, browserView?.InternalId ?? 0);
		public Task RemoveBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_RemoveBrowserView, this.Id, browserView?.InternalId ?? 0);
		public Task SetTopBrowserViewAsync(BrowserView browserView) =>
			Electron.ActionAsync(x => x.BrowserWindow_SetTopBrowserView, this.Id, browserView?.InternalId ?? 0);
		public async Task<BrowserView[]> GetBrowserViewsAsync() =>
			(await Electron.FuncAsync<int[], int>(x => x.BrowserWindow_GetBrowserViews, this.Id))
			.Select(x => ElectronDisposable.FromId<BrowserView>(x)).ToArray();
	}
}
