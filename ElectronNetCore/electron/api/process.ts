import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronProcess: ElectronApi = {
	type: "Process",
	init: x => {
		api = x;

		process.on("loaded", () =>
			api.send("Loaded_Event"));
	},
	handlers: {
		"DefaultApp_Get": () => process.defaultApp ?? false,
		"IsMainFrame_Get": () => process.isMainFrame ?? false,
		"Mas_Get": () => process.mas ?? false,
		"NoAsar_Get": () => process.noAsar ?? false,
		"NoAsar_Set": value => { process.noAsar = value; },
		"NoDeprecation_Get": () => process.noDeprecation ?? false,
		"NoDeprecation_Set": value => { process.noDeprecation = value; },
		"ResourcesPath_Get": () => process.resourcesPath,
		"Sandboxed_Get": () => process.sandboxed ?? false,
		"ThrowDeprecation_Get": () => process.throwDeprecation ?? false,
		"ThrowDeprecation_Set": value => { process.throwDeprecation = value; },
		"TraceDeprecation_Get": () => process.traceDeprecation ?? false,
		"TraceDeprecation_Set": value => { process.traceDeprecation = value; },
		"TraceProcessWarnings_Get": () => process.traceProcessWarnings ?? false,
		"TraceProcessWarnings_Set": value => { process.traceProcessWarnings = value; },
		"Type_Get": () => process.type,
		"WindowsStore_Get": () => process.windowsStore ?? false,

		"Crash": () => process.crash(),
		"GetCreationTime": () => process.getCreationTime(),
		"GetCpuUsage": () => process.getCPUUsage(),
		"GetIoCounters": () => process.getIOCounters(),
		"GetHeapStatistics": () => process.getHeapStatistics(),
		"GetBlinkMemoryInfo": () => process.getBlinkMemoryInfo(),
		"GetProcessMemoryInfo": () => process.getProcessMemoryInfo(),
		"GetSystemMemoryInfo": () => process.getSystemMemoryInfo(),
		"GetSystemVersion": () => process.getSystemVersion(),
		"TakeHeapSnapshot": filePath => process.takeHeapSnapshot(filePath),
		"Hang": () => process.hang(),
		"SetFdLimit": maxDescriptors => process.setFdLimit(maxDescriptors)
	}
};
