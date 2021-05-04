using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		/*Task WebContents_WillNavigate_PreventDefault(int requestId, bool value);
		Task WebContents_WillRedirect_PreventDefault(int requestId, bool value);
		Task WebContents_WillPreventUnload_PreventDefault(int requestId, bool value);
		Task WebContents_BeforeInputEvent_PreventDefault(int requestId, bool value);
		Task WebContents_SelectBluetoothDevice_PreventDefault(int requestId, bool value);
		Task WebContents_WillAttachWebview_PreventDefault(int requestId, bool value);
		Task WebContents_DesktopCapturerGetSources_PreventDefault(int requestId, bool value);
		Task WebContents_SetWindowOpenHandler_Return(int requestId, WebContentsSetWindowOpenHandlerReturnValueDto value);

		Task WebContents_GetFocusedWebContents(int requestId, int id);
		Task WebContents_LoadUrl(int requestId, int id, string url, LoadUrlOptionsDto options);
		Task WebContents_LoadFile(int requestId, int id, string filePath, LoadFileOptions options);
		Task WebContents_DownloadUrl(int requestId, int id, string url);
		Task WebContents_GetUrl(int requestId, int id);
		Task WebContents_GetTitle(int requestId, int id);
		Task WebContents_IsDestroyed(int requestId, int id);
		Task WebContents_Focus(int requestId, int id);
		Task WebContents_IsFocused(int requestId, int id);
		Task WebContents_IsLoading(int requestId, int id);
		Task WebContents_IsLoadingMainFrame(int requestId, int id);
		Task WebContents_IsWaitingForResponse(int requestId, int id);
		Task WebContents_Stop(int requestId, int id);
		Task WebContents_Reload(int requestId, int id);
		Task WebContents_ReloadIgnoringCache(int requestId, int id);
		Task WebContents_CanGoBack(int requestId, int id);
		Task WebContents_CanGoForward(int requestId, int id);
		Task WebContents_CanGoToOffset(int requestId, int id, int index);
		Task WebContents_ClearHistory(int requestId, int id);
		Task WebContents_GoBack(int requestId, int id);
		Task WebContents_GoForward(int requestId, int id);
		Task WebContents_GoToIndex(int requestId, int id, int index);
		Task WebContents_GoToOffset(int requestId, int id, int offset);
		Task WebContents_IsCrashed(int requestId, int id);
		Task WebContents_ForcefullyCrashRenderer(int requestId, int id);
		Task WebContents_SetUserAgent(int requestId, int id, string userAgent);
		Task WebContents_GetUserAgent(int requestId, int id);
		Task WebContents_InsertCss(int requestId, int id, string css, InsertCssOptions options);
		Task WebContents_RemoveInsertedCss(int requestId, int id, string key);
		Task WebContents_ExecuteJavaScript(int requestId, int id, string code, bool userGesture);
		Task WebContents_ExecuteJavaScriptInIsolatedWorld(int requestId, int id, int worldId, WebSource[] scripts, bool userGesture);
		Task WebContents_SetIgnoreMenuShortcuts(int requestId, int id, bool ignore);
		Task WebContents_SetWindowOpenHandler(int requestId, int id, bool value);
		Task WebContents_SetAudioMuted(int requestId, int id, bool muted);
		Task WebContents_IsAudioMuted(int requestId, int id);
		Task WebContents_IsCurrentlyAudible(int requestId, int id);
		Task WebContents_SetZoomFactor(int requestId, int id, double factor);
		Task WebContents_GetZoomFactor(int requestId, int id);
		Task WebContents_SetZoomLevel(int requestId, int id, int level);
		Task WebContents_GetZoomLevel(int requestId, int id);
		Task WebContents_SetVisualZoomLevelLimits(int requestId, int id, int minimumLevel, int maximumLevel);
		Task WebContents_Undo(int requestId, int id);
		Task WebContents_Redo(int requestId, int id);
		Task WebContents_Cut(int requestId, int id);
		Task WebContents_Copy(int requestId, int id);
		Task WebContents_CopyImageAt(int requestId, int id, int x, int y);
		Task WebContents_Paste(int requestId, int id);
		Task WebContents_PasteAndMatchStyle(int requestId, int id);
		Task WebContents_Delete(int requestId, int id);
		Task WebContents_SelectAll(int requestId, int id);
		Task WebContents_Unselect(int requestId, int id);
		Task WebContents_Replace(int requestId, int id, string text);
		Task WebContents_ReplaceMisspelling(int requestId, int id, string text);
		Task WebContents_InsertText(int requestId, int id, string text);
		Task WebContents_FindInPage(int requestId, int id, string text, FindInPageOptions options);
		Task WebContents_StopFindInPage(int requestId, int id, string action);
		Task WebContents_CapturePage(int requestId, int id, Rectangle rect);
		Task WebContents_IsBeingCaptured(int requestId, int id);
		Task WebContents_IncrementCapturerCount(int requestId, int id, Size size, bool stayHidden);
		Task WebContents_DecrementCapturerCount(int requestId, int id, bool stayHidden);
		Task WebContents_GetPrinters(int requestId, int id);
		Task WebContents_Print(int requestId, int id, WebContentsPrintOptions options);
		Task WebContents_PrintToPdf(int requestId, int id, PrintToPdfOptions options);
		Task WebContents_AddWorkSpace(int requestId, int id, string path);
		Task WebContents_RemoveWorkSpace(int requestId, int id, string path);
		Task WebContents_SetDevToolsWebContents(int requestId, int id, int devToolsWebContents);
		Task WebContents_OpenDevTools(int requestId, int id, OpenDevToolsOptions options);
		Task WebContents_CloseDevTools(int requestId, int id);
		Task WebContents_IsDevToolsOpened(int requestId, int id);
		Task WebContents_IsDevToolsFocused(int requestId, int id);
		Task WebContents_ToggleDevTools(int requestId, int id);
		Task WebContents_InspectElement(int requestId, int id, int x, int y);
		Task WebContents_InspectSharedWorker(int requestId, int id);
		Task WebContents_InspectSharedWorkerById(int requestId, int id, string workerId);
		Task WebContents_GetAllSharedWorkers(int requestId, int id);
		Task WebContents_InspectServiceWorker(int requestId, int id);
		Task WebContents_Send(int requestId, int id, string channel, object[] args);
		Task WebContents_SendToFrame(int requestId, int id, int frameId, string channel, object[] args);
		Task WebContents_SendToFrame_OutOfProcess(int requestId, int id, int[] frameId, string channel, object[] args);
		Task WebContents_PostMessage(int requestId, int id, string channel, object message, int[] transfer);
		Task WebContents_EnableDeviceEmulation(int requestId, int id, Parameters parameters);
		Task WebContents_DisableDeviceEmulation(int requestId, int id);
		Task WebContents_SendInputEvent(int requestId, int id, InputEvent inputEvent);
		Task WebContents_BeginFrameSubstitution(int requestId, int id, bool onlyDirty);
		Task WebContents_EndFrameSubstitution(int requestId, int id);
		Task WebContents_StartDrag(int requestId, int id, ItemDto item);
		Task WebContents_SavePage(int requestId, int id, string fullPath, string saveType);
		Task WebContents_ShowDefinitionForSelection(int requestId, int id);
		Task WebContents_IsOffscreen(int requestId, int id);
		Task WebContents_StartPainting(int requestId, int id);
		Task WebContents_StopPainting(int requestId, int id);
		Task WebContents_IsPainting(int requestId, int id);
		Task WebContents_SetFrameRate(int requestId, int id, int fps);
		Task WebContents_GetFrameRate(int requestId, int id);
		Task WebContents_Invalidate(int requestId, int id);
		Task WebContents_GetWebRtcIpHandlingPolicy(int requestId, int id);
		Task WebContents_SetWebRtcIpHandlingPolicy(int requestId, int id, string policy);
		Task WebContents_GetOsProcessId(int requestId, int id);
		Task WebContents_GetProcessId(int requestId, int id);
		Task WebContents_TakeHeapSnapshot(int requestId, int id, string filePath);
		Task WebContents_GetBackgroundThrottling(int requestId, int id);
		Task WebContents_SetBackgroundThrottling(int requestId, int id, bool allowed);
		Task WebContents_GetType(int requestId, int id);

		Task WebContents_AudioMuted_Get(int requestId, int id);
		Task WebContents_AudioMuted_Set(int requestId, int id, bool value);
		Task WebContents_UserAgent_Get(int requestId, int id);
		Task WebContents_UserAgent_Set(int requestId, int id, string value);
		Task WebContents_ZoomLevel_Get(int requestId, int id);
		Task WebContents_ZoomLevel_Set(int requestId, int id, int value);
		Task WebContents_ZoomFactor_Get(int requestId, int id);
		Task WebContents_ZoomFactor_Set(int requestId, int id, double value);
		Task WebContents_FrameRate_Get(int requestId, int id);
		Task WebContents_FrameRate_Set(int requestId, int id, int value);
		Task WebContents_Session_Get(int requestId, int id);
		Task WebContents_HostWebContents_Get(int requestId, int id);
		Task WebContents_DevToolsWebContents_Get(int requestId, int id);
		Task WebContents_Debugger_Get(int requestId, int id);
		Task WebContents_BackgroundThrottling_Get(int requestId, int id);
		Task WebContents_BackgroundThrottling_Set(int requestId, int id, bool value);
		Task WebContents_MainFrame_Get(int requestId, int id);*/
	}

	internal partial class ElectronHub {
		/*public Task WebContents_DidFinishLoad_Event(int id) =>
			WebContents.FromId(id)?.OnDidFinishLoad() ?? Task.CompletedTask;
		public Task WebContents_DidFailLoad_Event(int id, int errorCode, string errorDescription, string validatedUrl, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidFailLoad(errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidFailProvisionalLoad_Event(int id, int errorCode, string errorDescription, string validatedUrl, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidFailProvisionalLoad(errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidFrameFinishLoad_Event(int id, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidFrameFinishLoad(isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidStartLoading_Event(int id) =>
			WebContents.FromId(id)?.OnDidStartLoading() ?? Task.CompletedTask;
		public Task WebContents_DidStopLoading_Event(int id) =>
			WebContents.FromId(id)?.OnDidStopLoading() ?? Task.CompletedTask;
		public Task WebContents_DomReady_Event(int id) =>
			WebContents.FromId(id)?.OnDomReady() ?? Task.CompletedTask;
		public Task WebContents_PageTitleUpdated_Event(int id, string title, bool explicitSet) =>
			WebContents.FromId(id)?.OnPageTitleUpdated(title, explicitSet) ?? Task.CompletedTask;
		public Task WebContents_PageFaviconUpdated_Event(int id, string[] favicons) =>
			WebContents.FromId(id)?.OnPageFaviconUpdated(favicons) ?? Task.CompletedTask;
		public Task WebContents_DidCreateWindow_Event(int id, int window, DidCreateWindowDetailsDto details) =>
			WebContents.FromId(id)?.OnDidCreateWindow(BrowserWindow.FromId(window), details?.ToDidCreateWindowDetails()) ?? Task.CompletedTask;
		public Task WebContents_WillNavigate_Event(int id, string url) =>
			WebContents.FromId(id)?.OnWillNavigate(ur) ?? Task.CompletedTask;
		public Task WebContents_DidStartNavigation_Event(int id, string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidStartNavigation(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_WillRedirect_Event(int id, string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnWillRedirect(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidRedirectNavigation_Event(int id, string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidRedirectNavigation(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidNavigate_Event(int id, string url, int httpResponseCode, string httpStatusText) =>
			WebContents.FromId(id)?.OnDidNavigate(url, httpResponseCode, httpStatusText) ?? Task.CompletedTask;
		public Task WebContents_DidFrameNavigate_Event(int id, string url, int httpResponseCode, string httpStatusText, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidFrameNavigate(url, httpResponseCode, httpStatusText, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_DidNavigateInPage_Event(int id, string url, bool isMainFrame, int frameProcessId, int frameRoutingId) =>
			WebContents.FromId(id)?.OnDidNavigateInPage(url, isMainFrame, frameProcessId, frameRoutingId) ?? Task.CompletedTask;
		public Task WebContents_WillPreventUnload_Event(int id) =>
			WebContents.FromId(id)?.OnWillPreventUnload() ?? Task.CompletedTask;
		public Task WebContents_RenderProcessGone_Event(int id, RenderProcessGoneDetails details) =>
			WebContents.FromId(id)?.OnRenderProcessGone(details) ?? Task.CompletedTask;
		public Task WebContents_Unresponsive_Event(int id) =>
			WebContents.FromId(id)?.OnUnresponsive() ?? Task.CompletedTask;
		public Task WebContents_Responsive_Event(int id) =>
			WebContents.FromId(id)?.OnResponsive() ?? Task.CompletedTask;
		public Task WebContents_PluginCrashed_Event(int id, string name, string version) =>
			WebContents.FromId(id)?.OnPluginCrashed(name, version) ?? Task.CompletedTask;*/
		public Task WebContents_Destroyed_Event(int id) =>
			WebContents.FromId(id)?.OnDestroyed() ?? Task.CompletedTask;
		/*public Task WebContents_BeforeInputEvent_Event(int id, Input input) =>
			WebContents.FromId(id)?.OnBeforeInputEvent(input) ?? Task.CompletedTask;
		public Task WebContents_EnterHtmlFullScreen_Event(int id) =>
			WebContents.FromId(id)?.OnEnterHtmlFullScreen() ?? Task.CompletedTask;
		public Task WebContents_LeaveHtmlFullScreen_Event(int id) =>
			WebContents.FromId(id)?.OnLeaveHtmlFullScreen() ?? Task.CompletedTask;
		public Task WebContents_ZoomChanged_Event(int id, string zoomDirection) =>
			WebContents.FromId(id)?.OnZoomChanged(zoomDirection) ?? Task.CompletedTask;
		public Task WebContents_DevtoolsOpened_Event(int id) =>
			WebContents.FromId(id)?.OnDevtoolsOpened() ?? Task.CompletedTask;
		public Task WebContents_DevtoolsClosed_Event(int id) =>
			WebContents.FromId(id)?.OnDevtoolsClosed() ?? Task.CompletedTask;
		public Task WebContents_DevtoolsFocused_Event(int id) =>
			WebContents.FromId(id)?.OnDevtoolsFocused() ?? Task.CompletedTask;
		public Task WebContents_CertificateError_Event(int id, string url, string error, Certificate certificate, int callback) =>
			WebContents.FromId(id)?.OnCertificateError(url, error, certificate, ElectronDisposable.FromId<ElectronFunction<bool>>(callback)) ?? Task.CompletedTask;
		public Task WebContents_SelectClientCertificate_Event(int id, string url, Certificate[] certificateList, int callback) =>
			WebContents.FromId(id)?.OnSelectClientCertificate(url, certificateList, ElectronDisposable.FromId<ElectronFunction<Certificate>>(callback)) ?? Task.CompletedTask;
		public Task WebContents_Login_Event(int id, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, int callback) =>
			WebContents.FromId(id)?.OnLogin(authenticationResponseDetails, authInfo, ElectronDisposable.FromId<ElectronFunction<string, string>>(callback)) ?? Task.CompletedTask;
		public Task WebContents_FoundInPage_Event(int id, Result result) =>
			WebContents.FromId(id)?.OnFoundInPage(result) ?? Task.CompletedTask;
		public Task WebContents_MediaStartedPlaying_Event(int id) =>
			WebContents.FromId(id)?.OnMediaStartedPlaying() ?? Task.CompletedTask;
		public Task WebContents_MediaPaused_Event(int id) =>
			WebContents.FromId(id)?.OnMediaPaused() ?? Task.CompletedTask;
		public Task WebContents_DidChangeThemeColor_Event(int id, string color) =>
			WebContents.FromId(id)?.OnDidChangeThemeColor(color) ?? Task.CompletedTask;
		public Task WebContents_UpdateTargetUrl_Event(int id, string url) =>
			WebContents.FromId(id)?.OnUpdateTargetUrl(url) ?? Task.CompletedTask;
		public Task WebContents_CursorChanged_Event(int id, string type, int image, double scale, Size size, Point hotspot) =>
			WebContents.FromId(id)?.OnCursorChanged(type, ElectronDisposable.FromId<NativeImage>(image), scale, size, hotspot) ?? Task.CompletedTask;
		public Task WebContents_ContextMenu_Event(int id, ContextMenuParams @params) =>
			WebContents.FromId(id)?.OnContextMenu(@params) ?? Task.CompletedTask;
		public Task WebContents_SelectBluetoothDevice_Event(int id, BlueToothDevice[] devices, int callback) =>
			WebContents.FromId(id)?.OnSelectBluetoothDevice(id, devices, ElectronDisposable.FromId<ElectronFunction<string>>(callback)) ?? Task.CompletedTask;
		public Task WebContents_Paint_Event(int id, Rectangle dirtyRect, int image) =>
			WebContents.FromId(id)?.OnPaint(dirtyRect, ElectronDisposable.FromId<NativeImage>(image)) ?? Task.CompletedTask;
		public Task WebContents_DevtoolsReloadPage_Event(int id) =>
			WebContents.FromId(id)?.OnDevtoolsReloadPage(id) ?? Task.CompletedTask;
		public Task WebContents_WillAttachWebview_Event(int id, WebPreferencesDto webPreferences, Dictionary<string, string> @params) =>
			WebContents.FromId(id)?.OnWillAttachWebview(webPreferences?.ToWebPreferences(), @params) ?? Task.CompletedTask;
		public Task WebContents_DidAttachWebview_Event(int id, int webContents) =>
			WebContents.FromId(id)?.OnDidAttachWebview(WebContents.FromId(webContents)) ?? Task.CompletedTask;
		public Task WebContents_ConsoleMessage_Event(int id, int level, string message, int line, string sourceId) =>
			WebContents.FromId(id)?.OnConsoleMessage(level, message, line, sourceId) ?? Task.CompletedTask;
		public Task WebContents_PreloadError_Event(int id, string preloadPath, Error error) =>
			WebContents.FromId(id)?.OnPreloadError(preloadPath, error) ?? Task.CompletedTask;
		public Task WebContents_IpcMessage_Event(int id, string channel, object[] args) =>
			WebContents.FromId(id)?.OnIpcMessage(channel, args) ?? Task.CompletedTask;
		public Task WebContents_IpcMessageSync_Event(int id, string channel, object[] args) =>
			WebContents.FromId(id)?.OnIpcMessageSync(channel, args) ?? Task.CompletedTask;
		public Task WebContents_DesktopCapturerGetSources_Event(int id) =>
			WebContents.FromId(id)?.OnDesktopCapturerGetSources() ?? Task.CompletedTask;
		public Task WebContents_PreferredSizeChanged_Event(int id, Size preferredSize) =>
			WebContents.FromId(id)?.OnPreferredSizeChanged(preferredSize) ?? Task.CompletedTask;

		public Task WebContents_SetWindowOpenHandler_Callback(int id, HandlerDetails details) =>
			WebContents.FromId(id)?.OnWindowOpenHandler(details);
		public Task WebContents_Print_Callback(int id, bool success, string failureReason) =>
			WebContents.OnPrintCallback(id, success, failureReason);*/
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class WebContents {
		private static readonly Dictionary<int, WebContents> instances = new();

		public static IEnumerable<WebContents> GetAllWebContents() =>
			instances.Values;
		/*public static Task<WebContents> GetFocusedWebContentsAsync() =>
			Electron.FuncAsync<WebContents, int>(x => x.WebContents_GetFocusedWebContents, 0);*/
		public static WebContents FromId(int id) =>
			instances.GetValueOrDefault(id);

		internal WebContents(int id) {
			this.Id = id;

			instances[id] = this;
		}
		public int Id { get; }

		/*public event EventHandler DidFinishLoad;
		internal Task OnDidFinishLoad() {
			this.DidFinishLoad?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsFailLoadEventArgs> DidFailLoad;
		internal Task OnDidFailLoad(int errorCode, string errorDescription, string validatedUrl, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidFailLoad?.Invoke(this, new(errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsFailLoadEventArgs> DidFailProvisionalLoad;
		internal Task OnDidFailProvisionalLoad(int errorCode, string errorDescription, string validatedUrl, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidFailProvisionalLoad?.Invoke(this, new(errorCode, errorDescription, validatedUrl, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsFrameEventArgs> DidFrameFinishLoad;
		internal Task OnDidFrameFinishLoad(bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidFrameFinishLoad?.Invoke(this, new(isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler DidStartLoading;
		internal Task OnDidStartLoading() {
			this.DidStartLoading?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DidStopLoading;
		internal Task OnDidStopLoading() {
			this.DidStopLoading?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DomReady;
		internal Task OnDomReady() {
			this.DomReady?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<PageTitleUpdatedEventArgs> PageTitleUpdated;
		internal Task OnPageTitleUpdated(string title, bool explicitset) {
			this.PageTitleUpdated?.Invoke(this, new(title, explicitset));
			return Task.CompletedTask;
		}

		public event EventHandler<FaviconsEventArgs> PageFaviconUpdated;
		internal Task OnPageFaviconUpdated(string[] favicons) {
			this.PageFaviconUpdated?.Invoke(this, new(favicons));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsDidCreateWindowEventArgs> DidCreateWindow;
		internal Task OnDidCreateWindow(BrowserWindow window, DidCreateWindowDetails details) {
			this.DidCreateWindow?.Invoke(this, new(window, details));
			return Task.CompletedTask;
		}

		private bool blockNavigation;
		public bool BlockNavigation {
			get => this.blockNavigation;
			set {
				if (this.blockNavigation == value) {
					return;
				}
				this.blockNavigation = value;

				Task.Run(() => ElectronHub.Electron.WebContents_WillNavigate_PreventDefault(0, value));
			}
		}

		public event EventHandler<UrlEventArgs> WillNavigate;
		internal Task OnWillNavigate(string url) {
			this.WillNavigate?.Invoke(this, new(url));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsNavigationEventArgs> DidStartNavigation;
		internal Task OnDidStartNavigation(string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidStartNavigation?.Invoke(this, new(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		private bool blockRedirect;
		public bool BlockRedirect {
			get => this.blockRedirect;
			set {
				if (this.blockRedirect == value) {
					return;
				}
				this.blockRedirect = value;

				Task.Run(() => ElectronHub.Electron.WebContents_WillRedirect_PreventDefault(0, value));
			}
		}

		public event EventHandler<WebContentsNavigationEventArgs> WillRedirect;
		internal Task OnWillRedirect(string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.WillRedirect?.Invoke(this, new(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsNavigationEventArgs> DidRedirectNavigation;
		internal Task OnDidRedirectNavigation(string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidRedirectNavigation?.Invoke(this, new(url, isInPlace, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsDidNavigateEventArgs> DidNavigate;
		internal Task OnDidNavigate(string url, int httpResponseCode, string httpStatusText) {
			this.DidNavigate?.Invoke(this, new(url, httpResponseCode, httpStatusText));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsDidFrameNavigateEventArgs> DidFrameNavigate;
		internal Task OnDidFrameNavigate(string url, int httpResponseCode, string httpStatusText, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidFrameNavigate?.Invoke(this, new(url, httpResponseCode, httpStatusText, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsNavigationEventArgs> DidNavigateInPage;
		internal Task OnDidNavigateInPage(string url, bool isMainFrame, int frameProcessId, int frameRoutingId) {
			this.DidNavigateInPage?.Invoke(this, new(url, isMainFrame, frameProcessId, frameRoutingId));
			return Task.CompletedTask;
		}

		private bool skipBeforeUnload;
		public bool SkipBeforeUnload {
			get => this.skipBeforeUnload;
			set {
				if (this.skipBeforeUnload == value) {
					return;
				}
				this.skipBeforeUnload = value;

				Task.Run(() => ElectronHub.Electron.WebContents_WillPreventUnload_PreventDefault(0, value));
			}
		}

		public event EventHandler WillPreventUnload;
		internal Task OnWillPreventUnload() {
			this.WillPreventUnload?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<RenderProcessGoneDetailsEventArgs> RenderProcessGone;
		internal Task OnRenderProcessGone(RenderProcessGoneDetails details) {
			this.RenderProcessGone?.Invoke(this, new(details));
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

		public event EventHandler<WebContentsPluginCrashedEventArgs> PluginCrashed;
		internal Task OnPluginCrashed(string name, string version) {
			this.PluginCrashed?.Invoke(this, new(name, version));
			return Task.CompletedTask;
		}*/

		public event EventHandler Destroyed;
		internal Task OnDestroyed() {
			this.Destroyed?.Invoke(this, new());
			instances.Remove(this.Id);
			return Task.CompletedTask;
		}

		/*private bool blockPageInputEvents;
		public bool BlockPageInputEvents {
			get => this.blockPageInputEvents;
			set {
				if (this.blockPageInputEvents == value) {
					return;
				}
				this.blockPageInputEvents = value;

				Task.Run(() => ElectronHub.Electron.WebContents_BeforeInputEvent_PreventDefault(0, value));
			}
		}

		public event EventHandler<InputEventArgs> BeforeInputEvent;
		internal Task OnBeforeInputEvent(Input input) {
			this.BeforeInputEvent?.Invoke(this, new(input));
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

		public event EventHandler<ZoomDirectionEventArgs> ZoomChanged;
		internal Task OnZoomChanged(string zoomDirection) {
			this.ZoomChanged?.Invoke(this, new(zoomDirection));
			return Task.CompletedTask;
		}

		public event EventHandler DevtoolsOpened;
		internal Task OnDevtoolsOpened() {
			this.DevtoolsOpened?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DevtoolsClosed;
		internal Task OnDevtoolsClosed() {
			this.DevtoolsClosed?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DevtoolsFocused;
		internal Task OnDevtoolsFocused() {
			this.DevtoolsFocused?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<CertificateErrorEventArgs> CertificateError;
		internal Task OnCertificateError(string url, string error, Certificate certificate, ElectronFunction<bool> callback) {
			this.CertificateError?.Invoke(this, new(url, error, certificate, callback));
			return Task.CompletedTask;
		}

		public event EventHandler<SelectClientCertificateEventArgs> SelectClientCertificate;
		internal Task OnSelectClientCertificate(string url, Certificate[] certificateList, ElectronFunction<Certificate> callback) {
			this.SelectClientCertificate?.Invoke(this, new(url, certificateList, callback));
			return Task.CompletedTask;
		}

		public event EventHandler<LoginEventArgs> Login;
		internal Task OnLogin(AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, ElectronFunction<string, string> callback) {
			this.Login?.Invoke(this, new(authenticationResponseDetails, authInfo, callback));
			return Task.CompletedTask;
		}

		public event EventHandler<FoundInPageEventArgs> FoundInPage;
		internal Task OnFoundInPage(Result result) {
			this.FoundInPage?.Invoke(this, new(result));
			return Task.CompletedTask;
		}

		public event EventHandler MediaStartedPlaying;
		internal Task OnMediaStartedPlaying() {
			this.MediaStartedPlaying?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler MediaPaused;
		internal Task OnMediaPaused() {
			this.MediaPaused?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<ColorEventArgs> DidChangeThemeColor;
		internal Task OnDidChangeThemeColor(string color) {
			this.DidChangeThemeColor?.Invoke(this, new(color));
			return Task.CompletedTask;
		}

		public event EventHandler<UrlEventArgs> UpdateTargetUrl;
		internal Task OnUpdateTargetUrl(string url) {
			this.UpdateTargetUrl?.Invoke(this, new(url));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsCursorChangedEventArgs> CursorChanged;
		internal Task OnCursorChanged(string type, NativeImage image, double scale, Size size, Point hotspot) {
			this.CursorChanged?.Invoke(this, new(type, image, scale, size, hotspot));
			return Task.CompletedTask;
		}

		public event EventHandler<ContextMenuParamsEventArgs> ContextMenu;
		internal Task OnContextMenu(ContextMenuParams @params) {
			this.ContextMenu?.Invoke(this, new(@params));
			return Task.CompletedTask;
		}

		private bool allowBluetoothDeviceSelect;
		public bool AllowBluetoothDeviceSelect {
			get => this.allowBluetoothDeviceSelect;
			set {
				if (this.allowBluetoothDeviceSelect == value) {
					return;
				}
				this.allowBluetoothDeviceSelect = value;

				Task.Run(() => ElectronHub.Electron.WebContents_SelectBluetoothDevice_PreventDefault(0, value));
			}
		}

		public event EventHandler<WebContentsSelectBluetoothDeviceEventArgs> SelectBluetoothDevice;
		internal Task OnSelectBluetoothDevice(BlueToothDevice[] devices, ElectronFunction<string> callback) {
			this.SelectBluetoothDevice?.Invoke(this, new(devices, callback));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsPaintEventArgs> Paint;
		internal Task OnPaint(Rectangle dirtyRect, NativeImage image) {
			this.Paint?.Invoke(this, new(dirtyRect, image));
			return Task.CompletedTask;
		}

		public event EventHandler DevtoolsReloadPage;
		internal Task OnDevtoolsReloadPage() {
			this.DevtoolsReloadPage?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool blockAttachingWebviews;
		public bool BlockAttachingWebviews {
			get => this.blockAttachingWebviews;
			set {
				if (this.blockAttachingWebviews == value) {
					return;
				}
				this.blockAttachingWebviews = value;

				Task.Run(() => ElectronHub.Electron.WebContents_WillAttachWebview_PreventDefault(0, value));
			}
		}

		public event EventHandler<WebContentsWillAttachWebviewEventArgs> WillAttachWebview;
		internal Task OnWillAttachWebview(WebPreferences webPreferences, Dictionary<string, string> @params) {
			this.WillAttachWebview?.Invoke(this, new(webPreferences, @params));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsEventArgs> DidAttachWebview;
		internal Task OnDidAttachWebview(WebContents webContents) {
			this.DidAttachWebview?.Invoke(this, new(webContents));
			return Task.CompletedTask;
		}

		public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
		internal Task OnConsoleMessage(int level, string message, int line, string sourceId) {
			this.ConsoleMessage?.Invoke(this, new(level, message, line, sourceId));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsPreloadErrorEventArgs> PreloadError;
		internal Task OnPreloadError(string preloadPath, Error error) {
			this.PreloadError?.Invoke(this, new(preloadPath, error));
			return Task.CompletedTask;
		}

		public event EventHandler<IpcMessageEventArgs> IpcMessage;
		internal Task OnIpcMessage(string channel, object[] args) {
			this.IpcMessage?.Invoke(this, new(channel, args));
			return Task.CompletedTask;
		}

		public event EventHandler<IpcMessageEventArgs> IpcMessageSync;
		internal Task OnIpcMessageSync(string channel, object[] args) {
			this.IpcMessageSync?.Invoke(this, new(channel, args));
			return Task.CompletedTask;
		}

		public event EventHandler DesktopCapturerGetSources;
		internal Task OnDesktopCapturerGetSources() {
			this.DesktopCapturerGetSources?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<PreferredSizeEventArgs> PreferredSizeChanged;
		internal Task OnPreferredSizeChanged(Size preferredSize) {
			this.PreferredSizeChanged?.Invoke(this, new(preferredSize));
			return Task.CompletedTask;
		}*/


	}
}
