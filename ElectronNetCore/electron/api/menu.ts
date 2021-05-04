import { BrowserWindow, Menu, MenuItem, MenuItemConstructorOptions, NativeImage, PopupOptions } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronMenu: ElectronApi = {
	type: "Menu",
	instanceOf: x => x instanceof Menu,
	fromId: x => api.get<Menu>(x),
	toId: (x: Menu) => api.store(x),
	init: x => api = x,
	onStore: (x: Menu, id: number) => {
		x.on("menu-will-show", _ => api.send("MenuWillShow_Event", id));
		x.on("menu-will-close", _ => api.send("MenuWillClose_Event", id));
	},
	handlers: {
		"Ctor": (_: null) => new Menu(),

		"SetApplicationMenu": (_ : null, menu: number) => Menu.setApplicationMenu(api.get<Menu>(menu)),
		"GetApplicationMenu": (_ : null) => Menu.getApplicationMenu(),
		"SendActionToFirstResponder": (_: null, action) => Menu.sendActionToFirstResponder(action),
		"BuildFromTemplate": (_: null, template: (MenuItemConstructorOptions | number)[]) => {
			const buildMenuItemOptions = (x: MenuItemConstructorOptions | number) => {
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

			const items = template.map(buildMenuItemOptions);
			return Menu.buildFromTemplate(items);
		},

		"Popup": (self: Menu, options: PopupOptions, requestId) => {
			if (!options) {
				options = {};
			}
			options.window = options.window ? BrowserWindow.fromId(<any>options.window) : null;
			options.callback = () => api.send("Popup_Closed", api.store(self), requestId);
			self.popup(options);
		},
		"ClosePopup": (self: Menu, browserWindow) => {
			browserWindow = browserWindow ? BrowserWindow.fromId(browserWindow) : null;
			self.closePopup(browserWindow);
		},
		"Append": (self: Menu, menuItem) => {
			menuItem = api.get<MenuItem>(menuItem);
			self.append(menuItem);
		},
		"GetMenuItemById": (self: Menu, id) => api.store(self.getMenuItemById(id)),
		"Insert": (self: Menu, pos, menuItem) => {
			menuItem = api.get<MenuItem>(menuItem);
			self.insert(pos, menuItem);
		},

		"Items_Get": (self: Menu) => self.items.map(x => api.store(x)),
		"Items_Set": (self: Menu, value: number[]) => { self.items = value.map(x => api.get<MenuItem>(x)) }
	}
};
