using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task AutoUpdater_SetFeedUrl(int requestId, FeedUrlOptions options);
		Task AutoUpdater_GetFeedUrl(int requestId);
		Task AutoUpdater_CheckForUpdates(int requestId);
		Task AutoUpdater_QuitAndInstall(int requestId);
	}

	internal partial class ElectronHub {
		public Task AutoUpdater_Error_Event(Error error) =>
			Api.Electron.AutoUpdater.OnError(error);
		public Task AutoUpdater_CheckingForUpdate_Event() =>
			Api.Electron.AutoUpdater.OnCheckingForUpdate();
		public Task AutoUpdater_UpdateAvailable_Event() =>
			Api.Electron.AutoUpdater.OnUpdateAvailable();
		public Task AutoUpdater_UpdateNotAvailable_Event() =>
			Api.Electron.AutoUpdater.OnUpdateNotAvailable();
		public Task AutoUpdater_UpdateDownloaded_Event(string releaseNotes, string releaseName, double releaseDate, string updateUrl) =>
			Api.Electron.AutoUpdater.OnUpdateDownloaded(releaseNotes, releaseName, DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromMilliseconds(releaseDate), DateTimeKind.Utc), updateUrl);
		public Task AutoUpdater_BeforeQuitForUpdate_Event() =>
			Api.Electron.AutoUpdater.OnBeforeQuitForUpdate();
	}
}

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