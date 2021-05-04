import { TouchBarOtherItemsProxy } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarOtherItemsProxy : ElectronApi = {
	type: "TouchBarOtherItemsProxy",
	instanceOf: x => x?.constructor?.name === "TouchBarOtherItemsProxy",
	fromId: x => api.get<TouchBarOtherItemsProxy>(x),
	toId: (x: TouchBarOtherItemsProxy) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null) => new TouchBarOtherItemsProxy()
	}
};
