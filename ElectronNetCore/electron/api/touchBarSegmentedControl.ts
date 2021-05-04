import { NativeImage, TouchBarSegmentedControl, TouchBarSegmentedControlConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarSegmentedControl : ElectronApi = {
	type: "TouchBarSegmentedControl",
	instanceOf: x => x?.constructor?.name === "TouchBarSegmentedControl",
	fromId: x => api.get<TouchBarSegmentedControl>(x),
	toId: (x: TouchBarSegmentedControl) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarSegmentedControlConstructorOptions, id) => {
			if (!options) {
				options = <any>{};
			}
			if (options.segments) {
				for (const item of options.segments) {
					if ("icon" in item) {
						item.icon = api.get<NativeImage>(<any>item.icon);
					}
				}
			}
			options.change = (selectedIndex, isSelected) => api.send("Ctor_Change", id, selectedIndex, isSelected);
			return new TouchBarSegmentedControl(options);
		},

		"SegmentStyle_Get": (self: TouchBarSegmentedControl) => self.segmentStyle,
		"SegmentStyle_Set": (self: TouchBarSegmentedControl, value) => { self.segmentStyle = value },
		"Segments_Get": (self: TouchBarSegmentedControl) => self.segments?.filter(x => {
			x.icon = <any>api.store(x.icon);
			return x;
		}),
		"Segments_Set": (self: TouchBarSegmentedControl, value) => {
			value.icon = api.get<NativeImage>(value.icon);
			self.segments = value;
		},
		"SelectedIndex_Get": (self: TouchBarSegmentedControl) => self.selectedIndex,
		"SelectedIndex_Set": (self: TouchBarSegmentedControl, value) => { self.selectedIndex = value },
		"Mode_Get": (self: TouchBarSegmentedControl) => self.mode,
		"Mode_Set": (self: TouchBarSegmentedControl, value) => { self.mode = value },

	}
};
