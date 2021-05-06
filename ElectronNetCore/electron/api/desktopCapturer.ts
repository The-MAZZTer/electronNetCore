import { desktopCapturer } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronDesktopCapturer : ElectronApi = {
	type: "DesktopCapturer",
	init: x => api = x,
	handlers: {
		"GetSources": async options => (await desktopCapturer.getSources(options))?.map(x => {
			if (x.appIcon) {
				(<any>x).appIcon = api.store(x.appIcon);
			}
			if (x.thumbnail) {
				(<any>x).thumbnail = api.store(x.appIcon);
			}
			return x;
		})
	}
};
