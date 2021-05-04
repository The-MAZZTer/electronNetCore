using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task MenuItem_Ctor(int requestId, int id, MenuItemConstructorOptionsDto options);

		Task MenuItem_Id_Get(int requestId, int id);
		Task MenuItem_Id_Set(int requestId, int id, string value);
		Task MenuItem_Label_Get(int requestId, int id);
		Task MenuItem_Label_Set(int requestId, int id, string value);
		Task MenuItem_Click_Get(int requestId, int id);
		Task MenuItem_Click_Set(int requestId, int id, bool value);
		Task MenuItem_Submenu_Get(int requestId, int id);
		Task MenuItem_Submenu_Set(int requestId, int id, int value);
		Task MenuItem_Type_Get(int requestId, int id);
		Task MenuItem_Type_Set(int requestId, int id, string value);
		Task MenuItem_Role_Get(int requestId, int id);
		Task MenuItem_Role_Set(int requestId, int id, string value);
		Task MenuItem_Accelerator_Get(int requestId, int id);
		Task MenuItem_Accelerator_Set(int requestId, int id, string value);
		Task MenuItem_IconImage_Get(int requestId, int id);
		Task MenuItem_IconImage_Set(int requestId, int id, int value);
		Task MenuItem_IconPath_Get(int requestId, int id);
		Task MenuItem_IconPath_Set(int requestId, int id, string value);
		Task MenuItem_Sublabel_Get(int requestId, int id);
		Task MenuItem_Sublabel_Set(int requestId, int id, string value);
		Task MenuItem_ToolTip_Get(int requestId, int id);
		Task MenuItem_ToolTip_Set(int requestId, int id, string value);
		Task MenuItem_Enabled_Get(int requestId, int id);
		Task MenuItem_Enabled_Set(int requestId, int id, bool value);
		Task MenuItem_Visible_Get(int requestId, int id);
		Task MenuItem_Visible_Set(int requestId, int id, bool value);
		Task MenuItem_Checked_Get(int requestId, int id);
		Task MenuItem_Checked_Set(int requestId, int id, bool value);
		Task MenuItem_RegisterAccelerator_Get(int requestId, int id);
		Task MenuItem_RegisterAccelerator_Set(int requestId, int id, bool value);
		Task MenuItem_SharingItem_Get(int requestId, int id);
		Task MenuItem_SharingItem_Set(int requestId, int id, SharingItem value);
		Task MenuItem_CommandId_Get(int requestId, int id);
		Task MenuItem_CommandId_Set(int requestId, int id, int value);
		Task MenuItem_Menu_Get(int requestId, int id);
		Task MenuItem_Menu_Set(int requestId, int id, int value);
	}

	internal partial class ElectronHub {
		public Task MenuItem_Click_Callback(int id, KeyboardEvent e, int browserWindow, int webContents) =>
			ElectronDisposable.FromId<MenuItem>(id)?.OnClick(e, browserWindow > 0 ? BrowserWindow.FromId(browserWindow) : null,
			webContents > 0 ? WebContents.FromId(webContents) : null);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class MenuItem : ElectronDisposable<MenuItem> {
		public async static Task<MenuItem> CreateAsync(MenuItemConstructorOptions options) {
			MenuItem ret = await Electron.FuncAsync<MenuItem, int, MenuItemConstructorOptionsDto>(x => x.MenuItem_Ctor, 0, options?.ToMenuItemConstructorOptionsDto());
			if (options?.Click != null) {
				await ret.ClickSetAsync(options.Click);
			}
			return ret;
		}

		internal MenuItem(int id) : base(id) { }

		private ElectronInstanceProperty<string> id;
		public ElectronInstanceProperty<string> Id {
			get {
				if (this.id == null) {
					this.id = new(this.InternalId, x => x.MenuItem_Id_Get,
						x => x.MenuItem_Id_Set);
				}
				return this.id;
			}
		}

		private ElectronInstanceProperty<string> label;
		public ElectronInstanceProperty<string> Label {
			get {
				if (this.label == null) {
					this.label = new(this.InternalId, x => x.MenuItem_Label_Get,
						x => x.MenuItem_Label_Set);
				}
				return this.label;
			}
		}

		public Action<KeyboardEvent, BrowserWindow, WebContents> Click { get; internal set; }
		internal Task OnClick(KeyboardEvent e, BrowserWindow browserWindow, WebContents webContents) {
			this.Click?.Invoke(e, browserWindow, webContents);
			return Task.CompletedTask;
		}
		public Task ClickSetAsync(Action<KeyboardEvent, BrowserWindow, WebContents> value) {
			this.Click = value;
			return Electron.ActionAsync(x => x.MenuItem_Click_Set, this.InternalId, value != null);
		}

		private ElectronInstanceProperty<Menu> submenu;
		public ElectronInstanceProperty<Menu> Submenu {
			get {
				if (this.submenu == null) {
					this.submenu = new(this.InternalId, x =>x.MenuItem_Submenu_Get,
						x => (requestId, id, value) => x.MenuItem_Submenu_Set(requestId, id, value?.InternalId ?? 0));
				}
				return this.submenu;
			}
		}

		private ElectronInstanceProperty<string> type;
		public ElectronInstanceProperty<string> Type {
			get {
				if (this.type == null) {
					this.type = new(this.InternalId, x => x.MenuItem_Type_Get,
						x => x.MenuItem_Type_Set);
				}
				return this.type;
			}
		}

		private ElectronInstanceProperty<string> role;
		public ElectronInstanceProperty<string> Role {
			get {
				if (this.role == null) {
					this.role = new(this.InternalId, x => x.MenuItem_Role_Get,
						x => x.MenuItem_Role_Set);
				}
				return this.role;
			}
		}

		private ElectronInstanceProperty<string> accelerator;
		public ElectronInstanceProperty<string> Accelerator {
			get {
				if (this.accelerator == null) {
					this.accelerator = new(this.InternalId, x => x.MenuItem_Accelerator_Get,
						x => x.MenuItem_Accelerator_Set);
				}
				return this.accelerator;
			}
		}

		private ElectronInstanceProperty<NativeImage> iconImage;
		public ElectronInstanceProperty<NativeImage> IconImage {
			get {
				if (this.iconImage == null) {
					this.iconImage = new(this.InternalId, x => x.MenuItem_IconImage_Get,
						x => (requestId, id, value) => x.MenuItem_IconImage_Set(requestId, id, value?.InternalId ?? 0));
				}
				return this.iconImage;
			}
		}

		private ElectronInstanceProperty<string> iconPath;
		public ElectronInstanceProperty<string> IconPath {
			get {
				if (this.iconPath == null) {
					this.iconPath = new(this.InternalId, x => x.MenuItem_IconPath_Get,
						x => x.MenuItem_IconPath_Set);
				}
				return this.iconPath;
			}
		}

		private ElectronInstanceProperty<string> sublabel;
		public ElectronInstanceProperty<string> Sublabel {
			get {
				if (this.sublabel == null) {
					this.sublabel = new(this.InternalId, x => x.MenuItem_Sublabel_Get,
						x => x.MenuItem_Sublabel_Set);
				}
				return this.sublabel;
			}
		}

		private ElectronInstanceProperty<string> toolTip;
		public ElectronInstanceProperty<string> ToolTip {
			get {
				if (this.toolTip == null) {
					this.toolTip = new(this.InternalId, x => x.MenuItem_ToolTip_Get,
						x => x.MenuItem_ToolTip_Set);
				}
				return this.toolTip;
			}
		}

		private ElectronInstanceProperty<bool> enabled;
		public ElectronInstanceProperty<bool> Enabled {
			get {
				if (this.enabled == null) {
					this.enabled = new(this.InternalId, x => x.MenuItem_Enabled_Get,
						x => x.MenuItem_Enabled_Set);
				}
				return this.enabled;
			}
		}

		private ElectronInstanceProperty<bool> visible;
		public ElectronInstanceProperty<bool> Visible {
			get {
				if (this.visible == null) {
					this.visible = new(this.InternalId, x => x.MenuItem_Visible_Get,
						x => x.MenuItem_Visible_Set);
				}
				return this.visible;
			}
		}

		private ElectronInstanceProperty<bool> @checked;
		public ElectronInstanceProperty<bool> Checked {
			get {
				if (this.@checked == null) {
					this.@checked = new(this.InternalId, x => x.MenuItem_Checked_Get,
						x => x.MenuItem_Checked_Set);
				}
				return this.@checked;
			}
		}

		private ElectronInstanceProperty<bool> registerAccelerator;
		public ElectronInstanceProperty<bool> RegisterAccelerator {
			get {
				if (this.registerAccelerator == null) {
					this.registerAccelerator = new(this.InternalId, x => x.MenuItem_RegisterAccelerator_Get,
						x => x.MenuItem_RegisterAccelerator_Set);
				}
				return this.registerAccelerator;
			}
		}

		private ElectronInstanceProperty<SharingItem> sharingItem;
		public ElectronInstanceProperty<SharingItem> SharingItem {
			get {
				if (this.sharingItem == null) {
					this.sharingItem = new(this.InternalId, x => x.MenuItem_SharingItem_Get,
						x => x.MenuItem_SharingItem_Set);
				}
				return this.sharingItem;
			}
		}

		private ElectronInstanceProperty<int> commandId;
		public ElectronInstanceProperty<int> CommandId {
			get {
				if (this.commandId == null) {
					this.commandId = new(this.InternalId, x => x.MenuItem_CommandId_Get,
						x => x.MenuItem_CommandId_Set);
				}
				return this.commandId;
			}
		}

		private ElectronInstanceProperty<Menu> menu;
		public ElectronInstanceProperty<Menu> Menu {
			get {
				if (this.menu == null) {
					this.menu = new(this.InternalId, x => x.MenuItem_Menu_Get,
						x => (requestId, id, value) => x.MenuItem_Menu_Set(requestId, id, value?.InternalId ?? 0));
				}
				return this.menu;
			}
		}
	}
}