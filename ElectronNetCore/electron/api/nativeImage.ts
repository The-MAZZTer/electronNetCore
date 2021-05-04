import { NativeImage } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronNativeImage: ElectronApi = {
	type: "NativeImage",
	instanceOf: x => x?.constructor?.name === "NativeImage",
	fromId: x => api.get<NativeImage>(x),
	toId: (x: NativeImage) => api.store(x),
	init: x => api = x,
	handlers: {
		"GetSize": (self: NativeImage, scaleFactor) => self.getSize(scaleFactor),
		"ToDataUrl": (self: NativeImage, options) => self.toDataURL(options)
	}
};
