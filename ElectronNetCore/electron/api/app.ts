import { app, Menu } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let appBeforeQuitPreventDefault = false;
let appWillQuitPreventDefault = false;
let appOpenFilePreventDefault = false;
let appOpenUrlPreventDefault = false;
let appContinueActivityPreventDefault = false;
let appWillContinueActivityPreventDefault = false;
let appUpdateActivityStatePreventDefault = false;
let appCertificateErrorPreventDefault = false;
let appSelectClientCertificatePreventDefault = false;
let appLoginPreventDefault = false;
let appDesktopCapturerGetSourcesPreventDefault = false;

let api: SignalRApi;

export const ElectronApp: ElectronApi = {
	type: "App",
	init: x => {
		api = x;

		app.on("will-finish-launching", () =>
			api.send("WillFinishLaunching_Event"))

		app.on("ready", (_, launchInfo) => {
			api.send("Ready_Event", launchInfo);
		});

		app.on("window-all-closed", () =>
			api.send("WindowAllClosed_Event"));

		app.on("before-quit", e => {
			if (appBeforeQuitPreventDefault) {
				e.preventDefault();
			}
			return api.send("BeforeQuit_Event");
		});

		app.on("will-quit", e => {
			if (appWillQuitPreventDefault) {
				e.preventDefault();
			}
			return api.send("WillQuit_Event");
		});

		app.on("quit", (_, exitCode) =>
			api.send("Quit_Event", exitCode));

		app.on("open-file", (e, path) => {
			if (appOpenFilePreventDefault) {
				e.preventDefault();
			}
			return api.send("OpenFile_Event", path);
		});

		app.on("open-url", (e, url) => {
			if (appOpenUrlPreventDefault) {
				e.preventDefault();
			}
			return api.send("OpenUrl_Event", url);
		});

		app.on("activate", (_, hasVisibleWindows) =>
			api.send("Activate_Event", hasVisibleWindows));

		app.on("did-become-active", _ =>
			api.send("DidBecomeActive_Event"));

		app.on("continue-activity", (e, type, userInfo) => {
			if (appContinueActivityPreventDefault) {
				e.preventDefault();
			}

			return api.send("ContinueActivity_Event", type, userInfo);
		});

		app.on("will-continue-activity", (e, type) => {
			if (appWillContinueActivityPreventDefault) {
				e.preventDefault();
			}

			return api.send("WillContinueActivity_Event", type);
		});

		app.on("continue-activity-error", (_, type, error) =>
			api.send("ContinueActivityError_Event", type, error));

		app.on("activity-was-continued", (_, type, userInfo) =>
			api.send("ActivityWasContinued_Event", type, userInfo));

		app.on("update-activity-state", (e, type, userInfo) => {
			if (appUpdateActivityStatePreventDefault) {
				e.preventDefault();
			}

			return api.send("UpdateActivityState_Event", type, userInfo);
		});

		app.on("new-window-for-tab", _ =>
			api.send("NewWindowForTab_Event"));

		app.on("browser-window-blur", (_, window) =>
			api.send("BrowserWindowBlur_Event", window.id));

		app.on("browser-window-focus", (_, window) =>
			api.send("BrowserWindowFocus_Event", window.id));

		app.on("browser-window-created", (_, window) =>
			api.send("BrowserWindowCreated_Event", window.id));

		app.on("web-contents-created", (_, contents) =>
			api.send("WebContentsCreated_Event", contents.id));

		app.on("certificate-error", (e, webContents, url, error, certficate, callback) => {
			if (appCertificateErrorPreventDefault) {
				e.preventDefault();
			}

			return api.send("CertificateError_Event", webContents?.id ?? 0, url, error, certficate, api.store(callback));
		});

		app.on("select-client-certificate", (e, webContents, url, certificateList, callback) => {
			if (appSelectClientCertificatePreventDefault) {
				e.preventDefault();
			}

			return api.send("SelectClientCertificate_Event", webContents?.id ?? 0, url, certificateList, api.store(callback));
		});

		app.on("login", (e, webContents, authenticationResponseDetails, authInfo, callback) => {
			if (appLoginPreventDefault) {
				e.preventDefault();
			}

			return api.send("Login_Event", webContents?.id ?? 0, authenticationResponseDetails, authInfo, api.store(callback));
		});

		app.on("gpu-info-update", () =>
			api.send("GpuInfoUpdate_Event"));

		app.on("render-process-gone", (_, webContents, details) =>
			api.send("RenderProcessGone_Event", webContents?.id ?? 0, details));

		app.on("child-process-gone", (_, details) =>
			api.send("ChildProcessGone_Event", details));

		app.on("accessibility-support-changed", (_, accessibilitySupportEnabled) =>
			api.send("AccessibilitySupportChanged_Event", accessibilitySupportEnabled));

		app.on("session-created", session =>
			api.send("SessionCreated_Event", api.store(session)));

		app.on("second-instance", (_, argv, workingDirectory) =>
			api.send("SecondInstance_Event", argv, workingDirectory));

		app.on("desktop-capturer-get-sources", (e, webContents) => {		
			if (appDesktopCapturerGetSourcesPreventDefault) {
				e.preventDefault();
			}

			return api.send("DesktopCapturerGetSources_Event", webContents?.id ?? 0);
		});
	},
	handlers: {
		"BeforeQuit_PreventDefault": value => { appBeforeQuitPreventDefault = value; },
		"WillQuit_PreventDefault": value => { appWillQuitPreventDefault = value; },
		"OpenFile_PreventDefault": value => { appOpenFilePreventDefault = value; },
		"OpenUrl_PreventDefault": value => { appOpenUrlPreventDefault = value; },
		"ContinueActivity_PreventDefault": value => { appContinueActivityPreventDefault = value; },
		"WillContinueActivity_PreventDefault": value => { appWillContinueActivityPreventDefault = value; },
		"UpdateActivityState_PreventDefault": value => { appUpdateActivityStatePreventDefault = value; },
		"CertificateError_PreventDefault": value => { appCertificateErrorPreventDefault = value; },
		"SelectClientCertificate_PreventDefault": value => { appSelectClientCertificatePreventDefault = value; },
		"Login_PreventDefault": value => { appLoginPreventDefault = value; },
		"DesktopCapturerGetSources_PreventDefault": value => { appDesktopCapturerGetSourcesPreventDefault = value; },

		"Quit": () => app.quit(),
		"Exit": exitCode => app.exit(exitCode),
		"Relaunch": options => app.relaunch(options),
		"IsReady": () => app.isReady(),
		"WhenReady": () => app.whenReady(),
		"Focus": options => app.focus(options),
		"Hide": () => app.hide(),
		"Show": () => app.show(),
		"SetAppLogsPath": path => app.setAppLogsPath(path),
		"GetAppPath": () => app.getAppPath(),
		"GetPath":  name => app.getPath(name),
		"GetFileIcon": (path, options) =>  app.getFileIcon(path, options),
		"SetPath":  (name, path) => app.setPath(name, path),
		"GetVersion": () => app.getVersion(),
		"GetName": () => app.getName(),
		"SetName": name => app.setName(name),
		"GetLocale": () => app.getLocale(),
		"GetLocaleCountryCode": () => app.getLocaleCountryCode(),
		"AddRecentDocument": path => app.addRecentDocument(path),
		"ClearRecentDocuments": () => app.clearRecentDocuments(),
		"SetAsDefaultProtocolClient": (protocol, path, args) => app.setAsDefaultProtocolClient(protocol, path, args),
		"RemoveAsDefaultProtocolClient": (protocol, path, args) => app.removeAsDefaultProtocolClient(protocol, path, args),
		"IsDefaultProtocolClient": (protocol, path, args) => app.isDefaultProtocolClient(protocol, path, args),
		"GetApplicationNameForProtocol": url => app.getApplicationNameForProtocol(url),
		"GetApplicationInfoForProtocol": async url => {
			const ret: any = await app.getApplicationInfoForProtocol(url);
			if (ret && ret.icon) {
				ret.icon = api.store(ret.icon);
			}
			return ret;
		},
		"SetUserTasks": tasks => app.setUserTasks(tasks),
		"GetJumpListSettings": () => app.getJumpListSettings(),
		"SetJumpList": categories => app.setJumpList(categories),
		"RequestSingleInstanceLock": () => app.requestSingleInstanceLock(),
		"HasSingleInstanceLock": () => app.hasSingleInstanceLock(),
		"ReleaseSingleInstanceLock": () => app.releaseSingleInstanceLock(),
		"SetUserActivity": (type, userInfo, webpageUrl) => app.setUserActivity(type, userInfo, webpageUrl),
		"GetCurrentActivityType": () => app.getCurrentActivityType(),
		"InvalidateCurrentActivity": () => app.invalidateCurrentActivity(),
		"ResignCurrentActivity": () => app.resignCurrentActivity(),
		"UpdateCurrentActivity": (type, userInfo) => app.updateCurrentActivity(type, userInfo),
		"SetAppUserModelId": id => app.setAppUserModelId(id),
		"SetActivationPolicy": policy => app.setActivationPolicy(policy),
		"ImportCertificate": options => new Promise<number>(resolve => app.importCertificate(options, x => resolve(x))),
		"DisableHardwareAcceleration": () => app.disableHardwareAcceleration(),
		"DisableDomainBlockingFor3dApis": () => app.disableDomainBlockingFor3DAPIs(),
		"GetAppMetrics": () => app.getAppMetrics(),
		"GetGpuFeatureStatus": () => app.getGPUFeatureStatus(),
		"GetGpuInfo": infoType => app.getGPUInfo(infoType),
		"SetBadgeCount": count => app.setBadgeCount(count),
		"GetBadgeCount": () => app.getBadgeCount(),
		"IsUnityRunning": () => app.isUnityRunning(),
		"GetLoginItemSettings": options => app.getLoginItemSettings(options),
		"SetLoginItemSettings": settings => app.setLoginItemSettings(settings),
		"IsAccessibilitySupportEnabled": () => app.isAccessibilitySupportEnabled(),
		"SetAccessibilitySupportEnabled": enabled => app.setAccessibilitySupportEnabled(enabled),
		"ShowAboutPanel": () => app.showAboutPanel(),
		"SetAboutPanelOptions": options => app.setAboutPanelOptions(options),
		"IsEmojiPanelSupported": () => app.isEmojiPanelSupported(),
		"ShowEmojiPanel": () => app.showEmojiPanel(),
		"StartAccessingSecurityScopedResource": bookmarkData => app.startAccessingSecurityScopedResource(bookmarkData),
		"EnableSandbox": () => app.enableSandbox(),
		"IsInApplicationsFolder": () => app.isInApplicationsFolder(),
		"MoveToApplicationsFolder": async id => {
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
			if (conflict && await api.invoke<boolean>("MoveToApplicationsFolder_Conflict", id, conflict)) {
				return app.moveToApplicationsFolder({ conflictHandler: _ =>  true })
			}
			return false;
		},
		"IsSecureKeyboardEntryEnabled": () => app.isSecureKeyboardEntryEnabled(),
		"SetSecureKeyboardEntryEnabled": enabled => app.setSecureKeyboardEntryEnabled(enabled),

		"AccessibilitySupportEnabled_Get": () => app.accessibilitySupportEnabled,
		"AccessibilitySupportEnabled_Set": value => { app.accessibilitySupportEnabled = value },
		"ApplicationMenu_Get": () => app.applicationMenu,
		"ApplicationMenu_Set": value => { app.applicationMenu = api.get<Menu>(value); },
		"BadgeCount_Get": () => app.badgeCount,
		"BadgeCount_Set": value => { app.badgeCount = value; },
		"IsPackaged_Get": () => app.isPackaged,
		"Name_Get": () => app.name,
		"Name_Set": value => { app.name = value; },
		"UserAgentFallback_Get": () => app.userAgentFallback,
		"UserAgentFallback_Set": value => { app.userAgentFallback = value; },
		"AllowRendererProcessReuse_Get": () => app.allowRendererProcessReuse,
		"AllowRendererProcessReuse_Set": value => { app.allowRendererProcessReuse = value; },
		"RunningUnderRosettaTranslation_Get": () => app.runningUnderRosettaTranslation
	}
};
