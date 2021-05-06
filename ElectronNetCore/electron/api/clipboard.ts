import { clipboard, Data, NativeImage } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronClipboard : ElectronApi = {
	type: "Clipboard",
	init: x => api = x,
	handlers: {
		"ReadText": type => clipboard.readText(type),
		"WriteText": (text, type) => clipboard.writeText(text, type),
		"ReadHtml": type => clipboard.readHTML(type),
		"WriteHtml": (markup, type) => clipboard.writeHTML(markup, type),
		"ReadImage": type => clipboard.readImage(type),
		"WriteImage": (image, type) => clipboard.writeImage(api.get<NativeImage>(image), type),
		"ReadRtf": type => clipboard.readRTF(type),
		"WriteRtf": (text, type) => clipboard.writeRTF(text, type),
		"ReadBookmark": () => clipboard.readBookmark(),
		"WriteBookmark": (title, url, type) => clipboard.writeBookmark(title, url, type),
		"ReadFindText": () => clipboard.readFindText(),
		"WriteFindText": text => clipboard.writeFindText(text),
		"Clear": type => clipboard.clear(type),
		"AvailableFormats": type => clipboard.availableFormats(type),
		"Has": (format, type) => clipboard.has(format, type),
		"Read": format => clipboard.read(format),
		"ReadBuffer": format => clipboard.readBuffer(format)?.toString("base64"),
		"WriteBuffer": (format, buffer, type) => clipboard.writeBuffer(format, Buffer.from(buffer, "base64"), type),
		"Write": (data: Data, type) => {
			if (data) {
				data.image = api.get<NativeImage>((<any>data).image);
			}
			return clipboard.write(data, type);
		}
	}
};
