using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Clipboard_ReadText(int requestId, string type);
		Task Clipboard_WriteText(int requestId, string text, string type);
		Task Clipboard_ReadHtml(int requestId, string type);
		Task Clipboard_WriteHtml(int requestId, string markup, string type);
		Task Clipboard_ReadImage(int requestId, string type);
		Task Clipboard_WriteImage(int requestId, int image, string type);
		Task Clipboard_ReadRtf(int requestId, string type);
		Task Clipboard_WriteRtf(int requestId, string text, string type);
		Task Clipboard_ReadBookmark(int requestId);
		Task Clipboard_WriteBookmark(int requestId, string title, string url, string type);
		Task Clipboard_ReadFindText(int requestId);
		Task Clipboard_WriteFindText(int requestId, string text);
		Task Clipboard_Clear(int requestId, string type);
		Task Clipboard_AvailableFormats(int requestId, string type);
		Task Clipboard_Has(int requestId, string format, string type);
		Task Clipboard_Read(int requestId, string format);
		Task Clipboard_ReadBuffer(int requestId, string format);
		Task Clipboard_WriteBuffer(int requestId, string format, string buffer, string type);
		Task Clipboard_Write(int requestId, DataDto data, string type);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronClipboard {
		internal ElectronClipboard() { }

		public Task<string> ReadTextAsync(string type = null) =>
			Electron.FuncAsync<string, string>(x => x.Clipboard_ReadText, type);
		public Task WriteTextAsync(string text, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteText, text, type);
		public Task<string> ReadHtmlAsync(string type = null) =>
			Electron.FuncAsync<string, string>(x => x.Clipboard_ReadHtml, type);
		public Task WriteHtmlAsync(string markup, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteHtml, markup, type);
		public Task<NativeImage> ReadImageAsync(string type = null) =>
			Electron.FuncAsync<NativeImage, string>(x => x.Clipboard_ReadImage, type);
		public Task WriteImageAsync(NativeImage image, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteImage, image?.InternalId ?? 0, type);
		public Task<string> ReadRtfAsync(string type = null) =>
			Electron.FuncAsync<string, string>(x => x.Clipboard_ReadRtf, type);
		public Task WriteRtfAsync(string text, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteRtf, text, type);
		public Task<ReadBookmark> ReadBookmarkAsync() =>
			Electron.FuncAsync<ReadBookmark>(x => x.Clipboard_ReadBookmark);
		public Task WriteBookmarkAsync(string title, string url, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteBookmark, title, url, type);
		public Task<string> ReadFindTextAsync() =>
			Electron.FuncAsync<string>(x => x.Clipboard_ReadFindText);
		public Task WriteFindTextAsync(string text) =>
			Electron.ActionAsync(x => x.Clipboard_WriteFindText, text);
		public Task ClearAsync(string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_Clear, type);
		public Task<string[]> AvailableFormatsAsync(string type = null) =>
			Electron.FuncAsync<string[], string>(x => x.Clipboard_AvailableFormats, type);
		public Task<bool> HasAsync(string format, string type = null) =>
			Electron.FuncAsync<bool, string, string>(x => x.Clipboard_Has, format, type);
		public Task<string> ReadAsync(string format) =>
			Electron.FuncAsync<string, string>(x => x.Clipboard_Read, format);
		public async Task<byte[]> ReadBufferAsync(string format) =>
			Convert.FromBase64String(await Electron.FuncAsync<string, string>(x => x.Clipboard_ReadBuffer, format));
		public Task WriteBufferAsync(string format, byte[] buffer, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_WriteBuffer, format, Convert.ToBase64String(buffer), type);
		public Task WriteAsync(Data data, string type = null) =>
			Electron.ActionAsync(x => x.Clipboard_Write, data?.ToDataDto(), type);
	}
}