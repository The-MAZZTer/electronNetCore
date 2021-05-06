using MZZT.ElectronNetCore.Api;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task NativeImage_CreateEmpty(int requestId, int id);
		Task NativeImage_CreateThumbnailFromPath(int requestId, int id, string path, Size maxSize);
		Task NativeImage_CreateFromPath(int requestId, int id, string path);
		Task NativeImage_CreateFromBitmap(int requestId, int id, string buffer, CreateFromBitmapOptions options);
		Task NativeImage_CreateFromBuffer(int requestId, int id, string buffer, CreateFromBufferOptions options);
		Task NativeImage_CreateFromDataUrl(int requestId, int id, string dataUrl);
		Task NativeImage_CreateFromNamedImage(int requestId, int id, string imageName, double[] hslShift);

		Task NativeImage_ToPng(int requestId, int id, ToPngOptions options);
		Task NativeImage_ToJpeg(int requestId, int id, int quality);
		Task NativeImage_ToBitmap(int requestId, int id, ToBitmapOptions options);
		Task NativeImage_ToDataUrl(int requestId, int id, ToDataUrlOptions options);
		Task NativeImage_GetBitmap(int requestId, int id, BitmapOptions options);
		Task NativeImage_GetNativeHandle(int requestId, int id);
		Task NativeImage_IsEmpty(int requestId, int id);
		Task NativeImage_GetSize(int requestId, int id, double scaleFactor);
		Task NativeImage_SetTemplateImage(int requestId, int id, bool option);
		Task NativeImage_IsTemplateImage(int requestId, int id);
		Task NativeImage_Crop(int requestId, int id, Rectangle rect);
		Task NativeImage_Resize(int requestId, int id, ResizeOptions options);
		Task NativeImage_GetAspectRatio(int requestId, int id, double scaleFactor);
		Task NativeImage_GetScaleFactors(int requestId, int id);
		Task NativeImage_AddRepresentation(int requestId, int id, AddRepresentationOptionsDto options);

		Task NativeImage_IsMacTemplateImage_Get(int requestId, int id);
		Task NativeImage_IsMacTemplateImage_Set(int requestId, int id, bool value);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class NativeImage : ElectronDisposable<NativeImage> {
		public static Task<NativeImage> CreateEmptyAsync() =>
			Electron.FuncAsync<NativeImage, int>(x => x.NativeImage_CreateEmpty, 0);
		public static Task<NativeImage> CreateThumbnailFromPathAsync(string path, Size maxSize) =>
			Electron.FuncAsync<NativeImage, int, string, Size>(x => x.NativeImage_CreateThumbnailFromPath, 0, path, maxSize);
		public static Task<NativeImage> CreateFromPathAsync(string path) =>
			Electron.FuncAsync<NativeImage, int, string>(x => x.NativeImage_CreateFromPath, 0, path);
		public static Task<NativeImage> CreateFromBitmapAsync(byte[] buffer, CreateFromBitmapOptions options) =>
			Electron.FuncAsync<NativeImage, int, string, CreateFromBitmapOptions>(x => x.NativeImage_CreateFromBitmap, 0, Convert.ToBase64String(buffer), options);
		public static Task<NativeImage> CreateFromBufferAsync(byte[] buffer, CreateFromBufferOptions options) =>
			Electron.FuncAsync<NativeImage, int, string, CreateFromBufferOptions>(x => x.NativeImage_CreateFromBuffer, 0, Convert.ToBase64String(buffer), options);
		public static Task<NativeImage> CreateFromDataUrlAsync(string dataUrl) =>
			Electron.FuncAsync<NativeImage, int, string>(x => x.NativeImage_CreateFromDataUrl, 0, dataUrl);
		public static Task<NativeImage> CreateFromNamedImageAsync(string imageName, double[] hslShift = null) =>
			Electron.FuncAsync<NativeImage, int, string, double[]>(x => x.NativeImage_CreateFromNamedImage, 0, imageName, hslShift);

		internal NativeImage(int id) : base(id) { }

		public async Task<byte[]> ToPngAsync(ToPngOptions options = null) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, ToPngOptions>(x => x.NativeImage_ToPng, this.InternalId, options));
		public async Task<byte[]> ToJpegAsync(int quality) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, int>(x => x.NativeImage_ToJpeg, this.InternalId, quality));
		public async Task<byte[]> ToBitmapAsync(ToBitmapOptions options = null) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, ToBitmapOptions>(x => x.NativeImage_ToBitmap, this.InternalId, options));
		public Task<string> ToDataUrlAsync(ToDataUrlOptions options = null) =>
			Electron.FuncAsync<string, int, ToDataUrlOptions>(x => x.NativeImage_ToDataUrl, this.InternalId, options);
		public async Task<byte[]> GetBitmapAsync(BitmapOptions options = null) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, int, BitmapOptions>(x => x.NativeImage_GetBitmap, this.InternalId, options));
		public async Task<IntPtr> GetNativeHandleAsync() {
			byte[] bytes = Convert.FromBase64String(await Electron.FuncAsync<string, int>(x => x.NativeImage_GetNativeHandle, this.InternalId));
			return bytes.Length switch {
				4 => new IntPtr(BitConverter.ToInt32(bytes)),
				8 => new IntPtr(BitConverter.ToInt64(bytes)),
				_ => throw new InvalidDataException($"Unexpected handle size {bytes.Length}!"),
			};
		}
		public Task<bool> IsEmptyAsync() =>
			Electron.FuncAsync<bool, int>(x => x.NativeImage_IsEmpty, this.InternalId);
		public Task<Size> GetSizeAsync(double scaleFactor = 1.0) =>
			Electron.FuncAsync<Size, int, double>(x => x.NativeImage_GetSize, this.InternalId, scaleFactor);
		public Task SetTemplateImageAsync(bool option) =>
			Electron.ActionAsync(x => x.NativeImage_SetTemplateImage, this.InternalId, option);
		public Task<bool> IsTemplateImageAsync() =>
			Electron.FuncAsync<bool, int>(x => x.NativeImage_IsTemplateImage, this.InternalId);
		public Task<NativeImage> CropAsync(Rectangle rect) =>
			Electron.FuncAsync<NativeImage, int, Rectangle>(x => x.NativeImage_Crop, this.InternalId, rect);
		public Task<NativeImage> ResizeAsync(ResizeOptions options) =>
			Electron.FuncAsync<NativeImage, int, ResizeOptions>(x => x.NativeImage_Resize, this.InternalId, options);
		public Task<double> GetAspectRatioAsync(double scaleFactor = 1.0) =>
			Electron.FuncAsync<double, int, double>(x => x.NativeImage_GetAspectRatio, this.InternalId, scaleFactor);
		public Task<double[]> GetScaleFactorsAsync() =>
			Electron.FuncAsync<double[], int>(x => x.NativeImage_GetScaleFactors, this.InternalId);
		public Task AddRepresentationAsync(AddRepresentationOptions options) =>
			Electron.ActionAsync(x => x.NativeImage_AddRepresentation, this.InternalId, options?.ToAddRepresentationOptionsDto());

		private ElectronInstanceProperty<bool> isMacTemplateImage;
		public ElectronInstanceProperty<bool> IsMacTemplateImage {
			get {
				if (this.isMacTemplateImage == null) {
					this.isMacTemplateImage = new(this.InternalId, x => x.NativeImage_IsMacTemplateImage_Get,
						x => x.NativeImage_IsMacTemplateImage_Set);
				}
				return this.isMacTemplateImage;
			}
		}
	}
}
