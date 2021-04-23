using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MZZT.ElectronNetCore.Api {
	public class AppAccessibilitySupportChangedEventArgs : EventArgs {
		public AppAccessibilitySupportChangedEventArgs(bool accessibilitySupportEnabled) : base() {
			this.AccessibilitySupportEnabled = accessibilitySupportEnabled;
		}

		public bool AccessibilitySupportEnabled { get; }
	}

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

	public class AppActivateEventArgs : EventArgs {
		public AppActivateEventArgs(bool hasVisibleWindows) : base() {
			this.HasVisibleWindows = hasVisibleWindows;
		}

		public bool HasVisibleWindows { get; }
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

	public class AppCertificateErrorEventArgs : EventArgs {
		public AppCertificateErrorEventArgs(WebContents webContents, string url, string error, Certificate certificate, ElectronFunction<bool> callback) : base() {
			this.WebContents = webContents;
			this.Url = url;
			this.Error = error;
			this.Certificate = certificate;
			this.Callback = callback;
		}

		public WebContents WebContents { get; }
		public string Url { get; }
		public string Error { get; }
		public Certificate Certificate { get; }
		public ElectronFunction<bool> Callback { get; }
	}

	public class AppChildProcessGoneEventArgs : EventArgs {
		public AppChildProcessGoneEventArgs(ChildProcessGone details) : base() {
			this.Details = details;
		}

		public ChildProcessGone Details { get; }
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

	public class FileEventArgs : EventArgs {
		public FileEventArgs(string path): base() {
			this.Path = path;
		}

		public string Path { get; }
	}

	public class AppLoginEventArgs : EventArgs {
		public AppLoginEventArgs(WebContents webContents, AuthenticationResponseDetails authenticationResponseDetails, AuthInfo authInfo, ElectronFunction<string, string> callback) : base() {
			this.WebContents = webContents;
			this.AuthenticationResponseDetails = authenticationResponseDetails;
			this.AuthInfo = authInfo;
			this.Callback = callback;
		}

		public WebContents WebContents { get; }
		public AuthenticationResponseDetails AuthenticationResponseDetails { get; }
		public AuthInfo AuthInfo { get; }
		public ElectronFunction<string, string> Callback { get; }
	}

	public class BrowserWindowPageTitleUpdatedEventArgs : EventArgs {
		public BrowserWindowPageTitleUpdatedEventArgs(string title, bool explicitSet) : base() {
			this.Title = title;
			this.ExplicitSet = explicitSet;
		}

		public string Title { get; }
		public bool ExplicitSet { get; }
	}

	public class PointEventArgs : EventArgs {
		public PointEventArgs(Point point) : base() {
			this.Point = point;
		}

		public Point Point { get; }
	}

	public class AppReadyEventArgs : EventArgs {
		public AppReadyEventArgs(Dictionary<string, object> launchInfo) : base() {
			this.LaunchInfo = new(launchInfo);
		}

		public ReadOnlyDictionary<string, object> LaunchInfo { get; }
	}

	public class RectangleEventArgs : EventArgs {
		public RectangleEventArgs(Rectangle newBounds) : base() {
			this.NewBounds = newBounds;
		}

		public Rectangle NewBounds { get; }
	}

	public class AppRenderProcessGoneEventArgs : WebContentsEventArgs {
		public AppRenderProcessGoneEventArgs(WebContents contents, RenderProcessGone details) : base(contents) {
			this.Details = details;
		}

		public RenderProcessGone Details { get; }
	}

	public class BrowserWindowRotateGestureEventArgs : EventArgs {
		public BrowserWindowRotateGestureEventArgs(double rotation) : base() {
			this.Rotation = rotation;
		}

		public double Rotation { get; }
	}

	public class AppSecondInstanceEventArgs : EventArgs {
		public AppSecondInstanceEventArgs(string[] argv, string workingDirectory) {
			this.ArgV = argv;
			this.WorkingDirectory = workingDirectory;
		}

		public string[] ArgV { get; }
		public string WorkingDirectory { get; }
	}

	public class AppSelectClientCertificateEventArgs : EventArgs {
		public AppSelectClientCertificateEventArgs(WebContents webContents, string url, Certificate[] certificateList, ElectronFunction<Certificate> callback) : base() {
			this.WebContents = webContents;
			this.Url = url;
			this.CertificateList = certificateList;
			this.Callback = callback;
		}

		public WebContents WebContents { get; }
		public string Url { get; }
		public Certificate[] CertificateList { get; }
		public ElectronFunction<Certificate> Callback { get; }
	}

	public class SessionEventArgs : EventArgs {
		public SessionEventArgs(Session session) {
			this.Session = session;
		}

		public Session Session { get; }
	}

	public class BrowserWindowSwipeEventArgs : EventArgs {
		public BrowserWindowSwipeEventArgs(string direction) : base() {
			this.Direction = direction;
		}

		public string Direction { get; }
	}

	public class TransactionsEventArgs : EventArgs {
		public TransactionsEventArgs(Transaction[] transactions) : base() {
			this.Transactions = transactions;
		}

		public Transaction[] Transactions { get; }
	}

	public class UrlEventArgs : EventArgs {
		public UrlEventArgs(string url) : base() {
			this.Url = url;
		}

		public string Url { get; }
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

	public class WebContentsEventArgs : EventArgs {
		public WebContentsEventArgs(WebContents contents) : base() {
			this.WebContents = contents;
		}

		public WebContents WebContents { get; }
	}
}
