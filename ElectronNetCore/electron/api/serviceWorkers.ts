import { ServiceWorkers } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronServiceWorkers: ElectronApi = {
	type: "ServiceWorkers",
	instanceOf: x => x?.constructor?.name === "ServiceWorkers",
	fromId: x => api.get<ServiceWorkers>(x),
	toId: (x: ServiceWorkers) => api.store(x),
	init: x => api = x,
	onStore: (x: ServiceWorkers, id: number) => {
		x.on("console-message", (_, messageDetails) =>
			api.send("ConsoleMessage_Event", id, messageDetails));
	},
	handlers: {
		"GetAllRunning": (self: ServiceWorkers) => self.getAllRunning(),
		"GetFromVersionId": (self: ServiceWorkers, versionId) => self.getFromVersionID(versionId)
	}
};
