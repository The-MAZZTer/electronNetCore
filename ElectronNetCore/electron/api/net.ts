import { net } from "electron";
import { ElectronApi } from "./api";

export const ElectronNet: ElectronApi = {
	type: "Net",
	init: () => {},
	handlers: {
		"IsOnline": () => net.isOnline(),

		"Online_Get": () => net.online
	}
};
