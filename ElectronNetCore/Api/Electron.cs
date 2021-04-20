using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public static class Electron {
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

		internal static Task OnError(int requestId, Error error) {
			lock (data) {
				data[requestId] = error;
			}
			return Task.CompletedTask;
		}

		internal static int NextRequestId { get; set; } = 1;
		internal static Task Fulfill(int requestId) {
			lock (data) {
				data[requestId] = null;
			}
			return Task.CompletedTask;
		}
		internal static Task Fulfill<T>(int requestId, T response) {
			lock (data) {
				data[requestId] = response;
			}
			return Task.CompletedTask;
		}
		private static readonly Dictionary<int, object> data = new();
		internal static async Task WaitUntilFulfilledAsync(int requestId) {
			bool fulfilled = false;
			while (!fulfilled) {
				lock (data) {
					if (data.ContainsKey(requestId)) {
						fulfilled = true;
						data.Remove(requestId);
					}
				}

				if (!fulfilled) {
					await Task.Delay(5);
				}
			}
		}
		internal static async Task<T> WaitUntilFulfilledAsync<T>(int requestId) {
			object ret = null;
			bool fulfilled = false;
			while (!fulfilled) {
				lock (data) {
					if (data.TryGetValue(requestId, out ret)) {
						fulfilled = true;
						data.Remove(requestId);
					}
				}

				if (!fulfilled) {
					await Task.Delay(25);
				}
			}

			if (ret is Error err) {
				throw new ElectronException(err);
			}

			/*Type type = typeof(T);
			while (type != null) {
				if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(ElectronDisposable<>)) {
					return (T)ElectronDisposable.FromId(typeof(T), (int)ret);
				}
				type = type.BaseType;
			}*/

			return (T)ret;
		}

		internal async static Task ActionAsync(Func<IElectronInterface, Func<int, Task>> resolver) {
			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			await WaitUntilFulfilledAsync(id);
		}
		internal async static Task ActionAsync<TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			await WaitUntilFulfilledAsync(id);
		}
		internal async static Task ActionAsync<TArg1, TArg2>(Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver,
			TArg1 arg1, TArg2 arg2) {

			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			await WaitUntilFulfilledAsync(id);
		}
		internal async static Task ActionAsync<TArg1, TArg2, TArg3>(Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver,
			TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			await WaitUntilFulfilledAsync(id);
		}

		internal async static Task<TRet> FuncAsync<TRet>(Func<IElectronInterface, Func<int, Task>> resolver) {
			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id);
			return await WaitUntilFulfilledAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg>(Func<IElectronInterface, Func<int, TArg, Task>> resolver, TArg arg) {
			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg);
			return await WaitUntilFulfilledAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2>(
			Func<IElectronInterface, Func<int, TArg1, TArg2, Task>> resolver, TArg1 arg1, TArg2 arg2) {

			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2);
			return await WaitUntilFulfilledAsync<TRet>(id);
		}
		internal async static Task<TRet> FuncAsync<TRet, TArg1, TArg2, TArg3>(
			Func<IElectronInterface, Func<int, TArg1, TArg2, TArg3, Task>> resolver, TArg1 arg1, TArg2 arg2, TArg3 arg3) {

			int id = NextRequestId++;
			while (!Connected) {
				await Task.Delay(25);
			}
			await resolver(ElectronHub.Electron)(id, arg1, arg2, arg3);
			return await WaitUntilFulfilledAsync<TRet>(id);
		}

		public static ElectronApp App { get; } = new();
		public static ElectronAutoUpdater AutoUpdater { get; } = new();
		public static ElectronProcess Process { get; } = new();

		public static event EventHandler<ExitCodeEventArgs> ProcessExited;
		internal static void OnProcessExited(int exitCode) {
			ProcessExited?.Invoke(null, new(exitCode));
		}
	}
}
