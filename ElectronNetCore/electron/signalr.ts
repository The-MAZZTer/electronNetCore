import { HubConnection, HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";
import { app, autoUpdater, BrowserView, BrowserWindow, LoadURLOptions, Menu, NativeImage, WebContents,
	BrowserViewConstructorOptions, BrowserWindowConstructorOptions, Session, TouchBar, contentTracing,
	dialog, MessageBoxOptions, globalShortcut, inAppPurchase, Transaction } from "electron";

export class SignalR {
	private appBeforeQuitPreventDefault = false;
	private appWillQuitPreventDefault = false;
	private appOpenFilePreventDefault = false;
	private appOpenUrlPreventDefault = false;
	private appContinueActivityPreventDefault = false;
	private appWillContinueActivityPreventDefault = false;
	private appUpdateActivityStatePreventDefault = false;
	private appCertificateErrorPreventDefault = false;
	private appSelectClientCertificatePreventDefault = false;
	private appLoginPreventDefault = false;
	private appDesktopCapturerGetSourcesPreventDefault = false;

	private readonly browserWindowPageTitleUpdatedPreventDefault: Record<number, true> = {};
	private readonly browserWindowClosePreventDefault: Record<number, true> = {};
	private readonly browserWindowWillResizePreventDefault: Record<number, true> = {};
	private readonly browserWindowWillMovePreventDefault: Record<number, true> = {};
	private readonly browserWindowSystemContextMenuPreventDefault: Record<number, true> = {};

	private readonly handlers: Record<string, (...args: any[]) => any> = {
		"AppCommandLine_AppendSwitch": (_switch, value) => app.commandLine.appendSwitch(_switch, value),
		"AppCommandLine_AppendArgument": value => app.commandLine.appendArgument(value),
		"AppCommandLine_HasSwitch": _switch => app.commandLine.hasSwitch(_switch),
		"AppCommandLine_GetSwitchValue": _switch => app.commandLine.getSwitchValue(_switch),

		"AppDock_Bound": type => app.dock.bounce(type),
		"AppDock_CancelBound": id => app.dock.cancelBounce(id),
		"AppDock_DownloadFinished": filePath => app.dock.downloadFinished(filePath),
		"AppDock_SetBadge": text => app.dock.setBadge(text),
		"AppDock_GetBadge": () => app.dock.getBadge(),
		"AppDock_Hide": () => app.dock.hide(),
		"AppDock_Show": () => app.dock.show(),
		"AppDock_IsVisible": () => app.dock.isVisible(),
		"AppDock_SetMenu": id => app.dock.setMenu(id ? <Menu>this.objects[id] : null),
		"AppDock_GetMenu": () => app.dock.getMenu(),
		"AppDock_SetIconImage": image => app.dock.setIcon(image ? <NativeImage>this.objects[image] : null),
		"AppDock_SetIconPath": image => app.dock.setIcon(image),

		"App_BeforeQuit_PreventDefault": value => this.appBeforeQuitPreventDefault = value,
		"App_WillQuit_PreventDefault": value => this.appWillQuitPreventDefault = value,
		"App_OpenFile_PreventDefault": value => this.appOpenFilePreventDefault = value,
		"App_OpenUrl_PreventDefault": value => this.appOpenUrlPreventDefault = value,
		"App_ContinueActivity_PreventDefault": value => this.appContinueActivityPreventDefault = value,
		"App_WillContinueActivity_PreventDefault": value => this.appWillContinueActivityPreventDefault = value,
		"App_UpdateActivityState_PreventDefault": value => this.appUpdateActivityStatePreventDefault = value,
		"App_CertificateError_PreventDefault": value => this.appCertificateErrorPreventDefault = value,
		"App_SelectClientCertificate_PreventDefault": value => this.appSelectClientCertificatePreventDefault = value,
		"App_Login_PreventDefault": value => this.appLoginPreventDefault = value,
		"App_DesktopCapturerGetSources_PreventDefault": value => this.appDesktopCapturerGetSourcesPreventDefault = value,

		"App_Quit": () => app.quit(),
		"App_Exit": exitCode => app.exit(exitCode),
		"App_Relaunch": options => app.relaunch(options),
		"App_IsReady": () => app.isReady(),
		"App_WhenReady": () => app.whenReady(),
		"App_Focus": options => app.focus(options),
		"App_Hide": () => app.hide(),
		"App_Show": () => app.show(),
		"App_SetAppLogsPath": path => app.setAppLogsPath(path),
		"App_GetAppPath": () => app.getAppPath(),
		"App_GetPath":  name => app.getPath(name),
		"App_GetFileIcon": (path, options) =>  app.getFileIcon(path, options),
		"App_SetPath":  (name, path) => app.setPath(name, path),
		"App_GetVersion": () => app.getVersion(),
		"App_GetName": () => app.getName(),
		"App_SetName": name => app.setName(name),
		"App_GetLocale": () => app.getLocale(),
		"App_GetLocaleCountryCode": () => app.getLocaleCountryCode(),
		"App_AddRecentDocument": path => app.addRecentDocument(path),
		"App_ClearRecentDocuments": () => app.clearRecentDocuments(),
		"App_SetAsDefaultProtocolClient": (protocol, path, args) => app.setAsDefaultProtocolClient(protocol, path, args),
		"App_RemoveAsDefaultProtocolClient": (protocol, path, args) => app.removeAsDefaultProtocolClient(protocol, path, args),
		"App_IsDefaultProtocolClient": (protocol, path, args) => app.isDefaultProtocolClient(protocol, path, args),
		"App_GetApplicationNameForProtocol": url => app.getApplicationNameForProtocol(url),
		"App_GetApplicationInfoForProtocol": async url => {
			const ret: any = await app.getApplicationInfoForProtocol(url);
			if (ret && ret.icon) {
				const id = this.nextGeneratedObjectId++;
				this.objects[id] = ret.icon;
				ret.icon = id;
			}
			return ret;
		},
		"App_SetUserTasks": tasks => app.setUserTasks(tasks),
		"App_GetJumpListSettings": () => app.getJumpListSettings(),
		"App_SetJumpList": categories => app.setJumpList(categories),
		"App_RequestSingleInstanceLock": () => app.requestSingleInstanceLock(),
		"App_HasSingleInstanceLock": () => app.hasSingleInstanceLock(),
		"App_ReleaseSingleInstanceLock": () => app.releaseSingleInstanceLock(),
		"App_SetUserActivity": (type, userInfo, webpageUrl) => app.setUserActivity(type, userInfo, webpageUrl),
		"App_GetCurrentActivityType": () => app.getCurrentActivityType(),
		"App_InvalidateCurrentActivity": () => app.invalidateCurrentActivity(),
		"App_ResignCurrentActivity": () => app.resignCurrentActivity(),
		"App_UpdateCurrentActivity": (type, userInfo) => app.updateCurrentActivity(type, userInfo),
		"App_SetAppUserModelId": id => app.setAppUserModelId(id),
		"App_SetActivationPolicy": policy => app.setActivationPolicy(policy),
		"App_ImportCertificate": options => new Promise<number>(resolve => app.importCertificate(options, x => resolve(x))),
		"App_DisableHardwareAcceleration": () => app.disableHardwareAcceleration(),
		"App_DisableDomainBlockingFor3dApis": () => app.disableDomainBlockingFor3DAPIs(),
		"App_GetAppMetrics": () => app.getAppMetrics(),
		"App_GetGpuFeatureStatus": () => app.getGPUFeatureStatus(),
		"App_GetGpuInfo": infoType => app.getGPUInfo(infoType),
		"App_SetBadgeCount": count => app.setBadgeCount(count),
		"App_GetBadgeCount": () => app.getBadgeCount(),
		"App_IsUnityRunning": () => app.isUnityRunning(),
		"App_GetLoginItemSettings": options => app.getLoginItemSettings(options),
		"App_SetLoginItemSettings": settings => app.setLoginItemSettings(settings),
		"App_IsAccessibilitySupportEnabled": () => app.isAccessibilitySupportEnabled(),
		"App_SetAccessibilitySupportEnabled": enabled => app.setAccessibilitySupportEnabled(enabled),
		"App_ShowAboutPanel": () => app.showAboutPanel(),
		"App_SetAboutPanelOptions": options => app.setAboutPanelOptions(options),
		"App_IsEmojiPanelSupported": () => app.isEmojiPanelSupported(),
		"App_ShowEmojiPanel": () => app.showEmojiPanel(),
		"App_StartAccessingSecurityScopedResource": bookmarkData => app.startAccessingSecurityScopedResource(bookmarkData),
		"App_EnableSandbox": () => app.enableSandbox(),
		"App_IsInApplicationsFolder": () => app.isInApplicationsFolder(),
		"App_MoveToApplicationsFolder": async id => {
			let conflict: null | "exists" | "existsAndRunning" = null;
			const success = app.moveToApplicationsFolder({
				conflictHandler: conflictType => {
					conflict = conflictType;
					return false;
				}
			});
			if (success) {
				return true;
			}
			if (conflict && await this.invoke<boolean>("App_MoveToApplicationsFolder_Conflict", id, conflict)) {
				return app.moveToApplicationsFolder({ conflictHandler: _ =>  true })
			}
			return false;
		},
		"App_IsSecureKeyboardEntryEnabled": () => app.isSecureKeyboardEntryEnabled(),
		"App_SetSecureKeyboardEntryEnabled": enabled => app.setSecureKeyboardEntryEnabled(enabled),

		"App_AccessibilitySupportEnabled_Get": () => app.accessibilitySupportEnabled,
		"App_AccessibilitySupportEnabled_Set": value => { app.accessibilitySupportEnabled = value },
		"App_ApplicationMenu_Get": () => {
			const menu = app.applicationMenu;
			if (menu) {
				(<any>menu).__typeName = "Menu";
			}
			return menu ?? 0;
		},
		"App_ApplicationMenu_Set": value => { app.applicationMenu = value ? <Menu>this.objects[value] : null; },
		"App_BadgeCount_Get": () => app.badgeCount,
		"App_BadgeCount_Set": value => { app.badgeCount = value; },
		"App_IsPackaged_Get": () => app.isPackaged,
		"App_Name_Get": () => app.name,
		"App_Name_Set": value => { app.name = value; },
		"App_UserAgentFallback_Get": () => app.userAgentFallback,
		"App_UserAgentFallback_Set": value => { app.userAgentFallback = value; },
		"App_AllowRendererProcessReuse_Get": () => app.allowRendererProcessReuse,
		"App_AllowRendererProcessReuse_Set": value => { app.allowRendererProcessReuse = value; },
		"App_RunningUnderRosettaTranslation_Get": () => app.runningUnderRosettaTranslation,
		
		"AutoUpdater_SetFeedUrl": options => autoUpdater.setFeedURL(options),
		"AutoUpdater_GetFeedUrl": () => autoUpdater.getFeedURL(),
		"AutoUpdater_CheckForUpdates": () => autoUpdater.checkForUpdates(),
		"AutoUpdater_QuitAndInstall": () => autoUpdater.quitAndInstall(),

		"BrowserView_Ctor": (_: null, options: BrowserViewConstructorOptions) => {
			if (options && options.webPreferences) {
				if (options.webPreferences.session) {
					options.webPreferences.session = <Session>this.objects[<any>options.webPreferences.session];
				} else {
					options.webPreferences.session = null;
				}
			}
			return new BrowserView(options);
		},

		"BrowserView_WebContents_Get": (self: BrowserView) => self.webContents?.id ?? 0,
		"BrowserView_WebContents_Set": (self: BrowserView, value: number) => { self.webContents = value ? WebContents.fromId(value) : null },

		"BrowserView_SetAutoResize": (self: BrowserView, options) => self.setAutoResize(options),
		"BrowserView_SetBounds": (self: BrowserView, bounds) => self.setBounds(bounds),
		"BrowserView_GetBounds": (self: BrowserView) => self.getBounds(),
		"BrowserView_SetBackgroundColor": (self: BrowserView, color) => self.setBackgroundColor(color),

		"BrowserWindow_Ctor": (_: null, options: BrowserWindowConstructorOptions) => {
			if (options) {
				if ((<any>options).iconImage) {
					options.icon = <NativeImage>this.objects[(<any>options).iconImage];
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
					if (options.webPreferences.session) {
						options.webPreferences.session = <Session>this.objects[<any>options.webPreferences.session];
					} else {
						options.webPreferences.session = null;
					}
				}
			}
			return new BrowserWindow(options).id;
		},

		"BrowserWindow_PageTitleUpdated_PreventDefault": (self: BrowserWindow, value) => this.browserWindowPageTitleUpdatedPreventDefault[self.id] = value,
		"BrowserWindow_Close_PreventDefault": (self: BrowserWindow, value) => this.browserWindowClosePreventDefault[self.id] = value,
		"BrowserWindow_WillResize_PreventDefault": (self: BrowserWindow, value) => this.browserWindowWillResizePreventDefault[self.id] = value,
		"BrowserWindow_WillMove_PreventDefault": (self: BrowserWindow, value) => this.browserWindowWillMovePreventDefault[self.id] = value,
		"BrowserWindow_SystemContextMenu_PreventDefault": (self: BrowserWindow, value) => this.browserWindowSystemContextMenuPreventDefault[self.id] = value,

		"BrowserWindow_GetFocusedWindow": (_: null) => BrowserWindow.getFocusedWindow()?.id ?? 0,
		"BrowserWindow_FromWebContents": (_: null, webConntents) => BrowserWindow.fromWebContents(webConntents ? WebContents.fromId(webConntents) : null)?.id ?? 0,
		"BrowserWindow_FromBrowserView": (_: null, browserView) => BrowserWindow.fromBrowserView(browserView ? <BrowserView>this.objects[browserView] : null)?.id ?? 0,

		"BrowserWindow_WebContents_Get": (self: BrowserWindow) => self.webContents?.id ?? 0,
		"BrowserWindow_AutoHideMenuBar_Get": (self: BrowserWindow) => self.autoHideMenuBar,
		"BrowserWindow_AutoHideMenuBar_Set": (self: BrowserWindow, value) => { self.autoHideMenuBar = value; },
		"BrowserWindow_SimpleFullScreen_Get": (self: BrowserWindow) => self.simpleFullScreen,
		"BrowserWindow_SimpleFullScreen_Set": (self: BrowserWindow, value) => { self.simpleFullScreen = value; },
		"BrowserWindow_FullScreen_Get": (self: BrowserWindow) => self.fullScreen,
		"BrowserWindow_FullScreen_Set": (self: BrowserWindow, value) => { self.fullScreen = value; },
		"BrowserWindow_VisibleOnAllWorkspaces_Get": (self: BrowserWindow) => self.visibleOnAllWorkspaces,
		"BrowserWindow_VisibleOnAllWorkspaces_Set": (self: BrowserWindow, value) => { self.visibleOnAllWorkspaces = value; },
		"BrowserWindow_Shadow_Get": (self: BrowserWindow) => self.shadow,
		"BrowserWindow_Shadow_Set": (self: BrowserWindow, value) => { self.shadow = value; },
		"BrowserWindow_MenuBarVisible_Get": (self: BrowserWindow) => self.menuBarVisible,
		"BrowserWindow_MenuBarVisible_Set": (self: BrowserWindow, value) => { self.menuBarVisible = value; },
		"BrowserWindow_Kiosk_Get": (self: BrowserWindow) => self.kiosk,
		"BrowserWindow_Kiosk_Set": (self: BrowserWindow, value) => { self.kiosk = value; },
		"BrowserWindow_DocumentEdited_Get": (self: BrowserWindow) => self.documentEdited,
		"BrowserWindow_DocumentEdited_Set": (self: BrowserWindow, value) => { self.documentEdited = value; },
		"BrowserWindow_RepresentedFilename_Get": (self: BrowserWindow) => self.representedFilename,
		"BrowserWindow_RepresentedFilename_Set": (self: BrowserWindow, value) => { self.representedFilename = value; },
		"BrowserWindow_Title_Get": (self: BrowserWindow) => self.title,
		"BrowserWindow_Title_Set": (self: BrowserWindow, value) => { self.title = value; },
		"BrowserWindow_Minimizable_Get": (self: BrowserWindow) => self.minimizable,
		"BrowserWindow_Minimizable_Set": (self: BrowserWindow, value) => { self.minimizable = value; },
		"BrowserWindow_Maximizable_Get": (self: BrowserWindow) => self.maximizable,
		"BrowserWindow_Maximizable_Set": (self: BrowserWindow, value) => { self.maximizable = value; },
		"BrowserWindow_FullScreenable_Get": (self: BrowserWindow) => self.fullScreenable,
		"BrowserWindow_FullScreenable_Set": (self: BrowserWindow, value) => { self.fullScreenable = value; },
		"BrowserWindow_Resizable_Get": (self: BrowserWindow) => self.resizable,
		"BrowserWindow_Resizable_Set": (self: BrowserWindow, value) => { self.resizable = value; },
		"BrowserWindow_Closable_Get": (self: BrowserWindow) => self.closable,
		"BrowserWindow_Closable_Set": (self: BrowserWindow, value) => { self.closable = value; },
		"BrowserWindow_Movable_Get": (self: BrowserWindow) => self.movable,
		"BrowserWindow_Movable_Set": (self: BrowserWindow, value) => { self.movable = value; },
		"BrowserWindow_ExcludedFromShownWindowsMenu_Get": (self: BrowserWindow) => self.excludedFromShownWindowsMenu,
		"BrowserWindow_ExcludedFromShownWindowsMenu_Set": (self: BrowserWindow, value) => { self.excludedFromShownWindowsMenu = value; },

		"BrowserWindow_Destroy": (self: BrowserWindow) => self.destroy(),
		"BrowserWindow_Close": (self: BrowserWindow) => self.close(),
		"BrowserWindow_Focus": (self: BrowserWindow) => self.focus(),
		"BrowserWindow_Blur": (self: BrowserWindow) => self.blur(),
		"BrowserWindow_IsFocused": (self: BrowserWindow) => self.isFocused(),
		"BrowserWindow_IsDestroyed": (self: BrowserWindow) => self.isDestroyed(),
		"BrowserWindow_Show": (self: BrowserWindow) => self.show(),
		"BrowserWindow_ShowInactive": (self: BrowserWindow) => self.showInactive(),
		"BrowserWindow_Hide": (self: BrowserWindow) => self.hide(),
		"BrowserWindow_IsVisible": (self: BrowserWindow) => self.isVisible(),
		"BrowserWindow_IsModal": (self: BrowserWindow) => self.isModal(),
		"BrowserWindow_Maximize": (self: BrowserWindow) => self.maximize(),
		"BrowserWindow_Unmaximize": (self: BrowserWindow) => self.unmaximize(),
		"BrowserWindow_IsMaximized": (self: BrowserWindow) => self.isMaximized(),
		"BrowserWindow_Minimize": (self: BrowserWindow) => self.minimize(),
		"BrowserWindow_Restore": (self: BrowserWindow) => self.restore(),
		"BrowserWindow_IsMinimized": (self: BrowserWindow) => self.isMinimized(),
		"BrowserWindow_SetFullScreen": (self: BrowserWindow, flag) => self.setFullScreen(flag),
		"BrowserWindow_IsFullScreen": (self: BrowserWindow) => self.isFullScreen(),
		"BrowserWindow_SetSimpleFullScreen": (self: BrowserWindow, flag) => self.setSimpleFullScreen(flag),
		"BrowserWindow_IsSimpleFullScreen": (self: BrowserWindow) => self.isSimpleFullScreen(),
		"BrowserWindow_IsNormal": (self: BrowserWindow) => self.isNormal(),
		"BrowserWindow_SetAspectRatio": (self: BrowserWindow, aspectRatio, extraSize) => self.setAspectRatio(aspectRatio, extraSize),
		"BrowserWindow_SetBackgroundColor": (self: BrowserWindow, backgroundColor) => self.setBackgroundColor(backgroundColor),
		"BrowserWindow_PreviewFile": (self: BrowserWindow, path, displayName) => self.previewFile(path, displayName),
		"BrowserWindow_CloseFilePreview": (self: BrowserWindow) => self.closeFilePreview(),
		"BrowserWindow_SetBounds": (self: BrowserWindow, bounds, animate) => self.setBounds(bounds, animate),
		"BrowserWindow_GetBounds": (self: BrowserWindow) => self.getBounds(),
		"BrowserWindow_GetBackgroundColor": (self: BrowserWindow) => self.getBackgroundColor(),
		"BrowserWindow_SetContentBounds": (self: BrowserWindow, bounds, animate) => self.setContentBounds(bounds, animate),
		"BrowserWindow_GetContentBounds": (self: BrowserWindow) => self.getContentBounds(),
		"BrowserWindow_GetNormalBounds": (self: BrowserWindow) => self.getNormalBounds(),
		"BrowserWindow_SetEnabled": (self: BrowserWindow, enable) => self.setEnabled(enable),
		"BrowserWindow_IsEnabled": (self: BrowserWindow) => self.isEnabled(),
		"BrowserWindow_SetSize": (self: BrowserWindow, width, height, animate) => self.setSize(width, height, animate),
		"BrowserWindow_GetSize": (self: BrowserWindow) => self.getSize(),
		"BrowserWindow_SetContentSize": (self: BrowserWindow, width, height, animate) => self.setContentSize(width, height, animate),
		"BrowserWindow_GetContentSize": (self: BrowserWindow) => self.getContentSize(),
		"BrowserWindow_SetMinimumSize": (self: BrowserWindow, width, height) => self.setMinimumSize(width, height),
		"BrowserWindow_GetMinimumSize": (self: BrowserWindow) => self.getMinimumSize(),
		"BrowserWindow_SetMaximumSize": (self: BrowserWindow, width, height) => self.setMaximumSize(width, height),
		"BrowserWindow_GetMaximumSize": (self: BrowserWindow) => self.getMaximumSize(),
		"BrowserWindow_SetResizable": (self: BrowserWindow, resizable) => self.setResizable(resizable),
		"BrowserWindow_IsResizable": (self: BrowserWindow) => self.isResizable(),
		"BrowserWindow_SetMovable": (self: BrowserWindow, movable) => self.setMovable(movable),
		"BrowserWindow_IsMovable": (self: BrowserWindow) => self.isMovable(),
		"BrowserWindow_SetMinimizable": (self: BrowserWindow, minimizable) => self.setMinimizable(minimizable),
		"BrowserWindow_IsMinimizable": (self: BrowserWindow) => self.isMinimizable(),
		"BrowserWindow_SetMaximizable": (self: BrowserWindow, maximizable) => self.setMaximizable(maximizable),
		"BrowserWindow_IsMaximizable": (self: BrowserWindow) => self.isMaximizable(),
		"BrowserWindow_SetFullScreenable": (self: BrowserWindow, fullscreenable) => self.setFullScreenable(fullscreenable),
		"BrowserWindow_IsFullScreenable": (self: BrowserWindow) => self.isFullScreenable(),
		"BrowserWindow_SetClosable": (self: BrowserWindow, closable) => self.setClosable(closable),
		"BrowserWindow_IsClosable": (self: BrowserWindow) => self.isClosable(),
		"BrowserWindow_SetAlwaysOnTop": (self: BrowserWindow, flag, level, relativeLevel) => self.setAlwaysOnTop(flag, level, relativeLevel),
		"BrowserWindow_IsAlwaysOnTop": (self: BrowserWindow) => self.isAlwaysOnTop(),
		"BrowserWindow_MoveAbove": (self: BrowserWindow, mediaSourceId) => self.moveAbove(mediaSourceId),
		"BrowserWindow_MoveTop": (self: BrowserWindow) => self.moveTop(),
		"BrowserWindow_Center": (self: BrowserWindow) => self.center(),
		"BrowserWindow_SetPosition": (self: BrowserWindow, x, y, animate) => self.setPosition(x, y, animate),
		"BrowserWindow_GetPosition": (self: BrowserWindow) => self.getPosition(),
		"BrowserWindow_SetTitle": (self: BrowserWindow, title) => self.setTitle(title),
		"BrowserWindow_GetTitle": (self: BrowserWindow) => self.getTitle(),
		"BrowserWindow_SetSheetOffset": (self: BrowserWindow, offsetY, offsetX) => self.setSheetOffset(offsetY, offsetX),
		"BrowserWindow_FlashFrame": (self: BrowserWindow, flag) => self.flashFrame(flag),
		"BrowserWindow_SetSkipTaskbar": (self: BrowserWindow, skip) => self.setSkipTaskbar(skip),
		"BrowserWindow_SetKiosk": (self: BrowserWindow, flag) => self.setKiosk(flag),
		"BrowserWindow_IsKiosk": (self: BrowserWindow) => self.isKiosk(),
		"BrowserWindow_IsTabletMode": (self: BrowserWindow) => self.isTabletMode(),
		"BrowserWindow_GetMediaSourceId": (self: BrowserWindow) => self.getMediaSourceId(),
		"BrowserWindow_GetNativeWindowHandle": (self: BrowserWindow) => self.getNativeWindowHandle(),
		"BrowserWindow_HookWindowMessage": (self: BrowserWindow, message, requestId) =>
			self.hookWindowMessage(message, (wParam, lParam) => {
				this.send("BrowserWindow_HookWindowMessage_Callback", self.id, requestId, wParam, lParam);
			}),
		"BrowserWindow_IsWindowMessageHooked": (self: BrowserWindow, message) => self.isWindowMessageHooked(message),
		"BrowserWindow_UnhookWindowMessage": (self: BrowserWindow, message) => self.unhookWindowMessage(message),
		"BrowserWindow_UnhookAllWindowMessages": (self: BrowserWindow) => self.unhookAllWindowMessages(),
		"BrowserWindow_SetRepresentedFilename": (self: BrowserWindow, filename) => self.setRepresentedFilename(filename),
		"BrowserWindow_GetRepresentedFilename": (self: BrowserWindow) => self.getRepresentedFilename(),
		"BrowserWindow_SetDocumentEdited": (self: BrowserWindow, edited) => self.setDocumentEdited(edited),
		"BrowserWindow_IsDocumentEdited": (self: BrowserWindow) => self.isDocumentEdited(),
		"BrowserWindow_FocusOnWebView": (self: BrowserWindow) => self.focusOnWebView(),
		"BrowserWindow_BlurWebView": (self: BrowserWindow) => self.blurWebView(),
		"BrowserWindow_CapturePage": (self: BrowserWindow, rect) => self.capturePage(rect),
		"BrowserWindow_LoadUrl": (self: BrowserWindow, url, options: LoadURLOptions) => {
			if (options && options.postData) {
				for (const data of options.postData) {
					if (data.type === "rawData") {
						data.bytes = Buffer.from(<any>data.bytes, "base64");
					}
				}
			}
			return self.loadURL(url, options);
		},
		"BrowserWindow_LoadFile": (self: BrowserWindow, filePath, options) => self.loadFile(filePath, options),
		"BrowserWindow_Reload": (self: BrowserWindow) => self.reload(),
		"BrowserWindow_SetMenu": (self: BrowserWindow, menu) => self.setMenu(menu ? <Menu>this.objects[menu] : null),
		"BrowserWindow_RemoveMenu": (self: BrowserWindow) => self.removeMenu(),
		"BrowserWindow_SetProgressBar": (self: BrowserWindow, progress, options) => self.setProgressBar(progress, options),
		"BrowserWindow_SetOverlayIcon": (self: BrowserWindow, overlay, description) => {
			overlay = overlay ? this.objects[overlay] : null;
			return self.setOverlayIcon(overlay, description);
		},
		"BrowserWindow_SetHasShadow": (self: BrowserWindow, hasShadow) => self.setHasShadow(hasShadow),
		"BrowserWindow_HasShadow": (self: BrowserWindow) => self.hasShadow(),
		"BrowserWindow_SetOpacity": (self: BrowserWindow, opacity) => self.setOpacity(opacity),
		"BrowserWindow_GetOpacity": (self: BrowserWindow) => self.getOpacity(),
		"BrowserWindow_SetShape": (self: BrowserWindow, rects) => self.setShape(rects),
		"BrowserWindow_SetThumbarButtons": (self: BrowserWindow, buttons) => {
			buttons ??= [];
			for (let i = 0; i < buttons.length; i++) {
				const button = buttons[i];
				button.icon = button.icon ? this.objects[button.icon] : null,
				button.click = () => {
					this.send("BrowserWindow_SetThumbarButtons_Click", self.id, i);
				};
			}
			return self.setThumbarButtons(buttons);
		},
		"BrowserWindow_SetThumbnailClip": (self: BrowserWindow, region) => self.setThumbnailClip(region),
		"BrowserWindow_SetThumbnailToolTip": (self: BrowserWindow, toolTip) => self.setThumbnailToolTip(toolTip),
		"BrowserWindow_SetAppDetails": (self: BrowserWindow, options) => self.setAppDetails(options),
		"BrowserWindow_ShowDefinitionForSelection": (self: BrowserWindow) => self.showDefinitionForSelection(),
		"BrowserWindow_SetIcon": (self: BrowserWindow, icon) => self.setIcon(icon ? <NativeImage>this.objects[icon] : null),
		"BrowserWindow_SetWindowButtonVisibility": (self: BrowserWindow, visible) => self.setWindowButtonVisibility(visible),
		"BrowserWindow_SetAutoHideMenuBar": (self: BrowserWindow, hide) => self.setAutoHideMenuBar(hide),
		"BrowserWindow_IsMenuBarAutoHide": (self: BrowserWindow) => self.isMenuBarAutoHide(),
		"BrowserWindow_SetMenuBarVisibility": (self: BrowserWindow, visible) => self.setMenuBarVisibility(visible),
		"BrowserWindow_IsMenuBarVisible": (self: BrowserWindow) => self.isMenuBarVisible(),
		"BrowserWindow_SetVisibleOnAllWorkspaces": (self: BrowserWindow, visible, options) => self.setVisibleOnAllWorkspaces(visible, options),
		"BrowserWindow_IsVisibleOnAllWorkspaces": (self: BrowserWindow) => self.isVisibleOnAllWorkspaces(),
		"BrowserWindow_SetIgnoreMouseEvents": (self: BrowserWindow, ignore, options) => self.setIgnoreMouseEvents(ignore, options),
		"BrowserWindow_SetContentProtection": (self: BrowserWindow, enable) => self.setContentProtection(enable),
		"BrowserWindow_SetFocusable": (self: BrowserWindow, focusable) => self.setFocusable(focusable),
		"BrowserWindow_SetParentWindow": (self: BrowserWindow, parent) => self.setParentWindow(parent ? BrowserWindow.fromId(parent) : null),
		"BrowserWindow_GetParentWindow": (self: BrowserWindow) => self.getParentWindow(),
		"BrowserWindow_GetChildWindows": (self: BrowserWindow) => self.getChildWindows().map(x => x.id),
		"BrowserWindow_SetAutoHideCursor": (self: BrowserWindow, autoHide) => self.setAutoHideCursor(autoHide),
		"BrowserWindow_SelectPreviousTab": (self: BrowserWindow) => self.selectPreviousTab(),
		"BrowserWindow_SelectNextTab": (self: BrowserWindow) => self.selectNextTab(),
		"BrowserWindow_MergeAllWindows": (self: BrowserWindow) => self.mergeAllWindows(),
		"BrowserWindow_MoveTabToNewWindow": (self: BrowserWindow) => self.moveTabToNewWindow(),
		"BrowserWindow_ToggleTabBar": (self: BrowserWindow) => self.toggleTabBar(),
		"BrowserWindow_AddTabbedWindow": (self: BrowserWindow, browserWindow) => self.addTabbedWindow(browserWindow ? BrowserWindow.fromId(browserWindow) : null),
		"BrowserWindow_SetVibrancy": (self: BrowserWindow, type) => self.setVibrancy(type),
		"BrowserWindow_SetTrafficLightPosition": (self: BrowserWindow, position) => self.setTrafficLightPosition(position),
		"BrowserWindow_GetTrafficLightPosition": (self: BrowserWindow) => self.getTrafficLightPosition(),
		"BrowserWindow_SetTouchBar": (self: BrowserWindow, touchBar) => self.setTouchBar(touchBar ? <TouchBar>this.objects[touchBar] : null),
		"BrowserWindow_SetBrowserView": (self: BrowserWindow, browserView) => self.setBrowserView(browserView ? <BrowserView>this.objects[browserView] : null),
		"BrowserWindow_GetBrowserView": (self: BrowserWindow) => self.getBrowserView(),
		"BrowserWindow_AddBrowserView": (self: BrowserWindow, browserView) => self.addBrowserView(browserView ? <BrowserView>this.objects[browserView] : null),
		"BrowserWindow_RemoveBrowserView": (self: BrowserWindow, browserView) => self.removeBrowserView(browserView ? <BrowserView>this.objects[browserView] : null),
		"BrowserWindow_SetTopBrowserView": (self: BrowserWindow, browserView) => self.setTopBrowserView(browserView ? <BrowserView>this.objects[browserView] : null),
		"BrowserWindow_GetBrowserViews": (self: BrowserWindow) => self.getBrowserViews().map(x => {
			const id = this.nextGeneratedObjectId++;
			this.objects[id] = x;
			return id;	
		}),

		"ContentTracing_GetCategories": () => contentTracing.getCategories(),
		"ContentTracing_StartRecording_TraceConfig": options => contentTracing.startRecording(options),
		"ContentTracing_StartRecording_TraceCategoriesAndOptions": options => contentTracing.startRecording(options),
		"ContentTracing_StopRecording": resultFilePath => contentTracing.startRecording(resultFilePath),
		"ContentTracing_GetTraceBufferUsage": () => contentTracing.getTraceBufferUsage(),

		"Dialog_ShowOpenDialog": async (browserWindow: number, options) => dialog.showOpenDialog(browserWindow > 0 ? BrowserWindow.fromId(browserWindow) : null, options),
		"Dialog_ShowSaveDialog": (browserWindow: number, options) => dialog.showSaveDialog(browserWindow > 0 ? BrowserWindow.fromId(browserWindow) : null, options),
		"Dialog_ShowMessageBox": (browserWindow: number, options: MessageBoxOptions) => {
			if (options) {
				options.icon = <any>options.icon > 0 ? <NativeImage>this.objects[<any>options.icon] : null;
			}
			return dialog.showMessageBox(browserWindow > 0 ? BrowserWindow.fromId(browserWindow) : null, options);
		},
		"Dialog_ShowErrorBox": (title, content) => dialog.showErrorBox(title, content),
		"Dialog_ShowCertificateTrustDialog": (browserWindow: number, options) => dialog.showCertificateTrustDialog(browserWindow > 0 ? BrowserWindow.fromId(browserWindow) : null, options),

		"Function_Invoke": (self: Function, args: any[]) => self(...args),

		"GlobalShortcut_Register": (accelerator, requestId) => {
			return globalShortcut.register(accelerator, () => {
				this.send("GlobalShortcut_Register_Callback", requestId);
			});
		},
		"GlobalShortcut_RegisterAll": (accelerators, requestId) =>
			globalShortcut.registerAll(accelerators, () => {
				this.send("GlobalShortcut_Register_Callback", requestId);
			}),
		"GlobalShortcut_IsRegistered": accelerator => globalShortcut.isRegistered(accelerator),
		"GlobalShortcut_Unregister": accelerator => globalShortcut.unregister(accelerator),
		"GlobalShortcut_UnregisterAll": () => globalShortcut.unregisterAll(),

		"InAppPurchase_PurchaseProduct": (productId, quantity) => inAppPurchase.purchaseProduct(productId, quantity),
		"InAppPurchase_GetProducts": productIds => inAppPurchase.getProducts(productIds),
		"InAppPurchase_CanMakePayments": () => inAppPurchase.canMakePayments(),
		"InAppPurchase_RestoreCompletedTransactions": () => inAppPurchase.restoreCompletedTransactions(),
		"InAppPurchase_GetReceiptUrl": () => inAppPurchase.getReceiptURL(),
		"InAppPurchase_FinishAllTransactions": () => inAppPurchase.finishAllTransactions(),
		"InAppPurchase_FinishTransactionByDate": date => inAppPurchase.finishTransactionByDate(date),

		"NativeImage_GetSize": (self: NativeImage, scaleFactor) => self.getSize(scaleFactor),
		"NativeImage_ToDataUrl": (self: NativeImage, options) => self.toDataURL(options),

		"ProcessVersions_Chrome_Get": () => process.versions.chrome,
		"ProcessVersions_Electron_Get": () => process.versions.electron,

		"Process_DefaultApp_Get": () => process.defaultApp ?? false,
		"Process_IsMainFrame_Get": () => process.isMainFrame ?? false,
		"Process_Mas_Get": () => process.mas ?? false,
		"Process_NoAsar_Get": () => process.noAsar ?? false,
		"Process_NoAsar_Set": value => { process.noAsar = value; },
		"Process_NoDeprecation_Get": () => process.noDeprecation ?? false,
		"Process_NoDeprecation_Set": value => { process.noDeprecation = value; },
		"Process_ResourcesPath_Get": () => process.resourcesPath,
		"Process_Sandboxed_Get": () => process.sandboxed ?? false,
		"Process_ThrowDeprecation_Get": () => process.throwDeprecation ?? false,
		"Process_ThrowDeprecation_Set": value => { process.throwDeprecation = value; },
		"Process_TraceDeprecation_Get": () => process.traceDeprecation ?? false,
		"Process_TraceDeprecation_Set": value => { process.traceDeprecation = value; },
		"Process_TraceProcessWarnings_Get": () => process.traceProcessWarnings ?? false,
		"Process_TraceProcessWarnings_Set": value => { process.traceProcessWarnings = value; },
		"Process_Type_Get": () => process.type,
		"Process_WindowsStore_Get": () => process.windowsStore ?? false,

		"Process_Crash": () => process.crash(),
		"Process_GetCreationTime": () => process.getCreationTime(),
		"Process_GetCpuUsage": () => process.getCPUUsage(),
		"Process_GetIoCounters": () => process.getIOCounters(),
		"Process_GetHeapStatistics": () => process.getHeapStatistics(),
		"Process_GetBlinkMemoryInfo": () => process.getBlinkMemoryInfo(),
		"Process_GetProcessMemoryInfo": () => process.getProcessMemoryInfo(),
		"Process_GetSystemMemoryInfo": () => process.getSystemMemoryInfo(),
		"Process_GetSystemVersion": () => process.getSystemVersion(),
		"Process_TakeHeapSnapshot": filePath => process.takeHeapSnapshot(filePath),
		"Process_Hang": () => process.hang(),
		"Process_SetFdLimit": maxDescriptors => process.setFdLimit(maxDescriptors)
	};

	private nextGeneratedObjectId = 1;
	private readonly objects: Record<number, object> = {};

	private readonly trackedTypes: Record<string, true> = {
		"BrowserView": true,
		"Function": true,
		"Menu": true,
		"NativeImage": true,
		"Session": true,
		"TouchBar": true
	};

	private signalr: HubConnection;

	public async start(url: string): Promise<void> {
		const signalr = this.signalr = new HubConnectionBuilder()
			.withAutomaticReconnect([0, 250, 500, null])
			.withUrl(new URL("/electronnetcoreproxy", url).href)
			.build();

		signalr.on("DisposeObject", (id: number) => {
			delete this.objects[id];
		});

		for (const name in this.handlers) {
			const handler = this.handlers[name];
			signalr.on(name, async (...args: any[]) => {
				try {
					const index = name.indexOf("_");
					if (index >= 0) {
						const type = name.substr(0, index);
						if (type === "BrowserWindow") {
							args[1] = args[1] ? BrowserWindow.fromId(args[1]) : null;
						} else if (type === "WebContents") {
							args[1] = args[1] ? WebContents.fromId(args[1]) : null;
						} else if (this.trackedTypes[type]) {
							args[1] = args[1] ? this.objects[args[1]] : null;
						}
					}
	
					let ret = handler(...args.slice(1), args[0]);
					if (ret instanceof Promise) {
						ret = await ret;
					}
					if (ret === undefined) {
						await this.send("Return", args[0], "undefined");
					} else {
						//console.log(ret);

						if (this.trackedTypes[ret?.__typeName ?? ret?.constructor?.name]) {
							/*let found = false;
							for (const id in this.objects) {
								const obj = this.objects[id];
								if (obj === ret) {
									found = true;
									ret = id;
									break;
								}
							}

							if (!found) {*/
								const id = this.nextGeneratedObjectId++;
								this.objects[id] = ret;
								ret = id;	
							//}
						}
	
						await this.send("Return", args[0], JSON.stringify(ret));
					}
				} catch (e) {
					console.error(e);
					await this.send("Error", args[0], {
						name: e.name,
						message: e.message,
						stack: e.stack
					});
				}
			});
		}

		app.on("will-finish-launching", () =>
			this.send("App_WillFinishLaunching_Event"))

		app.on("ready", (_, launchInfo) =>
			this.send("App_Ready_Event", launchInfo));

		app.on("window-all-closed", () =>
			this.send("App_WindowAllClosed_Event"));

		app.on("before-quit", e => {
			if (this.appBeforeQuitPreventDefault) {
				e.preventDefault();
			}
			return this.send("App_BeforeQuit_Event");
		});

		app.on("will-quit", e => {
			if (this.appWillQuitPreventDefault) {
				e.preventDefault();
			}
			return this.send("App_WillQuit_Event");
		});

		app.on("quit", (_, exitCode) =>
			this.send("App_Quit_Event", exitCode));

		app.on("open-file", (e, path) => {
			if (this.appOpenFilePreventDefault) {
				e.preventDefault();
			}
			return this.send("App_OpenFile_Event", path);
		});

		app.on("open-url", (e, url) => {
			if (this.appOpenUrlPreventDefault) {
				e.preventDefault();
			}
			return this.send("App_OpenUrl_Event", url);
		});

		app.on("activate", (_, hasVisibleWindows) =>
			this.send("App_Activate_Event", hasVisibleWindows));

		app.on("did-become-active", _ =>
			this.send("App_DidBecomeActive_Event"));

		app.on("continue-activity", (e, type, userInfo) => {
			if (this.appContinueActivityPreventDefault) {
				e.preventDefault();
			}

			return this.send("App_ContinueActivity_Event", type, userInfo);
		});

		app.on("will-continue-activity", (e, type) => {
			if (this.appWillContinueActivityPreventDefault) {
				e.preventDefault();
			}

			return this.send("App_WillContinueActivity_Event", type);
		});

		app.on("continue-activity-error", (_, type, error) =>
			this.send("App_ContinueActivityError_Event", type, error));

		app.on("activity-was-continued", (_, type, userInfo) =>
			this.send("App_ActivityWasContinued_Event", type, userInfo));

		app.on("update-activity-state", (e, type, userInfo) => {
			if (this.appUpdateActivityStatePreventDefault) {
				e.preventDefault();
			}

			return this.send("App_UpdateActivityState_Event", type, userInfo);
		});

		app.on("new-window-for-tab", _ =>
			this.send("App_NewWindowForTab_Event"));

		app.on("browser-window-blur", (_, window) =>
			this.send("App_BrowserWindowBlur_Event", window.id));

		app.on("browser-window-focus", (_, window) =>
			this.send("App_BrowserWindowFocus_Event", window.id));

		app.on("browser-window-created", (_, window) => {
			const id = window.id;
			window.on("page-title-updated", (e, title, explicitSet) => {
				if (this.browserWindowPageTitleUpdatedPreventDefault[id]) {
					e.preventDefault();
				}

				return this.send("BrowserWindow_PageTitleUpdated_Event", id, title, explicitSet);
			});

			window.on("close", e => {
				if (this.browserWindowClosePreventDefault[id]) {
					e.preventDefault();
				}

				return this.send("BrowserWindow_Close_Event", id);
			});

			window.on("closed", () => {
				delete this.browserWindowPageTitleUpdatedPreventDefault[id];
				delete this.browserWindowClosePreventDefault[id];
				delete this.browserWindowWillResizePreventDefault[id];
				delete this.browserWindowWillMovePreventDefault[id];
				delete this.browserWindowSystemContextMenuPreventDefault[id];
			
				return this.send("BrowserWindow_Closed_Event", id);
			});

			window.on("session-end", () =>
				this.send("BrowserWindow_SessionEnd_Event", id));

			window.on("unresponsive", () =>
				this.send("BrowserWindow_Unresponsive_Event", id));

			window.on("responsive", () =>
				this.send("BrowserWindow_Responsive_Event", id));

			window.on("blur", () =>
				this.send("BrowserWindow_Blur_Event", id));

			window.on("focus", () =>
				this.send("BrowserWindow_Focus_Event", id));

			window.on("show", () =>
				this.send("BrowserWindow_Show_Event", id));

			window.on("hide", () =>
				this.send("BrowserWindow_Hide_Event", id));

			window.on("ready-to-show", () =>
				this.send("BrowserWindow_ReadyToShow_Event", id));

			window.on("maximize", () =>
				this.send("BrowserWindow_Maximize_Event", id));

			window.on("unmaximize", () =>
				this.send("BrowserWindow_Unmaximize_Event", id));

			window.on("minimize", () =>
				this.send("BrowserWindow_Minimize_Event", id));

			window.on("restore", () =>
				this.send("BrowserWindow_Restore_Event", id));

			window.on("will-resize", (e, newBounds) => {
				if (this.browserWindowWillResizePreventDefault[id]) {
					e.preventDefault();
				}

				return this.send("BrowserWindow_WillResize_Event", id, newBounds);
			});

			window.on("resize", () =>
				this.send("BrowserWindow_Resize_Event", id));

			window.on("resized", () =>
				this.send("BrowserWindow_Resized_Event", id));

			window.on("will-move", (e, newBounds) => {
				if (this.browserWindowWillMovePreventDefault[id]) {
					e.preventDefault();
				}

				return this.send("BrowserWindow_WillMove_Event", id, newBounds);
			});

			window.on("move", () =>
				this.send("BrowserWindow_Move_Event", id));

			window.on("moved", () =>
				this.send("BrowserWindow_Moved_Event", id));

			window.on("enter-full-screen", () =>
				this.send("BrowserWindow_EnterFullScreen_Event", id));

			window.on("leave-full-screen", () =>
				this.send("BrowserWindow_LeaveFullScreen_Event", id));

			window.on("enter-html-full-screen", () =>
				this.send("BrowserWindow_EnterHtmlFullScreen_Event", id));

			window.on("leave-html-full-screen", () =>
				this.send("BrowserWindow_LeaveHtmlFullScreen_Event", id));

			window.on("always-on-top-changed", (_, isAlwaysOnTop) =>
				this.send("BrowserWindow_AlwaysOnTopChanged_Event", id, isAlwaysOnTop));

			window.on("app-command", (_, command) =>
				this.send("BrowserWindow_AppCommand_Event", id, command));

			window.on("scroll-touch-begin", () =>
				this.send("BrowserWindow_ScrollTouchBegin_Event", id));

			window.on("scroll-touch-end", () =>
				this.send("BrowserWindow_ScrollTouchEnd_Event", id));

			window.on("scroll-touch-edge", () =>
				this.send("BrowserWindow_ScrollTouchEdge_Event", id));

			window.on("swipe", (_, direction) =>
				this.send("BrowserWindow_Swipe_Event", id, direction));

			window.on("rotate-gesture", (_, rotation) =>
				this.send("BrowserWindow_RotateGesture_Event", id, rotation));

			window.on("sheet-begin", () =>
				this.send("BrowserWindow_SheetBegin_Event", id));

			window.on("sheet-end", () =>
				this.send("BrowserWindow_SheetEnd_Event", id));

			window.on("new-window-for-tab", () =>
				this.send("BrowserWindow_NewWindowForTab_Event", id));

			window.on("system-context-menu", (e, point) => {
				if (this.browserWindowSystemContextMenuPreventDefault[id]) {
					e.preventDefault();
				}

				return this.send("BrowserWindow_SystemContextMenu_Event", id, point);
			});

			return this.send("App_BrowserWindowCreated_Event", id);
		});

		app.on("web-contents-created", (_, contents) => {
			const id = contents.id;
			contents.on("destroyed", () =>
				this.send("WebContents_Destroyed_Event", id));

			return this.send("App_WebContentsCreated_Event", id);
		});

		app.on("certificate-error", (e, webContents, url, error, certficate, callback) => {
			if (this.appCertificateErrorPreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			return this.send("App_CertificateError_Event", webContents.id, url, error, certficate, id);
		});

		app.on("select-client-certificate", (e, webContents, url, certificateList, callback) => {
			if (this.appSelectClientCertificatePreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			return this.send("App_SelectClientCertificate_Event", webContents.id, url, certificateList, id);
		});

		app.on("login", (e, webContents, authenticationResponseDetails, authInfo, callback) => {
			if (this.appLoginPreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			return this.send("App_Login_Event", webContents.id, authenticationResponseDetails, authInfo, id);
		});

		app.on("gpu-info-update", () =>
			this.send("App_GpuInfoUpdate_Event"));

		app.on("render-process-gone", (_, webContents, details) =>
			this.send("App_RenderProcessGone_Event", webContents.id, details));

		app.on("child-process-gone", (_, details) =>
			this.send("App_ChildProcessGone_Event", details));

		app.on("accessibility-support-changed", (_, accessibilitySupportEnabled) =>
			this.send("App_AccessibilitySupportChanged_Event", accessibilitySupportEnabled));

		app.on("session-created", session => {
			const id = this.nextGeneratedObjectId++;
			this.objects[id] = session;
			return this.send("App_SessionCreated_Event", id);
		});

		app.on("second-instance", (_, argv, workingDirectory) =>
			this.send("App_SecondInstance_Event", argv, workingDirectory));

		app.on("desktop-capturer-get-sources", (e, webContents) => {		
			if (this.appDesktopCapturerGetSourcesPreventDefault) {
				e.preventDefault();
			}

			return this.send("App_DesktopCapturerGetSources_Event", webContents.id);
		});

		autoUpdater.on("error", e =>
			this.send("AutoUpdater_Error", {
				name: e.name,
				message: e.message,
				stack: e.stack
			}));
		
		autoUpdater.on("checking-for-update", () =>
			this.send("AutoUpdater_CheckingForUpdate_Event"));

		autoUpdater.on("update-available", () =>
			this.send("AutoUpdater_UpdateAvailable_Event"));

		autoUpdater.on("update-not-available", () =>
			this.send("AutoUpdater_UpdateNotAvailable_Event"));

		autoUpdater.on("update-downloaded", (_, releaseNotes, releaseName, releaseDate, updateUrl) =>
			this.send("AutoUpdater_UpdateDownloaded_Event", releaseNotes, releaseName, releaseDate.valueOf(), updateUrl));

		autoUpdater.on("before-quit-for-update", () => 
			this.send("AutoUpdater_BeforeQuitForUpdate_Event"));

		inAppPurchase.on("transactions-updated", (_: Event, transactions: Transaction[]) =>
			this.send("InAppPurchase_TransactionsUpdated_Event", transactions));

		process.on("loaded", () =>
			this.send("Process_Loaded_Event"));

		signalr.onclose(e => {
			console.error("Can't reconnect to ASP.NET Core!");
			console.error(e);
			app.quit();
		});

		try {
			await signalr.start();
		} catch (e) {
			console.error("Can't connect to ASP.NET Core!");
			console.error(e);
			app.quit();
		}
	}

	private async invoke<T>(method: string, ...args: any[]): Promise<T> {
		while (this.signalr.state !== HubConnectionState.Connected) {
			await new Promise(resolve => setTimeout(resolve, 5));
		}

		return await this.signalr.invoke<T>(method, ...args);
	}

	private async send(method: string, ...args: any[]): Promise<void> {
		while (this.signalr.state !== HubConnectionState.Connected) {
			await new Promise(resolve => setTimeout(resolve, 5));
		}

		await this.signalr.send(method, ...args);
	}
}