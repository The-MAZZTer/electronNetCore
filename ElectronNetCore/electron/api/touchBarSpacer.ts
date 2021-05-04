import { TouchBarSpacer, TouchBarSpacerConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarSpacer : ElectronApi = {
	type: "TouchBarSpacer",
	instanceOf: x => x?.constructor?.name === "TouchBarSpacer",
	fromId: x => api.get<TouchBarSpacer>(x),
	toId: (x: TouchBarSpacer) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarSpacerConstructorOptions) => 
			new TouchBarSpacer(options),

		"Size_Get": (self: TouchBarSpacer) => self.size,
		"Size_Set": (self: TouchBarSpacer, value) => { self.size = value; }
	}
};
