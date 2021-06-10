using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MZZT.ElectronNetCore.Api {
	public class ActivityEventArgs : ActivityTypeEventArgs {
		public ActivityEventArgs(string type, Dictionary<string, object> userInfo) : base(type) {
			this.UserInfo = userInfo;
		}

		public Dictionary<string, object> UserInfo { get; }
	}

	public class ActivityErrorEventArgs : ActivityTypeEventArgs {
		public ActivityErrorEventArgs(string type, string error) : base(type) {
			this.Error = error;
		}

		public string Error { get; }
	}

	public class ActivityTypeEventArgs : EventArgs {
		public ActivityTypeEventArgs(string type) : base() {
			this.Type = type;
		}

		public string Type { get; }
	}

	public class AppAccessibilitySupportChangedEventArgs : EventArgs {
		public AppAccessibilitySupportChangedEventArgs(bool accessibilitySupportEnabled) : base() {
			this.AccessibilitySupportEnabled = accessibilitySupportEnabled;
		}

		public bool AccessibilitySupportEnabled { get; }
	}

	public class AppActivateEventArgs : EventArgs {
		public AppActivateEventArgs(bool hasVisibleWindows) : base() {
			this.HasVisibleWindows = hasVisibleWindows;
		}

		public bool HasVisibleWindows { get; }
	}

	public class CertificateErrorEventArgs : EventArgs {
		public CertificateErrorEventArgs(string url, string error, Certificate certificate, ElectronFunction<bool> callback) : base() {
			this.Url = url;
			this.Error = error;
			this.Certificate = certificate;
			this.Callback = callback;
		}

		public string Url { get; }
		public string Error { get; }
		public Certificate Certificate { get; }
		public ElectronFunction<bool> Callback { get; }
	}

	public class AppCertificateErrorEventArgs : CertificateErrorEventArgs {
		public AppCertificateErrorEventArgs(WebContents webContents, string url, string error, Certificate certificate, ElectronFunction<bool> callback) : base(url, error, certificate, callback) {
			this.WebContents = webContents;
		}

		public WebContents WebContents { get; }
	}

	public class AppChildProcessGoneEventArgs : EventArgs {
		public AppChildProcessGoneEventArgs(ChildProcessGone details) : base() {
			this.Details = details;
		}

		public ChildProcessGone Details { get; }
	}

	public class LoginEventArgs : EventArgs {
		public LoginEventArgs(AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, ElectronFunction<string, string> callback) : base() {
			this.AuthenticationResponseDetails = authenticationResponseDetails;
			this.AuthInfo = authInfo;
			this.Callback = callback;
		}

		public AuthenticationResponseDetails AuthenticationResponseDetails { get; }
		public AuthInfo AuthInfo { get; }
		public ElectronFunction<string, string> Callback { get; }
	}

	public class AppLoginEventArgs : LoginEventArgs {
		public AppLoginEventArgs(WebContents webContents, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, ElectronFunction<string, string> callback) : base(authenticationResponseDetails, authInfo, callback) {
			this.WebContents = webContents;
		}

		public WebContents WebContents { get; }
	}

	public class AppReadyEventArgs : EventArgs {
		public AppReadyEventArgs(Dictionary<string, object> launchInfo) : base() {
			this.LaunchInfo = new(launchInfo);
		}

		public ReadOnlyDictionary<string, object> LaunchInfo { get; }
	}

	public class AppRenderProcessGoneEventArgs : WebContentsEventArgs {
		public AppRenderProcessGoneEventArgs(WebContents contents, RenderProcessGone details) : base(contents) {
			this.Details = details;
		}

		public RenderProcessGone Details { get; }
	}

	public class AppSecondInstanceEventArgs : EventArgs {
		public AppSecondInstanceEventArgs(string[] argv, string workingDirectory) {
			this.ArgV = argv;
			this.WorkingDirectory = workingDirectory;
		}

		public string[] ArgV { get; }
		public string WorkingDirectory { get; }
	}

	public class SelectClientCertificateEventArgs : EventArgs {
		public SelectClientCertificateEventArgs(string url, Certificate[] certificateList, ElectronFunction<Certificate> callback) : base() {
			this.Url = url;
			this.CertificateList = certificateList;
			this.Callback = callback;
		}

		public string Url { get; }
		public Certificate[] CertificateList { get; }
		public ElectronFunction<Certificate> Callback { get; }
	}

	public class AppSelectClientCertificateEventArgs : SelectClientCertificateEventArgs {
		public AppSelectClientCertificateEventArgs(WebContents webContents, string url, Certificate[] certificateList, ElectronFunction<Certificate> callback) : base(url, certificateList, callback) {
			this.WebContents = webContents;
		}

		public WebContents WebContents { get; }
	}

	public class AutoUpdaterUpdateDownloadedEventArgs : EventArgs {
		public AutoUpdaterUpdateDownloadedEventArgs(string releaseNotes, string releaseName, DateTime releaseDate, string updateUrl) : base() {
			this.ReleaseNotes = releaseNotes;
			this.ReleaseName = releaseName;
			this.ReleaseDate = releaseDate;
			this.UpdateUrl = updateUrl;
		}

		public string ReleaseNotes { get; }
		public string ReleaseName { get; }
		public DateTime ReleaseDate { get; }
		public string UpdateUrl { get; }
	}

	public class BrowserWindowAlwaysOnTopChangedEventArgs : EventArgs {
		public BrowserWindowAlwaysOnTopChangedEventArgs(bool isAlwaysOnTop) : base() {
			this.IsAlwaysOnTop = isAlwaysOnTop;
		}

		public bool IsAlwaysOnTop { get; }
	}
	
	public class BrowserWindowAppCommandEventArgs : EventArgs {
		public BrowserWindowAppCommandEventArgs(string command) : base() {
			this.Command = command;
		}

		public string Command { get; }
	}

	public class BrowserWindowEventArgs : EventArgs {
		public BrowserWindowEventArgs(BrowserWindow window) : base() {
			this.Window = window;
		}

		public BrowserWindow Window { get; }
	}

	public class PageTitleUpdatedEventArgs : EventArgs {
		public PageTitleUpdatedEventArgs(string title, bool explicitSet) : base() {
			this.Title = title;
			this.ExplicitSet = explicitSet;
		}

		public string Title { get; }
		public bool ExplicitSet { get; }
	}

	public class BrowserWindowRotateGestureEventArgs : EventArgs {
		public BrowserWindowRotateGestureEventArgs(double rotation) : base() {
			this.Rotation = rotation;
		}

		public double Rotation { get; }
	}

	public class BrowserWindowSwipeEventArgs : EventArgs {
		public BrowserWindowSwipeEventArgs(string direction) : base() {
			this.Direction = direction;
		}

		public string Direction { get; }
	}

	public class ColorEventArgs : EventArgs {
		public ColorEventArgs(string color) : base() {
			this.Color = color;
		}

		public string Color { get; }
	}

	public class ConsoleMessageEventArgs : EventArgs {
		public ConsoleMessageEventArgs(int level, string message, int line, string sourceId) : base() {
			this.Level = level;
			this.Message = message;
			this.Line = line;
			this.SourceId = sourceId;
		}

		public int Level { get; }
		public string Message { get; }
		public int Line { get; }
		public string SourceId { get; }
	}

	public class ContextMenuParamsEventArgs : EventArgs {
		public ContextMenuParamsEventArgs(ContextMenuParams @params) : base() {
			this.Params = @params;
		}

		public ContextMenuParams Params { get; }
	}

	public class CookiesChangedEventArgs : EventArgs {
		public CookiesChangedEventArgs(Cookie cookie, string cause, bool removed) : base() {
			this.Cookie = cookie;
			this.Cause = cause;
			this.Removed = removed;
		}

		public Cookie Cookie { get; }
		public string Cause { get; }
		public bool Removed { get; }
	}

	public class DebuggerMessageEventArgs : EventArgs {
		public DebuggerMessageEventArgs(string method, object @params, string sessionId) {
			this.Method = method;
			this.Params = @params;
			this.SessionId = sessionId;
		}

		public string Method { get; }
		public object Params { get; }
		public string SessionId { get; }
	}

	public class DisplayEventArgs : EventArgs {
		public DisplayEventArgs(Display display) : base() {
			this.Display = display;
		}

		public Display Display { get; }
	}

	public class DisplayMetricsChangedEventArgs : DisplayEventArgs {
		public DisplayMetricsChangedEventArgs(Display display, string[] changedMetrics) : base(display) {
			this.ChangedMetrics = changedMetrics;
		}

		public string[] ChangedMetrics { get; }
	}

	public class DownloadItemEventArgs : EventArgs {
		public DownloadItemEventArgs(string state) : base() {
			this.State = state;
		}

		public string State { get; }
	}

	public class ErrorEventArgs : EventArgs {
		public ErrorEventArgs(Error error) : base() {
			this.Error = error;
		}

		public Error Error { get; }
	}

	public class ExitCodeEventArgs : EventArgs {
		public ExitCodeEventArgs(int exitCode) : base() {
			this.ExitCode = exitCode;
		}

		public int ExitCode { get; }
	}

	public class ExtensionEventArgs : EventArgs {
		public ExtensionEventArgs(Extension extension) : base() {
			this.Extension = extension;
		}

		public Extension Extension { get; }
	}

	public class FaviconsEventArgs : EventArgs {
		public FaviconsEventArgs(string[] favicons) {
			this.Favicons = favicons;
		}

		public string[] Favicons { get; }
	}

	public class FileEventArgs : EventArgs {
		public FileEventArgs(string path) : base() {
			this.Path = path;
		}

		public string Path { get; }
	}

	public class FoundInPageEventArgs : EventArgs {
		public FoundInPageEventArgs(Result result) : base() {
			this.Result = result;
		}

		public Result Result { get; }
	}

	public class InputEventArgs : EventArgs {
		public InputEventArgs(Input input) : base() {
			this.Input = input;
		}

		public Input Input { get; }
	}

	public class IpcMessageEventArgs : EventArgs {
		public IpcMessageEventArgs(string channel, object[] args) : base() {
			this.Channel = channel;
			this.Args = args;
		}

		public string Channel { get; }
		public object[] Args { get; }
	}

	public class LanguageCodeEventArgs : EventArgs {
		public LanguageCodeEventArgs(string languageCode) : base() {
			this.LanguageCode = languageCode;
		}

		public string LanguageCode { get; }
	}

	public class MessageDetailsEventArgs : EventArgs {
		public MessageDetailsEventArgs(MessageDetails messageDetails) : base() {
			this.MessageDetails = messageDetails;
		}

		public MessageDetails MessageDetails { get; }
	}

	public class MessagePortMainMessageEventArgs : EventArgs {
		public MessagePortMainMessageEventArgs(object data, MessagePortMain[] ports) : base() {
			this.Data = data;
			this.Ports = ports;
		}

		public object Data { get; }
		public MessagePortMain[] Ports { get; }
	}

	public class NotificationActionEventArgs : EventArgs {
		public NotificationActionEventArgs(int index) : base() {
			this.Index = index;
		}

		public int Index { get; }
	}

	public class NotificationErrorEventArgs : EventArgs {
		public NotificationErrorEventArgs(string error) : base() {
			this.Error = error;
		}

		public string Error { get; }
	}

	public class NotificationReplyEventArgs : EventArgs {
		public NotificationReplyEventArgs(string reply) : base() {
			this.Reply = reply;
		}

		public string Reply { get; }
	}

	public class PointEventArgs : EventArgs {
		public PointEventArgs(Point point) : base() {
			this.Point = point;
		}

		public Point Point { get; }
	}

	public class PreferredSizeEventArgs : EventArgs {
		public PreferredSizeEventArgs(Size preferredSize) : base() {
			this.PreferredSize = preferredSize;
		}

		public Size PreferredSize { get; }
	}

	public class RectangleEventArgs : EventArgs {
		public RectangleEventArgs(Rectangle newBounds) : base() {
			this.NewBounds = newBounds;
		}

		public Rectangle NewBounds { get; }
	}

	public class RenderProcessGoneEventArgs : EventArgs {
		public RenderProcessGoneEventArgs(RenderProcessGone details) : base() {
			this.Details = details;
		}

		public RenderProcessGone Details { get; }
	}

	public class SessionEventArgs : EventArgs {
		public SessionEventArgs(Session session) {
			this.Session = session;
		}

		public Session Session { get; }
	}

	public class SessionPreconnectEventArgs : EventArgs {
		public SessionPreconnectEventArgs(string preconnectUrl, bool allowCredentials) : base() {
			this.PreconnectUrl = preconnectUrl;
			this.AllowCredentials = allowCredentials;
		}

		public string PreconnectUrl { get; }
		public bool AllowCredentials { get; }
	}

	public class SessionSelectSerialPortEventArgs : EventArgs {
		public SessionSelectSerialPortEventArgs(SerialPort[] portList, WebContents webContents, ElectronFunction<string> callback) : base() {
			this.PortList = portList;
			this.WebContents = webContents;
			this.Callback = callback;
		}

		public SerialPort[] PortList { get; }
		public WebContents WebContents { get; }
		public ElectronFunction<string> Callback { get; }
	}

	public class SessionSerialPortEventArgs : EventArgs {
		public SessionSerialPortEventArgs(SerialPort port, WebContents webContents) : base() {
			this.Port = port;
			this.WebContents = webContents;
		}

		public SerialPort Port { get; }
		public WebContents WebContents { get; }
	}

	public class SessionWillDownloadEventArgs : EventArgs {
		public SessionWillDownloadEventArgs(DownloadItem item, WebContents webContents) : base() {
			this.Item = item;
			this.WebContents = webContents;
		}

		public DownloadItem Item { get; }
		public WebContents WebContents { get; }
	}

	public class SystemPreferenceAccentColorChangedEventArgs : EventArgs {
		public SystemPreferenceAccentColorChangedEventArgs(string newColor) : base() {
			this.NewColor = newColor;
		}

		public string NewColor { get; }
	}

	public class TransactionsEventArgs : EventArgs {
		public TransactionsEventArgs(Transaction[] transactions) : base() {
			this.Transactions = transactions;
		}

		public Transaction[] Transactions { get; }
	}

	public class TrayAuxClickEventArgs : EventArgs {
		public TrayAuxClickEventArgs(KeyboardEvent @event, Rectangle bounds) : base() {
			this.Event = @event;
			this.Bounds = bounds;
		}

		public KeyboardEvent Event { get; }
		public Rectangle Bounds { get; }
	}

	public class TrayClickEventArgs : TrayAuxClickEventArgs  {
		public TrayClickEventArgs(KeyboardEvent @event, Rectangle bounds, Point position) : base(@event, bounds) {
			this.Position = position;
		}

		public Point Position { get; }
	}

	public class TrayDropFilesEventArgs : EventArgs {
		public TrayDropFilesEventArgs(string[] files) : base() {
			this.Files = files;
		}

		public string[] Files { get; }
	}

	public class TrayDropTextEventArgs : EventArgs {
		public TrayDropTextEventArgs(string text) : base() {
			this.Text = text;
		}

		public string Text { get; }
	}

	public class TrayMouseEventArgs : EventArgs {
		public TrayMouseEventArgs(KeyboardEvent @event, Point position) : base() {
			this.Event = @event;
			this.Position = position;
		}

		public KeyboardEvent Event { get; }
		public Point Position { get; }
	}

	public class UrlEventArgs : EventArgs {
		public UrlEventArgs(string url) : base() {
			this.Url = url;
		}

		public string Url { get; }
	}

	public class WebContentsEventArgs : EventArgs {
		public WebContentsEventArgs(WebContents contents) : base() {
			this.WebContents = contents;
		}

		public WebContents WebContents { get; }
	}

	public class WebContentsCursorChangedEventArgs : EventArgs {
		public WebContentsCursorChangedEventArgs(string type, NativeImage image, double? scale, Size size, Point hotspot) : base() {
			this.Type = type;
			this.Image = image;
			this.Scale = scale;
			this.Size = size;
			this.Hotspot = hotspot;
		}

		public string Type { get; }
		public NativeImage Image { get; }
		public double? Scale { get; }
		public Size Size { get; }
		public Point Hotspot { get; }
	}

	public class WebContentsDidCreateWindowEventArgs : BrowserWindowEventArgs {
		public WebContentsDidCreateWindowEventArgs(BrowserWindow window, DidCreateWindowDetails details) : base(window) {
			this.Details = details;
		}

		public DidCreateWindowDetails Details { get; }
	}

	public class WebContentsDidFrameNavigateEventArgs : WebContentsFrameEventArgs {
		public WebContentsDidFrameNavigateEventArgs(string url, int httpResponseCode, string httpStatusText, bool isMainFrame, int frameProcessId, int frameRoutingId) : base(isMainFrame, frameProcessId, frameRoutingId) {
			this.Url = url;
			this.HttpResponseCode = httpResponseCode;
			this.HttpStatusText = httpStatusText;
		}

		public string Url { get; }
		public int HttpResponseCode { get; }
		public string HttpStatusText { get; }
	}

	public class WebContentsDidNavigateEventArgs : EventArgs {
		public WebContentsDidNavigateEventArgs(string url, int httpResponseCode, string httpStatusText) : base() {
			this.Url = url;
			this.HttpResponseCode = httpResponseCode;
			this.HttpStatusText = httpStatusText;
		}

		public string Url { get; }
		public int HttpResponseCode { get; }
		public string HttpStatusText { get; }
	}

	public class WebContentsDidNavigateInPageEventArgs : WebContentsFrameEventArgs {
		public WebContentsDidNavigateInPageEventArgs(string url, bool isMainFrame, int frameProcessId, int frameRoutingId) : base(isMainFrame, frameProcessId, frameRoutingId) {
			this.Url = url;
		}

		public string Url { get; }
	}

	public class WebContentsFailLoadEventArgs : WebContentsFrameEventArgs {
		public WebContentsFailLoadEventArgs(int errorCode, string errorDescription, string validatedUrl, bool isMainFrame, int frameProcessId, int frameRoutingId) : base(isMainFrame, frameProcessId, frameRoutingId) {
			this.ErrorCode = errorCode;
			this.ErrorDescription = errorDescription;
			this.ValidatedUrl = validatedUrl;
		}

		public int ErrorCode { get; }
		public string ErrorDescription { get; }
		public string ValidatedUrl { get; }
	}

	public class WebContentsFrameEventArgs : EventArgs {
		public WebContentsFrameEventArgs(bool isMainFrame, int frameProcessId, int frameRoutingId) : base() {
			this.IsMainFrame = isMainFrame;
			this.FrameProcessId = frameProcessId;
			this.FrameRoutingId = frameRoutingId;
		}

		public bool IsMainFrame { get; }
		public int FrameProcessId { get; }
		public int FrameRoutingId { get; }
	}

	public class WebContentsNavigationEventArgs : WebContentsFrameEventArgs {
		public WebContentsNavigationEventArgs(string url, bool isInPlace, bool isMainFrame, int frameProcessId, int frameRoutingId) : base(isMainFrame, frameProcessId, frameRoutingId) {
			this.Url = url;
			this.IsInPlace = isInPlace;
		}

		public string Url { get; }
		public bool IsInPlace { get; }
	}

	public class WebContentsPaintEventArgs : EventArgs {
		public WebContentsPaintEventArgs(Rectangle dirtyRect, NativeImage image) : base() {
			this.DirtyRect = dirtyRect;
			this.Image = image;
		}

		public Rectangle DirtyRect { get; }
		public NativeImage Image { get; }
	}

	public class WebContentsPluginCrashedEventArgs : EventArgs {
		public WebContentsPluginCrashedEventArgs(string name, string version) : base() {
			this.Name = name;
			this.Version = version;
		}

		public string Name { get; }
		public string Version { get; }
	}

	public class WebContentsPreloadErrorEventArgs : EventArgs {
		public WebContentsPreloadErrorEventArgs(string preloadPath, Error error) : base() {
			this.PreloadPath = preloadPath;
			this.Error = error;
		}

		public string PreloadPath { get; }
		public Error Error { get; }
	}

	public class WebContentsSelectBluetoothDeviceEventArgs : EventArgs {
		public WebContentsSelectBluetoothDeviceEventArgs(BluetoothDevice[] devices, ElectronFunction<string> callback) : base() {
			this.Devices = devices;
			this.Callback = callback;
		}

		public BluetoothDevice[] Devices { get; }
		public ElectronFunction<string> Callback { get; }
	}

	public class WebContentsWillAttachWebviewEventArgs : EventArgs {
		public WebContentsWillAttachWebviewEventArgs(WebPreferences webPreferences, Dictionary<string, string> @params) : base() {
			this.WebPreferences = webPreferences;
			this.Params = @params;
		}

		public WebPreferences WebPreferences { get; }
		public Dictionary<string, string> Params { get; }
	}

	public class ZoomDirectionEventArgs : EventArgs {
		public ZoomDirectionEventArgs(string zoomDirection) : base() {
			this.ZoomDirection = zoomDirection;
		}

		public string ZoomDirection { get; }
	}
}
