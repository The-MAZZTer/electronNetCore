using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronGlobalShortcut {
		internal ElectronGlobalShortcut() { }

		private readonly Dictionary<string, List<int>> callbackMap = new();
		private readonly Dictionary<int, Action> callbacks = new();
		internal Task OnCallback(int requestId) {
			Action callback = this.callbacks.GetValueOrDefault(requestId);
			callback?.Invoke();
			return Task.CompletedTask;
		}
		public async Task<bool> Register(string accelerator, Action callback) {
			int requestId = Electron.NextRequestId;
			List<int> map = this.callbackMap.GetValueOrDefault(accelerator);
			if (map == null) {
				this.callbackMap[accelerator] = map = new List<int>();
			}
			map.Add(requestId);
			this.callbacks[requestId] = callback;
			return await Electron.FuncAsync<bool, string>(x => x.GlobalShortcut_Register, accelerator);
		}
		public async Task<bool> RegisterAll(string[] accelerators, Action callback) {
			int requestId = Electron.NextRequestId;
			this.callbacks[requestId] = callback;
			return await Electron.FuncAsync<bool, string[]>(x => x.GlobalShortcut_RegisterAll, accelerators);
		}
		public Task<bool> IsRegistered(string accelerator) =>
			Electron.FuncAsync<bool, string>(x => x.GlobalShortcut_IsRegistered, accelerator);
		public async Task Unregister(string accelerator) {
			await Electron.ActionAsync(x => x.GlobalShortcut_Unregister, accelerator);
			List<int> list = this.callbackMap.GetValueOrDefault(accelerator);
			if (list != null) {
				foreach (int requestId in list) {
					this.callbacks.Remove(requestId);
				}
				this.callbackMap.Remove(accelerator);
			}
		}
		public async Task UnregisterAll() {
			await Electron.ActionAsync(x => x.GlobalShortcut_UnregisterAll);
			this.callbacks.Clear();
			this.callbackMap.Clear();
		}
	}
}