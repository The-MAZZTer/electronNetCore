using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Tray_Ctor_Image(int requestId, int id, int image, string guid);
		Task Tray_Ctor_Path(int requestId, int id, string image, string guid);

		Task Tray_Destroy(int requestId, int id);
		Task Tray_SetImage_Image(int requestId, int id, int image);
		Task Tray_SetImage_Path(int requestId, int id, string image);
		Task Tray_SetPressedImage_Image(int requestId, int id, int image);
		Task Tray_SetPressedImage_Path(int requestId, int id, string image);
		Task Tray_SetToolTip(int requestId, int id, string toolTip);
		Task Tray_SetTitle(int requestId, int id, string title, TitleOptions options);
		Task Tray_GetTitle(int requestId, int id);
		Task Tray_SetIgnoreDoubleClickEvents(int requestId, int id, bool ignore);
		Task Tray_GetIgnoreDoubleClickEvents(int requestId, int id);
		Task Tray_DisplayBalloon(int requestId, int id, DisplayBalloonOptionsDto options);
		Task Tray_RemoveBalloon(int requestId, int id);
		Task Tray_Focus(int requestId, int id);
		Task Tray_PopupContextMenu(int requestId, int id, int menu, Point position);
		Task Tray_CloseContextMenu(int requestId, int id);
		Task Tray_SetContextMenu(int requestId, int id, int menu);
		Task Tray_GetBounds(int requestId, int id);
		Task Tray_IsDestroyed(int requestId, int id);
	}

	internal partial class ElectronHub {
		public Task Tray_Click_Event(int id, KeyboardEvent e, Rectangle bounds, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnClick(e, bounds, position);
		public Task Tray_RightClick_Event(int id, KeyboardEvent e, Rectangle bounds) =>
			ElectronDisposable.FromId<Tray>(id).OnRightClick(e, bounds);
		public Task Tray_DoubleClick_Event(int id, KeyboardEvent e, Rectangle bounds) =>
			ElectronDisposable.FromId<Tray>(id).OnDoubleClick(e, bounds);
		public Task Tray_BalloonShow_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnBalloonShow();
		public Task Tray_BalloonClick_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnBalloonClick();
		public Task Tray_BalloonClosed_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnBalloonClosed();
		public Task Tray_Drop_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnDrop();
		public Task Tray_DropFiles_Event(int id, string[] files) =>
			ElectronDisposable.FromId<Tray>(id).OnDropFiles(files);
		public Task Tray_DropText_Event(int id, string text) =>
			ElectronDisposable.FromId<Tray>(id).OnDropText(text);
		public Task Tray_DragEnter_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnDragEnter();
		public Task Tray_DragLeave_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnDragLeave();
		public Task Tray_DragEnd_Event(int id) =>
			ElectronDisposable.FromId<Tray>(id).OnDragEnd();
		public Task Tray_MouseUp_Event(int id, KeyboardEvent e, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnMouseUp(e, position);
		public Task Tray_MouseDown_Event(int id, KeyboardEvent e, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnMouseDown(e, position);
		public Task Tray_MouseEnter_Event(int id, KeyboardEvent e, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnMouseEnter(e, position);
		public Task Tray_MouseLeave_Event(int id, KeyboardEvent e, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnMouseLeave(e, position);
		public Task Tray_MouseMove_Event(int id, KeyboardEvent e, Point position) =>
			ElectronDisposable.FromId<Tray>(id).OnMouseMove(e, position);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Tray : ElectronDisposable<Tray> {
		public static Task<Tray> CreateAsync(NativeImage image, string guid = null) =>
			Electron.FuncAsync<Tray, int, int, string>(x => x.Tray_Ctor_Image, 0, image?.InternalId ?? 0, guid);
		public static Task<Tray> CreateAsync(NativeImage image, Guid guid) =>
			Electron.FuncAsync<Tray, int, int, string>(x => x.Tray_Ctor_Image, 0, image?.InternalId ?? 0, guid.ToString());
		public static Task<Tray> CreateAsync(string image, string guid = null) =>
			Electron.FuncAsync<Tray, int, string, string>(x => x.Tray_Ctor_Path, 0, image, guid);
		public static Task<Tray> CreateAsync(string image, Guid guid) =>
			Electron.FuncAsync<Tray, int, string, string>(x => x.Tray_Ctor_Path, 0, image, guid.ToString());

		internal Tray(int id) : base(id) { }

		public event EventHandler<TrayClickEventArgs> Click;
		internal Task OnClick(KeyboardEvent e, Rectangle bounds, Point position) {
			this.Click?.Invoke(this, new(e, bounds, position));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayAuxClickEventArgs> RightClick;
		internal Task OnRightClick(KeyboardEvent e, Rectangle bounds) {
			this.RightClick?.Invoke(this, new(e, bounds));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayAuxClickEventArgs> DoubleClick;
		internal Task OnDoubleClick(KeyboardEvent e, Rectangle bounds) {
			this.DoubleClick?.Invoke(this, new(e, bounds));
			return Task.CompletedTask;
		}

		public event EventHandler BalloonShow;
		internal Task OnBalloonShow() {
			this.BalloonShow?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler BalloonClick;
		internal Task OnBalloonClick() {
			this.BalloonClick?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler BalloonClosed;
		internal Task OnBalloonClosed() {
			this.BalloonClosed?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Drop;
		internal Task OnDrop() {
			this.Drop?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<TrayDropFilesEventArgs> DropFiles;
		internal Task OnDropFiles(string[] files) {
			this.DropFiles?.Invoke(this, new(files));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayDropTextEventArgs> DropText;
		internal Task OnDropText(string text) {
			this.DropText?.Invoke(this, new(text));
			return Task.CompletedTask;
		}

		public event EventHandler DragEnter;
		internal Task OnDragEnter() {
			this.DragEnter?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DragLeave;
		internal Task OnDragLeave() {
			this.DragLeave?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler DragEnd;
		internal Task OnDragEnd() {
			this.DragEnd?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<TrayMouseEventArgs> MouseUp;
		internal Task OnMouseUp(KeyboardEvent e, Point position) {
			this.MouseUp?.Invoke(this, new(e, position));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayMouseEventArgs> MouseDown;
		internal Task OnMouseDown(KeyboardEvent e, Point position) {
			this.MouseDown?.Invoke(this, new(e, position));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayMouseEventArgs> MouseEnter;
		internal Task OnMouseEnter(KeyboardEvent e, Point position) {
			this.MouseEnter?.Invoke(this, new(e, position));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayMouseEventArgs> MouseLeave;
		internal Task OnMouseLeave(KeyboardEvent e, Point position) {
			this.MouseLeave?.Invoke(this, new(e, position));
			return Task.CompletedTask;
		}

		public event EventHandler<TrayMouseEventArgs> MouseMove;
		internal Task OnMouseMove(KeyboardEvent e, Point position) {
			this.MouseMove?.Invoke(this, new(e, position));
			return Task.CompletedTask;
		}

		public Task DestroyAsync() =>
			Electron.ActionAsync(x => x.Tray_Destroy, this.InternalId);
		public Task SetImageAsync(NativeImage image) =>
			Electron.ActionAsync(x => x.Tray_SetImage_Image, this.InternalId, image?.InternalId ?? 0);
		public Task SetImageAsync(string image) =>
			Electron.ActionAsync(x => x.Tray_SetImage_Path, this.InternalId, image);
		public Task SetPressedImageAsync(NativeImage image) =>
			Electron.ActionAsync(x => x.Tray_SetPressedImage_Image, this.InternalId, image?.InternalId ?? 0);
		public Task SetPressedImageAsync(string image) =>
			Electron.ActionAsync(x => x.Tray_SetPressedImage_Path, this.InternalId, image);
		public Task SetToolTipAsync(string toolTip) =>
			Electron.ActionAsync(x => x.Tray_SetToolTip, this.InternalId, toolTip);
		public Task SetTitleAsync(string title, TitleOptions options = null) =>
			Electron.ActionAsync(x => x.Tray_SetTitle, this.InternalId, title, options);
		public Task<string> GetTitleAsync() =>
			Electron.FuncAsync<string, int>(x => x.Tray_GetTitle, this.InternalId);
		public Task SetIgnoreDoubleClickEventsAsync(bool ignore) =>
			Electron.ActionAsync(x => x.Tray_SetIgnoreDoubleClickEvents, this.InternalId, ignore);
		public Task<bool> GetIgnoreDoubleClickEventsAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Tray_GetIgnoreDoubleClickEvents, this.InternalId);
		public Task DisplayBalloonAsync(DisplayBalloonOptions options) =>
			Electron.ActionAsync(x => x.Tray_DisplayBalloon, this.InternalId, options?.ToDisplayBalloonOptionsDto());
		public Task RemoveBalloonAsync() =>
			Electron.ActionAsync(x => x.Tray_RemoveBalloon, this.InternalId);
		public Task FocusAsync() =>
			Electron.ActionAsync(x => x.Tray_Focus, this.InternalId);
		public Task PopupContextMenuAsync(Menu menu = null, Point position = null) =>
			Electron.ActionAsync(x => x.Tray_PopupContextMenu, this.InternalId, menu?.InternalId ?? 0, position);
		public Task CloseContextMenuAsync() =>
			Electron.ActionAsync(x => x.Tray_CloseContextMenu, this.InternalId);
		public Task SetContextMenuAsync(Menu menu) =>
			Electron.ActionAsync(x => x.Tray_SetContextMenu, this.InternalId, menu?.InternalId ?? 0);
		public Task<Rectangle> GetBoundsAsync() =>
			Electron.FuncAsync<Rectangle, int>(x => x.Tray_GetBounds, this.InternalId);
		public Task<bool> IsDestroyedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Tray_IsDestroyed, this.InternalId);
	}
}
