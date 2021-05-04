import { Protocol, protocol, ProtocolResponse } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronProtocol: ElectronApi = {
	type: "Protocol",
	instanceOf: x => !!x.registerFileProtocol,
	fromId: x => api.get<Protocol>(x),
	toId: (x: Protocol) => api.store(x),
	init: x => api = x,
	handlers: {
		"RegisterSchemesAsPrivileged": (self: Protocol, customSchemes) => (self ?? protocol).registerSchemesAsPrivileged(customSchemes),
		"RegisterFileProtocol": (self: Protocol, scheme, id) => (self ?? protocol).registerFileProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("RegisterFileProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"RegisterBufferProtocol": (self: Protocol, scheme, id) => (self ?? protocol).registerBufferProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("RegisterBufferProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			if (response.data) {
				response.data = Buffer.from(<any>response.data, "base64");
			}
			callback(response);
		}),
		"RegisterStringProtocol": (self: Protocol, scheme, id) => (self ?? protocol).registerStringProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("RegisterStringProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"RegisterHttpProtocol": (self: Protocol, scheme, id) => (self ?? protocol).registerHttpProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("RegisterHttpProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"UnregisterProtocol": (self: Protocol, scheme) => (self ?? protocol).unregisterProtocol(scheme),
		"IsProtocolRegistered": (self: Protocol, scheme) => (self ?? protocol).isProtocolRegistered(scheme),
		"InterceptFileProtocol": (self: Protocol, scheme, id) => (self ?? protocol).interceptFileProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("InterceptFileProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"InterceptBufferProtocol": (self: Protocol, scheme, id) => (self ?? protocol).interceptBufferProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("InterceptBufferProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			if (response.data) {
				response.data = Buffer.from(<any>response.data, "base64");
			}
			callback(response);
		}),
		"InterceptStringProtocol": (self: Protocol, scheme, id) => (self ?? protocol).interceptStringProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("InterceptStringProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"InterceptHttpProtocol": (self: Protocol, scheme, id) => (self ?? protocol).interceptHttpProtocol(scheme, async (request, callback) => {
			if (request.uploadData) {
				for (const uploadData of request.uploadData) {
					uploadData.bytes = <any>uploadData.bytes.toString("base64");
				}
			}
			const response = await api.invoke<ProtocolResponse>("InterceptHttpProtocol_Callback", id, request);
			if (response.uploadData) {
				if ((<any>response.uploadData).dataRaw) {
					response.uploadData.data = Buffer.from((<any>response.uploadData).dataRaw, "base64");
					delete (<any>response.uploadData).dataRaw;
				}
			}
			callback(response);
		}),
		"UninterceptProtocol": (self: Protocol, scheme) => (self ?? protocol).uninterceptProtocol(scheme),
		"IsProtocolIntercepted": (self: Protocol, scheme) => (self ?? protocol).isProtocolIntercepted(scheme)
	}
};
