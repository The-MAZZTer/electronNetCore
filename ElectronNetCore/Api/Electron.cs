using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public static class Electron {
		internal static ILogger Log;
		public static bool Connected => ElectronHub.Electron != null;

		internal static string AppPath {
			get {
				string path = Assembly.GetEntryAssembly().Location;
				if (Path.GetExtension(path).ToLower() == ".dll") {
					path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
						path += ".exe";
					}
				}
				return path;
			}
		}

		internal static async Task DisposeObjectAsync<T>(ElectronDisposable<T> obj) where T : ElectronDisposable<T> {
			while (!Connected) {
				await Task.Delay(5);
			}
			await ElectronHub.Electron.DisposeObject(obj.InternalId);
		}

		private static readonly Dictionary<int, ReturnData> returnData = new();

		internal static Task OnError(int requestId, Error error) {
			lock (returnData) {
				returnData[requestId].Error = error;
			}
			return Task.CompletedTask;
		}

		private static int RequestId { get; set; } = 1;
		internal static int NextRequestId => RequestId++;

		internal static Task OnReturn(int requestId, string response = "null") {
			lock (returnData) {
				returnData[requestId].Json = response;
			}
			return Task.CompletedTask;
		}
		internal static async Task<ReturnData> WaitUntilResponseAsync(int requestId) {
			ReturnData data;
			lock (returnData) {
				data = returnData[requestId];
			}
			while (true) {
				lock (returnData) {
					if (data.Json != null || data.Error != null) {
						returnData.Remove(requestId);
						break;
					}
				}

				await Task.Delay(5);
			}

			if (data.Error != null) {
				throw new ElectronException(data.Error);
			}

			return data;
		}
		internal static async Task WaitUntilVoidAsync(int requestId) {
			ReturnData data = await WaitUntilResponseAsync(requestId);
			if (data.Json != "undefined") {
				Log.LogInformation($"Unexpected return value from {data.Name}: {data.Json}");
			}
		}
		internal static async Task<T> WaitUntilReturnAsync<T>(int requestId) {
			string json = (await WaitUntilResponseAsync(requestId)).Json;

			Type type = typeof(T);
			if (type == typeof(BrowserWindow)) {
				int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				return (T)(object)BrowserWindow.FromId(id);
			} else if (type == typeof(WebContents)) {
				int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				return (T)(object)WebContents.FromId(id);
			} else if (type == typeof(WebFrameMain)) {
				WebFrameMainId id = (WebFrameMainId)JsonSerializer.Deserialize(json, typeof(WebFrameMainId), new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				if (id == null) {
					return default;
				}
				return (T)(object)new WebFrameMain(id.ProcessId, id.RoutingId);
			} 

			Type electronType = type;
			while (electronType != null) {
				if (electronType.IsConstructedGenericType && electronType.GetGenericTypeDefinition() == typeof(ElectronDisposable<>)) {
					int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
						PropertyNameCaseInsensitive = true,
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});
					return (T)ElectronDisposable.FromId(type, id);
				}
				electronType = electronType.BaseType;
			}
			
			if (typeof(ElectronDisposable).IsAssignableFrom(type)) {
				int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				return (T)ElectronDisposable.FromId(typeof(T), id);
			}

			return (T)JsonSerializer.Deserialize(json, type, new() {
				PropertyNameCaseInsensitive = true,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			});
		}

		internal async static Task ActionAsync(int id, Func<IElectronInterface, Func<int, Task>> resolver) {
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			await WaitUntilVoidAsync(id);
		}
		internal static Task ActionAsync(Func<IElectronInterface, Func<int, Task>> resolver) =>
			ActionAsync(NextRequestId, resolver);
		internal async static Task ActionAsync<TArg>(int id, Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			await WaitUntilVoidAsync(id);
		}
		internal static Task ActionAsync<TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) =>
			ActionAsync(NextRequestId, resolver, arg);
		internal async static Task ActionAsync<TArg1, TArg2>(int id, Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver,
			TArg1 arg1, TArg2 arg2) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			await WaitUntilVoidAsync(id);
		}
		internal static Task ActionAsync<TArg1, TArg2>(Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver, TArg1 arg1, TArg2 arg2) =>
			ActionAsync(NextRequestId, resolver, arg1, arg2);
		internal async static Task ActionAsync<TArg1, TArg2, TArg3>(int id, Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver,
			TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			await WaitUntilVoidAsync(id);
		}
		internal static Task ActionAsync<TArg1, TArg2, TArg3>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
			ActionAsync(NextRequestId, resolver, arg1, arg2, arg3);
		internal async static Task ActionAsync<TArg1, TArg2, TArg3, TArg4>(int id, Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver,
			TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3, arg4);
			await WaitUntilVoidAsync(id);
		}
		internal static Task ActionAsync<TArg1, TArg2, TArg3, TArg4>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
			ActionAsync(NextRequestId, resolver, arg1, arg2, arg3, arg4);

		internal async static Task<TRet> FuncAsync<TRet>(int id, Func<IElectronInterface, Func<int, Task>> resolver) {
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal static Task<TRet> FuncAsync<TRet>(Func<IElectronInterface, Func<int, Task>> resolver) =>
			FuncAsync<TRet>(NextRequestId, resolver);
		internal async static Task<TRet> FuncAsync<TRet, TArg>(int id, Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal static Task<TRet> FuncAsync<TRet, TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) =>
			FuncAsync<TRet, TArg>(NextRequestId, resolver, arg);
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2>(int id,
			Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver, TArg1 arg1, TArg2 arg2) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal static Task<TRet> FuncAsync<TRet, TArg1, TArg2>(Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver, TArg1 arg1, TArg2 arg2) =>
			FuncAsync<TRet, TArg1, TArg2>(NextRequestId, resolver, arg1, arg2);
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3>(int id,
			Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
			FuncAsync<TRet, TArg1, TArg2, TArg3>(NextRequestId, resolver, arg1, arg2, arg3);
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3, TArg4>(int id,
			Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {

			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3, arg4);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3, TArg4>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
			FuncAsync<TRet, TArg1, TArg2, TArg3, TArg4>(NextRequestId, resolver, arg1, arg2, arg3, arg4);

		public static ElectronApp App { get; } = new();
		public static ElectronAutoUpdater AutoUpdater { get; } = new();
		public static ElectronClipboard Clipboard { get; } = new();
		public static ElectronContentTracing ContentTracing { get; } = new();
		public static ElectronCrashReporter CrashReporter { get; } = new();
		public static ElectronDesktopCapturer DesktopCapturer { get; } = new();
		public static ElectronDialog Dialog { get; } = new();
		public static ElectronGlobalShortcut GlobalShortcut { get; } = new();
		public static ElectronInAppPurchase InAppPurchase { get; } = new();
		public static ElectronIpcMain IpcMain { get; } = new();
		public static ElectronNativeTheme NativeTheme { get; } = new();
		public static ElectronNet Net { get; } = new();
		public static NetLog NetLog { get; } = new(0);
		public static ElectronPowerMonitor PowerMonitor { get; } = new();
		public static ElectronPowerSaveBlocker PowerSaveBlocker { get; } = new();
		public static ElectronProcess Process { get; } = new();
		public static Protocol Protocol { get; } = new(0);
		public static ElectronScreen Screen { get; } = new();
		public static ElectronShell Shell { get; } = new();
		public static ElectronSystemPreferences SystemPreferences { get; } = new();

		public static event EventHandler<ExitCodeEventArgs> ProcessExited;
		internal static void OnProcessExited(int exitCode) {
			ProcessExited?.Invoke(null, new(exitCode));
		}
	}

	internal class ReturnData {
		public ReturnData(string name) {
			this.Name = name;
		}

		public string Name { get; }
		public string Json { get; set; }
		public Error Error { get; set; }
	}
}
