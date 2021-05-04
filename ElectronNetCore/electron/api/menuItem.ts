import { BrowserWindow, Menu, MenuItem, MenuItemConstructorOptions, NativeImage, WebContents } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronMenuItem: ElectronApi = {
	type: "MenuItem",
	instanceOf: x => x?.constructor?.name === "MenuItem",
	fromId: x => api.get<MenuItem>(x),
	toId: (x: MenuItem) => api.store(x),
	init: x => api = x,
	handlers: {
		"Ctor": (_: null, options: MenuItemConstructorOptions) => {
			const buildMenuItemOptions = (x: MenuItemConstructorOptions) => {
				if (typeof x == "number") {
					return api.get<MenuItem>(x);
				} else {
					if ((<any>x).iconImage) {
						x.icon = api.get<NativeImage>((<any>x).iconImage);
						delete (<any>x).iconImage;
					} else if ((<any>x).iconPath) {
						x.icon = (<any>x).iconPath;
						delete (<any>x).iconPath;
					}
					if ((<any>x).submenuMenu) {
						x.submenu = api.get<Menu>((<any>x).submenuMenu);
						delete (<any>x).submenuMenu;
					} else if ((<any>x).submenuTemplate) {
						x.submenu = <any>((<MenuItemConstructorOptions[]>(<any>x).submenuTemplate).map(x => buildMenuItemOptions(x)));
						delete (<any>x).submenuTemplate;
					}
				}
				return x;
			}

			return new MenuItem(options ? <MenuItemConstructorOptions>buildMenuItemOptions(options) : null);
		},

		"Id_Get": (self: MenuItem) => self.id,
		"Id_Set": (self: MenuItem, value) => { self.id = value },
		"Label_Get": (self: MenuItem) => self.label,
		"Label_Set": (self: MenuItem, value) => { self.label = value },
		"Click_Get": (self: MenuItem) => self.click != null,
		"Click_Set": (self: MenuItem, value) => {
			if (!value) {
				self.click = () => {};
			} else {
				self.click = (e: KeyboardEvent, browserWindow: BrowserWindow, webContents: WebContents) =>
					api.send("Click_Callback", api.store(self), e, browserWindow?.id ?? 0, webContents?.id ?? 0);
			}
		},
		"Submenu_Get": (self: MenuItem) => self.submenu,
		"Submenu_Set": (self: MenuItem, value) => { self.submenu = api.get<Menu>(value) },
		"Type_Get": (self: MenuItem) => self.type,
		"Type_Set": (self: MenuItem, value) => { self.type = value },
		"Role_Get": (self: MenuItem) => self.role,
		"Role_Set": (self: MenuItem, value) => { self.role = value; },
		"Accelerator_Get": (self: MenuItem) => self.accelerator,
		"Accelerator_Set": (self: MenuItem, value) => { self.accelerator = value },
		"IconImage_Get": (self: MenuItem) => self.icon instanceof NativeImage ? api.store(self.icon) : null,
		"IconImage_Set": (self: MenuItem, value) => { self.icon = api.get<NativeImage>(value) },
		"IconPath_Get": (self: MenuItem) => !(self.icon instanceof NativeImage) ? self.icon : null,
		"IconPath_Set": (self: MenuItem, value) => { self.icon = value },
		"Sublabel_Get": (self: MenuItem) => self.sublabel,
		"Sublabel_Set": (self: MenuItem, value) => { self.sublabel = value },
		"ToolTip_Get": (self: MenuItem) => self.toolTip,
		"ToolTip_Set": (self: MenuItem, value) => { self.toolTip = value },
		"Enabled_Get": (self: MenuItem) => self.enabled,
		"Enabled_Set": (self: MenuItem, value) => { self.enabled = value },
		"Visible_Get": (self: MenuItem) => self.visible,
		"Visible_Set": (self: MenuItem, value) => { self.visible = value },
		"Checked_Get": (self: MenuItem) => self.checked,
		"Checked_Set": (self: MenuItem, value) => { self.checked = value },
		"RegisterAccelerator_Get": (self: MenuItem) => self.registerAccelerator,
		"RegisterAccelerator_Set": (self: MenuItem, value) => { self.registerAccelerator = value },
		"SharingItem_Get": (self: MenuItem) => self.sharingItem,
		"SharingItem_Set": (self: MenuItem, value) => { self.sharingItem = value },
		"CommandId_Get": (self: MenuItem) => self.commandId,
		"CommandId_Set": (self: MenuItem, value) => { self.commandId = value },
		"Menu_Get": (self: MenuItem) => self.menu,
		"Menu_Set": (self: MenuItem, value) => { self.menu = api.get<Menu>(value) }
	}
};
