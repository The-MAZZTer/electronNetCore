﻿using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task NativeImage_CreateFromPath(int requestId, int id, string path);

		Task NativeImage_GetSize(int requestId, int id, double scaleFactor);
		Task NativeImage_ToDataUrl(int requestId, int id, ToDataUrlOptions options);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class NativeImage : ElectronDisposable<NativeImage> {
		public Task<NativeImage> CreateFromPathAsync(string path) =>
			Electron.FuncAsync<NativeImage, int, string>(x => x.NativeImage_CreateFromPath, 0, path);

		internal NativeImage(int id) : base(id) { }

		public Task<Size> GetSizeAsync(double scaleFactor = 1.0) =>
			Electron.FuncAsync<Size, int, double>(x => x.NativeImage_GetSize, this.InternalId, scaleFactor);
		public Task<string> ToDataUrlAsync(ToDataUrlOptions options = null) =>
			Electron.FuncAsync<string, int, ToDataUrlOptions>(x => x.NativeImage_ToDataUrl, this.InternalId, options);
	}
}
