import { BeforeSendResponse, Response, WebRequest } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronWebRequest : ElectronApi = {
	type: "WebRequest",
	instanceOf: x => x?.constructor?.name === "WebRequest",
	fromId: x => api.get<WebRequest>(x),
	toId: (x: WebRequest) => api.store(x),
	init: x => api = x,
	handlers: {
		"OnBeforeRequest": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onBeforeRequest(filter, async (details, callback) => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
						if (details.uploadData) {
							for (const data of details.uploadData) {
								data.bytes = <any>data.bytes.toString("base64");
							}
						}
					}
					const response = await api.invoke<Response>("OnBeforeRequest_Callback", id, details);
					callback(response);
				});	
			} else {
				self.onBeforeRequest(null);	
			}
		},
		"OnBeforeSendHeaders": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onBeforeSendHeaders(filter, async (details, callback) => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					const headersReceivedResponse = await api.invoke<BeforeSendResponse>("OnBeforeSendHeaders_Callback", id, details);
					callback(headersReceivedResponse);
				});	
			} else {
				self.onBeforeSendHeaders(null);	
			}
		},
		"OnSendHeaders": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onBeforeSendHeaders(filter, details => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					return api.send("OnSendHeaders_Callback", id, details);
				});	
			} else {
				self.onBeforeSendHeaders(null);	
			}
		},
		"OnHeadersReceived": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onHeadersReceived(filter, async (details, callback) => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					const headersReceivedResponse = await api.invoke<BeforeSendResponse>("OnHeadersReceived_Callback", id, details);
					callback(headersReceivedResponse);
				});	
			} else {
				self.onHeadersReceived(null);	
			}
		},
		"OnResponseStarted": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onResponseStarted(filter, details => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					return api.send("OnResponseStarted_Callback", id, details);
				});	
			} else {
				self.onResponseStarted(null);	
			}
		},
		"OnBeforeRedirect": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onBeforeRedirect(filter, details => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					return api.send("OnBeforeRedirect_Callback", id, details);
				});	
			} else {
				self.onBeforeRedirect(null);	
			}
		},
		"OnCompleted": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onCompleted(filter, details => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					return api.send("OnCompleted_Callback", id, details);
				});	
			} else {
				self.onCompleted(null);	
			}
		},
		"OnErrorOccurred": (self: WebRequest, filter, value, id) => {
			if (value) {
				self.onErrorOccurred(filter, details => {
					if (details) {
						details.webContents = <any>details.webContents?.id ?? 0;
						details.frame = details.frame ? <any>{processId: details.frame.processId, routingId: details.frame.routingId} : 0;
					}
					return api.send("OnErrorOccurred_Callback", id, details);
				});	
			} else {
				self.onErrorOccurred(null);	
			}
		}
	}
};
