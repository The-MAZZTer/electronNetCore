using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class WebContents {
		private static readonly Dictionary<int, WebContents> instances = new();

		public static WebContents FromId(int id) {
			return instances.GetValueOrDefault(id);
		}

		internal WebContents(int id) {
			this.Id = id;

			instances[id] = this;
		}
		public int Id { get; }

		public event EventHandler Destroyed;
		internal Task OnDestroyed() {
			this.Destroyed?.Invoke(this, new());
			instances.Remove(this.Id);
			return Task.CompletedTask;
		}
	}
}
