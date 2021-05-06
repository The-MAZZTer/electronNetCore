import { AddRepresentationOptions, nativeImage, NativeImage } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronNativeImage: ElectronApi = {
	type: "NativeImage",
	instanceOf: x => x?.constructor?.name === "NativeImage",
	fromId: x => api.get<NativeImage>(x),
	toId: (x: NativeImage) => api.store(x),
	init: x => api = x,
	handlers: {
		"CreateEmpty": (_: null) => nativeImage.createEmpty(),
		"CreateThumbnailFromPath": (_: null, path, maxSize) => nativeImage.createThumbnailFromPath(path, maxSize),
		"CreateFromPath": (_: null, path) => nativeImage.createFromPath(path),
		"CreateFromBitmap": (_: null, buffer, options) => nativeImage.createFromBitmap(Buffer.from(buffer, "base64"), options),
		"CreateFromBuffer": (_: null, buffer, options) => nativeImage.createFromBuffer(Buffer.from(buffer, "base64"), options),
		"CreateFromDataUrl": (_: null, dataUrl) => nativeImage.createFromDataURL(dataUrl),
		"CreateFromNamedImage": (_: null, imageName, hslShift) => nativeImage.createFromNamedImage(imageName, hslShift),
		
		"ToPng": (self: NativeImage, options) => self.toPNG(options)?.toString("base64"),
		"ToJpeg": (self: NativeImage, quality) => self.toJPEG(quality)?.toString("base64"),
		"ToBitmap": (self: NativeImage, options) => self.toBitmap(options)?.toString("base64"),
		"ToDataUrl": (self: NativeImage, options) => self.toDataURL(options),
		"GetBitmap": (self: NativeImage, options) => self.getBitmap(options)?.toString("base64"),
		"GetNativeHandle": (self: NativeImage) => self.getNativeHandle()?.toString("base64"),
		"IsEmpty": (self: NativeImage) => self.isEmpty(),
		"GetSize": (self: NativeImage, scaleFactor) => self.getSize(scaleFactor),
		"SetTemplateImage": (self: NativeImage, option) => self.setTemplateImage(option),
		"IsTemplateImage": (self: NativeImage) => self.isTemplateImage(),
		"Crop": (self: NativeImage, rect) => self.crop(rect),
		"Resize": (self: NativeImage, options) => self.resize(options),
		"GetAspectRatio": (self: NativeImage, scaleFactor) => self.getAspectRatio(scaleFactor),
		"GetScaleFactors": (self: NativeImage) => self.getScaleFactors(),
		"AddRepresentation": (self: NativeImage, options: AddRepresentationOptions) => {
			if (options && options.buffer) {
				options.buffer = Buffer.from((<any>options).buffer, "base64");
			}
			return self.addRepresentation(options);
		},

		"IsMacTemplateImage_Get": (self: NativeImage) => self.isMacTemplateImage,
		"IsMacTemplateImage_Set": (self: NativeImage, value) => { self.isMacTemplateImage = value }
	}
};
