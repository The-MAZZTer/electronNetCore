import { app, BrowserView, BrowserWindow, BrowserWindowConstructorOptions, LoadURLOptions, Menu,
	NativeImage, Session, TouchBar, webContents } from "electron";
import { ElectronApi, SignalRApi } from "./api";

const browserWindowPageTitleUpdatedPreventDefault: Record<number, true> = {};
const browserWindowClosePreventDefault: Record<number, true> = {};
const browserWindowWillResizePreventDefault: Record<number, true> = {};
const browserWindowWillMovePreventDefault: Record<number, true> = {};
const browserWindowSystemContextMenuPreventDefault: Record<number, true> = {};

let api: SignalRApi;
export const ElectronBrowserWindow: ElectronApi = {
	type: "BrowserWindow",
	instanceOf: x => x?.constructor?.name === "BrowserWindow",
	fromId: x => BrowserWindow.fromId(x),
	toId: (x: BrowserWindow) => x.id,
	init: x => {
		api = x;
		
		app.on("browser-window-created", (_, window) => {
			const id = window.id;
			window.on("page-title-updated", (e, title, explicitSet) => {
				if (browserWindowPageTitleUpdatedPreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("PageTitleUpdated_Event", id, title, explicitSet);
			});

			window.on("close", e => {
				if (browserWindowClosePreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("Close_Event", id);
			});

			window.on("closed", () => {
				delete browserWindowPageTitleUpdatedPreventDefault[id];
				delete browserWindowClosePreventDefault[id];
				delete browserWindowWillResizePreventDefault[id];
				delete browserWindowWillMovePreventDefault[id];
				delete browserWindowSystemContextMenuPreventDefault[id];
			
				return api.send("Closed_Event", id);
			});

			window.on("session-end", () =>
				api.send("SessionEnd_Event", id));

			window.on("unresponsive", () =>
				api.send("Unresponsive_Event", id));

			window.on("responsive", () =>
				api.send("Responsive_Event", id));

			window.on("blur", () =>
				api.send("Blur_Event", id));

			window.on("focus", () =>
				api.send("Focus_Event", id));

			window.on("show", () =>
				api.send("Show_Event", id));

			window.on("hide", () =>
				api.send("Hide_Event", id));

			window.on("ready-to-show", () =>
				api.send("ReadyToShow_Event", id));

			window.on("maximize", () =>
				api.send("Maximize_Event", id));

			window.on("unmaximize", () =>
				api.send("Unmaximize_Event", id));

			window.on("minimize", () =>
				api.send("Minimize_Event", id));

			window.on("restore", () =>
				api.send("Restore_Event", id));

			window.on("will-resize", (e, newBounds) => {
				if (browserWindowWillResizePreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("WillResize_Event", id, newBounds);
			});

			window.on("resize", () =>
				api.send("Resize_Event", id));

			window.on("resized", () =>
				api.send("Resized_Event", id));

			window.on("will-move", (e, newBounds) => {
				if (browserWindowWillMovePreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("WillMove_Event", id, newBounds);
			});

			window.on("move", () =>
				api.send("Move_Event", id));

			window.on("moved", () =>
				api.send("Moved_Event", id));

			window.on("enter-full-screen", () =>
				api.send("EnterFullScreen_Event", id));

			window.on("leave-full-screen", () =>
				api.send("LeaveFullScreen_Event", id));

			window.on("enter-html-full-screen", () =>
				api.send("EnterHtmlFullScreen_Event", id));

			window.on("leave-html-full-screen", () =>
				api.send("LeaveHtmlFullScreen_Event", id));

			window.on("always-on-top-changed", (_, isAlwaysOnTop) =>
				api.send("AlwaysOnTopChanged_Event", id, isAlwaysOnTop));

			window.on("app-command", (_, command) =>
				api.send("AppCommand_Event", id, command));

			window.on("scroll-touch-begin", () =>
				api.send("ScrollTouchBegin_Event", id));

			window.on("scroll-touch-end", () =>
				api.send("ScrollTouchEnd_Event", id));

			window.on("scroll-touch-edge", () =>
				api.send("ScrollTouchEdge_Event", id));

			window.on("swipe", (_, direction) =>
				api.send("Swipe_Event", id, direction));

			window.on("rotate-gesture", (_, rotation) =>
				api.send("RotateGesture_Event", id, rotation));

			window.on("sheet-begin", () =>
				api.send("SheetBegin_Event", id));

			window.on("sheet-end", () =>
				api.send("SheetEnd_Event", id));

			window.on("new-window-for-tab", () =>
				api.send("NewWindowForTab_Event", id));

			window.on("system-context-menu", (e, point) => {
				if (browserWindowSystemContextMenuPreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("SystemContextMenu_Event", id, point);
			});
		});

	},
	handlers: {
		"Ctor": (_: null, options: BrowserWindowConstructorOptions) => {
			if (options) {
				if ((<any>options).iconImage) {
					options.icon = api.get<NativeImage>((<any>options).iconImage);
					delete (<any>options).iconImage;
				} else if ((<any>options).iconPath) {
					options.icon = (<any>options).iconPath;
					delete (<any>options).iconPath;
				}
				if (options.parent) {
					options.parent = BrowserWindow.fromId(<any>options.parent);
				} else {
					options.parent = null;
				}	
				if (options.webPreferences) {
					options.webPreferences.session = api.get<Session>(<any>options.webPreferences.session);
				}
			}
			return new BrowserWindow(options).id;
		},

		"PageTitleUpdated_PreventDefault": (self: BrowserWindow, value) => { browserWindowPageTitleUpdatedPreventDefault[self.id] = value; },
		"Close_PreventDefault": (self: BrowserWindow, value) => { browserWindowClosePreventDefault[self.id] = value; },
		"WillResize_PreventDefault": (self: BrowserWindow, value) => { browserWindowWillResizePreventDefault[self.id] = value; },
		"WillMove_PreventDefault": (self: BrowserWindow, value) => { browserWindowWillMovePreventDefault[self.id] = value; },
		"SystemContextMenu_PreventDefault": (self: BrowserWindow, value) => { browserWindowSystemContextMenuPreventDefault[self.id] = value; },

		"GetFocusedWindow": (_: null) => BrowserWindow.getFocusedWindow(),
		"FromWebContents": (_: null, contents) => BrowserWindow.fromWebContents(contents ? webContents.fromId(contents) : null),
		"FromBrowserView": (_: null, browserView) => BrowserWindow.fromBrowserView(api.get<BrowserView>(browserView)),

		"WebContents_Get": (self: BrowserWindow) => self.webContents,
		"AutoHideMenuBar_Get": (self: BrowserWindow) => self.autoHideMenuBar,
		"AutoHideMenuBar_Set": (self: BrowserWindow, value) => { self.autoHideMenuBar = value; },
		"SimpleFullScreen_Get": (self: BrowserWindow) => self.simpleFullScreen,
		"SimpleFullScreen_Set": (self: BrowserWindow, value) => { self.simpleFullScreen = value; },
		"FullScreen_Get": (self: BrowserWindow) => self.fullScreen,
		"FullScreen_Set": (self: BrowserWindow, value) => { self.fullScreen = value; },
		"VisibleOnAllWorkspaces_Get": (self: BrowserWindow) => self.visibleOnAllWorkspaces,
		"VisibleOnAllWorkspaces_Set": (self: BrowserWindow, value) => { self.visibleOnAllWorkspaces = value; },
		"Shadow_Get": (self: BrowserWindow) => self.shadow,
		"Shadow_Set": (self: BrowserWindow, value) => { self.shadow = value; },
		"MenuBarVisible_Get": (self: BrowserWindow) => self.menuBarVisible,
		"MenuBarVisible_Set": (self: BrowserWindow, value) => { self.menuBarVisible = value; },
		"Kiosk_Get": (self: BrowserWindow) => self.kiosk,
		"Kiosk_Set": (self: BrowserWindow, value) => { self.kiosk = value; },
		"DocumentEdited_Get": (self: BrowserWindow) => self.documentEdited,
		"DocumentEdited_Set": (self: BrowserWindow, value) => { self.documentEdited = value; },
		"RepresentedFilename_Get": (self: BrowserWindow) => self.representedFilename,
		"RepresentedFilename_Set": (self: BrowserWindow, value) => { self.representedFilename = value; },
		"Title_Get": (self: BrowserWindow) => self.title,
		"Title_Set": (self: BrowserWindow, value) => { self.title = value; },
		"Minimizable_Get": (self: BrowserWindow) => self.minimizable,
		"Minimizable_Set": (self: BrowserWindow, value) => { self.minimizable = value; },
		"Maximizable_Get": (self: BrowserWindow) => self.maximizable,
		"Maximizable_Set": (self: BrowserWindow, value) => { self.maximizable = value; },
		"FullScreenable_Get": (self: BrowserWindow) => self.fullScreenable,
		"FullScreenable_Set": (self: BrowserWindow, value) => { self.fullScreenable = value; },
		"Resizable_Get": (self: BrowserWindow) => self.resizable,
		"Resizable_Set": (self: BrowserWindow, value) => { self.resizable = value; },
		"Closable_Get": (self: BrowserWindow) => self.closable,
		"Closable_Set": (self: BrowserWindow, value) => { self.closable = value; },
		"Movable_Get": (self: BrowserWindow) => self.movable,
		"Movable_Set": (self: BrowserWindow, value) => { self.movable = value; },
		"ExcludedFromShownWindowsMenu_Get": (self: BrowserWindow) => self.excludedFromShownWindowsMenu,
		"ExcludedFromShownWindowsMenu_Set": (self: BrowserWindow, value) => { self.excludedFromShownWindowsMenu = value; },

		"Destroy": (self: BrowserWindow) => self.destroy(),
		"Close": (self: BrowserWindow) => self.close(),
		"Focus": (self: BrowserWindow) => self.focus(),
		"Blur": (self: BrowserWindow) => self.blur(),
		"IsFocused": (self: BrowserWindow) => self.isFocused(),
		"IsDestroyed": (self: BrowserWindow) => self.isDestroyed(),
		"Show": (self: BrowserWindow) => self.show(),
		"ShowInactive": (self: BrowserWindow) => self.showInactive(),
		"Hide": (self: BrowserWindow) => self.hide(),
		"IsVisible": (self: BrowserWindow) => self.isVisible(),
		"IsModal": (self: BrowserWindow) => self.isModal(),
		"Maximize": (self: BrowserWindow) => self.maximize(),
		"Unmaximize": (self: BrowserWindow) => self.unmaximize(),
		"IsMaximized": (self: BrowserWindow) => self.isMaximized(),
		"Minimize": (self: BrowserWindow) => self.minimize(),
		"Restore": (self: BrowserWindow) => self.restore(),
		"IsMinimized": (self: BrowserWindow) => self.isMinimized(),
		"SetFullScreen": (self: BrowserWindow, flag) => self.setFullScreen(flag),
		"IsFullScreen": (self: BrowserWindow) => self.isFullScreen(),
		"SetSimpleFullScreen": (self: BrowserWindow, flag) => self.setSimpleFullScreen(flag),
		"IsSimpleFullScreen": (self: BrowserWindow) => self.isSimpleFullScreen(),
		"IsNormal": (self: BrowserWindow) => self.isNormal(),
		"SetAspectRatio": (self: BrowserWindow, aspectRatio, extraSize) => self.setAspectRatio(aspectRatio, extraSize),
		"SetBackgroundColor": (self: BrowserWindow, backgroundColor) => self.setBackgroundColor(backgroundColor),
		"PreviewFile": (self: BrowserWindow, path, displayName) => self.previewFile(path, displayName),
		"CloseFilePreview": (self: BrowserWindow) => self.closeFilePreview(),
		"SetBounds": (self: BrowserWindow, bounds, animate) => self.setBounds(bounds, animate),
		"GetBounds": (self: BrowserWindow) => self.getBounds(),
		"GetBackgroundColor": (self: BrowserWindow) => self.getBackgroundColor(),
		"SetContentBounds": (self: BrowserWindow, bounds, animate) => self.setContentBounds(bounds, animate),
		"GetContentBounds": (self: BrowserWindow) => self.getContentBounds(),
		"GetNormalBounds": (self: BrowserWindow) => self.getNormalBounds(),
		"SetEnabled": (self: BrowserWindow, enable) => self.setEnabled(enable),
		"IsEnabled": (self: BrowserWindow) => self.isEnabled(),
		"SetSize": (self: BrowserWindow, width, height, animate) => self.setSize(width, height, animate),
		"GetSize": (self: BrowserWindow) => self.getSize(),
		"SetContentSize": (self: BrowserWindow, width, height, animate) => self.setContentSize(width, height, animate),
		"GetContentSize": (self: BrowserWindow) => self.getContentSize(),
		"SetMinimumSize": (self: BrowserWindow, width, height) => self.setMinimumSize(width, height),
		"GetMinimumSize": (self: BrowserWindow) => self.getMinimumSize(),
		"SetMaximumSize": (self: BrowserWindow, width, height) => self.setMaximumSize(width, height),
		"GetMaximumSize": (self: BrowserWindow) => self.getMaximumSize(),
		"SetResizable": (self: BrowserWindow, resizable) => self.setResizable(resizable),
		"IsResizable": (self: BrowserWindow) => self.isResizable(),
		"SetMovable": (self: BrowserWindow, movable) => self.setMovable(movable),
		"IsMovable": (self: BrowserWindow) => self.isMovable(),
		"SetMinimizable": (self: BrowserWindow, minimizable) => self.setMinimizable(minimizable),
		"IsMinimizable": (self: BrowserWindow) => self.isMinimizable(),
		"SetMaximizable": (self: BrowserWindow, maximizable) => self.setMaximizable(maximizable),
		"IsMaximizable": (self: BrowserWindow) => self.isMaximizable(),
		"SetFullScreenable": (self: BrowserWindow, fullscreenable) => self.setFullScreenable(fullscreenable),
		"IsFullScreenable": (self: BrowserWindow) => self.isFullScreenable(),
		"SetClosable": (self: BrowserWindow, closable) => self.setClosable(closable),
		"IsClosable": (self: BrowserWindow) => self.isClosable(),
		"SetAlwaysOnTop": (self: BrowserWindow, flag, level, relativeLevel) => self.setAlwaysOnTop(flag, level, relativeLevel),
		"IsAlwaysOnTop": (self: BrowserWindow) => self.isAlwaysOnTop(),
		"MoveAbove": (self: BrowserWindow, mediaSourceId) => self.moveAbove(mediaSourceId),
		"MoveTop": (self: BrowserWindow) => self.moveTop(),
		"Center": (self: BrowserWindow) => self.center(),
		"SetPosition": (self: BrowserWindow, x, y, animate) => self.setPosition(x, y, animate),
		"GetPosition": (self: BrowserWindow) => self.getPosition(),
		"SetTitle": (self: BrowserWindow, title) => self.setTitle(title),
		"GetTitle": (self: BrowserWindow) => self.getTitle(),
		"SetSheetOffset": (self: BrowserWindow, offsetY, offsetX) => self.setSheetOffset(offsetY, offsetX),
		"FlashFrame": (self: BrowserWindow, flag) => self.flashFrame(flag),
		"SetSkipTaskbar": (self: BrowserWindow, skip) => self.setSkipTaskbar(skip),
		"SetKiosk": (self: BrowserWindow, flag) => self.setKiosk(flag),
		"IsKiosk": (self: BrowserWindow) => self.isKiosk(),
		"IsTabletMode": (self: BrowserWindow) => self.isTabletMode(),
		"GetMediaSourceId": (self: BrowserWindow) => self.getMediaSourceId(),
		"GetNativeWindowHandle": (self: BrowserWindow) => self.getNativeWindowHandle(),
		"HookWindowMessage": (self: BrowserWindow, message, requestId) =>
			self.hookWindowMessage(message, (wParam, lParam) => {
				api.send("HookWindowMessage_Callback", self.id, requestId, wParam, lParam);
			}),
		"IsWindowMessageHooked": (self: BrowserWindow, message) => self.isWindowMessageHooked(message),
		"UnhookWindowMessage": (self: BrowserWindow, message) => self.unhookWindowMessage(message),
		"UnhookAllWindowMessages": (self: BrowserWindow) => self.unhookAllWindowMessages(),
		"SetRepresentedFilename": (self: BrowserWindow, filename) => self.setRepresentedFilename(filename),
		"GetRepresentedFilename": (self: BrowserWindow) => self.getRepresentedFilename(),
		"SetDocumentEdited": (self: BrowserWindow, edited) => self.setDocumentEdited(edited),
		"IsDocumentEdited": (self: BrowserWindow) => self.isDocumentEdited(),
		"FocusOnWebView": (self: BrowserWindow) => self.focusOnWebView(),
		"BlurWebView": (self: BrowserWindow) => self.blurWebView(),
		"CapturePage": (self: BrowserWindow, rect) => self.capturePage(rect),
		"LoadUrl": (self: BrowserWindow, url, options: LoadURLOptions) => {
			if (options) {
				if ((<any>options).httpReferrerReferrer) {
					options.httpReferrer = (<any>options).httpReferrerReferrer;
					delete (<any>options).httpReferrerReferrer;
				} else if ((<any>options).httpReferrerString) {
					options.httpReferrer = (<any>options).httpReferrerString;
					delete (<any>options).httpReferrerString;
				}
				if (options.postData) {
					for (const data of options.postData) {
						if (data.type === "rawData") {
							data.bytes = Buffer.from(<any>data.bytes, "base64");
						}
					}
				}
			}
			return self.loadURL(url, options);
		},
		"LoadFile": (self: BrowserWindow, filePath, options) => self.loadFile(filePath, options),
		"Reload": (self: BrowserWindow) => self.reload(),
		"SetMenu": (self: BrowserWindow, menu) => self.setMenu(api.get<Menu>(menu)),
		"RemoveMenu": (self: BrowserWindow) => self.removeMenu(),
		"SetProgressBar": (self: BrowserWindow, progress, options) => self.setProgressBar(progress, options),
		"SetOverlayIcon": (self: BrowserWindow, overlay, description) => {
			overlay = api.get<NativeImage>(overlay);
			return self.setOverlayIcon(overlay, description);
		},
		"SetHasShadow": (self: BrowserWindow, hasShadow) => self.setHasShadow(hasShadow),
		"HasShadow": (self: BrowserWindow) => self.hasShadow(),
		"SetOpacity": (self: BrowserWindow, opacity) => self.setOpacity(opacity),
		"GetOpacity": (self: BrowserWindow) => self.getOpacity(),
		"SetShape": (self: BrowserWindow, rects) => self.setShape(rects),
		"SetThumbarButtons": (self: BrowserWindow, buttons) => {
			buttons ??= [];
			for (let i = 0; i < buttons.length; i++) {
				const button = buttons[i];
				button.icon = api.get<NativeImage>(button.icon),
				button.click = () =>
					api.send("SetThumbarButtons_Click", self.id, i);
			}
			return self.setThumbarButtons(buttons);
		},
		"SetThumbnailClip": (self: BrowserWindow, region) => self.setThumbnailClip(region),
		"SetThumbnailToolTip": (self: BrowserWindow, toolTip) => self.setThumbnailToolTip(toolTip),
		"SetAppDetails": (self: BrowserWindow, options) => self.setAppDetails(options),
		"ShowDefinitionForSelection": (self: BrowserWindow) => self.showDefinitionForSelection(),
		"SetIcon": (self: BrowserWindow, icon) => self.setIcon(api.get<NativeImage>(icon)),
		"SetWindowButtonVisibility": (self: BrowserWindow, visible) => self.setWindowButtonVisibility(visible),
		"SetAutoHideMenuBar": (self: BrowserWindow, hide) => self.setAutoHideMenuBar(hide),
		"IsMenuBarAutoHide": (self: BrowserWindow) => self.isMenuBarAutoHide(),
		"SetMenuBarVisibility": (self: BrowserWindow, visible) => self.setMenuBarVisibility(visible),
		"IsMenuBarVisible": (self: BrowserWindow) => self.isMenuBarVisible(),
		"SetVisibleOnAllWorkspaces": (self: BrowserWindow, visible, options) => self.setVisibleOnAllWorkspaces(visible, options),
		"IsVisibleOnAllWorkspaces": (self: BrowserWindow) => self.isVisibleOnAllWorkspaces(),
		"SetIgnoreMouseEvents": (self: BrowserWindow, ignore, options) => self.setIgnoreMouseEvents(ignore, options),
		"SetContentProtection": (self: BrowserWindow, enable) => self.setContentProtection(enable),
		"SetFocusable": (self: BrowserWindow, focusable) => self.setFocusable(focusable),
		"SetParentWindow": (self: BrowserWindow, parent) => self.setParentWindow(parent ? BrowserWindow.fromId(parent) : null),
		"GetParentWindow": (self: BrowserWindow) => self.getParentWindow(),
		"GetChildWindows": (self: BrowserWindow) => self.getChildWindows().map(x => x.id),
		"SetAutoHideCursor": (self: BrowserWindow, autoHide) => self.setAutoHideCursor(autoHide),
		"SelectPreviousTab": (self: BrowserWindow) => self.selectPreviousTab(),
		"SelectNextTab": (self: BrowserWindow) => self.selectNextTab(),
		"MergeAllWindows": (self: BrowserWindow) => self.mergeAllWindows(),
		"MoveTabToNewWindow": (self: BrowserWindow) => self.moveTabToNewWindow(),
		"ToggleTabBar": (self: BrowserWindow) => self.toggleTabBar(),
		"AddTabbedWindow": (self: BrowserWindow, browserWindow) => self.addTabbedWindow(browserWindow ? BrowserWindow.fromId(browserWindow) : null),
		"SetVibrancy": (self: BrowserWindow, type) => self.setVibrancy(type),
		"SetTrafficLightPosition": (self: BrowserWindow, position) => self.setTrafficLightPosition(position),
		"GetTrafficLightPosition": (self: BrowserWindow) => self.getTrafficLightPosition(),
		"SetTouchBar": (self: BrowserWindow, touchBar) => self.setTouchBar(api.get<TouchBar>(touchBar)),
		"SetBrowserView": (self: BrowserWindow, browserView) => self.setBrowserView(api.get<BrowserView>(browserView)),
		"GetBrowserView": (self: BrowserWindow) => self.getBrowserView(),
		"AddBrowserView": (self: BrowserWindow, browserView) => self.addBrowserView(api.get<BrowserView>(browserView)),
		"RemoveBrowserView": (self: BrowserWindow, browserView) => self.removeBrowserView(api.get<BrowserView>(browserView)),
		"SetTopBrowserView": (self: BrowserWindow, browserView) => self.setTopBrowserView(api.get<BrowserView>(browserView)),
		"GetBrowserViews": (self: BrowserWindow) => self.getBrowserViews().map(x => api.store(x))
	}
};
