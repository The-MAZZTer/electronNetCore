import { app, BrowserWindow, screen } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronScreen : ElectronApi = {
	type: "Screen",
	init: x => {
		api = x;

		app.on("ready", () => {
			screen.on("display-added", (_, newDisplay) =>
				api.send("DisplayAdded_Event", newDisplay));
			screen.on("display-removed", (_, oldDisplay) =>
				api.send("DisplayRemoved_Event", oldDisplay));
			screen.on("display-metrics-changed", (_, display, changedMetrics) =>
				api.send("DisplayMetricsChanged_Event", display, changedMetrics));
		});
	},
	handlers: {
		"GetCursorScreenPoint": () => screen.getCursorScreenPoint(),
		"GetPrimaryDisplay": () => screen.getPrimaryDisplay(),
		"GetAllDisplays": () => screen.getAllDisplays(),
		"GetDisplayNearestPoint": point => screen.getDisplayNearestPoint(point),
		"GetDisplayMatching": rect => screen.getDisplayMatching(rect),
		"ScreenToDipPoint": point => screen.screenToDipPoint(point),
		"DipToScreenPoint": point => screen.dipToScreenPoint(point),
		"ScreenToDipRect": (window, rect) => screen.screenToDipRect(window ? BrowserWindow.fromId(window) : null, rect),
		"DipToScreenRect": (window, rect) => screen.dipToScreenRect(window ? BrowserWindow.fromId(window) : null, rect)
	}
};
