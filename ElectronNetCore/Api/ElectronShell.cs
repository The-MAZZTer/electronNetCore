using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Shell_ShowItemInFolder(int requestId, string fullPath);
		Task Shell_OpenPath(int requestId, string path);
		Task Shell_OpenExternal(int requestId, string url, OpenExternalOptions options);
		Task Shell_TrashItem(int requestId, string path);
		Task Shell_Beep(int requestId);
		Task Shell_WriteShortcutLink(int requestId, string shortcutPath, string operation, ShortcutDetails options);
		Task Shell_ReadShortcutLink(int requestId, string shortcutPath);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronShell {
		internal ElectronShell() { }

		public Task ShowItemInFolderAsync(string fullPath) =>
			Electron.ActionAsync(x => x.Shell_ShowItemInFolder, fullPath);
		public Task<string> OpenPathAsync(string path) =>
			Electron.FuncAsync<string, string>(x => x.Shell_OpenPath, path);
		public Task OpenExternalAsync(string url, OpenExternalOptions options = null) =>
			Electron.ActionAsync(x => x.Shell_OpenExternal, url, options);
		public Task TrashItemAsync(string path) =>
			Electron.ActionAsync(x => x.Shell_TrashItem, path);
		public Task BeepAsync() =>
			Electron.ActionAsync(x => x.Shell_Beep);
		public Task<bool> WriteShortcutLinkAsync(string shortcutPath, ShortcutDetails options) =>
			this.WriteShortcutLinkAsync(shortcutPath, ShortcutOperations.Create, options);
		public Task<bool> WriteShortcutLinkAsync(string shortcutPath, string operation, ShortcutDetails options) =>
			Electron.FuncAsync<bool, string, string, ShortcutDetails>(x => x.Shell_WriteShortcutLink, shortcutPath, operation, options);
		public Task<ShortcutDetails> ReadShortcutLinkAsync(string shortcutPath) =>
			Electron.FuncAsync<ShortcutDetails, string>(x => x.Shell_ReadShortcutLink, shortcutPath);
	}
}
