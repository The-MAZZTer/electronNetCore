using System.Threading.Tasks;
using System;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task PowerMonitor_Shutdown_PreventDefault(int requestId, bool value);

		Task PowerMonitor_GetSystemIdleState(int requestId, int idleThreshold);
		Task PowerMonitor_GetSystemIdleTime(int requestId);
		Task PowerMonitor_IsOnBatteryPower(int requestId);

		Task PowerMonitor_OnBatteryPower_Get(int requestId);
	}

	internal partial class ElectronHub {
		public Task PowerMonitor_Suspend_Event() =>
			Api.Electron.PowerMonitor.OnSuspend();
		public Task PowerMonitor_Resume_Event() =>
			Api.Electron.PowerMonitor.OnResume();
		public Task PowerMonitor_OnAc_Event() =>
			Api.Electron.PowerMonitor.OnOnAc();
		public Task PowerMonitor_OnBattery_Event() =>
			Api.Electron.PowerMonitor.OnOnBattery();
		public Task PowerMonitor_Shutdown_Event() =>
			Api.Electron.PowerMonitor.OnShutdown();
		public Task PowerMonitor_LockScreen_Event() =>
			Api.Electron.PowerMonitor.OnLockScreen();
		public Task PowerMonitor_UnlockScreen_Event() =>
			Api.Electron.PowerMonitor.OnUnlockScreen();
		public Task PowerMonitor_UserDidBecomeActive_Event() =>
			Api.Electron.PowerMonitor.OnUserDidBecomeActive();
		public Task PowerMonitor_UserDidResignActive_Event() =>
			Api.Electron.PowerMonitor.OnUserDidResignActive();
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronPowerMonitor {
		internal ElectronPowerMonitor() { }

		public event EventHandler Suspend;
		internal Task OnSuspend() {
			this.Suspend?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler Resume;
		internal Task OnResume() {
			this.Resume?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler OnAc;
		internal Task OnOnAc() {
			this.OnAc?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler OnBattery;
		internal Task OnOnBattery() {
			this.OnBattery?.Invoke(this, new());
			return Task.CompletedTask;
		}

		private bool cancelShutdown;
		public bool CancelShutdown {
			get => this.cancelShutdown;
			set {
				if (this.cancelShutdown == value) {
					return;
				}
				this.cancelShutdown = value;

				Task.Run(() => ElectronHub.Electron.PowerMonitor_Shutdown_PreventDefault(0, value));
			}
		}

		public event EventHandler Shutdown;
		internal Task OnShutdown() {
			this.Shutdown?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler LockScreen;
		internal Task OnLockScreen() {
			this.LockScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler UnlockScreen;
		internal Task OnUnlockScreen() {
			this.UnlockScreen?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler UserDidBecomeActive;
		internal Task OnUserDidBecomeActive() {
			this.UserDidBecomeActive?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public event EventHandler UserDidResignActive;
		internal Task OnUserDidResignActive() {
			this.UserDidResignActive?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public Task<string> GetSystemIdleStateAsync(int idleThreshold) =>
			Electron.FuncAsync<string, int>(x => x.PowerMonitor_GetSystemIdleState, idleThreshold);
		public Task<int> GetSystemIdleTimeAsync() =>
			Electron.FuncAsync<int>(x => x.PowerMonitor_GetSystemIdleTime);
		public Task<bool> IsOnBatteryPowerAsync() =>
			Electron.FuncAsync<bool>(x => x.PowerMonitor_IsOnBatteryPower);

		public ElectronReadOnlyProperty<bool> OnBatteryPower { get; } = new(x => x.PowerMonitor_OnBatteryPower_Get);
	}
}