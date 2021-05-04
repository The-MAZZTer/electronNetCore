import { Cookies } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronCookies : ElectronApi = {
	type: "Cookies",
	instanceOf: x => x?.constructor?.name === "Cookies",
	fromId: x => api.get<Cookies>(x),
	toId: (x: Cookies) => api.store(x),
	init: x => api = x,
	onStore: (x: Cookies, id: number) => {
		x.on("changed", (_, cookie, cause, removed) => 
			api.send("Changed_Event", id, cookie, cause, removed));
	},
	handlers: {
		"Get": (self: Cookies, filter) => self.get(filter),
		"Set": (self: Cookies, details) => self.set(details),
		"Remove": (self: Cookies, url, name) => self.remove(url, name),
		"FlushStore": (self: Cookies) => self.flushStore()
	}
};
