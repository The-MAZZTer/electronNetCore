import { crashReporter } from "electron";
import { ElectronApi } from "./api";

export const ElectronCrashReporter : ElectronApi = {
	type: "CrashReporter",
	init: () => {},
	handlers: {
		"Start": options => crashReporter.start(options),
		"GetLastCrashReport": () => crashReporter.getLastCrashReport(),
		"GetUploadedReports": () => crashReporter.getUploadedReports(),
		"GetUploadToServer": () => crashReporter.getUploadToServer(),
		"SetUploadToServer": uploadToServer => crashReporter.setUploadToServer(uploadToServer),
		"AddExtraParameter": (key, value) => crashReporter.addExtraParameter(key, value),
		"RemoveExtraParameter": key => crashReporter.removeExtraParameter(key),
		"GetParameters": () => crashReporter.getParameters()
	}
};
