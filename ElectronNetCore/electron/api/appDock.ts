import { app, Menu, NativeImage } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronAppDock: ElectronApi = {
	type: "AppDock",
	init: x => api = x,
	handlers: {
		"Bound": type => app.dock.bounce(type),
		"CancelBound": id => app.dock.cancelBounce(id),
		"DownloadFinished": filePath => app.dock.downloadFinished(filePath),
		"SetBadge": text => app.dock.setBadge(text),
		"GetBadge": () => app.dock.getBadge(),
		"Hide": () => app.dock.hide(),
		"Show": () => app.dock.show(),
		"IsVisible": () => app.dock.isVisible(),
		"SetMenu": id => app.dock.setMenu(api.get<Menu>(id)),
		"GetMenu": () => app.dock.getMenu(),
		"SetIconImage": image => app.dock.setIcon(api.get<NativeImage>(image)),
		"SetIconPath": image => app.dock.setIcon(image)
	}
};
