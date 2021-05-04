import { app } from "electron";
import { ElectronApi } from "./api";

export const ElectronAppCommandLine: ElectronApi = {
	type: "AppCommandLine",
	init: () => {},
	handlers: {
		"AppendSwitch": (_switch, value) => app.commandLine.appendSwitch(_switch, value),
		"AppendArgument": value => app.commandLine.appendArgument(value),
		"HasSwitch": _switch => app.commandLine.hasSwitch(_switch),
		"GetSwitchValue": _switch => app.commandLine.getSwitchValue(_switch)
	}
};
