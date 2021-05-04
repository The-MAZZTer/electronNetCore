import { globalShortcut } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronGlobalShortcut: ElectronApi = {
	type: "GlobalShortcut",
	init: x => api = x,
	handlers: {
		"Register": (accelerator, requestId) =>
			globalShortcut.register(accelerator, () => api.send("Register_Callback", requestId)),
		"RegisterAll": (accelerators, requestId) =>
			globalShortcut.registerAll(accelerators, () => api.send("Register_Callback", requestId)),
		"IsRegistered": accelerator => globalShortcut.isRegistered(accelerator),
		"Unregister": accelerator => globalShortcut.unregister(accelerator),
		"UnregisterAll": () => globalShortcut.unregisterAll()
	}
};
