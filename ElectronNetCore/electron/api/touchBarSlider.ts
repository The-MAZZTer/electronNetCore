import { TouchBarSlider, TouchBarSliderConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarSlider : ElectronApi = {
	type: "TouchBarSlider",
	instanceOf: x => x?.constructor?.name === "TouchBarSlider",
	fromId: x => api.get<TouchBarSlider>(x),
	toId: (x: TouchBarSlider) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarSliderConstructorOptions, id) => {
			if (!options) {
				options = <any>{};
			}
			options.change = newValue => api.send("Ctor_Change", id, newValue);
			return new TouchBarSlider(options);
		},

		"Label_Get": (self: TouchBarSlider) => self.label,
		"Label_Set": (self: TouchBarSlider, value) => { self.label = value; },
		"Value_Get": (self: TouchBarSlider) => self.value,
		"Value_Set": (self: TouchBarSlider, value) => { self.value = value; },
		"MinValue_Get": (self: TouchBarSlider) => self.minValue,
		"MinValue_Set": (self: TouchBarSlider, value) => { self.minValue = value; },
		"MaxValue_Get": (self: TouchBarSlider) => self.maxValue,
		"MaxValue_Set": (self: TouchBarSlider, value) => { self.maxValue = value; }
	}
};
