import { app, BrowserWindow, BrowserWindowConstructorOptions, Item, LoadURLOptions, MessagePortMain,
	NativeImage, PrintToPDFOptions, Session, WebContents, WebContentsPrintOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

const willNavigatePreventDefault: Record<number, true> = {};
const willRedirectPreventDefault: Record<number, true> = {};
const willPreventUnloadPreventDefault: Record<number, true> = {};
const beforeInputEventPreventDefault: Record<number, true> = {};
const selectBluetoothDevicePreventDefault: Record<number, true> = {};
const willAttachWebviewPreventDefault: Record<number, true> = {};
const desktopCapturerGetSourcesPreventDefault: Record<number, true> = {};
const setWindowOpenHandlerReturn: Record<number, { action: "deny"; } | { action: "allow"; overrideBrowserWindowOptions?: BrowserWindowConstructorOptions; }> = {};

let api: SignalRApi;
export const ElectronWebContents : ElectronApi = {
	type: "WebContents",
	instanceOf: x => x?.constructor?.name === "WebContents",
	fromId: x => WebContents.fromId(x),
	toId: (x: WebContents) => x.id,
	init: x => {
		api = x;

		app.on("web-contents-created", (_, contents) => {
			const id = contents.id;
			contents.on("did-finish-load", () => 
				api.send("DidFinishLoad_Event", id));

			contents.on("did-fail-load", (_, errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidFailLoad_Event", id, errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("did-fail-provisional-load", (_, errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidFailProvisionalLoad_Event", id, errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("did-frame-finish-load", (_, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidFrameFinishLoad_Event", id, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("did-start-loading", () => 
				api.send("DidStartLoading_Event", id));

			contents.on("did-stop-loading", () => 
				api.send("DidStopLoading_Event", id));

			contents.on("dom-ready", _ => 
				api.send("DomReady_Event", id));

			contents.on("page-title-updated", (_, title, explicitSet) => 
				api.send("PageTitleUpdated_Event", id, title, explicitSet));

			contents.on("page-favicon-updated", (_, favicons) => 
				api.send("PageFaviconUpdated_Event", id, favicons));

			contents.on("did-create-window", (window, details) => {
				if (details.options) {
					if (details.options.icon) {
						if (details.options.icon?.constructor?.name === "NativeImage") {
							(<any>details.options).iconImage = api.store(details.options.icon);
						} else {
							(<any>details.options).iconPath = details.options.icon;
						}
						delete details.options.icon;
					}
					if (details.options.parent) {
						(<any>details.options).parent = details.options.parent.id;
					}	
					if (details.options.webPreferences) {
						(<any>details.options.webPreferences).session = api.store(details.options.webPreferences.session);
					}
				}
				return api.send("DidCreateWindow_Event", id, window?.id ?? 0, details);
			});

			contents.on("will-navigate", (e, url) => {
				if (willNavigatePreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("WillNavigate_Event", id, url);
			});

			contents.on("did-start-navigation", (_, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidStartNavigation_Event", id, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("will-redirect", (e, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) => {
				if (willRedirectPreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("WillRedirect_Event", id, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId);
			});

			contents.on("did-redirect-navigation", (_, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidRedirectNavigation_Event", id, url, isInPlace, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("did-navigate", (_, url, httpResponseCode, httpStatusText) => 
				api.send("DidNavigate_Event", id, url, httpResponseCode, httpStatusText));

			contents.on("did-frame-navigate", (_, url, httpResponseCode, httpStatusText, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidFrameNavigate_Event", id, url, httpResponseCode, httpStatusText, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("did-navigate-in-page", (_, url, isMainFrame, frameProcessId, frameRoutingId) => 
				api.send("DidNavigateInPage_Event", id, url, isMainFrame, frameProcessId, frameRoutingId));

			contents.on("will-prevent-unload", e => {
				if (willPreventUnloadPreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("WillPreventUnload_Event", id);
			});

			contents.on("render-process-gone", (_, details) => 
				api.send("RenderProcessGone_Event", id, details));

			contents.on("unresponsive", () => 
				api.send("Unresponsive_Event", id));

			contents.on("responsive", () => 
				api.send("Responsive_Event", id));

			contents.on("plugin-crashed", (_, name, version) => 
				api.send("PluginCrashed_Event", id, name, version));

			contents.on("destroyed", () => {
				delete willNavigatePreventDefault[id];
				delete willRedirectPreventDefault[id];
				delete willPreventUnloadPreventDefault[id];
				delete beforeInputEventPreventDefault[id];
				delete selectBluetoothDevicePreventDefault[id];
				delete willAttachWebviewPreventDefault[id];
				delete desktopCapturerGetSourcesPreventDefault[id];
				delete setWindowOpenHandlerReturn[id];

				return api.send("Destroyed_Event", id);
			});

			contents.on("before-input-event", (e, input) => {
				if (beforeInputEventPreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("BeforeInputEvent_Event", input);
			});
			
			contents.on("enter-html-full-screen", () => 
				api.send("EnterHtmlFullScreen_Event", id));

			contents.on("leave-html-full-screen", () => 
				api.send("LeaveHtmlFullScreen_Event", id));

			contents.on("zoom-changed", (_, zoomDirection) => 
				api.send("ZoomChanged_Event", id, zoomDirection));

			contents.on("devtools-opened", () => 
				api.send("DevtoolsOpened_Event", id));

			contents.on("devtools-closed", () => 
				api.send("DevtoolsClosed_Event", id));

			contents.on("devtools-focused", () => 
				api.send("DevtoolsFocused_Event", id));
			
			contents.on("certificate-error", (_, url, error, certificate, callback) =>
				api.send("CertificateError_Event", id, url, error, certificate, api.store(callback)));

			contents.on("select-client-certificate", (_, url, certificateList, callback) =>
				api.send("SelectClientCertificate_Event", id, url, certificateList, api.store(callback)));

			contents.on("login", (_, authenticationResponseDetails, authInfo, callback) =>
				api.send("Login_Event", id, authenticationResponseDetails, authInfo, api.store(callback)));

			contents.on("found-in-page", (_, result) =>
				api.send("FoundInPage_Event", id, result));

			contents.on("media-started-playing", () => 
				api.send("MediaStartedPlaying_Event", id));

			contents.on("media-paused", () => 
				api.send("MediaPaused_Event", id));

			contents.on("did-change-theme-color", (_, color) => 
				api.send("DidChangeThemeColor_Event", id, color));

			contents.on("update-target-url", (_, url) => 
				api.send("UpdateTargetUrl_Event", id, url));

			contents.on("cursor-changed", (_, type, image, scale, size, hotspot) => 
				api.send("CursorChanged_Event", id, type, api.store(image), scale, size, hotspot));

			contents.on("context-menu", (_, params) => 
				api.send("ContextMenu_Event", id, params));

			contents.on("select-bluetooth-device", (e, devices, callback) => {
				if (selectBluetoothDevicePreventDefault[id]) {
					e.preventDefault();
				}

				return api.send("SelectBluetoothDevice_Event", devices, api.store(callback));
			});

			contents.on("paint", (_, dirtyRect, image) =>
				api.send("Paint_Event", dirtyRect, api.store(image)));

			contents.on("devtools-reload-page", () =>
				api.send("DevtoolsReloadPage_Event"));

			contents.on("will-attach-webview", (e, webPreferences, params) => {
				if (willAttachWebviewPreventDefault[id]) {
					e.preventDefault();
				}

				if (webPreferences) {
					webPreferences.session = <any>api.store(webPreferences.session);
				}

				return api.send("WillAttachWebview_Event", webPreferences, params);
			});

			contents.on("did-attach-webview", (_, webContents) => 
				api.send("DidAttachWebview_Event", webContents?.id ?? 0));

			contents.on("console-message", (_, level, message, line, sourceId) =>
				api.send("ConsoleMessage_Event", level, message, line, sourceId));

			contents.on("preload-error", (_, preloadPath, error) =>
				api.send("PreloadError_Event", preloadPath, {
					name: error.name,
					message: error.message,
					stack: error.stack
				}));
			
			contents.on("ipc-message", (_, channel, ...args) => 
				api.send("IpcMessage_Event", channel, args));
			
			contents.on("ipc-message-sync", (_, channel, ...args) => 
				api.send("IpcMessageSync_Event", channel, args));
			
			contents.on("desktop-capturer-get-sources", e => {
				if (desktopCapturerGetSourcesPreventDefault[id]) {
					e.preventDefault();
				}

				api.send("DesktopCapturerGetSources_Event");
			});

			contents.on("preferred-size-changed", (_, preferredSize) =>
				api.send("PreferredSizeChanged_Event", preferredSize));
		});
	},
	handlers: {
		"WillNavigate_PreventDefault": (self: WebContents, value) => { willNavigatePreventDefault[self.id] = value; },
		"WillRedirect_PreventDefault": (self: WebContents, value) => { willRedirectPreventDefault[self.id] = value; },
		"WillPreventUnload_PreventDefault": (self: WebContents, value) => { willPreventUnloadPreventDefault[self.id] = value; },
		"BeforeInputEvent_PreventDefault": (self: WebContents, value) => { beforeInputEventPreventDefault[self.id] = value; },
		"SelectBluetoothDevice_PreventDefault": (self: WebContents, value) => { selectBluetoothDevicePreventDefault[self.id] = value; },
		"WillAttachWebview_PreventDefault": (self: WebContents, value) => { willAttachWebviewPreventDefault[self.id] = value; },
		"DesktopCapturerGetSources_PreventDefault": (self: WebContents, value) => { desktopCapturerGetSourcesPreventDefault[self.id] = value; },
		"SetWindowOpenHandler_Return": (self: WebContents, value: { action: "deny"; } | { action: "allow"; overrideBrowserWindowOptions?: BrowserWindowConstructorOptions; }) => {
			if (value && value.action === "allow" && value.overrideBrowserWindowOptions) {
				if ((<any>value.overrideBrowserWindowOptions).iconImage) {
					value.overrideBrowserWindowOptions.icon = api.get<NativeImage>((<any>value.overrideBrowserWindowOptions).iconImage);
					delete (<any>value.overrideBrowserWindowOptions).iconImage;
				} else if ((<any>value.overrideBrowserWindowOptions).iconPath) {
					value.overrideBrowserWindowOptions.icon = (<any>value.overrideBrowserWindowOptions).iconPath;
					delete (<any>value.overrideBrowserWindowOptions).iconPath;
				}
				if (value.overrideBrowserWindowOptions.parent) {
					value.overrideBrowserWindowOptions.parent = BrowserWindow.fromId(<any>value.overrideBrowserWindowOptions.parent);
				} else {
					value.overrideBrowserWindowOptions.parent = null;
				}	
				if (value.overrideBrowserWindowOptions.webPreferences) {
					value.overrideBrowserWindowOptions.webPreferences.session = api.get<Session>(<any>value.overrideBrowserWindowOptions.webPreferences.session);
				}
			}
			setWindowOpenHandlerReturn[self.id] = value;
		},

		"GetFocusedWebContents": (_: null) => WebContents.getFocusedWebContents(),

		"LoadUrl": (self: WebContents, url, options: LoadURLOptions) => {
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
		"LoadFile": (self: WebContents, filePath, options) => self.loadFile(filePath, options),
		"DownloadUrl": (self: WebContents, url) => self.downloadURL(url),
		"GetUrl": (self: WebContents) => self.getURL(),
		"GetTitle": (self: WebContents) => self.getTitle(),
		"IsDestroyed": (self: WebContents) => self.isDestroyed(),
		"Focus": (self: WebContents) => self.focus(),
		"IsFocused": (self: WebContents) => self.isFocused(),
		"IsLoading": (self: WebContents) => self.isLoading(),
		"IsLoadingMainFrame": (self: WebContents) => self.isLoadingMainFrame(),
		"IsWaitingForResponse": (self: WebContents) => self.isWaitingForResponse(),
		"Stop": (self: WebContents) => self.stop(),
		"Reload": (self: WebContents) => self.reload(),
		"ReloadIgnoringCache": (self: WebContents) => self.reloadIgnoringCache(),
		"CanGoBack": (self: WebContents) => self.canGoBack(),
		"CanGoForward": (self: WebContents) => self.canGoForward(),
		"CanGoToOffset": (self: WebContents, index) => self.canGoToOffset(index),
		"ClearHistory": (self: WebContents) => self.clearHistory(),
		"GoBack": (self: WebContents) => self.goBack(),
		"GoForward": (self: WebContents) => self.goForward(),
		"GoToIndex": (self: WebContents, index) => self.goToIndex(index),
		"GoToOffset": (self: WebContents, offset) => self.goToOffset(offset),
		"IsCrashed": (self: WebContents) => self.isCrashed(),
		"ForcefullyCrashRenderer": (self: WebContents) => self.forcefullyCrashRenderer(),
		"SetUserAgent": (self: WebContents, userAgent) => self.setUserAgent(userAgent),
		"GetUserAgent": (self: WebContents) => self.getUserAgent(),
		"InsertCss": (self: WebContents, css, options) => self.insertCSS(css, options),
		"RemoveInsertedCss": (self: WebContents, key) => self.removeInsertedCSS(key),
		"ExecuteJavaScript": (self: WebContents, code, userGesture) => self.executeJavaScript(code, userGesture),
		"ExecuteJavaScriptInIsolatedWorld": (self: WebContents, worldId, scripts, userGesture) => self.executeJavaScriptInIsolatedWorld(worldId, scripts, userGesture),
		"SetIgnoreMenuShortcuts": (self: WebContents, ignore) => self.setIgnoreMenuShortcuts(ignore),
		"SetWindowOpenHandler": (self: WebContents, value) => {
			if (value) {
				self.setWindowOpenHandler(details => {
					api.send("SetWindowOpenHandler_Callback", self.id, details)

					return setWindowOpenHandlerReturn[self.id] ?? {action: "allow"};
				});
			} else {
				self.setWindowOpenHandler(null);
			}
		},
		"SetAudioMuted": (self: WebContents, muted) => self.setAudioMuted(muted),
		"IsAudioMuted": (self: WebContents) => self.isAudioMuted(),
		"IsCurrentlyAudible": (self: WebContents) => self.isCurrentlyAudible(),
		"SetZoomFactor": (self: WebContents, factor) => self.setZoomFactor(factor),
		"GetZoomFactor": (self: WebContents) => self.getZoomFactor(),
		"SetZoomLevel": (self: WebContents, level) => self.setZoomLevel(level),
		"GetZoomLevel": (self: WebContents) => self.getZoomLevel(),
		"SetVisualZoomLevelLimits": (self: WebContents, minimumLevel, maximumLevel) => self.setVisualZoomLevelLimits(minimumLevel, maximumLevel),
		"Undo": (self: WebContents) => self.undo(),
		"Redo": (self: WebContents) => self.redo(),
		"Cut": (self: WebContents) => self.cut(),
		"Copy": (self: WebContents) => self.copy(),
		"CopyImageAt": (self: WebContents, x, y) => self.copyImageAt(x, y),
		"Paste": (self: WebContents) => self.paste(),
		"PasteAndMatchStyle": (self: WebContents) => self.pasteAndMatchStyle(),
		"Delete": (self: WebContents) => self.delete(),
		"SelectAll": (self: WebContents) => self.selectAll(),
		"Unselect": (self: WebContents) => self.unselect(),
		"Replace": (self: WebContents, text) => self.replace(text),
		"ReplaceMisspelling": (self: WebContents, text) => self.replaceMisspelling(text),
		"InsertText": (self: WebContents, text) => self.insertText(text),
		"FindInPage": (self: WebContents, text, options) => self.findInPage(text, options),
		"StopFindInPage": (self: WebContents, action) => self.stopFindInPage(action),
		"CapturePage": (self: WebContents, rect) => self.capturePage(rect),
		"IsBeingCaptured": (self: WebContents) => self.isBeingCaptured(),
		"IncrementCapturerCount": (self: WebContents, size, stayHidden) => self.incrementCapturerCount(size, stayHidden),
		"DecrementCapturerCount": (self: WebContents, stayHidden) => self.decrementCapturerCount(stayHidden),
		"GetPrinters": (self: WebContents) => self.getPrinters(),
		"Print": (self: WebContents, options: WebContentsPrintOptions, id) => {
			if (options) {
				if ((<any>options).pageSizeSize) {
					options.pageSize = (<any>options).pageSizeSize;
					delete (<any>options).pageSizeSize;
				} else if ((<any>options).pageSizeString) {
					options.pageSize = (<any>options).pageSizeString;
					delete (<any>options).pageSizeString;
				}
			}
			return self.print(options, (success, failureReason) => 
			api.send("Print_Callback", id, success, failureReason));
		},
		"PrintToPdf": async (self: WebContents, options: PrintToPDFOptions) => {
			if (options) {
				if ((<any>options).pageSizeSize) {
					options.pageSize = (<any>options).pageSizeSize;
					delete (<any>options).pageSizeSize;
				} else if ((<any>options).pageSizeString) {
					options.pageSize = (<any>options).pageSizeString;
					delete (<any>options).pageSizeString;
				}
			}
			const buffer = await self.printToPDF(options);
			return buffer.toString("base64");
		},
		"AddWorkSpace": (self: WebContents, path) => self.addWorkSpace(path),
		"RemoveWorkSpace": (self: WebContents, path) => self.removeWorkSpace(path),
		"SetDevToolsWebContents": (self: WebContents, devToolsWebContents) => self.setDevToolsWebContents(api.get<WebContents>(devToolsWebContents)),
		"OpenDevTools": (self: WebContents, options) => self.openDevTools(options),
		"CloseDevTools": (self: WebContents) => self.closeDevTools(),
		"IsDevToolsOpened": (self: WebContents) => self.isDevToolsOpened(),
		"IsDevToolsFocused": (self: WebContents) => self.isDevToolsFocused(),
		"ToggleDevTools": (self: WebContents) => self.toggleDevTools(),
		"InspectElement": (self: WebContents, x, y) => self.inspectElement(x, y),
		"InspectSharedWorker": (self: WebContents) => self.inspectSharedWorker(),
		"InspectSharedWorkerById": (self: WebContents, workerId) => self.inspectSharedWorkerById(workerId),
		"GetAllSharedWorkers": (self: WebContents) => self.getAllSharedWorkers(),
		"InspectServiceWorker": (self: WebContents) => self.inspectServiceWorker(),
		"Send": (self: WebContents, channel, args) => self.send(channel, ...args),
		"SendToFrame": (self: WebContents, frameId, channel, args) => self.sendToFrame(frameId, channel, ...args),
		"SendToFrame_OutOfProcess": (self: WebContents, frameId, channel, args) => self.sendToFrame(frameId, channel, ...args),
		"PostMessage": (self: WebContents, channel, message, transfer: number[]) => self.postMessage(channel, message, transfer?.map(x => api.get<MessagePortMain>(x))),
		"EnableDeviceEmulation": (self: WebContents, parameters) => self.enableDeviceEmulation(parameters),
		"DisableDeviceEmulation": (self: WebContents) => self.disableDeviceEmulation(),
		"SendInputEvent": (self: WebContents, inputEvent) => self.sendInputEvent(inputEvent),
		"BeginFrameSubstitution": (self: WebContents, onlyDirty) => self.beginFrameSubscription(onlyDirty, (image, dirtyRect) =>
			api.send("BeginFrameSubstitution_Callback", self.id, api.store(image), dirtyRect)),
		"EndFrameSubstitution": (self: WebContents) => self.endFrameSubscription(),
		"StartDrag": (self: WebContents, item: Item) => {
			if (item) {
				if ((<any>item).iconImage) {
					item.icon = api.get<NativeImage>((<any>item).iconImage);
					delete (<any>item).iconImage;
				} else if ((<any>item).iconPath) {
					item.icon = (<any>item).iconPath;
					delete (<any>item).iconPath;
				}
			}
			return self.startDrag(item);
		},
		"SavePage": (self: WebContents, fullPath, saveType) => self.savePage(fullPath, saveType),
		"ShowDefinitionForSelection": (self: WebContents) => self.showDefinitionForSelection(),
		"IsOffscreen": (self: WebContents) => self.isOffscreen(),
		"StartPainting": (self: WebContents) => self.startPainting(),
		"StopPainting": (self: WebContents) => self.stopPainting(),
		"IsPainting": (self: WebContents) => self.isPainting(),
		"SetFrameRate": (self: WebContents, fps) => self.setFrameRate(fps),
		"GetFrameRate": (self: WebContents) => self.getFrameRate(),
		"Invalidate": (self: WebContents) => self.invalidate(),
		"GetWebRtcIpHandlingPolicy": (self: WebContents) => self.getWebRTCIPHandlingPolicy(),
		"SetWebRtcIpHandlingPolicy": (self: WebContents, policy) => self.setWebRTCIPHandlingPolicy(policy),
		"GetOsProcessId": (self: WebContents) => self.getOSProcessId(),
		"GetProcessId": (self: WebContents) => self.getProcessId(),
		"TakeHeapSnapshot": (self: WebContents, filePath) => self.takeHeapSnapshot(filePath),
		"GetBackgroundThrottling": (self: WebContents) => self.getBackgroundThrottling(),
		"SetBackgroundThrottling": (self: WebContents, allowed) => self.setBackgroundThrottling(allowed),
		"GetType": (self: WebContents) => self.getType(),

		"AudioMuted_Get": (self: WebContents) => self.audioMuted,
		"AudioMuted_Set": (self: WebContents, value) => { self.audioMuted = value; },
		"UserAgent_Get": (self: WebContents) => self.userAgent,
		"UserAgent_Set": (self: WebContents, value) => { self.userAgent = value; },
		"ZoomLevel_Get": (self: WebContents) => self.zoomLevel,
		"ZoomLevel_Set": (self: WebContents, value) => { self.zoomLevel = value; },
		"ZoomFactor_Get": (self: WebContents) => self.zoomFactor,
		"ZoomFactor_Set": (self: WebContents, value) => { self.zoomFactor = value; },
		"FrameRate_Get": (self: WebContents) => self.frameRate,
		"FrameRate_Set": (self: WebContents, value) => { self.frameRate = value; },
		"Session_Get": (self: WebContents) => api.store(self.session),
		"HostWebContents_Get": (self: WebContents) => api.store(self.hostWebContents),
		"DevToolsWebContents_Get": (self: WebContents) => api.store(self.devToolsWebContents),
		"Debugger_Get": (self: WebContents) => api.store(self.debugger),
		"BackgroundThrottling_Get": (self: WebContents) => self.backgroundThrottling,
		"BackgroundThrottling_Set": (self: WebContents, value) => { self.backgroundThrottling = value; },
		"MainFrame_Get": (self: WebContents) => api.store(self.mainFrame)
	}
};
