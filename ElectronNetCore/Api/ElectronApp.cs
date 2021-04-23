using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
		internal Task OnBrowserWindowBlur(int id) {
			BrowserWindow window = BrowserWindow.FromId(id);
			this.BrowserWindowBlur?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowEventArgs> BrowserWindowFocus;
		internal Task OnBrowserWindowFocus(int id) {
			BrowserWindow window = BrowserWindow.FromId(id);
			this.BrowserWindowFocus?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<BrowserWindowEventArgs> BrowserWindowCreated;
		internal Task OnBrowserWindowCreated(int id) {
			BrowserWindow window = new(id);
			this.BrowserWindowCreated?.Invoke(this, new(window));
			return Task.CompletedTask;
		}

		public event EventHandler<WebContentsEventArgs> WebContentsCreated;
		internal Task OnWebContentsCreated(int id) {
			WebContents contents = new(id);
			this.WebContentsCreated?.Invoke(this, new(contents));
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
		internal async Task OnCertificateError(int webContentsId, string url, string error, Certificate certificate, int callbackId) {
			WebContents webContents = WebContents.FromId(webContentsId);
			ElectronFunction<bool> callback = ElectronDisposable.FromId<ElectronFunction<bool>>(callbackId);
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
		internal async Task OnSelectClientCertificate(int webContentsId, string url, Certificate[] certificateList, int callbackId) {
			WebContents webContents = WebContents.FromId(webContentsId);
			ElectronFunction<Certificate> callback = ElectronDisposable.FromId<ElectronFunction<Certificate>>(callbackId);
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
		internal async Task OnLogin(int webContentsId, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, int callbackId) {
			WebContents webContents = WebContents.FromId(webContentsId);
			ElectronFunction<string, string> callback = ElectronDisposable.FromId<ElectronFunction<string, string>>(callbackId);
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
		internal Task OnRenderProcessGone(int id, RenderProcessGone details) {
			WebContents contents = WebContents.FromId(id);
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
		internal async Task OnSessionCreated(int id) {
			Session session = ElectronDisposable.FromId<Session>(id);
			if (this.SessionCreated != null) {
				this.SessionCreated.Invoke(this, new(session));
			} else {
				await session.DisposeAsync();
			}
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
		internal Task OnDesktopCapturerGetSources(int webContentsId) {
			WebContents webContents = WebContents.FromId(webContentsId);
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
			bool ret = await Electron.FuncAsync<bool>(x => x.App_MoveToApplicationsFolder);
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
			new(x => x.App_ApplicationMenu_Get, x => (requestId, menu) => x.App_ApplicationMenu_Set(requestId, menu.Id));
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

	public class ElectronAppCommandLine {
		internal ElectronAppCommandLine() { }

		public Task AppendSwitchAsync(string @switch, string value = null) =>
			Electron.ActionAsync(x => x.AppCommandLine_AppendSwitch, @switch, value);
		public Task AppendArgumentAsync(string value) =>
			Electron.ActionAsync(x => x.AppCommandLine_AppendArgument, value);
		public Task<bool> HasSwitchAsync(string @switch) =>
			Electron.FuncAsync<bool, string>(x => x.AppCommandLine_HasSwitch, @switch);
		public Task<string> GetSwitchValueAsync(string @switch) =>
			Electron.FuncAsync<string, string>(x => x.AppCommandLine_GetSwitchValue, @switch);
	}

	public class ElectronAppDock {
		internal ElectronAppDock() { }

		public Task<int> BounceAsync(string type = null) =>
			Electron.FuncAsync<int, string>(x => x.AppDock_Bounce, type);
		public Task CancelBounceAsync(int id) =>
			Electron.ActionAsync(x => x.AppDock_CancelBounce, id);
		public Task DownloadFinishedAsync(string filePath) =>
			Electron.ActionAsync(x => x.AppDock_DownloadFinished, filePath);
		public Task SetBadgeAsync(string text) =>
			Electron.ActionAsync(x => x.AppDock_SetBadge, text);
		public Task<string> GetBadgeAsync() =>
			Electron.FuncAsync<string>(x => x.AppDock_GetBadge);
		public Task HideAsync() =>
			Electron.ActionAsync(x => x.AppDock_Hide);
		public Task ShowAsync() =>
			Electron.ActionAsync(x => x.AppDock_Show);
		public Task<bool> IsVisibleAsync() =>
			Electron.FuncAsync<bool>(x => x.AppDock_IsVisible);
		public Task SetMenuAsync(Menu menu) =>
			Electron.ActionAsync(x => x.AppDock_SetMenu, menu.Id);
		public Task<Menu> GetMenuAsync() =>
			Electron.FuncAsync<Menu>(x => x.AppDock_GetMenu);
		public Task SetIconAsync(NativeImage image) =>
			Electron.ActionAsync(x => x.AppDock_SetIconImage, image.Id);
		public Task SetIconAsync(string image) =>
			Electron.ActionAsync(x => x.AppDock_SetIconPath, image);
	}
}
