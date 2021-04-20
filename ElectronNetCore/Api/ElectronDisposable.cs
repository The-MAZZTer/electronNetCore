using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MZZT.ElectronNetCore.Api {
	internal static class ElectronDisposable {
		internal static readonly Dictionary<int, object> instances = new();

		internal static object FromId(Type type, int id) {
			if (id <= 0) {
				return null;
			}
			return instances.GetValueOrDefault(id) ?? Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { id }, null);
		}
		internal static T FromId<T>(int id) where T : ElectronDisposable<T> => (T)FromId(typeof(T), id);
	}

	public abstract class ElectronDisposable<T> : IDisposable, IAsyncDisposable where T : ElectronDisposable<T> {
		internal ElectronDisposable(int id) {
			this.Id = id;
			ElectronDisposable.instances[id] = (T)this;
		}
		internal int Id { get; private set; }

		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public async ValueTask DisposeAsync() {
			await DisposeAsyncCore();

			Dispose(disposing: false);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				Electron.DisposeObjectAsync((T)this).GetAwaiter().GetResult();
				ElectronDisposable.instances.Remove(this.Id);
			}

			this.Id = 0;
		}

		protected virtual async ValueTask DisposeAsyncCore() {
			if (this.Id > 0) {
				await Electron.DisposeObjectAsync((T)this);
				ElectronDisposable.instances.Remove(this.Id);
			}

			this.Id = 0;
		}

		~ElectronDisposable() {
			this.Dispose(true);
		}
	}
}