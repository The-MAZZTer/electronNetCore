using System.Threading.Tasks;
using System;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronAutoUpdater {
		internal ElectronAutoUpdater() { }

		public event EventHandler<ErrorEventArgs> Error;
		internal Task OnError(Error error) {
			this.Error?.Invoke(this, new(error));
			return Task.CompletedTask;
		}

		public event EventHandler CheckingForUpdate;
		internal Task OnCheckingForUpdate() {
			this.CheckingForUpdate?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler UpdateAvailable;
		internal Task OnUpdateAvailable() {
			this.UpdateAvailable?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler UpdateNotAvailable;
		internal Task OnUpdateNotAvailable() {
			this.UpdateNotAvailable?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<AutoUpdaterUpdateDownloadedEventArgs> UpdateDownloaded;
		internal Task OnUpdateDownloaded(string releaseNotes, string releaseName, DateTime releaseDate, string updateUrl) {
			this.UpdateDownloaded?.Invoke(this, new(releaseNotes, releaseName, releaseDate, updateUrl));
			return Task.CompletedTask;
		}

		public event EventHandler BeforeQuitForUpdate;
		internal Task OnBeforeQuitForUpdate() {
			this.BeforeQuitForUpdate?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public Task SetFeedUrlAsync(FeedUrlOptions options) =>
			Electron.ActionAsync(x => x.AutoUpdater_SetFeedUrl, options);
		public Task<string> GetFeedUrlAsync() =>
			Electron.FuncAsync<string>(x => x.AutoUpdater_GetFeedUrl);
		public Task CheckForUpdateAsync() =>
			Electron.ActionAsync(x => x.AutoUpdater_CheckForUpdates);
		public Task QuitAndInstallAsync() =>
			Electron.ActionAsync(x => x.AutoUpdater_QuitAndInstall);
	}
}