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

		internal static async Task DisposeObjectAsync<T>(T obj) where T : ElectronDisposable<T> {
			while (!Connected) {
				await Task.Delay(5);
			}
			await ElectronHub.Electron.DisposeObject(obj.Id);
		}

		private static readonly Dictionary<int, ReturnData> returnData = new();

		internal static Task OnError(int requestId, Error error) {
			lock (returnData) {
				returnData[requestId].Error = error;
			}
			return Task.CompletedTask;
		}

		internal static int NextRequestId { get; set; } = 1;
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
			} 

			if (type == typeof(WebContents)) {
				int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
					PropertyNameCaseInsensitive = true,
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				return (T)(object)WebContents.FromId(id);
			}

			while (type != null) {
				if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(ElectronDisposable<>)) {
					int id = (int)JsonSerializer.Deserialize(json, typeof(int), new() {
						PropertyNameCaseInsensitive = true,
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});
					return (T)ElectronDisposable.FromId(typeof(T), id);
				}
				type = type.BaseType;
			}

			return (T)JsonSerializer.Deserialize(json, type, new() {
				PropertyNameCaseInsensitive = true,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			});
		}

		internal async static Task ActionAsync(Func<IElectronInterface, Func<int, Task>> resolver) {
			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			await WaitUntilVoidAsync(id);
		}
		internal async static Task ActionAsync<TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			await WaitUntilVoidAsync(id);
		}
		internal async static Task ActionAsync<TArg1, TArg2>(Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver,
			TArg1 arg1, TArg2 arg2) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			await WaitUntilVoidAsync(id);
		}
		internal async static Task ActionAsync<TArg1, TArg2, TArg3>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver,
			TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			await WaitUntilVoidAsync(id);
		}
		internal async static Task ActionAsync<TArg1, TArg2, TArg3, TArg4>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver,
			TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3, arg4);
			await WaitUntilVoidAsync(id);
		}

		internal async static Task<TRet> FuncAsync<TRet>(Func<IElectronInterface, Func<int, Task>> resolver) {
			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2>(
			Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver, TArg1 arg1, TArg2 arg2) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3>(
			Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			return await WaitUntilReturnAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3, TArg4>(
			Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, TArg4, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {

			int id = NextRequestId++;
			lock (returnData) {
				returnData[id] = new($"{resolver.Target.GetType().Name}::{resolver.Method.Name}");
			}
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3, arg4);
			return await WaitUntilReturnAsync<TRet>(id);
		}

		public static ElectronApp App { get; } = new();
		public static ElectronAutoUpdater AutoUpdater { get; } = new();
		public static ElectronContentTracing ContentTracing { get; } = new();
		public static ElectronDialog Dialog { get; } = new();
		public static ElectronProcess Process { get; } = new();

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
