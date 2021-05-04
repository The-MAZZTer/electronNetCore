import { BrowserWindow, dialog, MessageBoxOptions, NativeImage } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronDialog: ElectronApi = {
	type: "Dialog",
	init: x => api = x,
	handlers: {
		"ShowOpenDialog": async (browserWindow: number, options) => dialog.showOpenDialog(browserWindow ? BrowserWindow.fromId(browserWindow) : null, options),
		"ShowSaveDialog": (browserWindow: number, options) => dialog.showSaveDialog(browserWindow ? BrowserWindow.fromId(browserWindow) : null, options),
		"ShowMessageBox": (browserWindow: number, options: MessageBoxOptions) => {
			if (options) {
				options.icon = api.get<NativeImage>(<any>options.icon);
			}
			return dialog.showMessageBox(browserWindow ? BrowserWindow.fromId(browserWindow) : null, options);
		},
		"ShowErrorBox": (title, content) => dialog.showErrorBox(title, content),
		"ShowCertificateTrustDialog": (browserWindow: number, options) => dialog.showCertificateTrustDialog(browserWindow > 0 ? BrowserWindow.fromId(browserWindow) : null, options),
	}
};
