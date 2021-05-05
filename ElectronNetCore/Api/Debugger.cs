using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Debugger_Attach(int requestId, int id, string protocolVersion);
		Task Debugger_IsAttached(int requestId, int id);
		Task Debugger_Detach(int requestId, int id);
		Task Debugger_SendCommand(int requestId, int id, string method, object commandParams, string sessionId);
	}

	internal partial class ElectronHub {
		public Task Debugger_Detach_Event(int id) =>
			ElectronDisposable.FromId<Debugger>(id)?.OnDetach() ?? Task.CompletedTask;
		public Task Debugger_Message_Event(int id, string method, object @params, string sessionId) =>
			ElectronDisposable.FromId<Debugger>(id)?.OnMessage(method, @params, sessionId) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Debugger : ElectronDisposable<Debugger> {
		internal Debugger(int id) : base(id) { }

		public event EventHandler DetachEvent;
		internal Task OnDetach() {
			this.DetachEvent?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<DebuggerMessageEventArgs> Message;
		internal Task OnMessage(string method, object @params, string sessionId) {
			this.Message?.Invoke(this, new(method, @params, sessionId));
			return Task.CompletedTask;
		}

		public Task AttachAsync(string protocolVersion = null) =>
			Electron.ActionAsync(x => x.Debugger_Attach, this.InternalId, protocolVersion);
		public Task<bool> IsAttachedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Debugger_IsAttached, this.InternalId);
		public Task DetachAsync() =>
			Electron.ActionAsync(x => x.Debugger_Detach, this.InternalId);
		public Task SendCommandAsync(string method, object commandParams = null, string sessionId = null) =>
			Electron.ActionAsync(x => x.Debugger_SendCommand, this.InternalId, method, commandParams, sessionId);
		public Task<T> SendCommandAsync<T>(string method, object commandParams = null, string sessionId = null) =>
			Electron.FuncAsync<T, int, string, object, string>(x => x.Debugger_SendCommand, this.InternalId, method, commandParams, sessionId);
	}
}
