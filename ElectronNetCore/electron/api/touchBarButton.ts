import { NativeImage, TouchBarButton, TouchBarButtonConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTouchBarButton : ElectronApi = {
	type: "TouchBarButton",
	instanceOf: x => x?.constructor?.name === "TouchBarButton",
	fromId: x => api.get<TouchBarButton>(x),
	toId: (x: TouchBarButton) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: TouchBarButtonConstructorOptions, id) => {
			if (!options) {
				options = {};
			}
			if ((<any>options).iconImage) {
				options.icon = api.get<NativeImage>((<any>options).iconImage);
				delete (<any>options).iconImage;
			} else if ((<any>options).iconPath) {
				options.icon = (<any>options).iconPath;
				delete (<any>options).iconPath;
			}
			options.click = () => api.send("Ctor_Click", id);
			return new TouchBarButton(options);
		},

		"AccessibilityLabel_Get": (self: TouchBarButton) => self.accessibilityLabel,
		"AccessibilityLabel_Set": (self: TouchBarButton, value) => { self.accessibilityLabel = value; },
		"Label_Get": (self: TouchBarButton) => self.label,
		"Label_Set": (self: TouchBarButton, value) => { self.label = value; },
		"BackgroundColor_Get": (self: TouchBarButton) => self.backgroundColor,
		"BackgroundColor_Set": (self: TouchBarButton, value) => { self.backgroundColor = value; },
		"Icon_Get": (self: TouchBarButton) => self.icon,
		"Icon_Set": (self: TouchBarButton, value) => { self.icon = api.get<NativeImage>(value); },
		"IconPosition_Get": (self: TouchBarButton) => self.iconPosition,
		"IconPosition_Set": (self: TouchBarButton, value) => { self.iconPosition = value; },
		"Enabled_Get": (self: TouchBarButton) => self.enabled,
		"Enabled_Set": (self: TouchBarButton, value) => { self.enabled = value; }
	}
};
