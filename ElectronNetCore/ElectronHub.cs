using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	internal interface IElectronInterface {
		Task DisposeObject(int id);

		Task AppCommandLine_AppendSwitch(int requestId, string @switch, string value);
		Task AppCommandLine_AppendArgument(int requestId, string value);
		Task AppCommandLine_HasSwitch(int requestId, string @switch);
		Task AppCommandLine_GetSwitchValue(int requestId, string @switch);

		Task AppDock_Bounce(int requestId, string type);
		Task AppDock_CancelBounce(int requestId, int id);
		Task AppDock_DownloadFinished(int requestId, string filePath);
		Task AppDock_SetBadge(int requestId, string text);
		Task AppDock_GetBadge(int requestId);
		Task AppDock_Hide(int requestId);
		Task AppDock_Show(int requestId);
		Task AppDock_IsVisible(int requestId);
		Task AppDock_SetMenu(int requestId, int menuId);
		Task AppDock_GetMenu(int requestId);
		Task AppDock_SetIconImage(int requestId, int imageId);
		Task AppDock_SetIconPath(int requestId, string image);

		Task App_BeforeQuit_PreventDefault(int requestId, bool value);
		Task App_WillQuit_PreventDefault(int requestId, bool value);
		Task App_OpenFile_PreventDefault(int requestId, bool value);
		Task App_OpenUrl_PreventDefault(int requestId, bool value);
		Task App_ContinueActivity_PreventDefault(int requestId, bool value);
		Task App_WillContinueActivity_PreventDefault(int requestId, bool value);
		Task App_UpdateActivityState_PreventDefault(int requestId, bool value);
		Task App_CertificateError_PreventDefault(int requestId, bool value);
		Task App_SelectClientCertificate_PreventDefault(int requestId, bool value);
		Task App_Login_PreventDefault(int requestId, bool value);
		Task App_DesktopCapturerGetSources_PreventDefault(int requestId, bool value);

		Task App_Quit(int requestId);
		Task App_Exit(int requestId, int exitCode);
		Task App_Relaunch(int requestId, RelaunchOptions options);
		Task App_IsReady(int requestId);
		Task App_WhenReady(int requestId);
		Task App_Focus(int requestId, FocusOptions options);
		Task App_Hide(int requestId);
		Task App_Show(int requestId);
		Task App_SetAppLogsPath(int requestId, string path);
		Task App_GetAppPath(int requestId);
		Task App_GetPath(int requestId, string name);
		Task App_GetFileIcon(int requestId, string path, FileIconOptions options);
		Task App_SetPath(int requestId, string name, string path);
		Task App_GetVersion(int requestId);
		Task App_GetName(int requestId);
		Task App_SetName(int requestId, string name);
		Task App_GetLocale(int requestId);
		Task App_GetLocaleCountryCode(int requestId);
		Task App_AddRecentDocument(int requestId, string path);
		Task App_ClearRecentDocuments(int requestId);
		Task App_SetAsDefaultProtocolClient(int requestId, string protocol, string path, string[] args);
		Task App_RemoveAsDefaultProtocolClient(int requestId, string protocol, string path, string[] args);
		Task App_IsDefaultProtocolClient(int requestId, string protocol, string path, string[] args);
		Task App_GetApplicationNameForProtocol(int requestId, string url);
		Task App_GetApplicationInfoForProtocol(int requestId, string url);
		Task App_SetUserTasks(int requestId, JumpListTask[] tasks);
		Task App_GetJumpListSettings(int requestId);
		Task App_SetJumpList(int requestId, JumpListCategory[] categories);
		Task App_RequestSingleInstanceLock(int requestId);
		Task App_HasSingleInstanceLock(int requestId);
		Task App_ReleaseSingleInstanceLock(int requestId);
		Task App_SetUserActivity(int requestId, string type, object userInfo, string webpageUrl);
		Task App_GetCurrentActivityType(int requestId);
		Task App_InvalidateCurrentActivity(int requestId);
		Task App_ResignCurrentActivity(int requestId);
		Task App_UpdateCurrentActivity(int requestId, string type, object userInfo);
		Task App_SetAppUserModelId(int requestId, string id);
		Task App_SetActivationPolicy(int requestId, string policy);
		Task App_ImportCertificate(int requestId, ImportCertificateOptions options);
		Task App_DisableHardwareAcceleration(int requestId);
		Task App_DisableDomainBlockingFor3dApis(int requestId);
		Task App_GetAppMetrics(int requestId);
		Task App_GetGpuFeatureStatus(int requestId);
		Task App_GetGpuInfo(int requestId, string infoType);
		Task App_SetBadgeCount(int requestId, int? count);
		Task App_GetBadgeCount(int requestId);
		Task App_IsUnityRunning(int requestId);
		Task App_GetLoginItemSettings(int requestId, LoginItemSettingsOptions options);
		Task App_SetLoginItemSettings(int requestId, Settings settings);
		Task App_IsAccessibilitySupportEnabled(int requestId);
		Task App_SetAccessibilitySupportEnabled(int requestId, bool enabled);
		Task App_ShowAboutPanel(int requestId);
		Task App_SetAboutPanelOptions(int requestId, AboutPanelOptionsOptions options);
		Task App_IsEmojiPanelSupported(int requestId);
		Task App_ShowEmojiPanel(int requestId);
		Task App_StartAccessingSecurityScopedResource(int requestId, string bookmarkData);
		Task App_EnableSandbox(int requestId);
		Task App_IsInApplicationsFolder(int requestId);
		Task App_MoveToApplicationsFolder(int requestId);
		Task App_IsSecureKeyboardEntryEnabled(int requestId);
		Task App_SetSecureKeyboardEntryEnabled(int requestId, bool enabled);

		Task App_AccessiiblitySupportEnabled_Get(int requestId);
		Task App_AccessiiblitySupportEnabled_Set(int requestId, bool value);
		Task App_ApplicationMenu_Get(int requestId);
		Task App_ApplicationMenu_Set(int requestId, int id);
		Task App_BadgeCount_Get(int requestId);
		Task App_BadgeCount_Set(int requestId, int value);
		Task App_IsPackaged_Get(int requestId);
		Task App_Name_Get(int requestId);
		Task App_Name_Set(int requestId, string value);
		Task App_UserAgentFallback_Get(int requestId);
		Task App_UserAgentFallback_Set(int requestId, string value);
		Task App_AllowRendererProcessReuse_Get(int requestId);
		Task App_AllowRendererProcessReuse_Set(int requestId, bool value);
		Task App_RunningUnderRosettaTranslation_Get(int requestId);

		Task AutoUpdater_SetFeedUrl(int requestId, FeedUrlOptions options);
		Task AutoUpdater_GetFeedUrl(int requestId);
		Task AutoUpdater_CheckForUpdates(int requestId);
		Task AutoUpdater_QuitAndInstall(int requestId);

		Task BrowserView_Ctor(int requestId, BrowserViewConstructorOptionsInternal options);

		Task BrowserView_WebContents_Get(int requestId, int id);
		Task BrowserView_WebContents_Set(int requestId, int id, int value);

		Task BrowserView_SetAutoResize(int requestId, int id, AutoResizeOptions options);
		Task BrowserView_SetBounds(int requestId, int id, Rectangle bounds);
		Task BrowserView_GetBounds(int requestId, int id);
		Task BrowserView_SetBackgroundColor(int requestId, int id, string color);

		Task BrowserWindow_Ctor(int requestId, BrowserWindowConstructorOptionsInternal options);

		Task BrowserWindow_PageTitleUpdated_PreventDefault(int requestId, bool value);
		Task BrowserWindow_Close_PreventDefault(int requestId, bool value);
		Task BrowserWindow_WillResize_PreventDefault(int requestId, bool value);
		Task BrowserWindow_WillMove_PreventDefault(int requestId, bool value);
		Task BrowserWindow_SystemContextMenu_PreventDefault(int requestId, bool value);

		Task BrowserWindow_GetFocusedWindow(int requestId, int id);
		Task BrowserWindow_FromWebContents(int requestId, int id, int webContents);
		Task BrowserWindow_FromBrowserView(int requestId, int id, int browserView);

		Task Function_Invoke(int requestId, int id, object[] args);

		Task NativeImage_GetSize(int requestId, int id, double scaleFactor);
		Task NativeImage_ToDataUrl(int requestId, int id, ToDataUrlOptions options);

		Task Process_DefaultApp_Get(int requestId);
		Task Process_IsMainFrame_Get(int requestId);
		Task Process_Mas_Get(int requestId);
		Task Process_NoAsar_Get(int requestId);
		Task Process_NoAsar_Set(int requestId, bool value);
		Task Process_NoDeprecation_Get(int requestId);
		Task Process_NoDeprecation_Set(int requestId, bool value);
		Task Process_ResourcesPath_Get(int requestId);
		Task Process_Sandboxed_Get(int requestId);
		Task Process_ThrowDeprecation_Get(int requestId);
		Task Process_ThrowDeprecation_Set(int requestId, bool value);
		Task Process_TraceDeprecation_Get(int requestId);
		Task Process_TraceDeprecation_Set(int requestId, bool value);
		Task Process_TraceProcessWarnings_Get(int requestId);
		Task Process_TraceProcessWarnings_Set(int requestId, bool value);
		Task Process_Type_Get(int requestId);
		Task ProcessVersions_Chrome_Get(int requestId);
		Task ProcessVersions_Electron_Get(int requestId);
		Task Process_WindowsStore_Get(int requestId);

		Task Process_Crash(int requestId);
		Task Process_GetCreationTime(int requestId);
		Task Process_GetCpuUsage(int requestId);
		Task Process_GetIoCounters(int requestId);
		Task Process_GetHeapStatistics(int requestId);
		Task Process_GetBlinkMemoryInfo(int requestId);
		Task Process_GetProcessMemoryInfo(int requestId);
		Task Process_GetSystemMemoryInfo(int requestId);
		Task Process_GetSystemVersion(int requestId);
		Task Process_TakeHeapSnapshot(int requestId, string filePath);
		Task Process_Hang(int requestId);
		Task Process_SetFdLimit(int requestId, int maxDescriptors);
	}

	internal class ElectronHub : Hub<IElectronInterface> {
		private readonly ILogger<ElectronHub> logger;

		public static IElectronInterface Electron { get; private set; }

		public ElectronHub(ILogger<ElectronHub> logger) {
			this.logger = logger;
		}

		public async override Task OnConnectedAsync() {
			await base.OnConnectedAsync();

			this.logger.LogDebug("Electron connected to ASP.NET Core.");

			Electron = this.Clients.Caller;
			//await Electron.AppSetName(0, AppDomain.CurrentDomain.FriendlyName);
		}

		public async override Task OnDisconnectedAsync(Exception exception) {
			await base.OnDisconnectedAsync(exception);

			this.logger.LogDebug("Electron disconnected from ASP.NET Core.");

			Electron = null;
		}

		public Task Return(int requestId) =>
			Api.Electron.Fulfill(requestId);
		public Task Error(int requestId, Error error) =>
			Api.Electron.OnError(requestId, error);

		public Task Return_AppCommandLine_HasSwitch(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_AppCommandLine_GetSwitchValue(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Return_AppDock_Bounce(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_AppDock_GetBadge(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_AppDock_IsVisible(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_AppDock_GetMenu(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, ElectronDisposable.FromId<Menu>(value));

		public Task App_WillFinishLaunching_Event() =>
			Api.Electron.App.OnWillFinishLaunching();
		public Task App_Ready_Event(Dictionary<string, object> launchInfo) =>
			Api.Electron.App.OnReady(launchInfo);
		public Task App_WindowAllClosed_Event() =>
			Api.Electron.App.OnWindowAllClosed();
		public Task App_BeforeQuit_Event() =>
			Api.Electron.App.OnBeforeQuit();
		public Task App_WillQuit_Event() =>
			Api.Electron.App.OnWillQuit();
		public Task App_Quit_Event(int exitCode) =>
			Api.Electron.App.OnQuit(exitCode);
		public Task App_OpenFile_Event(string path) =>
			Api.Electron.App.OnOpenFile(path);
		public Task App_OpenUrl_Event(string url) =>
			Api.Electron.App.OnOpenUrl(url);
		public Task App_Activate_Event(bool hasVisibleWindows) =>
			Api.Electron.App.OnActivate(hasVisibleWindows);
		public Task App_DidBecomeActive_Event() =>
			Api.Electron.App.OnDidBecomeActive();
		public Task App_ContinueActivity_Event(string type, Dictionary<string, object> userInfo) =>
			Api.Electron.App.OnContinueActivity(type, userInfo);
		public Task App_WillContinueActivity_Event(string type) =>
			Api.Electron.App.OnWillContinueActivity(type);
		public Task App_ContinueActivityError_Event(string type, string error) =>
			Api.Electron.App.OnContinueActivityError(type, error);
		public Task App_ActivityWasContinued_Event(string type, Dictionary<string, object> userInfo) =>
			Api.Electron.App.OnActivityWasContinued(type, userInfo);
		public Task App_UpdateActivityState_Event(string type, Dictionary<string, object> userInfo) =>
			Api.Electron.App.OnUpdateActivityState(type, userInfo);
		public Task App_NewWindowForTab_Event() =>
			Api.Electron.App.OnNewWindowForTab();
		public Task App_BrowserWindowBlur_Event(int id) =>
			Api.Electron.App.OnBrowserWindowBlur(id);
		public Task App_BrowserWindowFocus_Event(int id) =>
			Api.Electron.App.OnBrowserWindowFocus(id);
		public Task App_BrowserWindowCreated_Event(int id) =>
			Api.Electron.App.OnBrowserWindowCreated(id);
		public Task App_WebContentsCreated_Event(int id) =>
			Api.Electron.App.OnWebContentsCreated(id);
		public Task App_CertificateError_Event(int webContentsId, string url, string error, Certificate certificate, int functionId) =>
			Api.Electron.App.OnCertificateError(webContentsId, url, error, certificate, functionId);
		public Task App_SelectClientCertificate_Event(int webContentsId, string url, Certificate[] certificateList, int functionId) =>
			Api.Electron.App.OnSelectClientCertificate(webContentsId, url, certificateList, functionId);
		public Task App_Login_Event(int webContentsId, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, int functionId) =>
			Api.Electron.App.OnLogin(webContentsId, authenticationResponseDetails, authInfo, functionId);
		public Task App_GpuInfoUpdate_Event() =>
			Api.Electron.App.OnGpuInfoUpdate();
		public Task App_RenderProcessGone_Event(int id, RenderProcessGone details) =>
			Api.Electron.App.OnRenderProcessGone(id, details);
		public Task App_ChildProcessGone_Event(ChildProcessGone details) =>
			Api.Electron.App.OnChildProcessGone(details);
		public Task App_AccessibilitySupportChanged_Event(bool accessibilitySupportEnabled) =>
			Api.Electron.App.OnAccessibilitySupportChanged(accessibilitySupportEnabled);
		public Task App_SessionCreated_Event(int id) =>
			Api.Electron.App.OnSessionCreated(id);
		public Task App_SecondInstance_Event(string[] argv, string workingDirectory) =>
			Api.Electron.App.OnSecondInstance(argv, workingDirectory);
		public Task App_DesktopCapturerGetSources_Event(int webContentsId) =>
			Api.Electron.App.OnDesktopCapturerGetSources(webContentsId);

		public Task Return_App_IsReady(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetAppPath(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetPath(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetFileIcon(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetVersion(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetName(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetLocale(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetLocaleCountryCode(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_SetAsDefaultProtocolClient(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_RemoveAsDefaultProtocolClient(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsDefaultProtocolClient(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetApplicationNameForProtocol(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetApplicationInfoForProtocol(int requestId, ApplicationInfoForProtocolReturnValueInternal value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_SetUserTasks(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetJumpListSettings(int requestId, JumpListSettings value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_SetJumpList(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_RequestSingleInstanceLock(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_HasSingleInstanceLock(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetCurrentActivityType(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_ImportCertificate(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetAppMetrics(int requestId, ProcessMetric[] value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetGpuFeatureStatus(int requestId, GpuFeatureStatus value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetGpuInfo(int requestId, GpuInfo value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_SetBadgeCount(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetBadgeCount(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsUnityRunning(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_GetLoginItemSettings(int requestId, LoginItemSettings value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsAccessibilitySupportEnabled(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsEmojiPanelSupported(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_StartAccessingSecurityScopedResource(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsInApplicationsFolder(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task<bool> App_MoveToApplicationsFolder_Conflict(int requestId, string conflictType) =>
			Api.Electron.App.OnConflictMoveToApplicationsFolder(requestId, conflictType);
		public Task Return_App_MoveToApplicationsFolder(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsSecureKeyboardEntryEnabled(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Return_App_AccessibilitySupportEnabled_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_ApplicationMenu_Get(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, ElectronDisposable.FromId<Menu>(value));
		public Task Return_App_BadgeCount_Get(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_IsPackaged_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_Name_Get(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_UserAgentFallback_Get(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_AllowRendererProcessReuse_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_App_RunningUnderRosettaTranslation_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task AutoUpdater_Error_Event(Error error) =>
			Api.Electron.AutoUpdater.OnError(error);
		public Task AutoUpdater_CheckingForUpdate_Event() =>
			Api.Electron.AutoUpdater.OnCheckingForUpdate();
		public Task AutoUpdater_UpdateAvailable_Event() =>
			Api.Electron.AutoUpdater.OnUpdateAvailable();
		public Task AutoUpdater_UpdateNotAvailable_Event() =>
			Api.Electron.AutoUpdater.OnUpdateNotAvailable();
		public Task AutoUpdater_UpdateDownloaded_Event(string releaseNotes, string releaseName, double releaseDate, string updateUrl) =>
			Api.Electron.AutoUpdater.OnUpdateDownloaded(releaseNotes, releaseName, DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromMilliseconds(releaseDate), DateTimeKind.Utc), updateUrl);
		public Task AutoUpdater_BeforeQuitForUpdate_Event() =>
			Api.Electron.AutoUpdater.OnBeforeQuitForUpdate();

		public Task Return_AppUpdater_GetFeedUrl(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Return_BrowserView_Ctor(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, ElectronDisposable.FromId<BrowserView>(value));

		public Task Return_BrowserView_WebContents_Get(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, WebContents.FromId(value));
		public Task Return_BrowserView_GetBounds(int requestId, Rectangle value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Return_BrowserWindow_Ctor(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, BrowserWindow.FromId(value));

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

		public Task Return_BrowserWindow_GetFocusedWindow(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, BrowserWindow.FromId(value));
		public Task Return_BrowserWindow_FromWebContents(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, BrowserWindow.FromId(value));
		public Task Return_BrowserWindow_FromBrowserView(int requestId, int value) =>
			Api.Electron.Fulfill(requestId, BrowserWindow.FromId(value));

		public Task Return_NativeImage_GetSize(int requestId, Size value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_NativeImage_ToDataUrl(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Process_Loaded_Event() =>
			Api.Electron.Process.OnLoaded();

		public Task Return_Process_DefaultApp_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_IsMainFrame_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_Mas_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_NoAsar_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_NoDeprecation_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_ResourcesPath_Get(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_Sandboxed_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_ThrowDeprecation_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_TraceDeprecation_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_TraceProcessWarnings_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_Type_Get(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_ProcessVersions_Chrome_Get(int requestId, string version) =>
			Api.Electron.Fulfill(requestId, version);
		public Task Return_ProcessVersions_Electron_Get(int requestId, string version) =>
			Api.Electron.Fulfill(requestId, version);
		public Task Return_Process_WindowsStore_Get(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task Return_Process_GetCreationTime(int requestId, double? value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetCpuUsage(int requestId, CpuUsage value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetIoCounters(int requestId, IoCounters value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetHeapStatistics(int requestId, HeapStatistics value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetBlinkMemoryInfo(int requestId, BlinkMemoryInfo value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetProcessMemoryInfo(int requestId, ProcessMemoryInfo value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetSystemMemoryInfo(int requestId, SystemMemoryInfo value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_GetSystemVersion(int requestId, string value) =>
			Api.Electron.Fulfill(requestId, value);
		public Task Return_Process_TakeHeapSnapshot(int requestId, bool value) =>
			Api.Electron.Fulfill(requestId, value);

		public Task WebContents_Destroyed_Event(int id) =>
			WebContents.FromId(id)?.OnDestroyed() ?? Task.CompletedTask;
	}
}
