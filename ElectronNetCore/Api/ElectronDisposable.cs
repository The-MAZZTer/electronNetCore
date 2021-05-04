using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public abstract class ElectronDisposable {
		internal static readonly Dictionary<int, object> instances = new();

		internal static object FromId(Type type, int id) {
			if (id <= 0) {
				return null;
			}
			return instances.GetValueOrDefault(id) ?? Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { id }, null);
		}
		internal static T FromId<T>(int id) where T : ElectronDisposable<T> => (T)FromId(typeof(T), id);

		internal ElectronDisposable(int internalId) {
			this.internalId = internalId;
			if (internalId > 0) {
				instances[internalId] = this;
			}
		}
		protected int internalId;
		internal int InternalId {
			get {
				if (this.disposed) {
					throw new ObjectDisposedException(this.GetType().Name);
				}
				return this.internalId;
			}
		}
		protected bool disposed = false;
	}

	public abstract class ElectronDisposable<T> : ElectronDisposable, IDisposable, IAsyncDisposable where T : ElectronDisposable<T> {
		internal ElectronDisposable(int internalId) : base(internalId) { }

		public void Dispose() {
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public async ValueTask DisposeAsync() {
			await this.DisposeAsyncCore();

			this.Dispose(disposing: false);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing && this.internalId > 0) {
				Electron.DisposeObjectAsync((T)this).GetAwaiter().GetResult();
				instances.Remove(this.InternalId);
			}

			this.internalId = 0;
			this.disposed = true;
		}

		protected virtual async ValueTask DisposeAsyncCore() {
			if (this.internalId > 0) {
				await Electron.DisposeObjectAsync((T)this);
				instances.Remove(this.InternalId);
			}

			this.internalId = 0;
			this.disposed = true;
		}

		~ElectronDisposable() {
			this.Dispose(true);
		}
	}
}