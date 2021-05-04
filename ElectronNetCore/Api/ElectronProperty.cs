using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronReadOnlyProperty<TRet, TDto> {
		internal ElectronReadOnlyProperty(Func<IElectronInterface, Func<int, Task>> getter, Func<TDto, TRet> getTransformer) {
			this.getter = getter;
			this.getTransformer = getTransformer;
		}
		private readonly Func<IElectronInterface, Func<int, Task>> getter;
		private readonly Func<TDto, TRet> getTransformer;

		public async Task<TRet> GetAsync() =>
			this.getTransformer(await Electron.FuncAsync<TDto>(this.getter));
	}

	public class ElectronReadOnlyProperty<T> : ElectronReadOnlyProperty<T, T> {
		internal ElectronReadOnlyProperty(Func<IElectronInterface, Func<int, Task>> getter) : base(getter, x => x) { }
	}

	public class ElectronProperty<T> : ElectronReadOnlyProperty<T> {
		internal ElectronProperty(Func<IElectronInterface, Func<int, Task>> getter, Func<IElectronInterface, Func<int, T, Task>> setter) : base(getter) {
			this.setter = setter;
		}
		private readonly Func<IElectronInterface, Func<int, T, Task>> setter;

		public Task SetAsync(T value) =>
			Electron.ActionAsync(this.setter, value);
	}


	public class ElectronProperty<TRet, TDto> : ElectronReadOnlyProperty<TRet, TDto> {
		internal ElectronProperty(Func<IElectronInterface, Func<int, Task>> getter, Func<TDto, TRet> getTransformer,
			Func<IElectronInterface, Func<int, TDto, Task>> setter, Func<TRet, TDto> setTransformer) : base(getter, getTransformer) {

			this.setter = setter;
			this.setTransformer = setTransformer;
		}
		private readonly Func<IElectronInterface, Func<int, TDto, Task>> setter;
		private readonly Func<TRet, TDto> setTransformer;

		public Task SetAsync(TRet value) =>
			Electron.ActionAsync(this.setter, this.setTransformer(value));
	}

	public class ElectronInstanceReadOnlyProperty<TRet, TDto> {
		internal ElectronInstanceReadOnlyProperty(int id, Func<IElectronInterface, Func<int, int, Task>> getter, Func<TDto, TRet> getTransformer) {
			this.id = id;
			this.getter = getter;
			this.getTransformer = getTransformer;
		}
		private readonly Func<IElectronInterface, Func<int, int, Task>> getter;
		private readonly Func<TDto, TRet> getTransformer;
		protected int id;

		public async Task<TRet> GetAsync() =>
			this.getTransformer(await Electron.FuncAsync<TDto, int>(this.getter, this.id));
	}

	public class ElectronInstanceReadOnlyProperty<T> : ElectronInstanceReadOnlyProperty<T, T> {
		internal ElectronInstanceReadOnlyProperty(int id, Func<IElectronInterface, Func<int, int, Task>> getter) : base(id, getter, x => x) { }
	}

	public class ElectronInstanceProperty<T> : ElectronInstanceReadOnlyProperty<T> {
		internal ElectronInstanceProperty(int id, Func<IElectronInterface, Func<int, int, Task>> getter, Func<IElectronInterface, Func<int, int, T, Task>> setter) : base(id, getter) {
			this.setter = setter;
		}
		private readonly Func<IElectronInterface, Func<int, int, T, Task>> setter;

		public Task SetAsync(T value) =>
			Electron.ActionAsync(this.setter, this.id, value);
	}


	public class ElectronInstanceProperty<TRet, TDto> : ElectronInstanceReadOnlyProperty<TRet, TDto> {
		internal ElectronInstanceProperty(int id, Func<IElectronInterface, Func<int, int, Task>> getter, Func<TDto, TRet> getTransformer,
			Func<IElectronInterface, Func<int, int, TDto, Task>> setter, Func<TRet, TDto> setTransformer) : base(id, getter, getTransformer) {

			this.setter = setter;
			this.setTransformer = setTransformer;
		}
		private readonly Func<IElectronInterface, Func<int, int, TDto, Task>> setter;
		private readonly Func<TRet, TDto> setTransformer;

		public Task SetAsync(TRet value) =>
			Electron.ActionAsync(this.setter, this.id, this.setTransformer(value));
	}
}
