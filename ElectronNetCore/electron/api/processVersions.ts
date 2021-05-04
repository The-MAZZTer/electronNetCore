import { ElectronApi } from "./api";

export const ElectronProcessVersions: ElectronApi = {
	type: "ProcessVersions",
	init: () => {},
	handlers: {
		"Chrome_Get": () => process.versions.chrome,
		"Electron_Get": () => process.versions.electron
	}
};
