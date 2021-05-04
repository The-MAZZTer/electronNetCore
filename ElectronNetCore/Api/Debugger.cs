using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	namespace MZZT.ElectronNetCore {
		public partial interface IElectronInterface {
			Task Debugger_Attach(int requestId, int id, string protocolVersion);
			Task Debugger_IsAttached(int requestId, int id);
			Task Debugger_Detach(int requestId, int id);
			Task Debugger_SendCommand(int requestId, int id, string method, object commandParams, string sessionId);
		}

		internal partial class ElectronHub {
			/*public Task Debugger_Detach_Event(int id) =>
				ElectronDisposable.FromId<Debugger>(id)?.OnDetach() ?? Task.CompletedTask;
			public Task Debugger_Message_Event(int id, string method, object @params, string sessionId) =>
				ElectronDisposable.FromId<Debugger>(id)?.OnMessage(method, @params, sessionId) ?? Task.CompletedTask;*/
		}
	}

	public class Debugger : ElectronDisposable<Debugger> {
		internal Debugger(int id) : base(id) { }
	}
}
