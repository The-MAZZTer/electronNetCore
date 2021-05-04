using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task AppDock_Bounce(int requestId, string type);
		Task AppDock_CancelBounce(int requestId, int id);
		Task AppDock_DownloadFinished(int requestId, string filePath);
		Task AppDock_SetBadge(int requestId, string text);
		Task AppDock_GetBadge(int requestId);
		Task AppDock_Hide(int requestId);
		Task AppDock_Show(int requestId);
		Task AppDock_IsVisible(int requestId);
		Task AppDock_SetMenu(int requestId, int menuId);
		Task AppDock_GetMenu(int requestId);
		Task AppDock_SetIconImage(int requestId, int imageId);
		Task AppDock_SetIconPath(int requestId, string image);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronAppDock {
		internal ElectronAppDock() { }

		public Task<int> BounceAsync(string type = null) =>
			Electron.FuncAsync<int, string>(x => x.AppDock_Bounce, type);
		public Task CancelBounceAsync(int id) =>
			Electron.ActionAsync(x => x.AppDock_CancelBounce, id);
		public Task DownloadFinishedAsync(string filePath) =>
			Electron.ActionAsync(x => x.AppDock_DownloadFinished, filePath);
		public Task SetBadgeAsync(string text) =>
			Electron.ActionAsync(x => x.AppDock_SetBadge, text);
		public Task<string> GetBadgeAsync() =>
			Electron.FuncAsync<string>(x => x.AppDock_GetBadge);
		public Task HideAsync() =>
			Electron.ActionAsync(x => x.AppDock_Hide);
		public Task ShowAsync() =>
			Electron.ActionAsync(x => x.AppDock_Show);
		public Task<bool> IsVisibleAsync() =>
			Electron.FuncAsync<bool>(x => x.AppDock_IsVisible);
		public Task SetMenuAsync(Menu menu) =>
			Electron.ActionAsync(x => x.AppDock_SetMenu, menu.InternalId);
		public Task<Menu> GetMenuAsync() =>
			Electron.FuncAsync<Menu>(x => x.AppDock_GetMenu);
		public Task SetIconAsync(NativeImage image) =>
			Electron.ActionAsync(x => x.AppDock_SetIconImage, image.InternalId);
		public Task SetIconAsync(string image) =>
			Electron.ActionAsync(x => x.AppDock_SetIconPath, image);
	}
}
