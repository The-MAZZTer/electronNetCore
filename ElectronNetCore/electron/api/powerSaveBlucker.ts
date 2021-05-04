import { powerSaveBlocker } from "electron";
import { ElectronApi } from "./api";

export const ElectronPowerSaveBlocker: ElectronApi = {
	type: "PowerSaveBlocker",
	init: () => {},
	handlers: {
		"Start": type => powerSaveBlocker.start(type),
		"Stop": id => powerSaveBlocker.stop(id),
		"IsStarted": id => powerSaveBlocker.isStarted(id)
	}
};
