import { shell } from "electron";
import { ElectronApi } from "./api";

export const ElectronShell : ElectronApi = {
	type: "Shell",
	init: () => {},
	handlers: {
		"ShowItemInFolder": fullPath => shell.showItemInFolder(fullPath),
		"OpenPath": path => shell.openPath(path),
		"OpenExternal": (url, options) => shell.openExternal(url, options),
		"TrashItem": path => shell.trashItem(path),
		"Beep": () => shell.beep(),
		"WriteShortcutLink": (shortcutPath, operation, options) => shell.writeShortcutLink(shortcutPath, operation, options),
		"ReadShortcutLink": shortcutPath => shell.readShortcutLink(shortcutPath)
	}
};
