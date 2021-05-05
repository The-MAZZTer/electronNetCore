using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task IpcMain_On(int requestId, string channel);
		Task IpcMain_Once(int requestId, string channel);
		Task IpcMain_RemoveListener(int requestId, string channel, int callbackId);
		Task IpcMain_RemoveAllListeners(int requestId, string channel);
		Task IpcMain_Handle(int requestId, string channel);
		Task IpcMain_HandleOnce(int requestId, string channel);
		Task IpcMain_RemoveHandler(int requestId, string channel);
	}

	internal partial class ElectronHub {
		public Task IpcMain_On_Callback(int callbackId, int processId, int frameId, int sender, int[] ports, int reply, string[] args) =>
			Api.Electron.IpcMain.OnCallback(callbackId, processId, frameId, WebContents.FromId(sender), ports?.Select(x => ElectronDisposable.FromId<MessagePortMain>(x)).ToArray(), reply, args);
		public Task<object> IpcMain_Handle_Callback(int callbackId, int processId, int frameId, int sender, string[] args) =>
			Api.Electron.IpcMain.OnHandleCallback(callbackId, processId, frameId, WebContents.FromId(sender), args);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronIpcMain {
		internal ElectronIpcMain() { }

		private struct Callback {
			public Delegate Method;
			public bool Once;
			public Type[] ArgTypes;
		}

		private readonly Dictionary<string, List<int>> channelMap = new();
		private readonly Dictionary<int, Callback> callbacks = new();

		internal async Task OnCallback(int callbackId, int processId, int frameId, WebContents sender, MessagePortMain[] ports, int reply, string[] args) {
			WebFrameMain webFrameMain = new(processId, frameId);
			try {
				Callback callback = this.callbacks[callbackId];
				string channel = this.channelMap.First(x => x.Value.Contains(callbackId)).Key;
				IpcMainEvent @event = new() {
					ProcessId = processId,
					FrameId = frameId,
					Sender = sender,
					SenderFrame = webFrameMain,
					Ports = ports,
					Reply = reply
				};
				object[] decodedArgs = callback.ArgTypes.Zip(args).Select(x => JsonSerializer.Deserialize(x.Second, x.First, new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				})).Prepend(@event).ToArray();
				callback.Method.DynamicInvoke(decodedArgs);
				if (callback.Once) {
					this.channelMap[channel].Remove(callbackId);
					this.callbacks.Remove(callbackId);
				}
			} finally {
				if (ports != null) {
					foreach (MessagePortMain port in ports) {
						await port.DisposeAsync();
					}
				}
			}
		}

		public Task OnAsync(string channel, Delegate listener, Type[] argTypes) {
			if (!this.channelMap.TryGetValue(channel, out List<int> map)) {
				this.channelMap[channel] = map = new();
			}

			int requestId = Electron.NextRequestId;
			map.Add(requestId);
			this.callbacks[requestId] = new() {
				Method = listener,
				Once = false,
				ArgTypes = argTypes
			};
			return Electron.ActionAsync(requestId, x => x.IpcMain_On, channel);
		}
		public Task OnAsync(string channel, Action<IpcMainEvent> listener) =>
			this.OnAsync(channel, listener, Array.Empty<Type>());
		public Task OnAsync<T>(string channel, Action<IpcMainEvent, T> listener) =>
			this.OnAsync(channel, listener, new[] { typeof(T) });
		public Task OnAsync<TArg1, TArg2>(string channel, Action<IpcMainEvent, TArg1, TArg2> listener) =>
			this.OnAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2) });
		public Task OnAsync<TArg1, TArg2, TArg3>(string channel, Action<IpcMainEvent, TArg1, TArg2, TArg3> listener) =>
			this.OnAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });
		public Task OnOnceAsync(string channel, Delegate listener, Type[] argTypes) {
			if (!this.channelMap.TryGetValue(channel, out List<int> map)) {
				this.channelMap[channel] = map = new();
			}

			int requestId = Electron.NextRequestId;
			map.Add(requestId);
			this.callbacks[requestId] = new() {
				Method = listener,
				Once = true,
				ArgTypes = argTypes
			};
			return Electron.ActionAsync(requestId, x => x.IpcMain_Once, channel);
		}
		public Task OnOnceAsync(string channel, Action<IpcMainEvent> listener) =>
			this.OnOnceAsync(channel, listener, Array.Empty<Type>());
		public Task OnOnceAsync<T>(string channel, Action<IpcMainEvent, T> listener) =>
			this.OnOnceAsync(channel, listener, new[] { typeof(T) });
		public Task OnOnceAsync<TArg1, TArg2>(string channel, Action<IpcMainEvent, TArg1, TArg2> listener) =>
			this.OnOnceAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2) });
		public Task OnOnceAsync<TArg1, TArg2, TArg3>(string channel, Action<IpcMainEvent, TArg1, TArg2, TArg3> listener) =>
			this.OnOnceAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });
		public Task RemoveListenerAsync(string channel, Delegate listener) {
			int callbackId = this.callbacks.FirstOrDefault(x => x.Value.Method == listener).Key;
			if (callbackId <= 0) {
				return Task.CompletedTask;
			}

			if (this.channelMap.TryGetValue(channel, out List<int> map)) {
				map.Remove(callbackId);
			}
			this.callbacks.Remove(callbackId);

			return Electron.ActionAsync(x => x.IpcMain_RemoveListener, channel, callbackId);
		}
		public Task RemoveAllListenersAsync(string channel) {
			if (this.channelMap.TryGetValue(channel, out List<int> map)) {
				foreach (int callbackId in map) {
					this.callbacks.Remove(callbackId);
				}
				this.channelMap.Remove(channel);
			}

			return Electron.ActionAsync(x => x.IpcMain_RemoveAllListeners, channel);
		}

		private readonly Dictionary<string, List<int>> handleChannelMap = new();
		private readonly Dictionary<int, Callback> handleCallbacks = new();

		internal Task<object> OnHandleCallback(int callbackId, int processId, int frameId, WebContents sender, string[] args) {
			WebFrameMain webFrameMain = new(processId, frameId);
			Callback callback = this.handleCallbacks[callbackId];
			string channel = this.handleChannelMap.First(x => x.Value.Contains(callbackId)).Key;
			IpcMainInvokeEvent @event = new() {
				ProcessId = processId,
				FrameId = frameId,
				Sender = sender,
				SenderFrame = webFrameMain
			};
			object[] decodedArgs = callback.ArgTypes.Zip(args).Select(x => JsonSerializer.Deserialize(x.Second, x.First, new() {
				PropertyNameCaseInsensitive = true,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			})).Prepend(@event).ToArray();
			object ret = callback.Method.DynamicInvoke(decodedArgs);
			if (callback.Once) {
				this.handleChannelMap[channel].Remove(callbackId);
				this.handleCallbacks.Remove(callbackId);
			}
			return Task.FromResult(ret);
		}

		public Task HandleAsync(string channel, Delegate listener, Type[] argTypes) {
			if (!this.handleChannelMap.TryGetValue(channel, out List<int> map)) {
				this.handleChannelMap[channel] = map = new();
			}

			int requestId = Electron.NextRequestId;
			map.Add(requestId);
			this.handleCallbacks[requestId] = new() {
				Method = listener,
				Once = false,
				ArgTypes = argTypes
			};
			return Electron.ActionAsync(requestId, x => x.IpcMain_Handle, channel);
		}
		public Task HandleAsync(string channel, Action<IpcMainEvent> listener) =>
			this.HandleAsync(channel, listener, Array.Empty<Type>());
		public Task HandleAsync<T>(string channel, Action<IpcMainEvent, T> listener) =>
			this.HandleAsync(channel, listener, new[] { typeof(T) });
		public Task HandleAsync<TArg1, TArg2>(string channel, Action<IpcMainEvent, TArg1, TArg2> listener) =>
			this.HandleAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2) });
		public Task HandleAsync<TArg1, TArg2, TArg3>(string channel, Action<IpcMainEvent, TArg1, TArg2, TArg3> listener) =>
			this.HandleAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });
		public Task HandleOnceAsync(string channel, Delegate listener, Type[] argTypes) {
			if (!this.handleChannelMap.TryGetValue(channel, out List<int> map)) {
				this.handleChannelMap[channel] = map = new();
			}

			int requestId = Electron.NextRequestId;
			map.Add(requestId);
			this.handleCallbacks[requestId] = new() {
				Method = listener,
				Once = true,
				ArgTypes = argTypes
			};
			return Electron.ActionAsync(requestId, x => x.IpcMain_HandleOnce, channel);
		}
		public Task HandleOnceAsync(string channel, Action<IpcMainEvent> listener) =>
			this.HandleOnceAsync(channel, listener, Array.Empty<Type>());
		public Task HandleOnceAsync<T>(string channel, Action<IpcMainEvent, T> listener) =>
			this.HandleOnceAsync(channel, listener, new[] { typeof(T) });
		public Task HandleOnceAsync<TArg1, TArg2>(string channel, Action<IpcMainEvent, TArg1, TArg2> listener) =>
			this.HandleOnceAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2) });
		public Task HandleOnceAsync<TArg1, TArg2, TArg3>(string channel, Action<IpcMainEvent, TArg1, TArg2, TArg3> listener) =>
			this.HandleOnceAsync(channel, listener, new[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) });
		public Task RemoveHandler(string channel) {
			if (this.handleChannelMap.TryGetValue(channel, out List<int> map)) {
				foreach (int callbackId in map) {
					this.handleCallbacks.Remove(callbackId);
				}
				this.handleChannelMap.Remove(channel);
			}

			return Electron.ActionAsync(x => x.IpcMain_RemoveHandler, channel);
		}
	}
}