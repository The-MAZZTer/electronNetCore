using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task NetLog_StartLogging(int requestId, int id, string path, StartLoggingOptions options);
		Task NetLog_StopLogging(int requestId, int id);

		Task NetLog_CurrentlyLogging_Get(int requestId, int id);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class NetLog : ElectronDisposable<NetLog> {
		internal NetLog(int id) : base(id) { }

		public Task StartLoggingAsync(string path, StartLoggingOptions options) =>
			Electron.ActionAsync(x => x.NetLog_StartLogging, this.InternalId, path, options);
		public Task StopLoggingAsync() =>
			Electron.ActionAsync(x => x.NetLog_StopLogging, this.InternalId);

		private ElectronInstanceReadOnlyProperty<bool> currentlyLogging;
		public ElectronInstanceReadOnlyProperty<bool> CurrentlyLogging {
			get {
				if (this.currentlyLogging == null) {
					this.currentlyLogging = new(this.InternalId, x => x.NetLog_CurrentlyLogging_Get);
				}
				return this.currentlyLogging;
			}
		}
	}
}
