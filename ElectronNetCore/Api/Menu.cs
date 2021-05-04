using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Menu_Ctor(int requestId, int id);
		Task Menu_SetApplicationMenu(int requestId, int id, int menu);
		Task Menu_GetApplicationMenu(int requestId, int id);
		Task Menu_SendActionToFirstResponder(int requestId, int id, string action);
		Task Menu_BuildFromTemplate(int requestId, int id, object[] template);

		Task Menu_Popup(int requestId, int id, PopupOptionsDto options);
		Task Menu_ClosePopup(int requestId, int id, int browserWindow);
		Task Menu_Append(int requestId, int id, int menuItem);
		Task Menu_GetMenuItemById(int requestId, int menu, string id);
		Task Menu_Insert(int requrdId, int id, int pos, int menuItem);

		Task Menu_Items_Get(int requestId, int id);
		Task Menu_Items_Set(int requestId, int id, int[] items);
	}

	internal partial class ElectronHub {
		public Task Menu_MenuWillShow_Event(int id) =>
			ElectronDisposable.FromId<Menu>(id)?.OnMenuWillShow() ?? Task.CompletedTask;
		public Task Menu_MenuWillClose_Event(int id) =>
			ElectronDisposable.FromId<Menu>(id)?.OnMenuWillClose() ?? Task.CompletedTask;

		public Task Menu_Popup_Closed(int id, int requestId) =>
			ElectronDisposable.FromId<Menu>(id)?.OnPopupClosed(requestId) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Menu : ElectronDisposable<Menu> {
		public static Task<Menu> CreateAsync() =>
			Electron.FuncAsync<Menu, int>(x => x.Menu_Ctor, 0);

		public static Task SetApplicationMenuAsync(Menu menu) =>
			Electron.ActionAsync(x => x.Menu_SetApplicationMenu, 0, menu?.InternalId ?? 0);
		public static Task<Menu> GetApplicationMenuAsync() =>
			Electron.FuncAsync<Menu, int>(x => x.Menu_GetApplicationMenu, 0);
		public static Task SendActionToFirstResponderAsync(string action) =>
			Electron.ActionAsync(x => x.Menu_SendActionToFirstResponder, 0, action);
		public async static Task<Menu> BuildFromTemplate(object[] template) {
			Menu menu = await Electron.FuncAsync<Menu, int, object[]>(x => x.Menu_BuildFromTemplate, 0, template.Select<object, object>(x => {
				if (x is MenuItem menuItem) {
					return menuItem.Id;
				} else if (x is MenuItemConstructorOptions options) {
					return options.ToMenuItemConstructorOptionsDto();
				} else {
					throw new ArgumentException("Template must only have MenuItem and/or MenuItemConstructorOptions objects.", nameof(template));
				}
			}).ToArray());
			if (template.Any(x => x is MenuItemConstructorOptions options && options.Click != null)) {
				MenuItem[] items = await menu.Items.GetAsync();
				foreach ((MenuItem menuItem, MenuItemConstructorOptions options) in items
					.Zip(template)
					.OfType<(MenuItem, MenuItemConstructorOptions)>()
					.Where(x => x.Item2.Click != null)) {

					await menuItem.ClickSetAsync(options.Click);
				}
			}
			return menu;
		}

		internal Menu(int id) : base(id) { }

		private readonly Dictionary<int, Action> popupClosedCallbacks = new();
		internal Task OnPopupClosed(int requestId) {
			if (this.popupClosedCallbacks.TryGetValue(requestId, out Action callback)) {
				this.popupClosedCallbacks.Remove(requestId);
				callback();
			}
			return Task.CompletedTask;
		}
		public Task Popup(PopupOptions options) {
			int requestId = Electron.NextRequestId;
			if (options != null && options.Callback != null) {
				this.popupClosedCallbacks[requestId] = options.Callback;
			}
			return Electron.ActionAsync(requestId, x => x.Menu_Popup, this.InternalId, options?.ToPopupOptionsDto());
		}
		public Task ClosePopup(BrowserWindow browserWindow) =>
			Electron.ActionAsync(x => x.Menu_ClosePopup, this.InternalId, browserWindow?.Id ?? 0);
		public Task Append(MenuItem menuItem) =>
			Electron.ActionAsync(x => x.Menu_Append, this.InternalId, menuItem?.InternalId ?? 0);
		public Task<MenuItem> GetMenuItemById(string id) =>
			Electron.FuncAsync<MenuItem, int, string>(x => x.Menu_GetMenuItemById, this.InternalId, id);
		public Task Insert(int pos, MenuItem menuItem) =>
			Electron.ActionAsync(x => x.Menu_Insert, this.InternalId, pos, menuItem?.InternalId ?? 0);

		public event EventHandler MenuWillShow;
		internal Task OnMenuWillShow() {
			this.MenuWillShow?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler MenuWillClose;
		internal Task OnMenuWillClose() {
			this.MenuWillClose?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private ElectronProperty<MenuItem[], int[]> items;
		public ElectronProperty<MenuItem[], int[]> Items {
			get {
				if (this.items == null) {
					this.items = new(x => id => x.Menu_Items_Get(id, this.InternalId),
						x => x.Select(x => ElectronDisposable.FromId<MenuItem>(x)).ToArray(), x => (id, y) => x.Menu_Items_Set(id, this.InternalId, y),
						x => x.Select(x => x?.InternalId ?? 0).ToArray());
				}
				return this.items;
			}
		} 
	}
}
