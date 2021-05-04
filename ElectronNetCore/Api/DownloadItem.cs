using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task DownloadItem_SetSavePath(int requestId, int id, string path);
		Task DownloadItem_GetSavePath(int requestId, int id);
		Task DownloadItem_SetSaveDialogOptions(int requestId, int id, SaveDialogOptions options);
		Task DownloadItem_GetSaveDialogOptions(int requestId, int id);
		Task DownloadItem_Pause(int requestId, int id);
		Task DownloadItem_IsPaused(int requestId, int id);
		Task DownloadItem_Resume(int requestId, int id);
		Task DownloadItem_CanResume(int requestId, int id);
		Task DownloadItem_Cancel(int requestId, int id);
		Task DownloadItem_GetUrl(int requestId, int id);
		Task DownloadItem_GetMimeType(int requestId, int id);
		Task DownloadItem_HasUserGesture(int requestId, int id);
		Task DownloadItem_GetFilename(int requestId, int id);
		Task DownloadItem_GetTotalBytes(int requestId, int id);
		Task DownloadItem_GetReceivedBytes(int requestId, int id);
		Task DownloadItem_GetContentDisposition(int requestId, int id);
		Task DownloadItem_GetState(int requestId, int id);
		Task DownloadItem_GetUrlChain(int requestId, int id);
		Task DownloadItem_GetLastModifiedTime(int requestId, int id);
		Task DownloadItem_GetETag(int requestId, int id);
		Task DownloadItem_GetStartTime(int requestId, int id);

		Task DownloadItem_SavePath_Get(int requestId, int id);
		Task DownloadItem_SavePath_Set(int requestId, int id, string value);
	}

	internal partial class ElectronHub {
		public Task DownloadItem_Updated_Event(int id, string state) =>
			ElectronDisposable.FromId<DownloadItem>(id)?.OnUpdated(state) ?? Task.CompletedTask;
		public Task DownloadItem_Done_Event(int id, string state) =>
			ElectronDisposable.FromId<DownloadItem>(id)?.OnDone(state) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class DownloadItem : ElectronDisposable<DownloadItem> {
		internal DownloadItem(int id) : base(id) { }

		public event EventHandler<DownloadItemEventArgs> Updated;
		internal Task OnUpdated(string state) {
			this.Updated?.Invoke(this, new(state));
			return Task.CompletedTask;
		}

		public event EventHandler<DownloadItemEventArgs> Done;
		internal Task OnDone(string state) {
			this.Done?.Invoke(this, new(state));
			return Task.CompletedTask;
		}

		public Task SetSavePathAsync(string path) =>
			Electron.ActionAsync(x => x.DownloadItem_SetSavePath, this.InternalId, path);
		public Task<string> GetSavePathAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetSavePath, this.InternalId);
		public Task SetSaveDialogOptionsAsync(SaveDialogOptions options) =>
			Electron.ActionAsync(x => x.DownloadItem_SetSaveDialogOptions, this.InternalId, options);
		public Task<SaveDialogOptions> GetSaveDialogOptionsAsync() =>
			Electron.FuncAsync<SaveDialogOptions, int>(x => x.DownloadItem_GetSaveDialogOptions, this.InternalId);
		public Task PauseAsync() =>
			Electron.ActionAsync(x => x.DownloadItem_Pause, this.InternalId);
		public Task ResumeAsync() =>
			Electron.ActionAsync(x => x.DownloadItem_Resume, this.InternalId);
		public Task<bool> CanResumeAsync() =>
			Electron.FuncAsync<bool, int>(x => x.DownloadItem_CanResume, this.InternalId);
		public Task CancelAsync() =>
			Electron.ActionAsync(x => x.DownloadItem_Cancel, this.InternalId);
		public Task<string> GetUrlAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetUrl, this.InternalId);
		public Task<string> GetMimeTypeAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetMimeType, this.InternalId);
		public Task<bool> HasUserGestureAsync() =>
			Electron.FuncAsync<bool, int>(x => x.DownloadItem_HasUserGesture, this.InternalId);
		public Task<string> GetFilenameAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetFilename, this.InternalId);
		public Task<long> GetTotalBytesAsync() =>
			Electron.FuncAsync<long, int>(x => x.DownloadItem_GetTotalBytes, this.InternalId);
		public Task<long> GetReceivedBytesAsync() =>
			Electron.FuncAsync<long, int>(x => x.DownloadItem_GetReceivedBytes, this.InternalId);
		public Task<string> GetContentDispositionAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetContentDisposition, this.InternalId);
		public Task<string> GetStateAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetState, this.InternalId);
		public Task<string[]> GetUrlChainAsync() =>
			Electron.FuncAsync<string[], int>(x => x.DownloadItem_GetUrlChain, this.InternalId);
		public Task<string> GetLastModifiedTimeAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetLastModifiedTime, this.InternalId);
		public Task<string> GetETagAsync() =>
			Electron.FuncAsync<string, int>(x => x.DownloadItem_GetETag, this.InternalId);
		public Task<double> GetStartTimeAsync() =>
			Electron.FuncAsync<double, int>(x => x.DownloadItem_GetStartTime, this.InternalId);
		public async Task<DateTime> GetStartTimeDateTimeAsync() =>
			DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(await this.GetStartTimeAsync()), DateTimeKind.Utc);

		private ElectronInstanceProperty<string> savePath;
		public ElectronInstanceProperty<string> SavePath {
			get {
				if (this.savePath == null) {
					this.savePath = new(this.InternalId, x => x.DownloadItem_SavePath_Get,
						x => x.DownloadItem_SavePath_Set);
				}
				return this.savePath;
			}
		}
	}
}
