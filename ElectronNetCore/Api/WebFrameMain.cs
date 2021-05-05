using MZZT.ElectronNetCore.Api;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task WebFrameMain_FromId(int requestId, WebFrameMainId id, int processId, int routingId);

		Task WebFrameMain_ExecuteJavaScript(int requestId, WebFrameMainId id, string code, bool userGesture);
		Task WebFrameMain_Reload(int requestId, WebFrameMainId id);
		Task WebFrameMain_Send(int requestId, WebFrameMainId id, string channel, object[] args);
		Task WebFrameMain_PostMessage(int requestId, WebFrameMainId id, string channel, object message, int[] transfer);

		Task WebFrameMain_Url_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_Top_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_Parent_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_Frames_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_FramesInSubtree_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_FrameTreeNodeId_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_Name_Get(int requestId, WebFrameMainId id);
		Task WebFrameMain_OsProcessId_Get(int requestId, WebFrameMainId id);
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
		public bool Equals(WebFrameMain other) => this.ProcessId == other.ProcessId && this.RoutingId == other.RoutingId;

		public Task ExecuteJavaScriptAsync(string code, bool userGesture = false) =>
			Electron.ActionAsync(x => x.WebFrameMain_ExecuteJavaScript, this.Id, code, userGesture);
		public Task<T> ExecuteJavaScriptAsync<T>(string code, bool userGesture = false) =>
			Electron.FuncAsync<T, WebFrameMainId, string, bool>(x => x.WebFrameMain_ExecuteJavaScript, this.Id, code, userGesture);
		public Task ReloadAsync() =>
			Electron.ActionAsync(x => x.WebFrameMain_Reload, this.Id);
		public Task SendAsync(string channel, params object[] args) =>
			Electron.ActionAsync(x => x.WebFrameMain_Send, this.Id, channel, args);
		public Task PostMessageAsync(string channel, object message, MessagePortMain[] transfer = null) =>
			Electron.ActionAsync(x => x.WebFrameMain_PostMessage, this.Id, channel, message, transfer?.Select(x => x.InternalId).ToArray());

		private ElectronInstanceReadOnlyProperty<string, string, WebFrameMainId> url;
		public ElectronInstanceReadOnlyProperty<string, string, WebFrameMainId> Url {
			get {
				if (this.url == null) {
					this.url = new(this.Id, x => x.WebFrameMain_Url_Get, x => x);
				}
				return this.url;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebFrameMain, WebFrameMain, WebFrameMainId> top;
		public ElectronInstanceReadOnlyProperty<WebFrameMain, WebFrameMain, WebFrameMainId> Top {
			get {
				if (this.top == null) {
					this.top = new(this.Id, x => x.WebFrameMain_Top_Get, x => x);
				}
				return this.top;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebFrameMain, WebFrameMain, WebFrameMainId> parent;
		public ElectronInstanceReadOnlyProperty<WebFrameMain, WebFrameMain, WebFrameMainId> Parent {
			get {
				if (this.parent == null) {
					this.parent = new(this.Id, x => x.WebFrameMain_Parent_Get, x => x);
				}
				return this.parent;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebFrameMain[], WebFrameMainId[], WebFrameMainId> frames;
		public ElectronInstanceReadOnlyProperty<WebFrameMain[], WebFrameMainId[], WebFrameMainId> Frames {
			get {
				if (this.frames == null) {
					this.frames = new(this.Id, x => x.WebFrameMain_Frames_Get, x => x?.Select(x => FromId(x)).ToArray());
				}
				return this.frames;
			}
		}
		private ElectronInstanceReadOnlyProperty<WebFrameMain[], WebFrameMainId[], WebFrameMainId> framesInSubtree;
		public ElectronInstanceReadOnlyProperty<WebFrameMain[], WebFrameMainId[], WebFrameMainId> FramesInSubtree {
			get {
				if (this.framesInSubtree == null) {
					this.framesInSubtree = new(this.Id, x => x.WebFrameMain_FramesInSubtree_Get, x => x?.Select(x => FromId(x)).ToArray());
				}
				return this.framesInSubtree;
			}
		}
		private ElectronInstanceReadOnlyProperty<int, int, WebFrameMainId> frameTreeNodeId;
		public ElectronInstanceReadOnlyProperty<int, int, WebFrameMainId> FrameTreeNodeId {
			get {
				if (this.frameTreeNodeId == null) {
					this.frameTreeNodeId = new(this.Id, x => x.WebFrameMain_FrameTreeNodeId_Get, x => x);
				}
				return this.frameTreeNodeId;
			}
		}
		private ElectronInstanceReadOnlyProperty<string, string, WebFrameMainId> name;
		public ElectronInstanceReadOnlyProperty<string, string, WebFrameMainId> Name {
			get {
				if (this.name == null) {
					this.name = new(this.Id, x => x.WebFrameMain_Name_Get, x => x);
				}
				return this.name;
			}
		}

		private ElectronInstanceReadOnlyProperty<int, int, WebFrameMainId> osProcessId;
		public ElectronInstanceReadOnlyProperty<int, int, WebFrameMainId> OsProcessId {
			get {
				if (this.osProcessId == null) {
					this.osProcessId = new(this.Id, x => x.WebFrameMain_OsProcessId_Get, x => x);
				}
				return this.osProcessId;
			}
		}
		internal WebFrameMainId Id => new(this);
		public int ProcessId { get; }
		public int RoutingId { get; }

	}
}
