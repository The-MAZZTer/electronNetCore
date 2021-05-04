using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Session_WillDownload_PreventDefault(int requestId, int id, bool value);
		Task Session_WillDownload_SavePath(int requestid, int id, string value);

		Task Session_FromPartition(int requestId, int id, string partition, FromPartitionOptions options);

		Task Session_DefaultSession(int requestId, int id);

		Task Session_GetCacheSize(int requestId, int id);
		Task Session_ClearCache(int requestId, int id);
		Task Session_ClearStorageData(int requestId, int id, ClearStorageDataOptions options);
		Task Session_FlushStorageData(int requestId, int id);
		Task Session_SetProxy(int requestId, int id, Config config);
		Task Session_ResolveProxy(int requestId, int id, string url);
		Task Session_ForceReloadProxyConfig(int requestId, int id);
		Task Session_SetDownloadPath(int requestId, int id, string path);
		Task Session_EnableNetworkEmulation(int requestId, int id, EnableNetworkEmulationOptions options);
		Task Session_Preconnect(int requestId, int id, PreconnectOptions options);
		Task Session_CloseAllConnections(int requestId, int id);
		Task Session_DisableNetworkEmulation(int requestId, int id);
		Task Session_SetCertificateVerifyProc(int requestId, int id, bool value);
		Task Session_SetPermissionRequestHandler(int requestId, int id, bool value);
		Task Session_SetPermissionCheckHandler(int requestId, int id, bool value, bool ret);
		Task Session_ClearHostResolverCache(int requestId, int id);
		Task Session_AllowNtlmCredentialsForDomains(int requestId, int id, string domains);
		Task Session_SetUserAgent(int requestId, int id, string userAgent, string acceptLanguages);
		Task Session_IsPersistent(int requestId, int id);
		Task Session_GetUserAgent(int requestId, int id);
		Task Session_SetSslConfig(int requestId, int id, SslConfigConfig config);
		Task Session_GetBlobData(int requestId, int id, string identifier);
		Task Session_DownloadUrl(int requestId, int id, string url);
		Task Session_CreateInterruptedDownload(int requestId, int id, CreateInterruptedDownloadOptions options);
		Task Session_ClearAuthCache(int requestId, int id);
		Task Session_SetPreloads(int requestId, int id, string[] preloads);
		Task Session_GetPreloads(int requestId, int id);
		Task Session_SetSpellCheckerEnabled(int requestId, int id, bool enabled);
		Task Session_IsSpellCheckerEnabled(int requestId, int id);
		Task Session_SetSpellCheckerLanguages(int requestId, int id, string[] languages);
		Task Session_GetSpellCheckerLanguages(int requestId, int id);
		Task Session_SetSpellCheckerDictionaryDownloadUrl(int requestId, int id, string url);
		Task Session_ListWordsInSpellCheckerDictionary(int requestId, int id);
		Task Session_AddWordToSpellCheckerDictionary(int requestId, int id, string word);
		Task Session_RemoveWordFromSpellCheckerDictionary(int requestId, int id, string word);
		Task Session_LoadExtension(int requestId, int id, string path, LoadExtensionOptions options);
		Task Session_RemoveExtension(int requestId, int id, string extensionId);
		Task Session_GetExtension(int requestId, int id, string extensionId);
		Task Session_GetAllExtensions(int requestId, int id);

		Task Session_AvailableSpellCheckerLanguages_Get(int requestId, int id);
		Task Session_SpellCheckerEnabled_Get(int requestId, int id);
		Task Session_SpellCheckerEnabled_Set(int requestId, int id, bool value);
		Task Session_Cookies_Get(int requestId, int id);
		Task Session_ServiceWorkers_Get(int requestId, int id);
		Task Session_WebRequest_Get(int requestId, int id);
		Task Session_Protocol_Get(int requestId, int id);
		Task Session_NetLog_Get(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task Session_WillDownload_Event(int id, int item, int webContents) =>
			ElectronDisposable.FromId<Session>(id)?.OnWillDownload(ElectronDisposable.FromId<DownloadItem>(item), WebContents.FromId(webContents)) ?? Task.CompletedTask;
		public Task Session_ExtensionLoaded_Event(int id, Extension extension) =>
			ElectronDisposable.FromId<Session>(id)?.OnExtensionLoaded(extension) ?? Task.CompletedTask;
		public Task Session_ExtensionUnloaded_Event(int id, Extension extension) =>
			ElectronDisposable.FromId<Session>(id)?.OnExtensionUnloaded(extension) ?? Task.CompletedTask;
		public Task Session_ExtensionReady_Event(int id, Extension extension) =>
			ElectronDisposable.FromId<Session>(id)?.OnExtensionReady(extension) ?? Task.CompletedTask;
		public Task Session_Preconnect_Event(int id, string preconnectUrl, bool allowCredentials) =>
			ElectronDisposable.FromId<Session>(id)?.OnPreconnect(preconnectUrl, allowCredentials) ?? Task.CompletedTask;
		public Task Session_SpellcheckDictionaryInitialized_Event(int id, string languageCode) =>
			ElectronDisposable.FromId<Session>(id)?.OnSpellcheckDictionaryInitialized(languageCode) ?? Task.CompletedTask;
		public Task Session_SpellcheckDictionaryDownloadBegin_Event(int id, string languageCode) =>
			ElectronDisposable.FromId<Session>(id)?.OnSpellcheckDictionaryDownloadBegin(languageCode) ?? Task.CompletedTask;
		public Task Session_SpellcheckDictionaryDownloadSuccess_Event(int id, string languageCode) =>
			ElectronDisposable.FromId<Session>(id)?.OnSpellcheckDictionaryDownloadSuccess(languageCode) ?? Task.CompletedTask;
		public Task Session_SpellcheckDictionaryDownloadFailure_Event(int id, string languageCode) =>
			ElectronDisposable.FromId<Session>(id)?.OnSpellcheckDictionaryDownloadFailure(languageCode) ?? Task.CompletedTask;
		public Task Session_SelectSerialPort_Event(int id, SerialPort[] portList, int webContents, int callback) =>
			ElectronDisposable.FromId<Session>(id)?.OnSelectSerialPort(portList, WebContents.FromId(webContents), ElectronDisposable.FromId<ElectronFunction<string>>(callback)) ?? Task.CompletedTask;
		public Task Session_SerialPortAdded_Event(int id, SerialPort port, int webContents) =>
			ElectronDisposable.FromId<Session>(id)?.OnSerialPortAdded(port, WebContents.FromId(webContents)) ?? Task.CompletedTask;
		public Task Session_SerialPortRemoved_Event(int id, SerialPort port, int webContents) =>
			ElectronDisposable.FromId<Session>(id)?.OnSerialPortRemoved(port, WebContents.FromId(webContents)) ?? Task.CompletedTask;

		public Task Session_SetCertificateVerifyProc_Callback(int id, Request request) =>
			ElectronDisposable.FromId<Session>(id)?.OnSetCertificateVerifyProc(request) ?? Task.CompletedTask;
		public Task Session_SetPermissionRequestHandler_Callback(int id, int webContents, string permission, PermissionRequestHandlerHandlerDetails details) =>
			ElectronDisposable.FromId<Session>(id)?.OnSetPermissionRequestHandler(WebContents.FromId(webContents), permission, details) ?? Task.CompletedTask;
		public Task Session_SetPermissioCheckHandler_Callback(int id, int webContents, string permission, string requestingOrigin, PermissionCheckHanddlerHandlerDetails details) =>
			ElectronDisposable.FromId<Session>(id)?.OnSetPermissionCheckHandler(WebContents.FromId(webContents), permission, requestingOrigin, details) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Session : ElectronDisposable<Session> {
		public static Task<Session> FromPartitionAsync(string partition, FromPartitionOptions options = null) =>
			Electron.FuncAsync<Session, int, string, FromPartitionOptions>(x => x.Session_FromPartition, 0, partition, options);

		internal Session(int id) : base(id) { }

		private bool cancelDownloads;
		public bool CancelDownloads {
			get => this.cancelDownloads;
			set {
				if (this.cancelDownloads == value) {
					return;
				}
				this.cancelDownloads = value;

				Task.Run(() => ElectronHub.Electron.Session_WillDownload_PreventDefault(0, this.InternalId, value));
			}
		}

		private string nextDownloadSavePath;
		public string NextDownloadSavePath {
			get => this.nextDownloadSavePath;
			set {
				if (this.nextDownloadSavePath == value) {
					return;
				}
				this.nextDownloadSavePath = value;

				Task.Run(() => ElectronHub.Electron.Session_WillDownload_SavePath(0, this.InternalId, value));
			}
		}

		public event EventHandler<SessionWillDownloadEventArgs> WillDownload;
		internal Task OnWillDownload(DownloadItem item, WebContents webContents) {
			this.WillDownload?.Invoke(this, new(item, webContents));
			this.nextDownloadSavePath = null;
			return Task.CompletedTask;
		}

		public event EventHandler<ExtensionEventArgs> ExtensionLoaded;
		internal Task OnExtensionLoaded(Extension extension) {
			this.ExtensionLoaded?.Invoke(this, new(extension));
			return Task.CompletedTask;
		}

		public event EventHandler<ExtensionEventArgs> ExtensionUnloaded;
		internal Task OnExtensionUnloaded(Extension extension) {
			this.ExtensionUnloaded?.Invoke(this, new(extension));
			return Task.CompletedTask;
		}

		public event EventHandler<ExtensionEventArgs> ExtensionReady;
		internal Task OnExtensionReady(Extension extension) {
			this.ExtensionReady?.Invoke(this, new(extension));
			return Task.CompletedTask;
		}

		public event EventHandler<SessionPreconnectEventArgs> PreconnectEvent;
		internal Task OnPreconnect(string preconnectUrl, bool allowCredentials) {
			this.PreconnectEvent?.Invoke(this, new(preconnectUrl, allowCredentials));
			return Task.CompletedTask;
		}

		public event EventHandler<LanguageCodeEventArgs> SpellcheckDictionaryInitialized;
		internal Task OnSpellcheckDictionaryInitialized(string languageCode) {
			this.SpellcheckDictionaryInitialized?.Invoke(this, new(languageCode));
			return Task.CompletedTask;
		}

		public event EventHandler<LanguageCodeEventArgs> SpellcheckDictionaryDownloadBegin;
		internal Task OnSpellcheckDictionaryDownloadBegin(string languageCode) {
			this.SpellcheckDictionaryDownloadBegin?.Invoke(this, new(languageCode));
			return Task.CompletedTask;
		}

		public event EventHandler<LanguageCodeEventArgs> SpellcheckDictionaryDownloadSuccess;
		internal Task OnSpellcheckDictionaryDownloadSuccess(string languageCode) {
			this.SpellcheckDictionaryDownloadSuccess?.Invoke(this, new(languageCode));
			return Task.CompletedTask;
		}

		public event EventHandler<LanguageCodeEventArgs> SpellcheckDictionaryDownloadFailure;
		internal Task OnSpellcheckDictionaryDownloadFailure(string languageCode) {
			this.SpellcheckDictionaryDownloadFailure?.Invoke(this, new(languageCode));
			return Task.CompletedTask;
		}

		public event EventHandler<SessionSelectSerialPortEventArgs> SelectSerialPort;
		internal Task OnSelectSerialPort(SerialPort[] portList, WebContents webContents, ElectronFunction<string> callback) {
			this.SelectSerialPort?.Invoke(this, new(portList, webContents, callback));
			return Task.CompletedTask;
		}

		public event EventHandler<SessionSerialPortEventArgs> SerialPortAdded;
		internal Task OnSerialPortAdded(SerialPort port, WebContents webContents) {
			this.SerialPortAdded?.Invoke(this, new(port, webContents));
			return Task.CompletedTask;
		}

		public event EventHandler<SessionSerialPortEventArgs> SerialPortRemoved;
		internal Task OnSerialPortRemoved(SerialPort port, WebContents webContents) {
			this.SerialPortRemoved?.Invoke(this, new(port, webContents));
			return Task.CompletedTask;
		}

		public Task<int> GetCacheSizeAsync() =>
			Electron.FuncAsync<int, int>(x => x.Session_GetCacheSize, this.InternalId);
		public Task ClearCacheAsync() =>
			Electron.ActionAsync(x => x.Session_ClearCache, this.InternalId);
		public Task ClearStorageDataAsync(ClearStorageDataOptions options = null) =>
			Electron.ActionAsync(x => x.Session_ClearStorageData, this.InternalId, options);
		public Task FlushStorageDataAsync() =>
			Electron.ActionAsync(x => x.Session_FlushStorageData, this.InternalId);
		public Task SetProxyAsync(Config config) =>
			Electron.ActionAsync(x => x.Session_SetProxy, this.InternalId, config);
		public Task ResolveProxyAsync(string url) =>
			Electron.ActionAsync(x => x.Session_ResolveProxy, this.InternalId, url);
		public Task ForceReloadProxyConfigAsync() =>
			Electron.ActionAsync(x => x.Session_ForceReloadProxyConfig, this.InternalId);
		public Task SetDownloadPathAsync(string path) =>
			Electron.ActionAsync(x => x.Session_SetDownloadPath, this.InternalId, path);
		public Task EnableNetworkEmulationAsync(EnableNetworkEmulationOptions options) =>
			Electron.ActionAsync(x => x.Session_EnableNetworkEmulation, this.InternalId, options);
		public Task PreconnectAsync(PreconnectOptions options) =>
			Electron.ActionAsync(x => x.Session_Preconnect, this.InternalId, options);
		public Task CloseAllConnectionsAsync() =>
			Electron.ActionAsync(x => x.Session_CloseAllConnections, this.InternalId);
		public Task DisableNetworkEmulationAsync() =>
			Electron.ActionAsync(x => x.Session_DisableNetworkEmulation, this.InternalId);
		private Func<Request, int> setCertificateVerifyProc;
		internal Task<int> OnSetCertificateVerifyProc(Request request) =>
			Task.FromResult(this.setCertificateVerifyProc?.Invoke(request) ?? -3);
		public Task SetCertificateVerifyProcAsync(Func<Request, int> proc) {
			this.setCertificateVerifyProc = proc;
			return Electron.ActionAsync(x => x.Session_SetCertificateVerifyProc, this.InternalId, proc != null);
		}
		private Func<WebContents, string, PermissionRequestHandlerHandlerDetails, bool> setPermissionRequestHandler;
		internal Task<bool> OnSetPermissionRequestHandler(WebContents webContents, string permission, PermissionRequestHandlerHandlerDetails details) =>
			Task.FromResult(this.setPermissionRequestHandler?.Invoke(webContents, permission, details) ?? false);
		public Task SetPermissionRequestHandlerAsync(Func<WebContents, string, PermissionRequestHandlerHandlerDetails, bool> handler) {
			this.setPermissionRequestHandler = handler;
			return Electron.ActionAsync(x => x.Session_SetPermissionRequestHandler, this.InternalId, handler != null);
		}
		private Action<WebContents, string, string, PermissionCheckHanddlerHandlerDetails> setPermissionCheckHandler;
		internal Task OnSetPermissionCheckHandler(WebContents webContents, string permission, string requestingOrigin, PermissionCheckHanddlerHandlerDetails details) {
			this.setPermissionCheckHandler?.Invoke(webContents, permission, requestingOrigin, details);
			return Task.CompletedTask;
		}
		public Task SetPermissionCheckHandlerAsync(Action<WebContents, string, string, PermissionCheckHanddlerHandlerDetails> handler, bool handlerSyncReturnValue) {
			this.setPermissionCheckHandler = handler;
			return Electron.ActionAsync(x => x.Session_SetPermissionCheckHandler, this.InternalId, handler != null, handlerSyncReturnValue);
		}
		public Task ClearHostResolverCacheAsync() =>
			Electron.ActionAsync(x => x.Session_ClearHostResolverCache, this.InternalId);
		public Task AllowNtlmCredentialsForDomainsAsync(string domains) =>
			Electron.ActionAsync(x => x.Session_AllowNtlmCredentialsForDomains, this.InternalId, domains);
		public Task SetUserAgentAsync(string userAgent, string acceptLanguages = null) =>
			Electron.ActionAsync(x => x.Session_SetUserAgent, this.InternalId, userAgent, acceptLanguages);
		public Task<bool> IsPersistentAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Session_IsPersistent, this.InternalId);
		public Task<string> GetUserAgentAsync() =>
			Electron.FuncAsync<string, int>(x => x.Session_GetUserAgent, this.InternalId);
		public Task SetSslConfigAsync(SslConfigConfig config) =>
			Electron.ActionAsync(x => x.Session_SetSslConfig, this.InternalId, config);
		public async Task<byte[]> GetBlobDataAsync(string identifier) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, string>(x => x.Session_GetBlobData, this.InternalId, identifier));
		public Task DownloadUrlAsync(string url) =>
			Electron.ActionAsync(x => x.Session_DownloadUrl, this.InternalId, url);
		public Task CreateInterruptedDownloadAsync(CreateInterruptedDownloadOptions options) =>
			Electron.ActionAsync(x => x.Session_CreateInterruptedDownload, this.InternalId, options);
		public Task ClearAuthCacheAsync() =>
			Electron.ActionAsync(x => x.Session_ClearAuthCache, this.InternalId);
		public Task SetPreloadsAsync(string[] preloads) =>
			Electron.ActionAsync(x => x.Session_SetPreloads, this.InternalId, preloads);
		public Task<string> GetPreloadsAsync() =>
			Electron.FuncAsync<string, int>(x => x.Session_GetPreloads, this.InternalId);
		public Task SetSpellCheckerEnabledAsync(bool enable) =>
			Electron.ActionAsync(x => x.Session_SetSpellCheckerEnabled, this.InternalId, enable);
		public Task<bool> IsSpellCheckerEnabledAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Session_IsSpellCheckerEnabled, this.InternalId);
		public Task SetSpellCheckerLanguagesAsync(string[] languages) =>
			Electron.ActionAsync(x => x.Session_SetSpellCheckerLanguages, this.InternalId, languages);
		public Task<string[]> GetSpellCheckerLanguagesAsync() =>
			Electron.FuncAsync<string[], int>(x => x.Session_GetSpellCheckerLanguages, this.InternalId);
		public Task SetSpellCheckerDictionaryDownloadUrlAsync(string url) =>
			Electron.ActionAsync(x => x.Session_SetSpellCheckerDictionaryDownloadUrl, this.InternalId, url);
		public Task<string[]> ListWordsInSpellCheckerDictionaryAsync() =>
			Electron.FuncAsync<string[], int>(x => x.Session_ListWordsInSpellCheckerDictionary, this.InternalId);
		public Task<bool> AddWordToSpellCheckerDictionaryAsync(string word) =>
			Electron.FuncAsync<bool, int, string>(x => x.Session_AddWordToSpellCheckerDictionary, this.InternalId, word);
		public Task<bool> RemoveWordFromSpellCheckerDictionaryAsync(string word) =>
			Electron.FuncAsync<bool, int, string>(x => x.Session_RemoveWordFromSpellCheckerDictionary, this.InternalId, word);
		public Task<Extension> LoadExtensionAsync(string path, LoadExtensionOptions options = null) =>
			Electron.FuncAsync<Extension, int, string, LoadExtensionOptions>(x => x.Session_LoadExtension, this.InternalId, path, options);
		public Task RemoveExtensionAsync(string extensionId) =>
			Electron.ActionAsync(x => x.Session_RemoveExtension, this.InternalId, extensionId);
		public Task<Extension> GetExtensionAsync(string extensionId) =>
			Electron.FuncAsync<Extension, int, string>(x => x.Session_GetExtension, this.InternalId, extensionId);
		public Task<Extension[]> GetAllExtensionsAsync() =>
			Electron.FuncAsync<Extension[], int>(x => x.Session_GetAllExtensions, this.InternalId);

		private ElectronInstanceReadOnlyProperty<string[]> availableSpellCheckerLanguages;
		public ElectronInstanceReadOnlyProperty<string[]> AvailableSpellCheckerLanguages {
			get {
				if (this.availableSpellCheckerLanguages == null) {
					this.availableSpellCheckerLanguages = new(this.InternalId, x => x.Session_AvailableSpellCheckerLanguages_Get);
				}
				return this.availableSpellCheckerLanguages;
			}
		}
		private ElectronInstanceProperty<bool> spellCheckerEnabled;
		public ElectronInstanceProperty<bool> SpellCheckerEnabled {
			get {
				if (this.spellCheckerEnabled == null) {
					this.spellCheckerEnabled = new(this.InternalId, x => x.Session_SpellCheckerEnabled_Get,
						x => x.Session_SpellCheckerEnabled_Set);
				}
				return this.spellCheckerEnabled;
			}
		}
		private ElectronInstanceReadOnlyProperty<Cookies> cookies;
		public ElectronInstanceReadOnlyProperty<Cookies> Cookies {
			get {
				if (this.cookies == null) {
					this.cookies = new(this.InternalId, x => x.Session_Cookies_Get);
				}
				return this.cookies;
			}
		}
		private ElectronInstanceReadOnlyProperty<ServiceWorkers> serviceWorkers;
		public ElectronInstanceReadOnlyProperty<ServiceWorkers> ServiceWorkers {
			get {
				if (this.serviceWorkers == null) {
					this.serviceWorkers = new(this.InternalId, x => x.Session_ServiceWorkers_Get);
				}
				return this.serviceWorkers;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebRequest> webRequest;
		public ElectronInstanceReadOnlyProperty<WebRequest> WebRequest {
			get {
				if (this.webRequest == null) {
					this.webRequest = new(this.InternalId, x => x.Session_WebRequest_Get);
				}
				return this.webRequest;
			}
		}
		private ElectronInstanceReadOnlyProperty<Protocol> protocol;
		public ElectronInstanceReadOnlyProperty<Protocol> Protocol {
			get {
				if (this.protocol == null) {
					this.protocol = new(this.InternalId, x => x.Session_Protocol_Get);
				}
				return this.protocol;
			}
		}
		private ElectronInstanceReadOnlyProperty<NetLog> netLog;
		public ElectronInstanceReadOnlyProperty<NetLog> NetLog {
			get {
				if (this.netLog == null) {
					this.netLog = new(this.InternalId, x => x.Session_NetLog_Get);
				}
				return this.netLog;
			}
		}
	}
}
