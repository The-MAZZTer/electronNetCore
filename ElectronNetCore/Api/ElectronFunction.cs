using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronFunction : ElectronDisposable<ElectronFunction>, IDisposable, IAsyncDisposable {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync() =>
			Electron.ActionAsync(x => x.Function_Invoke, this.Id, Array.Empty<object>());
	}

	public class ElectronFunction<T> : ElectronDisposable<ElectronFunction<T>>, IDisposable, IAsyncDisposable {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync(T arg) =>
			Electron.ActionAsync(x => x.Function_Invoke, this.Id, new object[] { arg });
	}

	public class ElectronFunction<TArg1, TArg2> : ElectronDisposable<ElectronFunction<TArg1, TArg2>>, IDisposable, IAsyncDisposable {
		internal ElectronFunction(int id) : base(id) { }

		public Task InvokeAasync(TArg1 arg1, TArg2 arg2) =>
			Electron.ActionAsync(x => x.Function_Invoke, this.Id, new object[] { arg1, arg2 });
	}
}
