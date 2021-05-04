import { TouchBar, TouchBarGroup, TouchBarGroupConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarGroup : ElectronApi = {
	type: "TouchBarGroup",
	instanceOf: x => x?.constructor?.name === "TouchBarGroup",
	fromId: x => api.get<TouchBarGroup>(x),
	toId: (x: TouchBarGroup) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarGroupConstructorOptions) => {
			if (options && "items" in options) {
				options.items = api.get<TouchBar>(<any>options.items);
			}
			return new TouchBarGroup(options);
		}
	}
};
