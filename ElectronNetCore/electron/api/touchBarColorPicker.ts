import { TouchBarColorPicker, TouchBarColorPickerConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarColorPicker : ElectronApi = {
	type: "TouchBarColorPicker",
	instanceOf: x => x?.constructor?.name === "TouchBarColorPicker",
	fromId: x => api.get<TouchBarColorPicker>(x),
	toId: (x: TouchBarColorPicker) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarColorPickerConstructorOptions, id) => {
			if (!options) {
				options = {};
			}
			options.change = color => api.send("Ctor_Change", id, color);
			return new TouchBarColorPicker(options);
		},

		"AvailableColors_Get": (self: TouchBarColorPicker) => self.availableColors,
		"AvailableColors_Set": (self: TouchBarColorPicker, value) => { self.availableColors = value; },
		"SelectedColor_Get": (self: TouchBarColorPicker) => self.selectedColor,
		"SelectedColor_Set": (self: TouchBarColorPicker, value) => { self.selectedColor = value; }
	}
};
