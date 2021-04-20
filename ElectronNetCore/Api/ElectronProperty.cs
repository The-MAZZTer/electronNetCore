using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronReadOnlyProperty<T> {
		internal ElectronReadOnlyProperty(Func<IElectronInterface, Func<int, Task>> getter) {
			this.getter = getter;
		}
		private readonly Func<IElectronInterface, Func<int, Task>> getter;

		public Task<T> GetAsync() =>
			Electron.FuncAsync<T>(this.getter);
	}

	public class ElectronProperty<T> : ElectronReadOnlyProperty<T> {
		internal ElectronProperty(Func<IElectronInterface, Func<int, Task>> getter, Func<IElectronInterface, Func<int, T, Task>> setter) : base(getter) {
			this.setter = setter;
		}
		private readonly Func<IElectronInterface, Func<int, T, Task>> setter;

		public Task SetAsync(T value) =>
			Electron.ActionAsync(this.setter, value);
	}
}
