using MZZT.ElectronNetCore.Api;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task MessagePortMain_PostMessage(int requestId, int id, object message, int[] transfer);
		Task MessagePortMain_Start(int requestId, int id);
		Task MessagePortMain_Close(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task MessagePortMain_Message_Event(int id, object data, int[] ports) =>
			ElectronDisposable.FromId<MessagePortMain>(id)?.OnMessage(data, ports.Select(x => ElectronDisposable.FromId<MessagePortMain>(x)).ToArray());
		public Task MessagePortMain_Close_Event(int id) =>
			ElectronDisposable.FromId<MessagePortMain>(id)?.OnClose();
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class MessagePortMain : ElectronDisposable<MessagePortMain> {
		internal MessagePortMain(int id) : base(id) { }

		public Task PostMessageAsync(object message, MessagePortMain[] transfer = null) =>
			Electron.ActionAsync(x => x.MessagePortMain_PostMessage, this.InternalId, message, transfer?.Select(x => x.InternalId).ToArray());
		public Task StartAsync() =>
			Electron.ActionAsync(x => x.MessagePortMain_Start, this.InternalId);
		public Task CloseAsync() =>
			Electron.ActionAsync(x => x.MessagePortMain_Close, this.InternalId);

		public event EventHandler<MessagePortMainMessageEventArgs> Message;
		internal Task OnMessage(object data, MessagePortMain[] ports) {
			this.Message?.Invoke(this, new(data, ports));
			return Task.CompletedTask;
		}

		public event EventHandler Close;
		internal Task OnClose() {
			this.Close?.Invoke(this, new());
			return Task.CompletedTask;
		}
	}
}
