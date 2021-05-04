import { TouchBar, TouchBarConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBar : ElectronApi = {
	type: "TouchBar",
	instanceOf: x => x?.constructor?.name === "TouchBar",
	fromId: x => api.get<TouchBar>(x),
	toId: (x: TouchBar) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarConstructorOptions) => {
			if (options) {
				if (options.items) {
					options.items = options.items.filter(x => api.get(<any>x));
				}
				if ("escapeItem" in options) {
					options.escapeItem = api.get(<any>options.escapeItem);
				}
			}
			return new TouchBar(options);
		},

		"EscapeItem_Get": (self: TouchBar) => self.escapeItem,
		"EscapeItem_Set": (self: TouchBar, value) => self.escapeItem = api.get(value)
	}
};
