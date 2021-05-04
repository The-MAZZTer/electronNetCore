import { webFrameMain, WebFrameMain } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronWebFrameMain : ElectronApi = {
	type: "WebFrameMain",
	instanceOf: x => x?.constructor?.name === "WebFrameMain",
	fromId: x => api.get<WebFrameMain>(x),
	toId: (x: WebFrameMain) => { return {processId: x.processId, routingId: x.routingId}; },
	init: x => api = x,
	handlers: {
		"FromId": (_: null, processId, routingId) => webFrameMain.fromId(processId, routingId)
	}
};
