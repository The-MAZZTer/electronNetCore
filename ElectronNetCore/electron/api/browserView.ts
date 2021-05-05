import { BrowserView, BrowserViewConstructorOptions, Session, webContents } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronBrowserView: ElectronApi = {
	type: "BrowserView",
	instanceOf: x => x?.constructor?.name === "BrowserView",
	fromId: x => api.get<BrowserView>(x),
	toId: x => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: BrowserViewConstructorOptions) => {
			if (options && options.webPreferences) {
				options.webPreferences.session = api.get<Session>(<any>options.webPreferences.session);
			}
			return new BrowserView(options);
		},

		"WebContents_Get": (self: BrowserView) => self,
		"WebContents_Set": (self: BrowserView, value: number) => { self.webContents = value ? webContents.fromId(value) : null },

		"SetAutoResize": (self: BrowserView, options) => self.setAutoResize(options),
		"SetBounds": (self: BrowserView, bounds) => self.setBounds(bounds),
		"GetBounds": (self: BrowserView) => self.getBounds(),
		"SetBackgroundColor": (self: BrowserView, color) => self.setBackgroundColor(color)
	}
};
