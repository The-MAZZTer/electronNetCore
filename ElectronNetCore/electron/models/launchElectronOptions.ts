import { CustomScheme, CrashReporterStartOptions } from "electron";

export type LaunchElectronOptions = {
	chromiumCommandLineFlags?: Record<string, string>;
	paths?: Record<string, string>;
	hardwareAcceleration?: boolean;
	unstableDomainBlockingFor3dApis?: boolean;
	forceSandbox?: boolean;
	privilegedSchemes?: CustomScheme[];
	crashReporterOptions?: CrashReporterStartOptions;
	initScriptPath?: string
};
