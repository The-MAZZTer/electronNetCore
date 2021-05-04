import { nativeTheme } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronNativeTheme: ElectronApi = {
	type: "NativeTheme",
	init: x => {
		api = x;

		nativeTheme.on("updated", () =>
			api.send("Updated_Event"));
	},
	handlers: {
		"ShouldUseDarkColors_Get": () => nativeTheme.shouldUseDarkColors,
		"ThemeSource_Get": () => nativeTheme.themeSource,
		"ThemeSource_Set": value => { nativeTheme.themeSource = value; },
		"ShouldUseHighContrastColors_Get": () => nativeTheme.shouldUseHighContrastColors,
		"ShouldUseInvertedColorScheme_Get": () => nativeTheme.shouldUseInvertedColorScheme
	}
};
