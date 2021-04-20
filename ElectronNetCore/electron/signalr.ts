import { HubConnection, HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";
import { app, autoUpdater, BrowserView, BrowserWindow, Menu, NativeImage, WebContents, BrowserViewConstructorOptions, BrowserWindowConstructorOptions, Session } from "electron";
import { LoadURLOptions } from "electron/main";

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

		"BrowserView_Ctor": (options:BrowserViewConstructorOptions) => {
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

		"BrowserWindow_Ctor": (options: BrowserWindowConstructorOptions) => {
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

		"BrowserWindow_GetFocusedWdindow": (_: null) => BrowserWindow.getFocusedWindow()?.id ?? 0,
		"BrowserWindow_FromWebContents": (_: null, webConntents) => BrowserWindow.fromWebContents(webConntents ? WebContents.fromId(webConntents) : null)?.id ?? 0,
		"BrowserWindow_FromBrowserView": (_: null, browserView) => BrowserWindow.fromBrowserView(browserView ? <BrowserView>this.objects[browserView] : null)?.id ?? 0,

		"BrowserWindow_LoadUrl": (id: number, url, options: LoadURLOptions) => {
			const self = BrowserWindow.fromId(id);
			if (options && options.postData) {
				for (const data of options.postData) {
					if (data.type === "rawData") {
						data.bytes = Buffer.from(<any>data.bytes, "base64");
					}
				}
			}
			return self.loadURL(url, options);
		},

		"Function_Invoke": (self: Function, args: any[]) => self(...args),

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
		"Session": true
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
						if (this.trackedTypes[type]) {
							if (!args[1]) {
								args[1] = null;
							} else {
								args[1] = this.objects[args[1]];
							}
						}
					}
	
					let ret = handler(...args.slice(1), args[0]);
					if (ret instanceof Promise) {
						ret = await ret;
					}
					if (ret === undefined) {
						await this.send(`Return`, args[0]);
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
	
						await this.send(`Return_${name}`, args[0], ret);
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

		app.on("will-finish-launching", async () => {
			await this.send("App_WillFinishLaunching_Event");
		})

		app.on("ready", async (_, launchInfo) => {
			await this.send("App_Ready_Event", launchInfo);
		});

		app.on("window-all-closed", async () => {
			await this.send("App_WindowAllClosed_Event");
		});

		app.on("before-quit", async e => {
			if (this.appBeforeQuitPreventDefault) {
				e.preventDefault();
			}
			await this.send("App_BeforeQuit_Event");
		});

		app.on("will-quit", async e => {
			if (this.appWillQuitPreventDefault) {
				e.preventDefault();
			}
			await this.send("App_WillQuit_Event");
		});

		app.on("quit", async (_, exitCode) => {
			await this.send("App_Quit_Event", exitCode);
		});

		app.on("open-file", async (e, path) => {
			if (this.appOpenFilePreventDefault) {
				e.preventDefault();
			}
			await this.send("App_OpenFile_Event", path);
		});

		app.on("open-url", async (e, url) => {
			if (this.appOpenUrlPreventDefault) {
				e.preventDefault();
			}
			await this.send("App_OpenUrl_Event", url);
		});

		app.on("activate", async (_, hasVisibleWindows) => {
			await this.send("App_Activate_Event", hasVisibleWindows);
		});

		app.on("did-become-active", async _ => {
			await this.send("App_DidBecomeActive_Event");
		});

		app.on("continue-activity", async (e, type, userInfo) => {
			if (this.appContinueActivityPreventDefault) {
				e.preventDefault();
			}

			await this.send("App_ContinueActivity_Event", type, userInfo);
		});

		app.on("will-continue-activity", async (e, type) => {
			if (this.appWillContinueActivityPreventDefault) {
				e.preventDefault();
			}

			await this.send("App_WillContinueActivity_Event", type);
		});

		app.on("continue-activity-error", async (_, type, error) => {
			await this.send("App_ContinueActivityError_Event", type, error);
		});

		app.on("activity-was-continued", async (_, type, userInfo) => {
			await this.send("App_ActivityWasContinued_Event", type, userInfo);
		});

		app.on("update-activity-state", async (e, type, userInfo) => {
			if (this.appUpdateActivityStatePreventDefault) {
				e.preventDefault();
			}

			await this.send("App_UpdateActivityState_Event", type, userInfo);
		});

		app.on("new-window-for-tab", async _ => {
			await this.send("App_NewWindowForTab_Event");
		});

		app.on("browser-window-blur", async (_, window) => {
			await this.send("App_BrowserWindowBlur_Event", window.id);
		});

		app.on("browser-window-focus", async (_, window) => {
			await this.send("App_BrowserWindowFocus_Event", window.id);
		});

		app.on("browser-window-created", async (_, window) => {
			const id = window.id;
			window.on("page-title-updated", async (e, title, explicitSet) => {
				if (this.browserWindowPageTitleUpdatedPreventDefault[id]) {
					e.preventDefault();
				}

				await this.send("BrowserWindow_PageTitleUpdated_Event", id, title, explicitSet);
			});

			window.on("close", async e => {
				if (this.browserWindowClosePreventDefault[id]) {
					e.preventDefault();
				}

				await this.send("BrowserWindow_Close_Event", id);
			});

			window.on("closed", async () => {
				delete this.browserWindowPageTitleUpdatedPreventDefault[id];
				delete this.browserWindowClosePreventDefault[id];
				delete this.browserWindowWillResizePreventDefault[id];
				delete this.browserWindowWillMovePreventDefault[id];
				delete this.browserWindowSystemContextMenuPreventDefault[id];
			
				await this.send("BrowserWindow_Closed_Event", id);
			});

			window.on("session-end", async () => {
				await this.send("BrowserWindow_SessionEnd_Event", id);
			});

			window.on("unresponsive", async () => {
				await this.send("BrowserWindow_Unresponsive_Event", id);
			});

			window.on("responsive", async () => {
				await this.send("BrowserWindow_Responsive_Event", id);
			});

			window.on("blur", async () => {
				await this.send("BrowserWindow_Blur_Event", id);
			});

			window.on("focus", async () => {
				await this.send("BrowserWindow_Focus_Event", id);
			});

			window.on("show", async () => {
				await this.send("BrowserWindow_Show_Event", id);
			});

			window.on("hide", async () => {
				await this.send("BrowserWindow_Hide_Event", id);
			});

			window.on("ready-to-show", async () => {
				await this.send("BrowserWindow_ReadyToShow_Event", id);
			});

			window.on("maximize", async () => {
				await this.send("BrowserWindow_Maximize_Event", id);
			});

			window.on("unmaximize", async () => {
				await this.send("BrowserWindow_Unmaximize_Event", id);
			});

			window.on("minimize", async () => {
				await this.send("BrowserWindow_Minimize_Event", id);
			});

			window.on("restore", async () => {
				await this.send("BrowserWindow_Restore_Event", id);
			});

			window.on("will-resize", async (e, newBounds) => {
				if (this.browserWindowWillResizePreventDefault[id]) {
					e.preventDefault();
				}

				await this.send("BrowserWindow_WillResize_Event", id, newBounds);
			});

			window.on("resize", async () => {
				await this.send("BrowserWindow_Resize_Event", id);
			});

			window.on("resized", async () => {
				await this.send("BrowserWindow_Resized_Event", id);
			});

			window.on("will-move", async (e, newBounds) => {
				if (this.browserWindowWillMovePreventDefault[id]) {
					e.preventDefault();
				}

				await this.send("BrowserWindow_WillMove_Event", id, newBounds);
			});

			window.on("move", async () => {
				await this.send("BrowserWindow_Move_Event", id);
			});

			window.on("moved", async () => {
				await this.send("BrowserWindow_Moved_Event", id);
			});

			window.on("enter-full-screen", async () => {
				await this.send("BrowserWindow_EnterFullScreen_Event", id);
			});

			window.on("leave-full-screen", async () => {
				await this.send("BrowserWindow_LeaveFullScreen_Event", id);
			});

			window.on("enter-html-full-screen", async () => {
				await this.send("BrowserWindow_EnterHtmlFullScreen_Event", id);
			});

			window.on("leave-html-full-screen", async () => {
				await this.send("BrowserWindow_LeaveHtmlFullScreen_Event", id);
			});

			window.on("always-on-top-changed", async (_, isAlwaysOnTop) => {
				await this.send("BrowserWindow_AlwaysOnTopChanged_Event", id, isAlwaysOnTop);
			});

			window.on("app-command", async (_, command) => {
				await this.send("BrowserWindow_AppCommand_Event", id, command);
			});

			window.on("scroll-touch-begin", async () => {
				await this.send("BrowserWindow_ScrollTouchBegin_Event", id);
			});

			window.on("scroll-touch-end", async () => {
				await this.send("BrowserWindow_ScrollTouchEnd_Event", id);
			});

			window.on("scroll-touch-edge", async () => {
				await this.send("BrowserWindow_ScrollTouchEdge_Event", id);
			});

			window.on("swipe", async (_, direction) => {
				await this.send("BrowserWindow_Swipe_Event", id, direction);
			});

			window.on("rotate-gesture", async (_, rotation) => {
				await this.send("BrowserWindow_RotateGesture_Event", id, rotation);
			});

			window.on("sheet-begin", async () => {
				await this.send("BrowserWindow_SheetBegin_Event", id);
			});

			window.on("sheet-end", async () => {
				await this.send("BrowserWindow_SheetEnd_Event", id);
			});

			window.on("new-window-for-tab", async () => {
				await this.send("BrowserWindow_NewWindowForTab_Event", id);
			});

			window.on("system-context-menu", async (e, point) => {
				if (this.browserWindowSystemContextMenuPreventDefault[id]) {
					e.preventDefault();
				}

				await this.send("BrowserWindow_SystemContextMenu_Event", id, point);
			});

			await this.send("App_BrowserWindowCreated_Event", id);
		});

		app.on("web-contents-created", async (_, contents) => {
			const id = contents.id;
			contents.on("destroyed", async () => {
				await this.send("WebContents_Destroyed_Event", id);
			});

			await this.send("App_WebContentsCreated_Event", id);
		});

		app.on("certificate-error", async (e, webContents, url, error, certficate, callback) => {
			if (this.appCertificateErrorPreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			await this.send("App_CertificateError_Event", webContents.id, url, error, certficate, id);
		});

		app.on("select-client-certificate", async (e, webContents, url, certificateList, callback) => {
			if (this.appSelectClientCertificatePreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			await this.send("App_SelectClientCertificate_Event", webContents.id, url, certificateList, id);
		});

		app.on("login", async (e, webContents, authenticationResponseDetails, authInfo, callback) => {
			if (this.appLoginPreventDefault) {
				e.preventDefault();
			}

			const id = this.nextGeneratedObjectId++;
			this.objects[id] = callback;
			await this.send("App_Login_Event", webContents.id, authenticationResponseDetails, authInfo, id);
		});

		app.on("gpu-info-update", async () => {
			await this.send("App_GpuInfoUpdate_Event");
		});

		app.on("render-process-gone", async (_, webContents, details) => {
			await this.send("App_RenderProcessGone_Event", webContents.id, details);
		});

		app.on("child-process-gone", async (_, details) => {
			await this.send("App_ChildProcessGone_Event", details);
		});

		app.on("accessibility-support-changed", async (_, accessibilitySupportEnabled) => {
			await this.send("App_AccessibilitySupportChanged_Event", accessibilitySupportEnabled);
		});

		app.on("session-created", async session => {
			const id = this.nextGeneratedObjectId++;
			this.objects[id] = session;
			await this.send("App_SessionCreated_Event", id);
		})

		app.on("second-instance", async (_, argv, workingDirectory) => {
			await this.send("App_SecondInstance_Event", argv, workingDirectory);
		});

		app.on("desktop-capturer-get-sources", async (e, webContents) => {		
			if (this.appDesktopCapturerGetSourcesPreventDefault) {
				e.preventDefault();
			}

			await this.send("App_DesktopCapturerGetSources_Event", webContents.id);
		});

		autoUpdater.on("error", async e => {
			await this.send("AutoUpdater_Error", {
				name: e.name,
				message: e.message,
				stack: e.stack
			});
		});

		autoUpdater.on("checking-for-update", async () => {
			await this.send("AutoUpdater_CheckingForUpdate_Event");
		});

		autoUpdater.on("update-available", async () => {
			await this.send("AutoUpdater_UpdateAvailable_Event");
		});

		autoUpdater.on("update-not-available", async () => {
			await this.send("AutoUpdater_UpdateNotAvailable_Event");
		});

		autoUpdater.on("update-downloaded", async (_, releaseNotes, releaseName, releaseDate, updateUrl) => {
			await this.send("AutoUpdater_UpdateDownloaded_Event", releaseNotes, releaseName, releaseDate.valueOf(), updateUrl);
		});

		autoUpdater.on("before-quit-for-update", async () => {
			await this.send("AutoUpdater_BeforeQuitForUpdate_Event");
		});

		process.on("loaded", async () => {
			await this.send("Process_Loaded_Event");
		})

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