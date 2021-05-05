using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task WebContents_WillNavigate_PreventDefault(int requestId, bool value);
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
		Task WebContents_BeginFrameSubscription(int requestId, int id, bool onlyDirty);
		Task WebContents_EndFrameSubscription(int requestId, int id);
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
		Task WebContents_MainFrame_Get(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task WebContents_DidFinishLoad_Event(int id) =>
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
			WebContents.FromId(id)?.OnWillNavigate(url) ?? Task.CompletedTask;
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
		public Task WebContents_RenderProcessGone_Event(int id, RenderProcessGone details) =>
			WebContents.FromId(id)?.OnRenderProcessGone(details) ?? Task.CompletedTask;
		public Task WebContents_Unresponsive_Event(int id) =>
			WebContents.FromId(id)?.OnUnresponsive() ?? Task.CompletedTask;
		public Task WebContents_Responsive_Event(int id) =>
			WebContents.FromId(id)?.OnResponsive() ?? Task.CompletedTask;
		public Task WebContents_PluginCrashed_Event(int id, string name, string version) =>
			WebContents.FromId(id)?.OnPluginCrashed(name, version) ?? Task.CompletedTask;
		public Task WebContents_Destroyed_Event(int id) =>
			WebContents.FromId(id)?.OnDestroyed() ?? Task.CompletedTask;
		public Task WebContents_BeforeInputEvent_Event(int id, Input input) =>
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
		public Task WebContents_SelectBluetoothDevice_Event(int id, BluetoothDevice[] devices, int callback) =>
			WebContents.FromId(id)?.OnSelectBluetoothDevice(devices, ElectronDisposable.FromId<ElectronFunction<string>>(callback)) ?? Task.CompletedTask;
		public Task WebContents_Paint_Event(int id, Rectangle dirtyRect, int image) =>
			WebContents.FromId(id)?.OnPaint(dirtyRect, ElectronDisposable.FromId<NativeImage>(image)) ?? Task.CompletedTask;
		public Task WebContents_DevtoolsReloadPage_Event(int id) =>
			WebContents.FromId(id)?.OnDevtoolsReloadPage() ?? Task.CompletedTask;
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
			WebContents.OnPrintCallback(id, success, failureReason);
		public Task WebContents_BeginFrameSubscription_Callback(int id, int image, Rectangle dirtyRect) =>
			WebContents.FromId(id)?.OnFrameSubscription(ElectronDisposable.FromId<NativeImage>(image), dirtyRect);

	}
}

namespace MZZT.ElectronNetCore.Api {
	public class WebContents {
		private static readonly Dictionary<int, WebContents> instances = new();

		public static IEnumerable<WebContents> GetAllWebContents() =>
			instances.Values;
		public static Task<WebContents> GetFocusedWebContentsAsync() =>
			Electron.FuncAsync<WebContents, int>(x => x.WebContents_GetFocusedWebContents, 0);
		public static WebContents FromId(int id) =>
			instances.GetValueOrDefault(id);

		internal WebContents(int id) {
			this.Id = id;

			instances[id] = this;
		}

		public event EventHandler DidFinishLoad;
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

		public event EventHandler<WebContentsDidNavigateInPageEventArgs> DidNavigateInPage;
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

		public event EventHandler<RenderProcessGoneEventArgs> RenderProcessGone;
		internal Task OnRenderProcessGone(RenderProcessGone details) {
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
		}

		public event EventHandler Destroyed;
		internal Task OnDestroyed() {
			this.Destroyed?.Invoke(this, new());
			instances.Remove(this.Id);
			return Task.CompletedTask;
		}

		private bool blockPageInputEvents;
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
		internal Task OnSelectBluetoothDevice(BluetoothDevice[] devices, ElectronFunction<string> callback) {
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

		private bool forceDesktopCapturerEmptySources;
		public bool ForceDesktopCapturerEmptySources {
			get => this.forceDesktopCapturerEmptySources;
			set {
				if (this.forceDesktopCapturerEmptySources == value) {
					return;
				}
				this.forceDesktopCapturerEmptySources = value;

				Task.Run(() => ElectronHub.Electron.WebContents_DesktopCapturerGetSources_PreventDefault(0, value));
			}
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
		}

		public Task LoadUrlAsync(string url, LoadUrlOptions options = null) =>
			Electron.ActionAsync(x => x.WebContents_LoadUrl, this.Id, url, options?.ToLoadUrlOptionsDto());
		public Task LoadFileAsync(string filePath, LoadFileOptions options = null) =>
			Electron.ActionAsync(x => x.WebContents_LoadFile, this.Id, filePath, options);
		public Task DownloadUrlAsync(string url) =>
			Electron.ActionAsync(x => x.WebContents_DownloadUrl, this.Id, url);
		public Task<string> GetUrlAsync() =>
			Electron.FuncAsync<string, int>(x => x.WebContents_GetUrl, this.Id);
		public Task<string> GetTitleAsync() =>
			Electron.FuncAsync<string, int>(x => x.WebContents_GetTitle, this.Id);
		public Task<bool> IsDestroyedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsDestroyed, this.Id);
		public Task FocusAsync() =>
			Electron.ActionAsync(x => x.WebContents_Focus, this.Id);
		public Task<bool> IsFocusedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsFocused, this.Id);
		public Task<bool> IsLoadingAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsLoading, this.Id);
		public Task<bool> IsLoadingMainFrameAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsLoadingMainFrame, this.Id);
		public Task<bool> IsWaitingForResponseAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsWaitingForResponse, this.Id);
		public Task StopAsync() =>
			Electron.ActionAsync(x => x.WebContents_Stop, this.Id);
		public Task ReloadAsync() =>
			Electron.ActionAsync(x => x.WebContents_Reload, this.Id);
		public Task ReloadIgnoringCacheAsync() =>
			Electron.ActionAsync(x => x.WebContents_ReloadIgnoringCache, this.Id);
		public Task<bool> CanGoBackAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_CanGoBack, this.Id);
		public Task<bool> CanGoForwardAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_CanGoForward, this.Id);
		public Task<bool> CanGoToOffsetAsync(int offset) =>
			Electron.FuncAsync<bool, int, int>(x => x.WebContents_CanGoToOffset, this.Id, offset);
		public Task ClearHistoryAsync() =>
			Electron.ActionAsync(x => x.WebContents_ClearHistory, this.Id);
		public Task GoBackAsync() =>
			Electron.ActionAsync(x => x.WebContents_GoBack, this.Id);
		public Task GoForwardAsync() =>
			Electron.ActionAsync(x => x.WebContents_GoForward, this.Id);
		public Task GoToIndexAsync(int index) =>
			Electron.ActionAsync(x => x.WebContents_GoToIndex, this.Id, index);
		public Task GoToOffsetAsync(int offset) =>
			Electron.ActionAsync(x => x.WebContents_GoToOffset, this.Id, offset);
		public Task<bool> IsCrashedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsCrashed, this.Id);
		public Task ForcefullyCrashRendererAsync() =>
			Electron.ActionAsync(x => x.WebContents_ForcefullyCrashRenderer, this.Id);
		public Task SetUserAgentAsync(string userAgent) =>
			Electron.ActionAsync(x => x.WebContents_SetUserAgent, this.Id, userAgent);
		public Task<string> GetUserAgentAsync() =>
			Electron.FuncAsync<string, int>(x => x.WebContents_GetUserAgent, this.Id);
		public Task<string> InsertCssAsync(string css, InsertCssOptions options = null) =>
			Electron.FuncAsync<string, int, string, InsertCssOptions>(x => x.WebContents_InsertCss, this.Id, css, options);
		public Task RemoveInsertedCssAsync(string key) =>
			Electron.ActionAsync(x => x.WebContents_RemoveInsertedCss, this.Id, key);
		public Task<T> ExecuteJavascriptAsync<T>(string code, bool userGesture = false) =>
			Electron.FuncAsync<T, int, string, bool>(x => x.WebContents_ExecuteJavaScript, this.Id, code, userGesture);
		public Task ExecuteJavascriptAsync(string code, bool userGesture = false) =>
			Electron.ActionAsync(x => x.WebContents_ExecuteJavaScript, this.Id, code, userGesture);
		public Task<T> ExecuteJavascriptInIsolatedWorldAsync<T>(int worldId, WebSource[] scripts, bool userGesture = false) =>
			Electron.FuncAsync<T, int, int, WebSource[], bool>(x => x.WebContents_ExecuteJavaScriptInIsolatedWorld, this.Id, worldId, scripts, userGesture);
		public Task ExecuteJavascriptInIsolatedWorldAsync(int worldId, WebSource[] scripts, bool userGesture = false) =>
			Electron.ActionAsync(x => x.WebContents_ExecuteJavaScriptInIsolatedWorld, this.Id, worldId, scripts, userGesture);
		public Task SetIgnoreMenuShortcutsAsync(bool ignore) =>
			Electron.ActionAsync(x => x.WebContents_SetIgnoreMenuShortcuts, this.Id, ignore);
		private WebContentsSetWindowOpenHandlerReturnValue windowOpenHandlerReturnValue;
		public WebContentsSetWindowOpenHandlerReturnValue WindowOpenHandlerReturnValue {
			get => this.windowOpenHandlerReturnValue;
			set {
				if (this.windowOpenHandlerReturnValue == value) {
					return;
				}
				this.windowOpenHandlerReturnValue = value;

				Task.Run(() => ElectronHub.Electron.WebContents_SetWindowOpenHandler_Return(0, value?.ToWebContentsSetWindowOpenHandlerReturnValueDto()));
			}
		}
		private Action<HandlerDetails> handler;
		internal Task OnWindowOpenHandler(HandlerDetails details) {
			this.handler?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task SetWindowOpenHandlerAsync(Action<HandlerDetails> handler) {
			this.handler = handler;
			return Electron.ActionAsync(x => x.WebContents_SetWindowOpenHandler, this.Id, handler != null);
		}
		public Task SetAudioMutedAsync(bool muted) =>
			Electron.ActionAsync(x => x.WebContents_SetAudioMuted, this.Id, muted);
		public Task<bool> IsAudioMutedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsAudioMuted, this.Id);
		public Task<bool> IsCurrentlyAudibleAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsCurrentlyAudible, this.Id);
		public Task SetZoomFactorAsync(double factor) =>
			Electron.ActionAsync(x => x.WebContents_SetZoomFactor, this.Id, factor);
		public Task<double> GetZoomFactorAsync() =>
			Electron.FuncAsync<double, int>(x => x.WebContents_GetZoomFactor, this.Id);
		public Task SetZoomLevelAsync(int level) =>
			Electron.ActionAsync(x => x.WebContents_SetZoomLevel, this.Id, level);
		public Task<int> GetZoomLevelAsync() =>
			Electron.FuncAsync<int, int>(x => x.WebContents_GetZoomLevel, this.Id);
		public Task SetVisualZoomLevelLimitsAsync(int minimumLevel, int maximumLevel) =>
			Electron.ActionAsync(x => x.WebContents_SetVisualZoomLevelLimits, this.Id, minimumLevel, maximumLevel);
		public Task UndoAsync() =>
			Electron.ActionAsync(x => x.WebContents_Undo, this.Id);
		public Task RedoAsync() =>
			Electron.ActionAsync(x => x.WebContents_Redo, this.Id);
		public Task CutAsync() =>
			Electron.ActionAsync(x => x.WebContents_Cut, this.Id);
		public Task CopyAsync() =>
			Electron.ActionAsync(x => x.WebContents_Copy, this.Id);
		public Task CopyImageAtAsync(int x, int y) =>
			Electron.ActionAsync(x => x.WebContents_CopyImageAt, this.Id, x, y);
		public Task PasteAsync() =>
			Electron.ActionAsync(x => x.WebContents_Paste, this.Id);
		public Task PasteAndMatchStyleAsync() =>
			Electron.ActionAsync(x => x.WebContents_PasteAndMatchStyle, this.Id);
		public Task DeleteAsync() =>
			Electron.ActionAsync(x => x.WebContents_Delete, this.Id);
		public Task SelectAllAsync() =>
			Electron.ActionAsync(x => x.WebContents_SelectAll, this.Id);
		public Task UnselectAsync() =>
			Electron.ActionAsync(x => x.WebContents_Unselect, this.Id);
		public Task ReplaceAsync(string text) =>
			Electron.ActionAsync(x => x.WebContents_Replace, this.Id, text);
		public Task ReplaceMisspellingAsync(string text) =>
			Electron.ActionAsync(x => x.WebContents_ReplaceMisspelling, this.Id, text);
		public Task InsertTextAsync(string text) =>
			Electron.ActionAsync(x => x.WebContents_InsertText, this.Id, text);
		public Task<int> FindInPageAsync(string text, FindInPageOptions options = null) =>
			Electron.FuncAsync<int, int, string, FindInPageOptions>(x => x.WebContents_FindInPage, this.Id, text, options);
		public Task StopFindInPageAsync(string action) =>
			Electron.ActionAsync(x => x.WebContents_StopFindInPage, this.Id, action);
		public Task<NativeImage> CapturePageAsync(Rectangle rect = null) =>
			Electron.FuncAsync<NativeImage, int, Rectangle>(x => x.WebContents_CapturePage, this.Id, rect);
		public Task<bool> IsBeingCapturedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsBeingCaptured, this.Id);
		public Task IncrementCapturerCountAsync(Size size = null, bool stayHidden = false) =>
			Electron.ActionAsync(x => x.WebContents_IncrementCapturerCount, this.Id, size, stayHidden);
		public Task DecrementCapturerCountAsync(bool stayHidden = false) =>
			Electron.ActionAsync(x => x.WebContents_DecrementCapturerCount, this.Id, stayHidden);
		public Task<PrinterInfo[]> GetPrinters() =>
			Electron.FuncAsync<PrinterInfo[], int>(x => x.WebContents_GetPrinters, this.Id);
		private static readonly Dictionary<int, Action<bool, string>> printCallbacks = new();
		internal static Task OnPrintCallback(int requestId, bool success, string failureReason) {
			Action<bool, string> callback = printCallbacks.GetValueOrDefault(requestId);
			callback?.Invoke(success, failureReason);
			printCallbacks.Remove(requestId);
			return Task.CompletedTask;
		}
		public Task PrintAsync(WebContentsPrintOptions options = null, Action<bool, string> callback = null) {
			int requestId = Electron.NextRequestId;
			if (callback != null) {
				printCallbacks[requestId] = callback;
			}
			return Electron.ActionAsync(requestId, x => x.WebContents_Print, this.Id, options);
		}
		public async Task<byte[]> PrintToPdfAsync(PrintToPdfOptions options) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, PrintToPdfOptions>(x => x.WebContents_PrintToPdf, this.Id, options));
		public Task AddWorkSpaceAsync(string path) =>
			Electron.ActionAsync(x => x.WebContents_AddWorkSpace, this.Id, path);
		public Task RemoveWorkSpaceAsync(string path) =>
			Electron.ActionAsync(x => x.WebContents_RemoveWorkSpace, this.Id, path);
		public Task SetDevToolsWebContentsAsync(WebContents devToolsWebContents) =>
			Electron.ActionAsync(x => x.WebContents_SetDevToolsWebContents, this.Id, devToolsWebContents?.Id ?? 0);
		public Task OpenDevToolsAsync(OpenDevToolsOptions options = null) =>
			Electron.ActionAsync(x => x.WebContents_OpenDevTools, this.Id, options);
		public Task CloseDevToolsAsync() =>
			Electron.ActionAsync(x => x.WebContents_CloseDevTools, this.Id);
		public Task<bool> IsDevToolsOpenedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsDevToolsOpened, this.Id);
		public Task<bool> IsDevToolsFocusedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsDevToolsFocused, this.Id);
		public Task ToggleDevToolsAsync() =>
			Electron.ActionAsync(x => x.WebContents_ToggleDevTools, this.Id);
		public Task InspectElementAsync(int x, int y) =>
			Electron.ActionAsync(x => x.WebContents_InspectElement, this.Id, x, y);
		public Task InspectSharedWorkerAsync() =>
			Electron.ActionAsync(x => x.WebContents_InspectSharedWorker, this.Id);
		public Task InspectSharedWorkerByIdAsync(string workerId) =>
			Electron.ActionAsync(x => x.WebContents_InspectSharedWorkerById, this.Id, workerId);
		public Task<SharedWorkerInfo[]> GetAllSharedWorkersAsync() =>
			Electron.FuncAsync<SharedWorkerInfo[], int>(x => x.WebContents_GetAllSharedWorkers, this.Id);
		public Task InspectServiceWorkerAsync() =>
			Electron.ActionAsync(x => x.WebContents_InspectServiceWorker, this.Id);
		public Task SendAsync(string channel, params object[] args) =>
			Electron.ActionAsync(x => x.WebContents_Send, this.Id, channel, args);
		public Task SendToFrameAsync(int frameId, string channel, params object[] args) =>
			Electron.ActionAsync(x => x.WebContents_SendToFrame, this.Id, frameId, channel, args);
		public Task SendToFrameAsync(int[] frameId, string channel, params object[] args) =>
			Electron.ActionAsync(x => x.WebContents_SendToFrame_OutOfProcess, this.Id, frameId, channel, args);
		public Task PostMessageAsync(string channel, object message, MessagePortMain[] transfer = null) =>
			Electron.ActionAsync(x => x.WebContents_PostMessage, this.Id, channel, message, transfer?.Select(x => x.InternalId).ToArray());
		public Task EnableDeviceEmulationAsync(Parameters parameters) =>
			Electron.ActionAsync(x => x.WebContents_EnableDeviceEmulation, this.Id, parameters);
		public Task DisableDeviceEmulationAsync() =>
			Electron.ActionAsync(x => x.WebContents_DisableDeviceEmulation, this.Id);
		public Task SendInputEventAsync(InputEvent inputEvent) =>
			Electron.ActionAsync(x => x.WebContents_SendInputEvent, this.Id, inputEvent);
		private Action<NativeImage, Rectangle> frameSubscription;
		internal Task OnFrameSubscription(NativeImage image, Rectangle dirtyRect) {
			this.frameSubscription?.Invoke(image, dirtyRect);
			return Task.CompletedTask;
		}
		public Task BeginFrameSubscriptionAsync(Action<NativeImage, Rectangle> callback) =>
			this.BeginFrameSubscriptionAsync(false, callback);
		public Task BeginFrameSubscriptionAsync(bool onlyDirty, Action<NativeImage, Rectangle> callback) {
			this.frameSubscription = callback;
			return Electron.ActionAsync(x => x.WebContents_BeginFrameSubscription, this.Id, onlyDirty);
		}
		public async Task EndFrameSubscriptionAsync() {
			await Electron.ActionAsync(x => x.WebContents_EndFrameSubscription, this.Id);
			this.frameSubscription = null;
		}
		public Task StartDragAsync(Item item) =>
			Electron.ActionAsync(x => x.WebContents_StartDrag, this.Id, item?.ToItemDto());
		public Task SavePageAsync(string fullPath, string saveType) =>
			Electron.ActionAsync(x => x.WebContents_SavePage, this.Id, fullPath, saveType);
		public Task ShowDefinitionForSelectionAsync() =>
			Electron.ActionAsync(x => x.WebContents_ShowDefinitionForSelection, this.Id);
		public Task<bool> IsOffscreenAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsOffscreen, this.Id);
		public Task StartPaintingAsync() =>
			Electron.ActionAsync(x => x.WebContents_StartPainting, this.Id);
		public Task StopPaintingAsync() =>
			Electron.ActionAsync(x => x.WebContents_StopPainting, this.Id);
		public Task<bool> IsPaintingAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_IsPainting, this.Id);
		public Task SetFrameRateAsync(int fps) =>
			Electron.ActionAsync(x => x.WebContents_SetFrameRate, this.Id, fps);
		public Task<int> GetFrameRateAsync() =>
			Electron.FuncAsync<int, int>(x => x.WebContents_GetFrameRate, this.Id);
		public Task InvalidateAsync() =>
			Electron.ActionAsync(x => x.WebContents_Invalidate, this.Id);
		public Task<string> GetWebRtcIpHandlingPolicyAsync() =>
			Electron.FuncAsync<string, int>(x => x.WebContents_GetWebRtcIpHandlingPolicy, this.Id);
		public Task SetWebRtcIpHandlingPolicyAsync(string policy) =>
			Electron.ActionAsync(x => x.WebContents_SetWebRtcIpHandlingPolicy, this.Id, policy);
		public Task<int> GetOsProcessIdAsync() =>
			Electron.FuncAsync<int, int>(x => x.WebContents_GetOsProcessId, this.Id);
		public Task<int> GetProcessIdAsync() =>
			Electron.FuncAsync<int, int>(x => x.WebContents_GetProcessId, this.Id);
		public Task TakeHeapSnapshotAsync(string filePath) =>
			Electron.ActionAsync(x => x.WebContents_TakeHeapSnapshot, this.Id, filePath);
		public Task<bool> GetBackgroundThrottlingAsync() =>
			Electron.FuncAsync<bool, int>(x => x.WebContents_GetBackgroundThrottling, this.Id);
		public Task SetBackgroundThrottlingAsync(bool allowed) =>
			Electron.ActionAsync(x => x.WebContents_SetBackgroundThrottling, this.Id, allowed);
		public Task<string> GetTypeAsync() =>
			Electron.FuncAsync<string, int>(x => x.WebContents_GetType, this.Id);

		private ElectronInstanceProperty<bool> audioMuted;
		public ElectronInstanceProperty<bool> AudioMuted {
			get {
				if (this.audioMuted == null) {
					this.audioMuted = new(this.Id, x => x.WebContents_AudioMuted_Get,
						x => x.WebContents_AudioMuted_Set);
				}
				return this.audioMuted;
			}
		}
		private ElectronInstanceProperty<string> userAgent;
		public ElectronInstanceProperty<string> UserAgent {
			get {
				if (this.userAgent == null) {
					this.userAgent = new(this.Id, x => x.WebContents_UserAgent_Get,
						x => x.WebContents_UserAgent_Set);
				}
				return this.userAgent;
			}
		}
		private ElectronInstanceProperty<int> zoomLevel;
		public ElectronInstanceProperty<int> ZoomLevel {
			get {
				if (this.zoomLevel == null) {
					this.zoomLevel = new(this.Id, x => x.WebContents_ZoomLevel_Get,
						x => x.WebContents_ZoomLevel_Set);
				}
				return this.zoomLevel;
			}
		}
		private ElectronInstanceProperty<double> zoomFactor;
		public ElectronInstanceProperty<double> ZoomFactor {
			get {
				if (this.zoomFactor == null) {
					this.zoomFactor = new(this.Id, x => x.WebContents_ZoomFactor_Get,
						x => x.WebContents_ZoomFactor_Set);
				}
				return this.zoomFactor;
			}
		}
		private ElectronInstanceProperty<int> frameRate;
		public ElectronInstanceProperty<int> FrameRate {
			get {
				if (this.frameRate == null) {
					this.frameRate = new(this.Id, x => x.WebContents_FrameRate_Get,
						x => x.WebContents_ZoomLevel_Set);
				}
				return this.frameRate;
			}
		}
		public int Id { get; }
		private ElectronInstanceReadOnlyProperty<Session> session;
		public ElectronInstanceReadOnlyProperty<Session> Session {
			get {
				if (this.session == null) {
					this.session = new(this.Id, x => x.WebContents_Session_Get);
				}
				return this.session;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebContents> hostWebContents;
		public ElectronInstanceReadOnlyProperty<WebContents> HostWebContents {
			get {
				if (this.hostWebContents == null) {
					this.hostWebContents = new(this.Id, x => x.WebContents_HostWebContents_Get);
				}
				return this.hostWebContents;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebContents> devToolstWebContents;
		public ElectronInstanceReadOnlyProperty<WebContents> DevToolsWebContents {
			get {
				if (this.devToolstWebContents == null) {
					this.devToolstWebContents = new(this.Id, x => x.WebContents_DevToolsWebContents_Get);
				}
				return this.devToolstWebContents;
			}
		}
		private ElectronInstanceReadOnlyProperty<Debugger> debugger;
		public ElectronInstanceReadOnlyProperty<Debugger> Debugger {
			get {
				if (this.debugger == null) {
					this.debugger = new(this.Id, x => x.WebContents_Debugger_Get);
				}
				return this.debugger;
			}
		}
		private ElectronInstanceProperty<bool> backgroundThrottling;
		public ElectronInstanceProperty<bool> BackgroundThrottling {
			get {
				if (this.backgroundThrottling == null) {
					this.backgroundThrottling = new(this.Id, x => x.WebContents_BackgroundThrottling_Get,
						x => x.WebContents_BackgroundThrottling_Set);
				}
				return this.backgroundThrottling;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebFrameMain> mainFrame;
		public ElectronInstanceReadOnlyProperty<WebFrameMain> MainFrame {
			get {
				if (this.mainFrame == null) {
					this.mainFrame = new(this.Id, x => x.WebContents_MainFrame_Get);
				}
				return this.mainFrame;
			}
		}
	}
}
