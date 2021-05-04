import { TouchBarLabel, TouchBarLabelConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarLabel : ElectronApi = {
	type: "TouchBarLabel",
	instanceOf: x => x?.constructor?.name === "TouchBarLabel",
	fromId: x => api.get<TouchBarLabel>(x),
	toId: (x: TouchBarLabel) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarLabelConstructorOptions) => new TouchBarLabel(options),

		"Label_Get": (self: TouchBarLabel) => self.label,
		"Label_Set": (self: TouchBarLabel, value) => { self.label = value; },
		"AccessibilityLabel_Get": (self: TouchBarLabel) => self.accessibilityLabel,
		"AccessibilityLabel_Set": (self: TouchBarLabel, value) => { self.accessibilityLabel = value; },
		"TextColor_Get": (self: TouchBarLabel) => self.textColor,
		"TextColor_Set": (self: TouchBarLabel, value) => { self.textColor = value; }
	}
};
