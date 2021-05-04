using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task WebFrameMain_FromId(int requestId, WebFrameMainId id, int processId, int routingId);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class WebFrameMain : IEquatable<WebFrameMain> {
		public static Task<WebFrameMain> FromIdAsync(int processId, int routingId) =>
			Electron.FuncAsync<WebFrameMain, WebFrameMainId, int, int>(x => x.WebFrameMain_FromId, null, processId, routingId);
		internal static WebFrameMain FromId(WebFrameMainId id) => id == null ? null :
			new WebFrameMain(id.ProcessId, id.RoutingId);

		internal WebFrameMain(int processId, int routingId) {
			this.ProcessId = processId;
			this.RoutingId = routingId;
		}
		public int ProcessId { get; }
		public int RoutingId { get; }

		public bool Equals(WebFrameMain other) => this.ProcessId == other.ProcessId && this.RoutingId == other.RoutingId;
	}
}
