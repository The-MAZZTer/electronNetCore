using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Function_Invoke(int requestId, int id, object[] args);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronFunction : ElectronDisposable<ElectronFunction> {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync() =>
			Electron.ActionAsync(x => x.Function_Invoke, this.InternalId, Array.Empty<object>());
	}

	public class ElectronFunction<T> : ElectronDisposable<ElectronFunction<T>> {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync(T arg) =>
			Electron.ActionAsync(x => x.Function_Invoke, this.InternalId, new object[] { arg });
	}

	public class ElectronFunction<TArg1, TArg2> : ElectronDisposable<ElectronFunction<TArg1, TArg2>> {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync(TArg1 arg1, TArg2 arg2) =>
			Electron.ActionAsync(x => x.Function_Invoke, this.InternalId, new object[] { arg1, arg2 });
	}
}
