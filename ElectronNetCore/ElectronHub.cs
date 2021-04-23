using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public interface IElectronInterface {
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

		Task BrowserView_Ctor(int requestId, int id, BrowserViewConstructorOptionsDto options);

		Task BrowserView_WebContents_Get(int requestId, int id);
		Task BrowserView_WebContents_Set(int requestId, int id, int value);

		Task BrowserView_SetAutoResize(int requestId, int id, AutoResizeOptions options);
		Task BrowserView_SetBounds(int requestId, int id, Rectangle bounds);
		Task BrowserView_GetBounds(int requestId, int id);
		Task BrowserView_SetBackgroundColor(int requestId, int id, string color);

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

		Task ContentTracing_GetCategories(int requestId);
		Task ContentTracing_StartRecording_TraceConfig(int requestId, TraceConfig options);
		Task ContentTracing_StartRecording_TraceCategoriesAndOptions(int requestId, TraceCategoriesAndOptions options);
		Task ContentTracing_StopRecording(int requestId, string resultFilePath);
		Task ContentTracing_GetTraceBufferUsage(int requestId);

		Task Dialog_ShowOpenDialog(int requestId, int browserWindow, OpenDialogOptions options);
		Task Dialog_ShowSaveDialog(int requestId, int browserWindow, SaveDialogOptions options);
		Task Dialog_ShowMessageBox(int requestId, int browserWindow, MessageBoxOptionsDto options);
		Task Dialog_ShowErrorBox(int requestId, string title, string content);
		Task Dialog_ShowCertificateTrustDialog(int requestId, int browserWindow, CertificateTrustDialogOptions options);

		Task Function_Invoke(int requestId, int id, object[] args);

		Task GlobalShortcut_Register(int requestId, string accelerator);
		Task GlobalShortcut_RegisterAll(int requestId, string[] accelerators);
		Task GlobalShortcut_IsRegistered(int requestId, string accelerator);
		Task GlobalShortcut_Unregister(int requestId, string accelerator);
		Task GlobalShortcut_UnregisterAll(int requestId);

		Task InAppPurchase_PurchaseProduct(int requestId, string productId, int quantity);
		Task InAppPurchase_GetProducts(int requestId, string[] productIds);
		Task InAppPurchase_CanMakePayments(int requestId);
		Task InAppPurchase_RestoreCompletedTransactions(int requestId);
		Task InAppPurchase_GetReceiptUrl(int requestId);
		Task InAppPurchase_FinishAllTransactions(int requestId);
		Task InAppPurchase_FinishTransactionByDate(int requestId, string date);

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

		public Task Error(int requestId, Error error) =>
			Api.Electron.OnError(requestId, error);
		public Task Return(int requestId, string value) =>
			Api.Electron.OnReturn(requestId, value);

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

		public Task App_MoveToApplicationsFolder_Conflict(int requestId, string conflictType) =>
			Api.Electron.App.OnConflictMoveToApplicationsFolder(requestId, conflictType);

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

		public Task GlobalShortcut_Register_Callback(int requestId) =>
			Api.Electron.GlobalShortcut.OnCallback(requestId) ?? Task.CompletedTask;

		public Task InAppPurchase_TransactionsUpdated_Event(Transaction[] transactions) =>
			Api.Electron.InAppPurchase.OnTransactionsUpdated(transactions);

		public Task Process_Loaded_Event() =>
			Api.Electron.Process.OnLoaded();

		public Task WebContents_Destroyed_Event(int id) =>
			WebContents.FromId(id)?.OnDestroyed() ?? Task.CompletedTask;
	}
}
