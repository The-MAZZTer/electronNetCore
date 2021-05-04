import { contentTracing } from "electron";
import { ElectronApi } from "./api";

export const ElectronContentTracing: ElectronApi = {
	type: "ContentTracing",
	init: () => {},
	handlers: {
		"GetCategories": () => contentTracing.getCategories(),
		"StartRecording_TraceConfig": options => contentTracing.startRecording(options),
		"StartRecording_TraceCategoriesAndOptions": options => contentTracing.startRecording(options),
		"StopRecording": resultFilePath => contentTracing.startRecording(resultFilePath),
		"GetTraceBufferUsage": () => contentTracing.getTraceBufferUsage()
	}
};
