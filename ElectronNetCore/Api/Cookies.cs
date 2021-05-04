using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Cookies_Get(int requestId, int id, CookiesGetFilter filter);
		Task Cookies_Set(int requestId, int id, CookiesSetDetails details);
		Task Cookies_Remove(int requestId, int id, string url, string name);
		Task Cookies_FlushStore(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task Cookies_Changed_Event(int id, Cookie cookie, string cause, bool removed) =>
			ElectronDisposable.FromId<Cookies>(id)?.OnChanged(cookie, cause, removed) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Cookies : ElectronDisposable<Cookies> {
		internal Cookies(int id) : base(id) { }

		public event EventHandler<CookiesChangedEventArgs> Changed;
		internal Task OnChanged(Cookie cookie, string cause, bool removed) {
			this.Changed?.Invoke(this, new(cookie, cause, removed));
			return Task.CompletedTask;
		}

		public Task<Cookie[]> GetAsync(CookiesGetFilter filter) =>
			Electron.FuncAsync<Cookie[], int, CookiesGetFilter>(x => x.Cookies_Get, this.InternalId, filter);
		public Task SetAsync(CookiesSetDetails details) =>
			Electron.ActionAsync(x => x.Cookies_Set, this.InternalId, details);
		public Task RemoveAsync(string url, string name) =>
			Electron.ActionAsync(x => x.Cookies_Remove, this.InternalId, url, name);
		public Task FlushStoreAsync() =>
			Electron.ActionAsync(x => x.Cookies_FlushStore, this.InternalId);
	}
}
