using MZZT.ElectronNetCore.Api;
using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task WebRequest_OnBeforeRequest(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnBeforeSendHeaders(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnSendHeaders(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnHeadersReceived(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnResponseStarted(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnBeforeRedirect(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnCompleted(int requestId, int id, Filter filter, bool value);
		Task WebRequest_OnErrorOccurred(int requestId, int id, Filter filter, bool value);
	}

	internal partial class ElectronHub {
		public Task<Response> WebRequest_OnBeforeRequest_Callback(int id, OnBeforeRequestListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnBeforeRequest(details.ToOnBeforeRequestListenerDetails()) ?? Task.FromResult<Response>(null);
		public Task<BeforeSendResponse> WebRequest_OnBeforeSendHeaders_Callback(int id, OnBeforeSendHeadersListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnBeforeSendHeaders(details.ToOnBeforeSendHeadersListenerDetails()) ?? Task.FromResult<BeforeSendResponse>(null);
		public Task WebRequest_OnSendHeaders_Callback(int id, OnBeforeSendHeadersListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnSendHeaders(details.ToOnBeforeSendHeadersListenerDetails()) ?? Task.CompletedTask;
		public Task<HeadersReceivedResponse> WebRequest_OnHeadersReceived_Callback(int id, OnHeadersReceivedListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnHeadersReceived(details.ToOnHeadersReceivedListenerDetails()) ?? Task.FromResult<HeadersReceivedResponse>(null);
		public Task WebRequest_OnResponseStarted_Callback(int id, OnResponseStartedListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnResponseStarted(details.ToOnResponseStartedListenerDetails()) ?? Task.CompletedTask;
		public Task WebRequest_OnBeforeRedirect_Callback(int id, OnBeforeRedirectListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnBeforeRedirect(details.ToOnBeforeRedirectListenerDetails()) ?? Task.CompletedTask;
		public Task WebRequest_OnCompleted_Callback(int id, OnCompletedListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnCompleted(details.ToOnCompletedListenerDetails()) ?? Task.CompletedTask;
		public Task WebRequest_OnErrorOccurred_Callback(int id, OnErrorOccurredListenerDetailsDto details) =>
			ElectronDisposable.FromId<WebRequest>(id)?.OnOnErrorOccurred(details.ToOnErrorOccurredListenerDetails()) ?? Task.CompletedTask;
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class WebRequest : ElectronDisposable<WebRequest> {
		internal WebRequest(int id) : base(id) { }

		private Func<OnBeforeRequestListenerDetails, Response> onBeforeRequest;
		internal Task<Response> OnOnBeforeRequest(OnBeforeRequestListenerDetails details) =>
			Task.FromResult(this.onBeforeRequest?.Invoke(details));
		public Task OnBeforeRequest(Func<OnBeforeRequestListenerDetails, Response> listener) =>
			this.OnBeforeRequest(null, listener);
		public Task OnBeforeRequest(Filter filter, Func<OnBeforeRequestListenerDetails, Response> listener) {
			this.onBeforeRequest = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnBeforeRequest, this.InternalId, filter, listener != null);
		}
		private Func<OnBeforeSendHeadersListenerDetails, BeforeSendResponse> onBeforeSendHeaders;
		internal Task<BeforeSendResponse> OnOnBeforeSendHeaders(OnBeforeSendHeadersListenerDetails details) =>
			Task.FromResult(this.onBeforeSendHeaders?.Invoke(details));
		public Task OnBeforeSendHeaders(Func<OnBeforeSendHeadersListenerDetails, BeforeSendResponse> listener) =>
			this.OnBeforeSendHeaders(null, listener);
		public Task OnBeforeSendHeaders(Filter filter, Func<OnBeforeSendHeadersListenerDetails, BeforeSendResponse> listener) {
			this.onBeforeSendHeaders = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnBeforeSendHeaders, this.InternalId, filter, listener != null);
		}
		private Action<OnBeforeSendHeadersListenerDetails> onSendHeaders;
		internal Task OnOnSendHeaders(OnBeforeSendHeadersListenerDetails details) {
			this.onSendHeaders?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task OnSendHeaders(Action<OnBeforeSendHeadersListenerDetails> listener) =>
			this.OnSendHeaders(null, listener);
		public Task OnSendHeaders(Filter filter, Action<OnBeforeSendHeadersListenerDetails> listener) {
			this.onSendHeaders = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnSendHeaders, this.InternalId, filter, listener != null);
		}
		private Func<OnHeadersReceivedListenerDetails, HeadersReceivedResponse> onHeadersReceived;
		internal Task<HeadersReceivedResponse> OnOnHeadersReceived(OnHeadersReceivedListenerDetails details) =>
			Task.FromResult(this.onHeadersReceived?.Invoke(details));
		public Task OnHeadersReceived(Func<OnHeadersReceivedListenerDetails, HeadersReceivedResponse> listener) =>
			this.OnHeadersReceived(null, listener);
		public Task OnHeadersReceived(Filter filter, Func<OnHeadersReceivedListenerDetails, HeadersReceivedResponse> listener) {
			this.onHeadersReceived = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnHeadersReceived, this.InternalId, filter, listener != null);
		}
		private Action<OnResponseStartedListenerDetails> onResponseStarted;
		internal Task OnOnResponseStarted(OnResponseStartedListenerDetails details) {
			this.onResponseStarted?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task OnResponseStarted(Action<OnResponseStartedListenerDetails> listener) =>
			this.OnResponseStarted(null, listener);
		public Task OnResponseStarted(Filter filter, Action<OnResponseStartedListenerDetails> listener) {
			this.onResponseStarted = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnResponseStarted, this.InternalId, filter, listener != null);
		}
		private Action<OnBeforeRedirectListenerDetails> onBeforeRedirect;
		internal Task OnOnBeforeRedirect(OnBeforeRedirectListenerDetails details) {
			this.onBeforeRedirect?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task OnBeforeRedirect(Action<OnBeforeRedirectListenerDetails> listener) =>
			this.OnBeforeRedirect(null, listener);
		public Task OnBeforeRedirect(Filter filter, Action<OnBeforeRedirectListenerDetails> listener) {
			this.onBeforeRedirect = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnBeforeRedirect, this.InternalId, filter, listener != null);
		}
		private Action<OnCompletedListenerDetails> onCompleted;
		internal Task OnOnCompleted(OnCompletedListenerDetails details) {
			this.onCompleted?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task OnCompleted(Action<OnCompletedListenerDetails> listener) =>
			this.OnCompleted(null, listener);
		public Task OnCompleted(Filter filter, Action<OnCompletedListenerDetails> listener) {
			this.onCompleted = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnCompleted, this.InternalId, filter, listener != null);
		}
		private Action<OnErrorOccurredListenerDetails> onErrorOccurred;
		internal Task OnOnErrorOccurred(OnErrorOccurredListenerDetails details) {
			this.onErrorOccurred?.Invoke(details);
			return Task.CompletedTask;
		}
		public Task OnErrorOccurred(Action<OnErrorOccurredListenerDetails> listener) =>
			this.OnErrorOccurred(null, listener);
		public Task OnErrorOccurred(Filter filter, Action<OnErrorOccurredListenerDetails> listener) {
			this.onErrorOccurred = listener;
			return Electron.ActionAsync(x => x.WebRequest_OnErrorOccurred, this.InternalId, filter, listener != null);
		}
	}
}