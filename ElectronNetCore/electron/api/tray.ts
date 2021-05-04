import { DisplayBalloonOptions, Menu, NativeImage, Tray } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronTray : ElectronApi = {
	type: "Tray",
	instanceOf: x => x instanceof Tray,
	fromId: x => api.get<Tray>(x),
	toId: (x: Tray) => api.store(x),
	init: x => api = x,
	onStore: (x: Tray, id: number) => {
		x.on("click", (e, bounds, position) =>
			api.send("Click_Event", id, e, bounds, position));
		x.on("right-click", (e, bounds) =>
			api.send("RightClick_Event", id, e, bounds));
		x.on("double-click", (e, bounds) =>
			api.send("DoubleClick_Event", id, e, bounds));
		x.on("balloon-show", () =>
			api.send("BalloonShow_Event", id));
		x.on("balloon-click", () =>
			api.send("BalloonClick_Event", id));
		x.on("balloon-closed", () =>
			api.send("BalloonClosed_Event", id));
		x.on("drop", () =>
			api.send("Drop_Event", id));
		x.on("drop-files", (_, files) =>
			api.send("DropFiles_Event", id, files));
		x.on("drop-text", (_, text) =>
			api.send("DropText_Event", id, text));
		x.on("drag-enter", () =>
			api.send("DragEnter_Event", id));
		x.on("drag-leave", () =>
			api.send("DragLeave_Event", id));
		x.on("drag-end", () =>
			api.send("DragEnd_Event", id));
		x.on("mouse-up", (e, position) =>
			api.send("MouseUp_Event", id, e, position));
		x.on("mouse-down", (e, position) =>
			api.send("MouseDown_Event", id, e, position));
		x.on("mouse-enter", (e, position) =>
			api.send("MouseEnter_Event", id, e, position));
		x.on("mouse-leave", (e, position) =>
			api.send("MouseLeave_Event", id, e, position));
		x.on("mouse-move", (e, position) =>
			api.send("MouseMove_Event", id, e, position));
	},
	handlers: {
		"Ctor_Image": (_: null, image, guid) => {
			if (guid) {
				return new Tray(api.get<NativeImage>(image), guid);
			} else {
				return new Tray(api.get<NativeImage>(image));
			}
		},
		"Ctor_Path": (_: null, image, guid) => {
			if (guid) {
				return new Tray(image, guid);
			} else {
				return new Tray(image);
			}
		},
		"Destroy": (self: Tray) =>
			self.destroy(),
		"SetImage_Image": (self: Tray, image) =>
			self.setImage(api.get<NativeImage>(image)),
		"SetImage_Path": (self: Tray, image) =>
			self.setImage(image),
		"SetPressedImage_Image": (self: Tray, image) =>
			self.setPressedImage(api.get<NativeImage>(image)),
		"SetPressedImage_Path": (self: Tray, image) =>
			self.setPressedImage(image),
		"SetToolTip": (self: Tray, toolTip) =>
			self.setToolTip(toolTip),
		"SetTitle": (self: Tray, title, options) =>
			self.setTitle(title, options),
		"GetTitle": (self: Tray) =>
			self.getTitle(),
		"SetIgnoreDoubleClickEvents": (self: Tray, ignore) =>
			self.setIgnoreDoubleClickEvents(ignore),
		"GetIgnoreDoubleClickEvents": (self: Tray) =>
			self.getIgnoreDoubleClickEvents(),
		"DisplayBalloon": (self: Tray, options: DisplayBalloonOptions) => {
			if (options) {
				if ((<any>options).iconImage) {
					options.icon = api.get<NativeImage>((<any>options).iconImage);
					delete (<any>options).iconImage;
				} else if ((<any>options).iconPath) {
					options.icon = (<any>options).iconPath;
					delete (<any>options).iconPath;
				}
			}
			self.displayBalloon(options);
		},
		"RemoveBalloon": (self: Tray) => 
			self.removeBalloon(),
		"Focus": (self: Tray) => 
			self.focus(),
		"PopupContextMenu": (self: Tray, menu, position) => 
			self.popUpContextMenu(api.get<Menu>(menu), position),
		"CloseContextMenu": (self: Tray) => 
			self.closeContextMenu(),
		"SetContextMenu": (self: Tray, menu) => 
			self.setContextMenu(api.get<Menu>(menu)),
		"GetBounds": (self: Tray) => 
			self.getBounds(),
		"IsDestroyed": (self: Tray) => 
			self.isDestroyed()		
	}
};
