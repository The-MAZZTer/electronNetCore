import { DownloadItem } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronDownloadItem: ElectronApi = {
	type: "DownloadItem",
	instanceOf: x => x?.constructor?.name === "DownloadItem",
	fromId: x => api.get<DownloadItem>(x),
	toId: (x: DownloadItem) => api.store(x),
	init: x => api = x,
	onStore: (x: DownloadItem, id: number) => {
		x.on("updated", (_, state) =>
			api.send("Updated_Event", id, state));
		x.on("done", (_, state) =>
			api.send("Done_Event", id, state));
	},
	handlers: {
		"SetSavePath": (self: DownloadItem, path) => self.setSavePath(path),
		"GetSavePath": (self: DownloadItem) => self.getSavePath(),
		"SetSaveDialogOptions": (self: DownloadItem, options) => self.setSaveDialogOptions(options),
		"GetSaveDialogOptions": (self: DownloadItem) => self.getSaveDialogOptions(),
		"Pause": (self: DownloadItem) => self.pause(),
		"IsPaused": (self: DownloadItem) => self.isPaused(),
		"Resume": (self: DownloadItem) => self.resume(),
		"CanResume": (self: DownloadItem) => self.canResume(),
		"Cancel": (self: DownloadItem) => self.cancel(),
		"GetUrl": (self: DownloadItem) => self.getURL(),
		"GetMimeType": (self: DownloadItem) => self.getMimeType(),
		"HasUserGesture": (self: DownloadItem) => self.hasUserGesture(),
		"GetFilename": (self: DownloadItem) => self.getFilename(),
		"GetTotalBytes": (self: DownloadItem) => self.getTotalBytes(),
		"GetReceivedBytes": (self: DownloadItem) => self.getReceivedBytes(),
		"GetContentDisposition": (self: DownloadItem) => self.getContentDisposition(),
		"GetState": (self: DownloadItem) => self.getState(),
		"GetUrlChain": (self: DownloadItem) => self.getURLChain(),
		"GetLastModifiedTime": (self: DownloadItem) => self.getLastModifiedTime(),
		"GetETag": (self: DownloadItem) => self.getETag(),
		"GetStartTime": (self: DownloadItem) => self.getStartTime(),

		"SavePath_Get": (self: DownloadItem) => self.savePath,
		"SavePath_Set": (self: DownloadItem, value) => { self.savePath = value }
	}
};
