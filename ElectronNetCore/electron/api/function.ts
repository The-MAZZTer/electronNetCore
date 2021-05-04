import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronFunction: ElectronApi = {
	type: "Function",
	instanceOf: x => x?.constructor?.name === "Function",
	fromId: x => api.get<Function>(x),
	toId: (x: Function) => api.store(x),
	init: x => api = x,
	handlers: {
		"Invoke": (self: Function, args: any[]) => self(...args)
	}
};
