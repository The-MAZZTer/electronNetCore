import { MessagePortMain, webFrameMain, WebFrameMain } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronWebFrameMain : ElectronApi = {
	type: "WebFrameMain",
	instanceOf: x => x?.constructor?.name === "WebFrameMain",
	fromId: x => api.get<WebFrameMain>(x),
	toId: (x: WebFrameMain) => { return {processId: x.processId, routingId: x.routingId}; },
	init: x => api = x,
	handlers: {
		"FromId": (_: null, processId, routingId) => webFrameMain.fromId(processId, routingId),

		"ExecuteJavaScript": (self: WebFrameMain, code, userGesture) => self.executeJavaScript(code, userGesture),
		"Reload": (self: WebFrameMain) => self.reload(),
		"Send": (self: WebFrameMain, channel, args) => self.send(channel, ...args),
		"PostMessage": (self: WebFrameMain, channel, message, transfer: number[]) => self.postMessage(channel, message, transfer?.map(x => api.get<MessagePortMain>(x))),

		"Url_Get": (self: WebFrameMain) => self.url,
		"Top_Get": (self: WebFrameMain) => self.top,
		"Parent_Get": (self: WebFrameMain) => self.parent,
		"Frames_Get": (self: WebFrameMain) => self.frames?.map(x => api.store(x)),
		"FramesInSubtree_Get": (self: WebFrameMain) => self.framesInSubtree?.map(x => api.store(x)),
		"FrameTreeNodeId_Get": (self: WebFrameMain) => self.frameTreeNodeId,
		"Name_Get": (self: WebFrameMain) => self.name,
		"OsProcessId_Get": (self: WebFrameMain) => self.osProcessId
	}
};
