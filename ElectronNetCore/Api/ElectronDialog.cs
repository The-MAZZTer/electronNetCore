﻿using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronDialog {
		internal ElectronDialog() { }

		public Task<OpenDialogReturnValue> ShowOpenDialogAsync(OpenDialogOptions options) =>
			this.ShowOpenDialogAsync(null, options);
		public Task<OpenDialogReturnValue> ShowOpenDialogAsync(BrowserWindow browserWindow, OpenDialogOptions options) =>
			Electron.FuncAsync<OpenDialogReturnValue, int, OpenDialogOptions>(x => x.Dialog_ShowOpenDialog, browserWindow?.Id ?? 0, options);
		public Task<SaveDialogReturnValue> ShowSaveDialogAsync(SaveDialogOptions options) =>
			this.ShowSaveDialogAsync(null, options);
		public Task<SaveDialogReturnValue> ShowSaveDialogAsync(BrowserWindow browserWindow, SaveDialogOptions options) =>
			Electron.FuncAsync<SaveDialogReturnValue, int, SaveDialogOptions>(x => x.Dialog_ShowSaveDialog, browserWindow?.Id ?? 0, options);
		public Task<MessageBoxReturnValue> ShowMessageBoxAsync(MessageBoxOptions options) =>
			this.ShowMessageBoxAsync(null, options);
		public Task<MessageBoxReturnValue> ShowMessageBoxAsync(BrowserWindow browserWindow, MessageBoxOptions options) =>
			Electron.FuncAsync<MessageBoxReturnValue, int, MessageBoxOptionsDto>(x => x.Dialog_ShowMessageBox, browserWindow?.Id ?? 0, options?.ToMessageBoxOptionsDto());
		public Task ShowErrorBoxAsync(string title, string content) =>
			Electron.ActionAsync(x => x.Dialog_ShowErrorBox, title, content);
		public Task ShowCertificateTrustDialogAsync(CertificateTrustDialogOptions options) =>
			this.ShowCertificateTrustDialogAsync(null, options);
		public Task ShowCertificateTrustDialogAsync(BrowserWindow browserWindow, CertificateTrustDialogOptions options) =>
			Electron.ActionAsync(x => x.Dialog_ShowCertificateTrustDialog, browserWindow?.Id ?? 0, options);
	}
}