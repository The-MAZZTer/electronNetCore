import { NativeImage, TouchBar, TouchBarPopover, TouchBarPopoverConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarPopover : ElectronApi = {
	type: "TouchBarPopover",
	instanceOf: x => x?.constructor?.name === "TouchBarPopover",
	fromId: x => api.get<TouchBarPopover>(x),
	toId: (x: TouchBarPopover) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarPopoverConstructorOptions) => {
			if (options) {
				if ("icon" in options) {
					options.icon = api.get<NativeImage>(<any>options.icon);
				}
				if ("items" in options) {
					options.items = api.get<TouchBar>(<any>options.items);
				}
			}
			return new TouchBarPopover(options);
		},

		"Label_Get": (self: TouchBarPopover) => self.label,
		"Label_Set": (self: TouchBarPopover, value) => { self.label = value; },
		"Icon_Get": (self: TouchBarPopover) => self.icon,
		"Icon_Set": (self: TouchBarPopover, value) => { self.icon = api.get<NativeImage>(value); }
	}
};
