import { NativeImage, Notification, NotificationConstructorOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronNotification: ElectronApi = {
	type: "Notification",
	instanceOf: x => x?.constructor?.name === "Notification",
	fromId: x => api.get<Notification>(x),
	toId: (x: Notification) => api.store(x),
	init: x => api = x,
	onStore: (x: Notification, id: number) => {
		x.on("show", _ => api.send("Show_Event", id));
		x.on("click", _ => api.send("Click_Event", id));
		x.on("close", _ => api.send("Close_Event", id));
		x.on("reply", (_, reply) => api.send("Reply_Event", id, reply));
		x.on("action", (_, index) => api.send("Action_Event", id, index));
		x.on("failed", (_, error) => api.send("Failed_Event", id, error));
},
	handlers: {
		"IsSupported": (_: null) => Notification.isSupported(),
		
		"Ctor": (_: null, options: NotificationConstructorOptions) => {
			if (options) {
				if ((<any>options).iconImage) {
					options.icon = api.get<NativeImage>((<any>options).iconImage);
					delete (<any>options).iconImage;
				} else if ((<any>options).iconPath) {
					options.icon = (<any>options).iconPath;
					delete (<any>options).iconPath;
				}
			}
			return new Notification(options);
		},

		"Show": (self: Notification) => self.show(),
		"Close": (self: Notification) => self.close(),

		"Title_Get": (self: Notification) => self.title,
		"Title_Set": (self: Notification, value) => { self.title = value; },
		"Subtitle_Get": (self: Notification) => self.subtitle,
		"Subtitle_Set": (self: Notification, value) => { self.subtitle = value; },
		"Body_Get": (self: Notification) => self.body,
		"Body_Set": (self: Notification, value) => { self.body = value; },
		"ReplyPlaceholder_Get": (self: Notification) => self.replyPlaceholder,
		"ReplyPlaceholder_Set": (self: Notification, value) => { self.replyPlaceholder = value; },
		"Sound_Get": (self: Notification) => self.sound,
		"Sound_Set": (self: Notification, value) => { self.sound = value; },
		"CloseButtonText_Get": (self: Notification) => self.closeButtonText,
		"CloseButtonText_Set": (self: Notification, value) => { self.closeButtonText = value; },
		"Silent_Get": (self: Notification) => self.silent,
		"Silent_Set": (self: Notification, value) => { self.silent = value; },
		"HasReply_Get": (self: Notification) => self.hasReply,
		"HasReply_Set": (self: Notification, value) => { self.hasReply = value; },
		"Urgency_Get": (self: Notification) => self.urgency,
		"Urgency_Set": (self: Notification, value) => { self.urgency = value; },
		"TimeoutType_Get": (self: Notification) => self.timeoutType,
		"TimeoutType_Set": (self: Notification, value) => { self.timeoutType = value; },
		"Actions_Get": (self: Notification) => self.actions,
		"Actions_Set": (self: Notification, value) => { self.actions = value; },
		"ToastXml_Get": (self: Notification) => self.toastXml,
		"ToastXml_Set": (self: Notification, value) => { self.toastXml = value; }
	}
};
