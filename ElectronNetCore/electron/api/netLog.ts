import { netLog, NetLog } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronNetLog: ElectronApi = {
	type: "NetLog",
	instanceOf: x => !!x.startLogging,
	fromId: x => api.get<NetLog>(x),
	toId: (x: NetLog) => api.store(x),
	init: x => api = x,
	handlers: {
		"StartLogging": (self: NetLog, path, options) => (self ?? netLog).startLogging(path, options),
		"StopLogging": (self: NetLog) => (self ?? netLog).stopLogging(),

		"CurrentlyLogging_Get": (self: NetLog) => (self ?? netLog).currentlyLogging
	}
};
