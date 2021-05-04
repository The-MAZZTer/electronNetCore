using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task ServiceWorkers_GetAllRunning(int requestId, int id);
		Task ServiceWorkers_GetFromVersionId(int requestId, int id, int versionId);
	}

	internal partial class ElectronHub {
		public Task ServiceWorkers_ConsoleMessage_Event(int id, MessageDetails messageDetails) =>
			ElectronDisposable.FromId<ServiceWorkers>(id)?.OnConsoleMessage(messageDetails) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ServiceWorkers : ElectronDisposable<ServiceWorkers> {
		internal ServiceWorkers(int id) : base(id) { }

		public event EventHandler<MessageDetailsEventArgs> ConsoleMessage;
		internal Task OnConsoleMessage(MessageDetails messageDetails) {
			this.ConsoleMessage?.Invoke(this, new(messageDetails));
			return Task.CompletedTask;
		}

		public Task<Dictionary<int, ServiceWorkerInfo>> GetAllRunningAsync() =>
			Electron.FuncAsync<Dictionary<int, ServiceWorkerInfo>, int>(x => x.ServiceWorkers_GetAllRunning, this.InternalId);
		public Task<ServiceWorkerInfo> GetFromVersionId(int versionId) =>
			Electron.FuncAsync<ServiceWorkerInfo, int, int>(x => x.ServiceWorkers_GetFromVersionId, this.InternalId, versionId);
	}
}
