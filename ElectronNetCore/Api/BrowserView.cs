using System;
using System.Drawing;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class BrowserView : ElectronDisposable<BrowserView>, IDisposable, IAsyncDisposable {
		public static Task<BrowserView> CreateAsync(BrowserViewConstructorOptions options = null) =>
			Electron.FuncAsync<BrowserView, int, BrowserViewConstructorOptionsInternal>(x => x.BrowserView_Ctor, 0, options.ToBrowserViewConstructorOptionsInternal());

		internal BrowserView(int id) : base(id) { }

		private ElectronProperty<WebContents> webContents;
		public ElectronProperty<WebContents> WebContents {
			get {
				if (this.webContents == null) {
					this.webContents = new(x => id => x.BrowserView_WebContents_Get(id, this.Id),
						x => (id, value) => x.BrowserView_WebContents_Set(id, this.Id, value.Id));
				}
				return this.webContents;
			}
		}

		public Task SetAutoResizeAsync(AutoResizeOptions options) =>
			Electron.ActionAsync(x => x.BrowserView_SetAutoResize, this.Id, options);
		public Task SetBoundsAsync(Rectangle bounds) =>
			Electron.ActionAsync(x => x.BrowserView_SetBounds, this.Id, bounds);
		public Task<Rectangle> GetBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.BrowserView_GetBounds, this.Id);
		public Task SetBackgroundColorAsync(string color) =>
			Electron.ActionAsync(x => x.BrowserView_SetBackgroundColor, this.Id, color);
		public Task SetBackgroundColorAsync(Color color) =>
			this.SetBackgroundColorAsync($"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}");
	}
}
