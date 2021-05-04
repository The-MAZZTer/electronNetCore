import { MessagePortMain } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronMessagePortMain: ElectronApi = {
	type: "MessagePortMain",
	instanceOf: x => x?.constructor?.name === "MessagePortMain",
	fromId: x => api.get<MessagePortMain>(x),
	toId: (x: MessagePortMain) => api.store(x),
	init: x => api = x,
	onStore: (x: MessagePortMain, id: number) => {
		x.on("message", async e =>
			api.send("Message_Event", id, e.data, e.ports.map(x => api.store(x))));

		x.on("close", () => 
			api.send("Close_Event", id));
	},
	handlers: {
		"PostMessage": (self: MessagePortMain, message, transfer: number[]) => self.postMessage(message, transfer?.map(x => api.get<MessagePortMain>(x))),
		"Start": (self: MessagePortMain) => self.start(),
		"Close": (self: MessagePortMain) => self.close()
	}
};
