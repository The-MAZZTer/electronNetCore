using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Notification_IsSupported(int requestId, int id);

		Task Notification_Ctor(int requestId, int id, NotificationConstructorOptionsDto options);

		Task Notification_Show(int requestId, int id);
		Task Notification_Close(int requestId, int id);

		Task Notification_Title_Get(int requestId, int id);
		Task Notification_Title_Set(int requestId, int id, string value);
		Task Notification_Subtitle_Get(int requestId, int id);
		Task Notification_Subtitle_Set(int requestId, int id, string value);
		Task Notification_Body_Get(int requestId, int id);
		Task Notification_Body_Set(int requestId, int id, string value);
		Task Notification_ReplyPlaceholder_Get(int requestId, int id);
		Task Notification_ReplyPlaceholder_Set(int requestId, int id, string value);
		Task Notification_Sound_Get(int requestId, int id);
		Task Notification_Sound_Set(int requestId, int id, string value);
		Task Notification_CloseButtonText_Get(int requestId, int id);
		Task Notification_CloseButtonText_Set(int requestId, int id, string value);
		Task Notification_Silent_Get(int requestId, int id);
		Task Notification_Silent_Set(int requestId, int id, bool value);
		Task Notification_HasReply_Get(int requestId, int id);
		Task Notification_HasReply_Set(int requestId, int id, bool value);
		Task Notification_Urgency_Get(int requestId, int id);
		Task Notification_Urgency_Set(int requestId, int id, string value);
		Task Notification_TimeoutType_Get(int requestId, int id);
		Task Notification_TimeoutType_Set(int requestId, int id, string value);
		Task Notification_Actions_Get(int requestId, int id);
		Task Notification_Actions_Set(int requestId, int id, NotificationAction[] value);
		Task Notification_ToastXml_Get(int requestId, int id);
		Task Notification_ToastXml_Set(int requestId, int id, string value);
	}

	internal partial class ElectronHub {
		public Task Notification_Show_Event(int id) =>
			ElectronDisposable.FromId<Notification>(id)?.OnShow();
		public Task Notification_Click_Event(int id) =>
			ElectronDisposable.FromId<Notification>(id)?.OnClick();
		public Task Notification_Close_Event(int id) =>
			ElectronDisposable.FromId<Notification>(id)?.OnClose();
		public Task Notification_Reply_Event(int id, string reply) =>
			ElectronDisposable.FromId<Notification>(id)?.OnReply(reply);
		public Task Notification_Action_Event(int id, int index) =>
			ElectronDisposable.FromId<Notification>(id)?.OnAction(index);
		public Task Notification_Failed_Event(int id, string error) =>
			ElectronDisposable.FromId<Notification>(id)?.OnFailed(error);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Notification : ElectronDisposable<Notification> {
		public static Task<Notification> CreateAsync(NotificationConstructorOptions options = null) =>
			Electron.FuncAsync<Notification, int, NotificationConstructorOptionsDto>(x => x.Notification_Ctor, 0, options.ToNotificationConstructorOptionsDto());

		public static Task<bool> IsSupportedAsync() =>
			Electron.FuncAsync<bool, int>(x => x.Notification_IsSupported, 0);

		internal Notification(int id) : base(id) { }

		public event EventHandler Show;
		internal Task OnShow() {
			this.Show?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Click;
		internal Task OnClick() {
			this.Click?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Close;
		internal Task OnClose() {
			this.Close?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler<NotificationReplyEventArgs> Reply;
		internal Task OnReply(string reply) {
			this.Reply?.Invoke(this, new(reply));
			return Task.CompletedTask;
		}

		public event EventHandler<NotificationActionEventArgs> Action;
		internal Task OnAction(int index) {
			this.Action?.Invoke(this, new(index));
			return Task.CompletedTask;
		}

		public event EventHandler<NotificationErrorEventArgs> Failed;
		internal Task OnFailed(string error) {
			this.Failed?.Invoke(this, new(error));
			return Task.CompletedTask;
		}

		public Task ShowAsync() =>
			Electron.ActionAsync(x => x.Notification_Show, this.InternalId);
		public Task CloseAsync() =>
			Electron.ActionAsync(x => x.Notification_Close, this.InternalId);

		private ElectronInstanceProperty<string> title;
		public ElectronInstanceProperty<string> Title {
			get {
				if (this.title == null) {
					this.title = new(this.InternalId, x => x.Notification_Title_Get,
						x => x.Notification_Title_Set);
				}
				return this.title;
			}
		}

		private ElectronInstanceProperty<string> subtitle;
		public ElectronInstanceProperty<string> Subtitle {
			get {
				if (this.subtitle == null) {
					this.subtitle = new(this.InternalId, x => x.Notification_Subtitle_Get,
						x => x.Notification_Subtitle_Set);
				}
				return this.subtitle;
			}
		}

		private ElectronInstanceProperty<string> body;
		public ElectronInstanceProperty<string> Body {
			get {
				if (this.body == null) {
					this.body = new(this.InternalId, x => x.Notification_Body_Get,
						x => x.Notification_Body_Set);
				}
				return this.body;
			}
		}

		private ElectronInstanceProperty<string> replyPlaceholder;
		public ElectronInstanceProperty<string> ReplyPlaceholder {
			get {
				if (this.replyPlaceholder == null) {
					this.replyPlaceholder = new(this.InternalId, x => x.Notification_ReplyPlaceholder_Get,
						x => x.Notification_ReplyPlaceholder_Set);
				}
				return this.replyPlaceholder;
			}
		}

		private ElectronInstanceProperty<string> sound;
		public ElectronInstanceProperty<string> Sound {
			get {
				if (this.sound == null) {
					this.sound = new(this.InternalId, x => x.Notification_Sound_Get,
						x => x.Notification_Sound_Set);
				}
				return this.sound;
			}
		}

		private ElectronInstanceProperty<string> closeButtonText;
		public ElectronInstanceProperty<string> CloseButtonText {
			get {
				if (this.closeButtonText == null) {
					this.closeButtonText = new(this.InternalId, x => x.Notification_CloseButtonText_Get,
						x => x.Notification_CloseButtonText_Set);
				}
				return this.closeButtonText;
			}
		}

		private ElectronInstanceProperty<bool> silent;
		public ElectronInstanceProperty<bool> Silent {
			get {
				if (this.silent == null) {
					this.silent = new(this.InternalId, x => x.Notification_Silent_Get,
						x => x.Notification_Silent_Set);
				}
				return this.silent;
			}
		}

		private ElectronInstanceProperty<bool> hasReply;
		public ElectronInstanceProperty<bool> HasReply {
			get {
				if (this.hasReply == null) {
					this.hasReply = new(this.InternalId, x => x.Notification_HasReply_Get,
						x => x.Notification_HasReply_Set);
				}
				return this.hasReply;
			}
		}

		private ElectronInstanceProperty<string> urgency;
		public ElectronInstanceProperty<string> Urgency {
			get {
				if (this.urgency == null) {
					this.urgency = new(this.InternalId, x => x.Notification_Urgency_Get,
						x => x.Notification_Urgency_Set);
				}
				return this.urgency;
			}
		}

		private ElectronInstanceProperty<string> timeoutType;
		public ElectronInstanceProperty<string> TimeoutType {
			get {
				if (this.timeoutType == null) {
					this.timeoutType = new(this.InternalId, x => x.Notification_TimeoutType_Get,
						x => x.Notification_TimeoutType_Set);
				}
				return this.timeoutType;
			}
		}

		private ElectronInstanceProperty<NotificationAction[]> actions;
		public ElectronInstanceProperty<NotificationAction[]> Actions {
			get {
				if (this.actions == null) {
					this.actions = new(this.InternalId, x => x.Notification_Actions_Get,
						x => x.Notification_Actions_Set);
				}
				return this.actions;
			}
		}

		private ElectronInstanceProperty<string> toastXml;
		public ElectronInstanceProperty<string> ToastXml {
			get {
				if (this.toastXml == null) {
					this.toastXml = new(this.InternalId, x => x.Notification_ToastXml_Get,
						x => x.Notification_ToastXml_Set);
				}
				return this.toastXml;
			}
		}
	}
}
