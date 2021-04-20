using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class NativeImage : ElectronDisposable<NativeImage>, IDisposable, IAsyncDisposable {
		internal NativeImage(int id) : base(id) { }

		public Task<Size> GetSizeAsync(double scaleFactor = 1.0) =>
			Electron.FuncAsync<Size, int, double>(x => x.NativeImage_GetSize, this.Id, scaleFactor);
		public Task<string> ToDataUrlAsync(ToDataUrlOptions options = null) =>
			Electron.FuncAsync<string, int, ToDataUrlOptions>(x => x.NativeImage_ToDataUrl, this.Id, options);
	}
}
