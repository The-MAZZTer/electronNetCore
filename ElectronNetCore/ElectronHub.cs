using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task DisposeObject(int id);
	}

	internal partial class ElectronHub : Hub<IElectronInterface> {
		private readonly ILogger<ElectronHub> logger;

		public static IElectronInterface Electron { get; private set; }

		public ElectronHub(ILogger<ElectronHub> logger) {
			this.logger = logger;
		}

		public async override Task OnConnectedAsync() {
			await base.OnConnectedAsync();

			this.logger.LogDebug("Electron connected to ASP.NET Core.");

			Electron = this.Clients.Caller;
		}

		public async override Task OnDisconnectedAsync(Exception exception) {
			await base.OnDisconnectedAsync(exception);

			this.logger.LogDebug("Electron disconnected from ASP.NET Core.");

			Electron = null;
		}

		public Task Error(int requestId, Error error) =>
			Api.Electron.OnError(requestId, error);
		public Task Return(int requestId, string value) =>
			Api.Electron.OnReturn(requestId, value);
	}
}
