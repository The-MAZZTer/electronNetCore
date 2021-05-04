using MZZT.ElectronNetCore.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task Protocol_RegisterSchemesAsPrivileged(int requestId, int id, CustomScheme[] customSchemes);
		Task Protocol_RegisterFileProtocol(int requestId, int id, string scheme);
		Task Protocol_RegisterBufferProtocol(int requestId, int id, string scheme);
		Task Protocol_RegisterStringProtocol(int requestId, int id, string scheme);
		Task Protocol_RegisterHttpProtocol(int requestId, int id, string scheme);
		Task Protocol_UnregisterProtocol(int requestId, int id, string scheme);
		Task Protocol_IsProtocolRegistered(int requestId, int id, string scheme);
		Task Protocol_InterceptFileProtocol(int requestId, int id, string scheme);
		Task Protocol_InterceptBufferProtocol(int requestId, int id, string scheme);
		Task Protocol_InterceptStringProtocol(int requestId, int id, string scheme);
		Task Protocol_InterceptHttpProtocol(int requestId, int id, string scheme);
		Task Protocol_UninterceptProtocol(int requestId, int id, string scheme);
		Task Protocol_IsProtocolIntercepted(int requestId, int id, string scheme);
	}

	internal partial class ElectronHub {
		public Task<ProtocolFileResponse> Protocol_RegisterFileProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnRegisterFileProtocolCallback(callbackId, request.ToProtocolRequest());
		public async Task<ProtocolBufferResponseDto> Protocol_RegisterBufferProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(await (id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnRegisterBufferProtocolCallback(callbackId, request.ToProtocolRequest())).ToProtocolBufferResponseDto();
		public Task<ProtocolStringResponse> Protocol_RegisterStringProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnRegisterStringProtocolCallback(callbackId, request.ToProtocolRequest());
		public async Task<ProtocolHttpResponseDto> Protocol_RegisterHttpProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(await (id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnRegisterHttpProtocolCallback(callbackId, request.ToProtocolRequest())).ToProtocolHttpResponseDto();
		public Task<ProtocolFileResponse> Protocol_InterceptFileProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnInterceptFileProtocolCallback(callbackId, request.ToProtocolRequest());
		public async Task<ProtocolBufferResponseDto> Protocol_InterceptBufferProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(await (id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnInterceptBufferProtocolCallback(callbackId, request.ToProtocolRequest())).ToProtocolBufferResponseDto();
		public Task<ProtocolStringResponse> Protocol_InterceptStringProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnInterceptStringProtocolCallback(callbackId, request.ToProtocolRequest());
		public async Task<ProtocolHttpResponseDto> Protocol_InterceptHttpProtocol_Callback(int id, int callbackId, ProtocolRequestDto request) =>
			(await (id > 0 ? ElectronDisposable.FromId<Protocol>(id) : Api.Electron.Protocol).OnInterceptHttpProtocolCallback(callbackId, request.ToProtocolRequest())).ToProtocolHttpResponseDto();
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class Protocol : ElectronDisposable<Protocol> {
		internal Protocol(int id) : base(id) { }

		public Task RegisterSchemesAsPrivileged(CustomScheme[] customSchemes) =>
			Electron.ActionAsync(x => x.Protocol_RegisterSchemesAsPrivileged, this.InternalId, customSchemes);
		private readonly Dictionary<string, List<int>> registerMap = new();
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolFileResponse>>> registerFileProtocolHandlers = new();
		public async Task<bool> RegisterFileProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolFileResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_RegisterFileProtocol, this.InternalId, scheme);
			if (result) {
				this.registerFileProtocolHandlers[requestId] = handler;
				if (!this.registerMap.TryGetValue(scheme, out List<int> map)) {
					this.registerMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolFileResponse> OnRegisterFileProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.registerFileProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolBufferResponse>>> registerBufferProtocolHandlers = new();
		public async Task<bool> RegisterBufferProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolBufferResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_RegisterBufferProtocol, this.InternalId, scheme);
			if (result) {
				this.registerBufferProtocolHandlers[requestId] = handler;
				if (!this.registerMap.TryGetValue(scheme, out List<int> map)) {
					this.registerMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolBufferResponse> OnRegisterBufferProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.registerBufferProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolStringResponse>>> registerStringProtocolHandlers = new();
		public async Task<bool> RegisterStringProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolStringResponse>> handler) {
			int nextRequestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(nextRequestId, x => x.Protocol_RegisterStringProtocol, this.InternalId, scheme);
			if (result) {
				this.registerStringProtocolHandlers[nextRequestId] = handler;
				if (!this.registerMap.TryGetValue(scheme, out List<int> map)) {
					this.registerMap[scheme] = map = new();
				}
				map.Add(nextRequestId);
			}
			return result;
		}
		public Task<ProtocolStringResponse> OnRegisterStringProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.registerStringProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolHttpResponse>>> registerHttpProtocolHandlers = new();
		public async Task<bool> RegisterHttpProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolHttpResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_RegisterHttpProtocol, this.InternalId, scheme);
			if (result) {
				this.registerHttpProtocolHandlers[requestId] = handler;
				if (!this.registerMap.TryGetValue(scheme, out List<int> map)) {
					this.registerMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolHttpResponse> OnRegisterHttpProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.registerHttpProtocolHandlers[callbackId](request);
		public async Task<bool> UnregisterProtocolAsync(string scheme) {
			bool result = await Electron.FuncAsync<bool, int, string>(x => x.Protocol_UnregisterProtocol, this.InternalId, scheme);
			if (result && this.registerMap.TryGetValue(scheme, out List<int> map)) {
				foreach (int id in map) {
					this.registerFileProtocolHandlers.Remove(id);
					this.registerBufferProtocolHandlers.Remove(id);
					this.registerStringProtocolHandlers.Remove(id);
					this.registerHttpProtocolHandlers.Remove(id);
				}
				this.registerMap.Remove(scheme);
			}
			return result;
		}
		public Task<bool> IsProtocolRegisteredAsync(string scheme) =>
			Electron.FuncAsync<bool, int, string>(x => x.Protocol_IsProtocolRegistered, this.InternalId, scheme);
		private readonly Dictionary<string, List<int>> interceptMap = new();
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolFileResponse>>> interceptFileProtocolHandlers = new();
		public async Task<bool> InterceptFileProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolFileResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_InterceptFileProtocol, this.InternalId, scheme);
			if (result) {
				this.interceptFileProtocolHandlers[requestId] = handler;
				if (!this.interceptMap.TryGetValue(scheme, out List<int> map)) {
					this.interceptMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolFileResponse> OnInterceptFileProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.interceptFileProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolBufferResponse>>> interceptBufferProtocolHandlers = new();
		public async Task<bool> InterceptBufferProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolBufferResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_InterceptBufferProtocol, this.InternalId, scheme);
			if (result) {
				this.interceptBufferProtocolHandlers[requestId] = handler;
				if (!this.interceptMap.TryGetValue(scheme, out List<int> map)) {
					this.interceptMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolBufferResponse> OnInterceptBufferProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.interceptBufferProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolStringResponse>>> interceptStringProtocolHandlers = new();
		public async Task<bool> InterceptStringProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolStringResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_InterceptStringProtocol, this.InternalId, scheme);
			if (result) {
				this.interceptStringProtocolHandlers[requestId] = handler;
				if (!this.interceptMap.TryGetValue(scheme, out List<int> map)) {
					this.interceptMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolStringResponse> OnInterceptStringProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.interceptStringProtocolHandlers[callbackId](request);
		private readonly Dictionary<int, Func<ProtocolRequest, Task<ProtocolHttpResponse>>> interceptHttpProtocolHandlers = new();
		public async Task<bool> InterceptHttpProtocolAsync(string scheme, Func<ProtocolRequest, Task<ProtocolHttpResponse>> handler) {
			int requestId = Electron.NextRequestId;
			bool result = await Electron.FuncAsync<bool, int, string>(requestId, x => x.Protocol_InterceptHttpProtocol, this.InternalId, scheme);
			if (result) {
				this.interceptHttpProtocolHandlers[requestId] = handler;
				if (!this.interceptMap.TryGetValue(scheme, out List<int> map)) {
					this.interceptMap[scheme] = map = new();
				}
				map.Add(requestId);
			}
			return result;
		}
		public Task<ProtocolHttpResponse> OnInterceptHttpProtocolCallback(int callbackId, ProtocolRequest request) =>
			this.interceptHttpProtocolHandlers[callbackId](request);
		public async Task<bool> UninterceptProtocolAsync(string scheme) {
			bool result = await Electron.FuncAsync<bool, int, string>(x => x.Protocol_UninterceptProtocol, this.InternalId, scheme);
			if (result && this.interceptMap.TryGetValue(scheme, out List<int> map)) {
				foreach (int id in map) {
					this.interceptFileProtocolHandlers.Remove(id);
					this.interceptBufferProtocolHandlers.Remove(id);
					this.interceptStringProtocolHandlers.Remove(id);
					this.interceptHttpProtocolHandlers.Remove(id);
				}
				this.interceptMap.Remove(scheme);
			}
			return result;
		}
		public Task<bool> IsProtocolInterceptedAsync(string scheme) =>
			Electron.FuncAsync<bool, int, string>(x => x.Protocol_IsProtocolIntercepted, this.InternalId, scheme);
	}
}
