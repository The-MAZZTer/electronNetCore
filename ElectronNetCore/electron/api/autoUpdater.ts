import { autoUpdater } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronAutoUpdater: ElectronApi = {
	type: "AutoUpdater",
	init: x => {
		api = x;

		autoUpdater.on("error", e =>
			api.send("Error", {
				name: e.name,
				message: e.message,
				stack: e.stack
			}));
		
		autoUpdater.on("checking-for-update", () =>
			api.send("CheckingForUpdate_Event"));

		autoUpdater.on("update-available", () =>
			api.send("UpdateAvailable_Event"));

		autoUpdater.on("update-not-available", () =>
			api.send("UpdateNotAvailable_Event"));

		autoUpdater.on("update-downloaded", (_, releaseNotes, releaseName, releaseDate, updateUrl) =>
			api.send("UpdateDownloaded_Event", releaseNotes, releaseName, releaseDate.valueOf(), updateUrl));

		autoUpdater.on("before-quit-for-update", () => 
			api.send("BeforeQuitForUpdate_Event"));
	},
	handlers: {
		"SetFeedUrl": options => autoUpdater.setFeedURL(options),
		"GetFeedUrl": () => autoUpdater.getFeedURL(),
		"CheckForUpdates": () => autoUpdater.checkForUpdates(),
		"QuitAndInstall": () => autoUpdater.quitAndInstall()
	}
};
