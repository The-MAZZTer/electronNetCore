import { app, session, Session } from "electron";
import { ElectronApi, SignalRApi } from "./api";

const sessionWillDownloadPreventDefault: Record<number, true> = {};
const sessionWillDownloadSavePath: Record<number, string> = {};

function hookSession(session: Session, id: number) {
	session.on("will-download", (e, item, webContents) => {
		if (sessionWillDownloadPreventDefault[id]) {
			e.preventDefault();
		}
		if (sessionWillDownloadSavePath[id]) {
			item.setSavePath(sessionWillDownloadSavePath[id]);
			delete sessionWillDownloadSavePath[id];
		}

		return api.send("Session_WillDownload_Event", id, api.store(item), webContents?.id ?? 0);
	});
	session.on("extension-loaded", (_, extension) =>
		api.send("Session_ExtensionLoaded_Event", id, extension));
	session.on("extension-unloaded", (_, extension) =>
		api.send("Session_ExtensionUnloaded_Event", id, extension));
	session.on("extension-ready", (_, extension) =>
		api.send("Session_ExtensionReady_Event", id, extension));
	session.on("preconnect", (_, preconnectUrl, allowCredentials) =>
		api.send("Session_Preconnect_Event", preconnectUrl, id, allowCredentials));
	session.on("spellcheck-dictionary-initialized", (_, languageCode) =>
		api.send("Session_SpellcheckDictionaryInitialized_Event", id, languageCode));
	session.on("spellcheck-dictionary-download-begin", (_, languageCode) =>
		api.send("Session_SpellcheckDictionaryDownloadBegin_Event", id, languageCode));
	session.on("spellcheck-dictionary-download-success", (_, languageCode) =>
		api.send("Session_SpellcheckDictionaryDownloadSuccess_Event", id, languageCode));
	session.on("spellcheck-dictionary-download-failure", (_, languageCode) =>
		api.send("Session_SpellcheckDictionaryDownloadFailure_Event", id, languageCode));
	session.on("select-serial-port", (_, portList, webContents, callback) =>
		api.send("Session_SelectSerialPort_Event", id, portList, webContents?.id ?? 0, api.store(callback)));
	session.on("serial-port-added", (_, port, webContents) =>
	api	.send("Session_SerialPortAdded_Event", id, port, webContents?.id ?? 0));
	session.on("serial-port-removed", (_, port, webContents) =>
		api.send("Session_SerialPortRemoved_Event", id, port, webContents?.id ?? 0));
}

let api: SignalRApi;
export const ElectronSession: ElectronApi = {
	type: "Session",
	instanceOf: x => x?.constructor?.name === "Session",
	fromId: x => api.get<Session>(x),
	toId: (x: Session) => api.store(x),
	init: x => {
		api = x;

		app.on("ready", () => hookSession(session.defaultSession, api.store(session.defaultSession)));
	},
	onStore: (x: Session, id: number) => hookSession(x, id),
	handlers: {
		"WillDownload_PreventDefault": (self: Session, value) => { sessionWillDownloadPreventDefault[api.store(self)] = value; },
		"WillDownload_SavePath": (self: Session, value) => { sessionWillDownloadSavePath[api.store(self)] = value; },

		"FromPartition": (_: null, partition, options) => session.fromPartition(partition, options),

		"DefaultSession": (_: null) => session.defaultSession,

		"GetCacheSize": (self: Session) => self.getCacheSize(),
		"ClearCache": (self: Session) => self.clearCache(),
		"ClearStorageData": (self: Session, options) => self.clearStorageData(options),
		"FlushStorageData": (self: Session) => self.flushStorageData(),
		"SetProxy": (self: Session, config) => self.setProxy(config),
		"ResolveProxy": (self: Session, url) => self.resolveProxy(url),
		"ForceReloadProxyConfig": (self: Session) => self.forceReloadProxyConfig(),
		"SetDownloadPath": (self: Session, path) => self.setDownloadPath(path),
		"EnableNetworkEmulation": (self: Session, options) => self.enableNetworkEmulation(options),
		"Preconnect": (self: Session, options) => self.preconnect(options),
		"CloseAllConnections": (self: Session) => self.closeAllConnections(),
		"DisableNetworkEmulation": (self: Session) => self.disableNetworkEmulation(),
		"SetCertificateVerifyProc": (self: Session, value, id) => {
			if (value) {
				self.setCertificateVerifyProc(async (request, callback) => {
					const response = await api.invoke<number>("SetCertificateVerifyProc_Callback", id, request);
					callback(response);
				});	
			} else {
				self.setCertificateVerifyProc(null);	
			}
		},
		"SetPermissionRequestHandler": (self: Session, value, id) => {
			if (value) {
				self.setPermissionRequestHandler(async (webContents, permission, callback, details) => {
					const response = await api.invoke<boolean>("SetPermissionRequestHandler_Callback", id, webContents?.id ?? 0, permission, details);
					callback(response);
				});
			} else {
				self.setPermissionRequestHandler(null);
			}
		},
		"SetPermissionCheckHandler": (self: Session, value, ret, id) => {
			if (value) {
				self.setPermissionCheckHandler((webContents, permission, requestingOrigin, details) => {
					api.send("SetPermissioCheckHandler_Callback", id, webContents?.id ?? 0, permission, requestingOrigin, details);
					return ret;
				});
			} else {
				self.setPermissionCheckHandler(null);
			}
		},
		"ClearHostResolverCache": (self: Session) => self.clearHostResolverCache(),
		"AllowNtlmCredentialsForDomains": (self: Session, domains) => self.allowNTLMCredentialsForDomains(domains),
		"SetUserAgent": (self: Session, userAgent, acceptLanguages) => self.setUserAgent(userAgent, acceptLanguages),
		"IsPersistent": (self: Session) => self.isPersistent(),
		"GetUserAgent": (self: Session) => self.getUserAgent(),
		"SetSslConfig": (self: Session, config) => self.setSSLConfig(config),
		"GetBlobData": async (self: Session, identifier) => {
			const buffer = await self.getBlobData(identifier);
			if (buffer) {
				return buffer.toString("base64");
			}
			return null;
		},
		"DownloadUrl": (self: Session, url) => self.downloadURL(url),
		"CreateInterruptedDownload": (self: Session, options) => self.createInterruptedDownload(options),
		"ClearAuthCache": (self: Session) => self.clearAuthCache(),
		"SetPreloads": (self: Session, preloads) => self.setPreloads(preloads),
		"GetPreloads": (self: Session) => self.getPreloads(),
		"SetSpellCheckerEnabled": (self: Session, enabled) => self.setSpellCheckerEnabled(enabled),
		"IsSpellCheckerEnabled": (self: Session) => self.isSpellCheckerEnabled(),
		"SetSpellCheckerLanguages": (self: Session, languages) => self.setSpellCheckerLanguages(languages),
		"GetSpellCheckerLanguages": (self: Session) => self.getSpellCheckerLanguages(),
		"SetSpellCheckerDictionaryDownloadUrl": (self: Session, url) => self.setSpellCheckerDictionaryDownloadURL(url),
		"ListWordsInSpellCheckerDictionary": (self: Session) => self.listWordsInSpellCheckerDictionary(),
		"AddWordToSpellCheckerDictionary": (self: Session, word) => self.addWordToSpellCheckerDictionary(word),
		"RemoveWordFromSpellCheckerDictionary": (self: Session, word) => self.removeWordFromSpellCheckerDictionary(word),
		"LoadExtension": (self: Session, path, options) => self.loadExtension(path, options),
		"RemoveExtension": (self: Session, extensionId) => self.removeExtension(extensionId),
		"GetExtension": (self: Session, extensionId) => self.getExtension(extensionId),
		"GetAllExtensions": (self: Session) => self.getAllExtensions(),

		"AvailableSpellCheckerLanguages_Get": (self: Session) => self.availableSpellCheckerLanguages,
		"SpellCheckerEnabled_Get": (self: Session) => self.spellCheckerEnabled,
		"SpellCheckerEnabled_Set": (self: Session, value) => { self.spellCheckerEnabled = value; },
		"Cookies_Get": (self: Session) => self.cookies,
		"ServiceWorkers_Get": (self: Session) => self.serviceWorkers,
		"WebRequest_Get": (self: Session) => self.webRequest,
		"Protocol_Get": (self: Session) => self.protocol,
		"NetLog_Get": (self: Session) => self.netLog,		
	}
};
