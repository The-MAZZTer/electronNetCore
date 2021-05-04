using MZZT.ElectronNetCore.Api;
using System.Drawing;
using System.Threading.Tasks;
using Rectangle = MZZT.ElectronNetCore.Api.Rectangle;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task BrowserView_Ctor(int requestId, int id, BrowserViewConstructorOptionsDto options);

		Task BrowserView_WebContents_Get(int requestId, int id);
		Task BrowserView_WebContents_Set(int requestId, int id, int value);

		Task BrowserView_SetAutoResize(int requestId, int id, AutoResizeOptions options);
		Task BrowserView_SetBounds(int requestId, int id, Rectangle bounds);
		Task BrowserView_GetBounds(int requestId, int id);
		Task BrowserView_SetBackgroundColor(int requestId, int id, string color);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class BrowserView : ElectronDisposable<BrowserView> {
		public static Task<BrowserView> CreateAsync(BrowserViewConstructorOptions options = null) =>
			Electron.FuncAsync<BrowserView, int, BrowserViewConstructorOptionsDto>(x => x.BrowserView_Ctor, 0, options.ToBrowserViewConstructorOptionsDto());

		internal BrowserView(int id) : base(id) { }

		private ElectronInstanceProperty<WebContents> webContents;
		public ElectronInstanceProperty<WebContents> WebContents {
			get {
				if (this.webContents == null) {
					this.webContents = new(this.InternalId, x => x.BrowserView_WebContents_Get,
						x => (requestId, id, value) => x.BrowserView_WebContents_Set(requestId, id, value.Id));
				}
				return this.webContents;
			}
		}

		public Task SetAutoResizeAsync(AutoResizeOptions options) =>
			Electron.ActionAsync(x => x.BrowserView_SetAutoResize, this.InternalId, options);
		public Task SetBoundsAsync(Rectangle bounds) =>
			Electron.ActionAsync(x => x.BrowserView_SetBounds, this.InternalId, bounds);
		public Task<Rectangle> GetBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.BrowserView_GetBounds, this.InternalId);
		public Task SetBackgroundColorAsync(string color) =>
			Electron.ActionAsync(x => x.BrowserView_SetBackgroundColor, this.InternalId, color);
		public Task SetBackgroundColorAsync(Color color) =>
			this.SetBackgroundColorAsync($"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}");
	}
}
