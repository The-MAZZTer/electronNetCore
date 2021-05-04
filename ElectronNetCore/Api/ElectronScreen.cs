using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Screen_GetCursorScreenPoint(int requestId);
		Task Screen_GetPrimaryDisplay(int requestId);
		Task Screen_GetAllDisplays(int requestId);
		Task Screen_GetDisplayNearestPoint(int requestId, Point point);
		Task Screen_GetDisplayMatching(int requestId, Rectangle rect);
		Task Screen_ScreenToDipPoint(int requestId, Point point);
		Task Screen_DipToScreenPoint(int requestId, Point point);
		Task Screen_ScreenToDipRect(int requestId, int window, Rectangle rect);
		Task Screen_DipToScreenRect(int requestId, int window, Rectangle rect);
	}

	internal partial class ElectronHub {
		public Task Screen_DisplayAdded_Event(Display newDisplay) =>
			Api.Electron.Screen.OnDisplayAdded(newDisplay);
		public Task Screen_DisplayRemoved_Event(Display oldDisplay) =>
			Api.Electron.Screen.OnDisplayRemoved(oldDisplay);
		public Task Screen_DisplayMetricsChanged_Event(Display display, string[] changedMetrics) =>
			Api.Electron.Screen.OnDisplayMetricsChanged(display, changedMetrics);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronScreen {
		internal ElectronScreen() { }

		public event EventHandler<DisplayEventArgs> DisplayAdded;
		internal Task OnDisplayAdded(Display display) {
			this.DisplayAdded?.Invoke(this, new(display));
			return Task.CompletedTask;
		}

		public event EventHandler<DisplayEventArgs> DisplayRemoved;
		internal Task OnDisplayRemoved(Display display) {
			this.DisplayRemoved?.Invoke(this, new(display));
			return Task.CompletedTask;
		}

		public event EventHandler<DisplayMetricsChangedEventArgs> DisplayMetricsChanged;
		internal Task OnDisplayMetricsChanged(Display display, string[] changedMetrics) {
			this.DisplayMetricsChanged?.Invoke(this, new(display, changedMetrics));
			return Task.CompletedTask;
		}

		public Task<Point> GetCursorScreenPointAsync() =>
			Electron.FuncAsync<Point>(x => x.Screen_GetCursorScreenPoint);
		public Task<Display> GetPrimaryDisplayAsync() =>
			Electron.FuncAsync<Display>(x => x.Screen_GetPrimaryDisplay);
		public Task<Display[]> GetAllDisplaysAsync() =>
			Electron.FuncAsync<Display[]>(x => x.Screen_GetAllDisplays);
		public Task<Display> GetDisplayNearestPointAsync(Point point) =>
			Electron.FuncAsync<Display, Point>(x => x.Screen_GetDisplayNearestPoint, point);
		public Task<Display> GetDisplayMatchingAsync(Rectangle rect) =>
			Electron.FuncAsync<Display, Rectangle>(x => x.Screen_GetDisplayMatching, rect);
		public Task<Point> ScreenToDipPointAsync(Point point) =>
			Electron.FuncAsync<Point, Point>(x => x.Screen_ScreenToDipPoint, point);
		public Task<Point> DipToScreenPointAsync(Point point) =>
			Electron.FuncAsync<Point, Point>(x => x.Screen_DipToScreenPoint, point);
		public Task<Rectangle> ScreenToDipRectAsync(BrowserWindow window, Rectangle rect) =>
			Electron.FuncAsync<Rectangle, int, Rectangle>(x => x.Screen_ScreenToDipRect, window?.Id ?? 0, rect);
		public Task<Rectangle> DipToScreenRectAsync(BrowserWindow window, Rectangle rect) =>
			Electron.FuncAsync<Rectangle, int, Rectangle>(x => x.Screen_DipToScreenRect, window?.Id ?? 0, rect);
	}
}
