using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
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
	}

	internal partial class ElectronHub {
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
		public Task App_BrowserWindowBlur_Event(int window) =>
			Api.Electron.App.OnBrowserWindowBlur(BrowserWindow.FromId(window));
		public Task App_BrowserWindowFocus_Event(int window) =>
			Api.Electron.App.OnBrowserWindowFocus(BrowserWindow.FromId(window));
		public Task App_BrowserWindowCreated_Event(int window) =>
			Api.Electron.App.OnBrowserWindowCreated(new BrowserWindow(window));
		public Task App_WebContentsCreated_Event(int webContents) =>
			Api.Electron.App.OnWebContentsCreated(new WebContents(webContents));
		public Task App_CertificateError_Event(int webContents, string url, string error, Certificate certificate, int callback) =>
			Api.Electron.App.OnCertificateError(WebContents.FromId(webContents), url, error, certificate, ElectronDisposable.FromId<ElectronFunction<bool>>(callback));
		public Task App_SelectClientCertificate_Event(int webContents, string url, Certificate[] certificateList, int callback) =>
			Api.Electron.App.OnSelectClientCertificate(WebContents.FromId(webContents), url, certificateList, ElectronDisposable.FromId<ElectronFunction<Certificate>>(callback));
		public Task App_Login_Event(int webContents, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, int callback) =>
			Api.Electron.App.OnLogin(WebContents.FromId(webContents), authenticationResponseDetails, authInfo, ElectronDisposable.FromId<ElectronFunction<string, string>>(callback));
		public Task App_GpuInfoUpdate_Event() =>
			Api.Electron.App.OnGpuInfoUpdate();
		public Task App_RenderProcessGone_Event(int webContents, RenderProcessGone details) =>
			Api.Electron.App.OnRenderProcessGone(WebContents.FromId(webContents), details);
		public Task App_ChildProcessGone_Event(ChildProcessGone details) =>
			Api.Electron.App.OnChildProcessGone(details);
		public Task App_AccessibilitySupportChanged_Event(bool accessibilitySupportEnabled) =>
			Api.Electron.App.OnAccessibilitySupportChanged(accessibilitySupportEnabled);
		public Task App_SessionCreated_Event(int session) =>
			Api.Electron.App.OnSessionCreated(ElectronDisposable.FromId<Session>(session));
		public Task App_SecondInstance_Event(string[] argv, string workingDirectory) =>
			Api.Electron.App.OnSecondInstance(argv, workingDirectory);
		public Task App_DesktopCapturerGetSources_Event(int webContents) =>
			Api.Electron.App.OnDesktopCapturerGetSources(WebContents.FromId(webContents));

		public Task App_MoveToApplicationsFolder_Conflict(int requestId, string conflictType) =>
			Api.Electron.App.OnConflictMoveToApplicationsFolder(requestId, conflictType);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronApp {
		internal ElectronApp() { }

		public ElectronAppCommandLine CommandLine { get; } = new();
		public ElectronAppDock Dock { get; } = new();

		public event EventHandler WillFinishLaunching;
		internal Task OnWillFinishLaunching() {
			this.WillFinishLaunching?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<AppReadyEventArgs> Ready;
		internal Task OnReady(Dictionary<string, object> launchInfo) {
			this.Ready?.Invoke(this, new(launchInfo));
			return Task.CompletedTask;
		}

		public event EventHandler WindowAllClosed;
		internal Task OnWindowAllClosed() {
			if (this.WindowAllClosed != null) {
				this.WindowAllClosed.Invoke(this, new());
				return Task.CompletedTask;
			} else {
				return this.QuitAsync();
			}
		}

		private bool cancelBeforeQuit;
		public bool CancelBeforeQuit {
			get => this.cancelBeforeQuit;
			set {
				if (this.cancelBeforeQuit == value) {
					return;
				}
				this.cancelBeforeQuit = value;

				Task.Run(() => ElectronHub.Electron.App_BeforeQuit_PreventDefault(0, value));
			}
		}

		public event EventHandler BeforeQuit;
		internal Task OnBeforeQuit() {
			this.BeforeQuit?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool cancelWillQuit;
		public bool CancelWillQuit {
			get => this.cancelWillQuit;
			set {
				if (this.cancelWillQuit == value) {
					return;
				}
				this.cancelWillQuit = value;

				Task.Run(() => ElectronHub.Electron.App_WillQuit_PreventDefault(0, value));
			}
		}

		public event EventHandler WillQuit;
		internal Task OnWillQuit() {
			this.WillQuit?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<ExitCodeEventArgs> QuitEvent;
		internal Task OnQuit(int exitCode) {
			this.QuitEvent?.Invoke(this, new(exitCode));
			return Task.CompletedTask;
		}

		private bool handleOpenFile;
		public bool HandleOpenFile {
			get => this.handleOpenFile;
			set {
				if (this.handleOpenFile == value) {
					return;
				}
				this.handleOpenFile = value;

				Task.Run(() => ElectronHub.Electron.App_OpenFile_PreventDefault(0, value));
			}
		}

		public event EventHandler<FileEventArgs> OpenFile;
		internal Task OnOpenFile(string path) {
			this.OpenFile?.Invoke(this, new(path));
			return Task.CompletedTask;
		}

		private bool handleOpenUrl;
		public bool HandleOpenUrl {
			get => this.handleOpenUrl;
			set {
				if (this.handleOpenUrl == value) {
					return;
				}
				this.handleOpenUrl = value;

				Task.Run(() => ElectronHub.Electron.App_OpenUrl_PreventDefault(0, value));
			}
		}

		public event EventHandler<UrlEventArgs> OpenUrl;
		internal Task OnOpenUrl(string url) {
			this.OpenUrl?.Invoke(this, new(url));
			return Task.CompletedTask;
		}

		public event EventHandler<AppActivateEventArgs> Activate;
		internal Task OnActivate(bool hasVisibleWindows) {
			this.Activate?.Invoke(this, new(hasVisibleWindows));
			return Task.CompletedTask;
		}

		public event EventHandler DidBecomeActive;
		internal Task OnDidBecomeActive() {
			this.DidBecomeActive?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool handleContinueActivity;
		public bool HandleContinueActivity {
			get => this.handleContinueActivity;
			set {
				if (this.handleContinueActivity == value) {
					return;
				}
				this.handleContinueActivity = value;

				Task.Run(() => ElectronHub.Electron.App_ContinueActivity_PreventDefault(0, value));
			}
		}

		public event EventHandler<ActivityEventArgs> ContinueActivity;
		internal Task OnContinueActivity(string type, Dictionary<string, object> userInfo) {
			this.ContinueActivity?.Invoke(this, new(type, userInfo));
			return Task.CompletedTask;
		}

		private bool handleWillContinueActivity;
		public bool HandleWillContinueActivity {
			get => this.handleWillContinueActivity;
			set {
				if (this.handleWillContinueActivity == value) {
					return;
				}
				this.handleWillContinueActivity = value;

				Task.Run(() => ElectronHub.Electron.App_WillContinueActivity_PreventDefault(0, value));
			}
		}

		public event EventHandler<ActivityTypeEventArgs> WillContinueActivity;
		internal Task OnWillContinueActivity(string type) {
			this.WillContinueActivity?.Invoke(this, new(type));
			return Task.CompletedTask;
		}

		public event EventHandler<ActivityErrorEventArgs> ContinueActivityError;
		internal Task OnContinueActivityError(string type, string error) {
			this.ContinueActivityError?.Invoke(this, new(type, error));
			return Task.CompletedTask;
		}

		public event EventHandler<ActivityEventArgs> ActivityWasContinued;
		internal Task OnActivityWasContinued(string type, Dictionary<string, object> userInfo) {
			this.ActivityWasContinued?.Invoke(this, new(type, userInfo));
			return Task.CompletedTask;
		}

		private bool handleUpdateActivityState;
		public bool HandleUpdateActivityState {
			get => this.handleUpdateActivityState;
			set {
				if (this.handleUpdateActivityState == value) {
					return;
				}
				this.handleUpdateActivityState = value;

				Task.Run(() => ElectronHub.Electron.App_UpdateActivityState_PreventDefault(0, value));
			}
		}

		public event EventHandler<ActivityEventArgs> UpdateActivityState;
		internal Task OnUpdateActivityState(string type, Dictionary<string, object> userInfo) {
			this.UpdateActivityState?.Invoke(this, new(type, userInfo));
			return Task.CompletedTask;
		}

		public event EventHandler NewWindowForTab;
		internal Task OnNewWindowForTab() {
			this.NewWindowForTab?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowEventArgs> BrowserWindowBlur;
		internal Task OnBrowserWindowBlur(BrowserWindow window) {
			this.BrowserWindowBlur?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowEventArgs> BrowserWindowFocus;
		internal Task OnBrowserWindowFocus(BrowserWindow window) {
			this.BrowserWindowFocus?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowEventArgs> BrowserWindowCreated;
		internal Task OnBrowserWindowCreated(BrowserWindow window) {
			this.BrowserWindowCreated?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsEventArgs> WebContentsCreated;
		internal Task OnWebContentsCreated(WebContents webContents) {
			this.WebContentsCreated?.Invoke(this, new(webContents));
			return Task.CompletedTask;
		}

		private bool handleCertificateError;
		public bool HandleCertificateError {
			get => this.handleCertificateError;
			set {
				if (this.handleCertificateError == value) {
					return;
				}
				this.handleCertificateError = value;

				Task.Run(() => ElectronHub.Electron.App_CertificateError_PreventDefault(0, value));
			}
		}

		public event EventHandler<AppCertificateErrorEventArgs> CertificateError;
		internal async Task OnCertificateError(WebContents webContents, string url, string error, Certificate certificate, ElectronFunction<bool> callback) {
			if (this.CertificateError != null) {
				this.CertificateError.Invoke(this, new(webContents, url, error, certificate, callback));
			} else {
				await callback.DisposeAsync();
			}
		}

		private bool handleSelectClientCertificate;
		public bool HandleSelectClientCertificate {
			get => this.handleSelectClientCertificate;
			set {
				if (this.handleSelectClientCertificate == value) {
					return;
				}
				this.handleSelectClientCertificate = value;

				Task.Run(() => ElectronHub.Electron.App_SelectClientCertificate_PreventDefault(0, value));
			}
		}

		public event EventHandler<AppSelectClientCertificateEventArgs> SelectClientCertificate;
		internal async Task OnSelectClientCertificate(WebContents webContents, string url, Certificate[] certificateList, ElectronFunction<Certificate> callback) {
			if (this.SelectClientCertificate != null) {
				this.SelectClientCertificate.Invoke(this, new(webContents, url, certificateList, callback));
			} else {
				await callback.DisposeAsync();
			}
		}

		private bool handleLogin;
		public bool HandleLogin {
			get => this.handleLogin;
			set {
				if (this.handleLogin == value) {
					return;
				}
				this.handleLogin = value;

				Task.Run(() => ElectronHub.Electron.App_Login_PreventDefault(0, value));
			}
		}

		public event EventHandler<AppLoginEventArgs> Login;
		internal async Task OnLogin(WebContents webContents, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, ElectronFunction<string, string> callback) {
			if (this.Login != null) {
				this.Login.Invoke(this, new(webContents, authenticationResponseDetails, authInfo, callback));
			} else {
				await callback.DisposeAsync();
			}
		}

		public event EventHandler GpuInfoUpdate;
		internal Task OnGpuInfoUpdate() {
			this.GpuInfoUpdate?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<AppRenderProcessGoneEventArgs> RenderProcessGone;
		internal Task OnRenderProcessGone(WebContents contents, RenderProcessGone details) {
			this.RenderProcessGone?.Invoke(this, new(contents, details));
			return Task.CompletedTask;
		}

		public event EventHandler<AppChildProcessGoneEventArgs> ChildProcessGone;
		internal Task OnChildProcessGone(ChildProcessGone details) {
			this.ChildProcessGone?.Invoke(this, new(details));
			return Task.CompletedTask;
		}

		public event EventHandler<AppAccessibilitySupportChangedEventArgs> AccessibilitySupportChanged;
		internal Task OnAccessibilitySupportChanged(bool accessibilitySupportEnabled) {
			this.AccessibilitySupportChanged?.Invoke(this, new(accessibilitySupportEnabled));
			return Task.CompletedTask;
		}

		public event EventHandler<SessionEventArgs> SessionCreated;
		internal /*async*/ Task OnSessionCreated(Session session) {
			//if (this.SessionCreated != null) {
				this.SessionCreated?.Invoke(this, new(session));
			/*} else {
				await session.DisposeAsync();
			}*/
			return Task.CompletedTask;
		}

		public event EventHandler<AppSecondInstanceEventArgs> SecondInstance;
		internal Task OnSecondInstance(string[] argv, string workingDirectory) {
			this.SecondInstance?.Invoke(this, new(argv, workingDirectory));
			return Task.CompletedTask;
		}

		private bool cancelDesktopCapturerGetSources;
		public bool CancelDesktopCapturerGetSources {
			get => this.cancelDesktopCapturerGetSources;
			set {
				if (this.cancelDesktopCapturerGetSources == value) {
					return;
				}
				this.cancelDesktopCapturerGetSources = value;

				Task.Run(() => ElectronHub.Electron.App_DesktopCapturerGetSources_PreventDefault(0, value));
			}
		}

		public event EventHandler<WebContentsEventArgs> DesktopCapturerGetSources;
		internal Task OnDesktopCapturerGetSources(WebContents webContents) {
			this.DesktopCapturerGetSources?.Invoke(this, new(webContents));
			return Task.CompletedTask;
		}

		public Task QuitAsync() =>
			Electron.ActionAsync(x => x.App_Quit);
		public Task ExitAsync(int exitCode = 0) =>
			Electron.ActionAsync(x => x.App_Exit, exitCode);
		public Task RelaunchAsync(RelaunchOptions options = null) {
			options ??= new();
			options.ExecPath ??= Electron.AppPath;
			return Electron.ActionAsync(x => x.App_Relaunch, options);
		}
		public Task<bool> IsReadyAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsReady);
		public Task WhenReadyAsync() =>
			Electron.ActionAsync(x => x.App_WhenReady);
		public Task FocusAsync(FocusOptions options = null) =>
			Electron.ActionAsync(x => x.App_Focus, options);
		public Task HideAsync() =>
			Electron.ActionAsync(x => x.App_Hide);
		public Task ShowAsync() =>
			Electron.ActionAsync(x => x.App_Show);
		public Task SetAppLogsPathAsync(string path = null) =>
			Electron.ActionAsync(x => x.App_SetAppLogsPath, path);
		public Task<string> GetAppPathAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetAppPath);
		public Task<string> GetPathAsync(string name) =>
			Electron.FuncAsync<string, string>(x => x.App_GetPath, name);
		public async Task<NativeImage> GetFileIconAsync(string path, FileIconOptions options = null) =>
			ElectronDisposable.FromId<NativeImage>(await Electron.FuncAsync<int, string, FileIconOptions>(x => x.App_GetFileIcon, path, options));
		public Task SetPathAsync(string name, string path) =>
			Electron.ActionAsync(x => x.App_SetPath, name, path);
		public Task<string> GetVersionAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetVersion);
		public Task<string> GetNameAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetName);
		public Task SetNameAsync(string name) =>
			Electron.ActionAsync(x => x.App_SetName, name);
		public Task<string> GetLocaleAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetLocale);
		public Task<string> GetLocaleCountryCodeAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetLocaleCountryCode);
		public Task AddRecentDocumentAsync(string path) =>
			Electron.ActionAsync(x => x.App_AddRecentDocument, path);
		public Task ClearRecentDocumentsAsync() =>
			Electron.ActionAsync(x => x.App_ClearRecentDocuments);
		public Task<bool> SetAsDefaultProtocolClientAsync(string protocol, string path = null, string[] args = null) {
			path ??= Electron.AppPath;
			args ??= Array.Empty<string>();
			return Electron.FuncAsync<bool, string, string, string[]>(x => x.App_SetAsDefaultProtocolClient, protocol, path, args);
		}
		public Task<bool> RemoveAsDefaultProtocolClientAsync(string protocol, string path = null, string[] args = null) {
			path ??= Electron.AppPath;
			args ??= Array.Empty<string>();
			return Electron.FuncAsync<bool, string, string, string[]>(x => x.App_RemoveAsDefaultProtocolClient, protocol, path, args);
		}
		public Task<bool> IsDefaultProtocolClientAsync(string protocol, string path = null, string[] args = null) {
			path ??= Electron.AppPath;
			args ??= Array.Empty<string>();
			return Electron.FuncAsync<bool, string, string, string[]>(x => x.App_IsDefaultProtocolClient, protocol, path, args);
		}
		public Task<string> GetApplicationNameForProtocolAsync(string url) =>
			Electron.FuncAsync<string, string>(x => x.App_GetApplicationNameForProtocol, url);
		public async Task<ApplicationInfoForProtocolReturnValue> GetApplicationInfoForProtocolAsync(string url) =>
			(await Electron.FuncAsync<ApplicationInfoForProtocolReturnValueDto, string>(x => x.App_GetApplicationInfoForProtocol, url))
			?.ToApplicationInfoForProtocolReturnValue();
		public Task<bool> SetUserTasksAsync(JumpListTask[] tasks) =>
			Electron.FuncAsync<bool, JumpListTask[]>(x => x.App_SetUserTasks, tasks);
		public Task<JumpListSettings> GetJumpListSettingsAsync() =>
			Electron.FuncAsync<JumpListSettings>(x => x.App_GetJumpListSettings);
		public Task<string> SetJumpListAsync(JumpListCategory[] categories) =>
			Electron.FuncAsync<string, JumpListCategory[]>(x => x.App_SetJumpList, categories);
		public Task<bool> RequestSingleInstanceLockAsync() =>
			Electron.FuncAsync<bool>(x => x.App_RequestSingleInstanceLock);
		public Task<bool> HasSingleInstanceLockAsync() =>
			Electron.FuncAsync<bool>(x => x.App_HasSingleInstanceLock);
		public Task ReleaseSingleInstanceLockAsync() =>
			Electron.ActionAsync(x => x.App_ReleaseSingleInstanceLock);
		public Task SetUserActivityAsync(string type, object userInfo, string webpageUrl = null) =>
			Electron.ActionAsync(x => x.App_SetUserActivity, type, userInfo, webpageUrl);
		public Task<string> GetCurrentActivityTypeAsync() =>
			Electron.FuncAsync<string>(x => x.App_GetCurrentActivityType);
		public Task InvalidateCurrentActivityAsync() =>
			Electron.ActionAsync(x => x.App_InvalidateCurrentActivity);
		public Task ResignCurrentActivityAsync() =>
			Electron.ActionAsync(x => x.App_ResignCurrentActivity);
		public Task UpdateCurrentActivityAsync(string type, object userInfo) =>
			Electron.ActionAsync(x => x.App_UpdateCurrentActivity, type, userInfo);
		public Task SetAppUserModelIdAsync(string id) =>
			Electron.ActionAsync(x => x.App_SetAppUserModelId, id);
		public Task SetActivationPolicyAsync(string policy) =>
			Electron.ActionAsync(x => x.App_SetActivationPolicy, policy);
		public Task<int> ImportCertificateAsync(ImportCertificateOptions options) =>
			Electron.FuncAsync<int, ImportCertificateOptions>(x => x.App_ImportCertificate, options);
		public Task DisableHardwareAccelerationAsync() =>
			Electron.ActionAsync(x => x.App_DisableHardwareAcceleration);
		public Task DisableDomainBlockingFor3dApisAsync() =>
			Electron.ActionAsync(x => x.App_DisableDomainBlockingFor3dApis);
		public Task<ProcessMetric[]> GetAppMetricsAsync() =>
			Electron.FuncAsync<ProcessMetric[]>(x => x.App_GetAppMetrics);
		public Task<GpuFeatureStatus> GetGpuFeatureStatusAsync() =>
			Electron.FuncAsync<GpuFeatureStatus>(x => x.App_GetGpuFeatureStatus);
		public Task<GpuInfo> GetGpuInfoAsync(string infoType) =>
			Electron.FuncAsync<GpuInfo, string>(x => x.App_GetGpuInfo, infoType);
		public Task<bool> SetBadgeCountAsync(int? count = null) =>
			Electron.FuncAsync<bool, int?>(x => x.App_SetBadgeCount, count);
		public Task<int> GetBadgeCountAsync() =>
			Electron.FuncAsync<int>(x => x.App_GetBadgeCount);
		public Task<bool> IsUnityRunningAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsUnityRunning);
		public Task<LoginItemSettings> GetLoginItemSettingsAsync(LoginItemSettingsOptions options = null) {
			options ??= new();
			options.Path ??= Electron.AppPath;
			options.Args ??= Array.Empty<string>();
			return Electron.FuncAsync<LoginItemSettings, LoginItemSettingsOptions>(x => x.App_GetLoginItemSettings, options);
		}
		public Task SetLoginItemSettingsAsync(Settings settings) {
			settings.Path ??= Electron.AppPath;
			settings.Args ??= Array.Empty<string>();
			return Electron.ActionAsync(x => x.App_SetLoginItemSettings, settings);
		}
		public Task<bool> IsAccessibilitySupportEnabledAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsAccessibilitySupportEnabled);
		public Task SetAccessibilitySupportEnabledAsync(bool enabled) =>
			Electron.ActionAsync(x => x.App_SetAccessibilitySupportEnabled, enabled);
		public Task ShowAboutPanelAsync() =>
			Electron.ActionAsync(x => x.App_ShowAboutPanel);
		public Task SetAboutPanelOptionsAsync(AboutPanelOptionsOptions options) =>
			Electron.ActionAsync(x => x.App_SetAboutPanelOptions, options);
		public Task<bool> IsEmojiPanelSupportedAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsEmojiPanelSupported);
		public Task ShowEmojiPanelAsync() =>
			Electron.ActionAsync(x => x.App_ShowEmojiPanel);
		public Task<ElectronFunction> StartAccessingSecurityScopedResourceAsync(string bookmarkData) =>
			Electron.FuncAsync<ElectronFunction, string>(x => x.App_StartAccessingSecurityScopedResource, bookmarkData);
		public Task EnableSandboxAsync() =>
			Electron.ActionAsync(x => x.App_EnableSandbox);
		public Task<bool> IsInApplicationsFolderAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsInApplicationsFolder);
		private readonly Dictionary<int, MoveToApplicationsFolderOptions> moveToApplicationsFolderOptions = new();
		internal Task<bool> OnConflictMoveToApplicationsFolder(int requestId, string conflictType) {
			MoveToApplicationsFolderOptions options = this.moveToApplicationsFolderOptions.GetValueOrDefault(requestId);
			if (options?.ConflictHandler == null) {
				return Task.FromResult(false);
			}
			return Task.FromResult(options.ConflictHandler(conflictType));
		}
		public async Task<bool> MoveToApplicationsFolderAsync(MoveToApplicationsFolderOptions options = null) {
			int requestId = Electron.NextRequestId;
			this.moveToApplicationsFolderOptions[requestId] = options;
			bool ret = await Electron.FuncAsync<bool>(requestId, x => x.App_MoveToApplicationsFolder);
			this.moveToApplicationsFolderOptions.Remove(requestId);
			return ret;
		}
		public Task<bool> IsSecureKeyboardEntryEnabledAsync() =>
			Electron.FuncAsync<bool>(x => x.App_IsSecureKeyboardEntryEnabled);
		public Task SetSecureKeyboardEntryEnabledAsync(bool enabled) =>
			Electron.ActionAsync(x => x.App_SetSecureKeyboardEntryEnabled, enabled);

		public ElectronProperty<bool> AccessibilitySupportEnabled { get; } =
			new(x => x.App_AccessiiblitySupportEnabled_Get, x => x.App_AccessiiblitySupportEnabled_Set);
		public ElectronProperty<Menu> ApplicationMenu { get; } =
			new(x => x.App_ApplicationMenu_Get, x => (requestId, menu) => x.App_ApplicationMenu_Set(requestId, menu.InternalId));
		public ElectronProperty<int> BadgeCount { get; } =
			new(x => x.App_BadgeCount_Get, x => x.App_BadgeCount_Set);
		public ElectronReadOnlyProperty<bool> IsPackaged { get; } =
			new(x => x.App_IsPackaged_Get);
		public ElectronProperty<string> Name { get; } =
			new(x => x.App_Name_Get, x => x.App_Name_Set);
		public ElectronProperty<string> UserAgentFallback { get; } =
			new(x => x.App_UserAgentFallback_Get, x => x.App_UserAgentFallback_Set);
		public ElectronProperty<bool> AllowRendererProcessReuse { get; } =
			new(x => x.App_AllowRendererProcessReuse_Get, x => x.App_AllowRendererProcessReuse_Set);
		public ElectronReadOnlyProperty<bool> RunningUnderRosettaTranslation { get; } =
			new(x => x.App_RunningUnderRosettaTranslation_Get);
	}
}
