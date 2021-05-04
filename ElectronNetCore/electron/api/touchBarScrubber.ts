import { NativeImage, TouchBarScrubber, TouchBarScrubberConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarScrubber : ElectronApi = {
	type: "TouchBarScrubber",
	instanceOf: x => x?.constructor?.name === "TouchBarScrubber",
	fromId: x => api.get<TouchBarScrubber>(x),
	toId: (x: TouchBarScrubber) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarScrubberConstructorOptions, id) => {
			if (!options) {
				options = <any>{};
			}
			if (options.items) {
				for (const item of options.items) {
					if ("icon" in item) {
						item.icon = api.get<NativeImage>(<any>item.icon);
					}
				}
			}
			options.select = selectedIndex => api.send("Ctor_Select", id, selectedIndex);
			options.highlight = highlightedIndex => api.send("Ctor_Highlight", id, highlightedIndex);
			return new TouchBarScrubber(options);
		},

		"Items_Get": (self: TouchBarScrubber) => self.items?.filter(x => {
			x.icon = <any>api.store(x.icon);
			return x;
		}),
		"Items_Set": (self: TouchBarScrubber, value) => {
			value.icon = api.get<NativeImage>(value.icon);
			self.items = value;
		},
		"SelectedStyle_Get": (self: TouchBarScrubber) => self.selectedStyle,
		"SelectedStyle_Set": (self: TouchBarScrubber, value) => { self.selectedStyle = value },
		"OverlayStyle_Get": (self: TouchBarScrubber) => self.overlayStyle,
		"OverlayStyle_Set": (self: TouchBarScrubber, value) => { self.overlayStyle = value },
		"ShowArrowButtons_Get": (self: TouchBarScrubber) => self.showArrowButtons,
		"ShowArrowButtons_Set": (self: TouchBarScrubber, value) => { self.showArrowButtons = value },
		"Mode_Get": (self: TouchBarScrubber) => self.mode,
		"Mode_Set": (self: TouchBarScrubber, value) => { self.mode = value },
		"Continuous_Get": (self: TouchBarScrubber) => self.continuous,
		"Continuous_Set": (self: TouchBarScrubber, value) => { self.continuous = value }
	}
};
