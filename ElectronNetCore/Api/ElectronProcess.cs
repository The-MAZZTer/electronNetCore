using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronProcess {
		internal ElectronProcess() { }

		public ElectronProcessVersions Versions { get; } = new();

		public event EventHandler Loaded;
		internal Task OnLoaded() {
			this.Loaded?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public ElectronReadOnlyProperty<bool> DefaultApp { get; } =
			new(x => x.Process_DefaultApp_Get);
		public ElectronReadOnlyProperty<bool> IsMainFrame { get; } =
			new(x => x.Process_IsMainFrame_Get);
		public ElectronReadOnlyProperty<bool> Mas { get; } =
			new(x => x.Process_Mas_Get);
		public ElectronProperty<bool> NoAsar { get; } =
			new(x => x.Process_NoAsar_Get, x => x.Process_NoAsar_Set);
		public ElectronProperty<bool> NoDeprecation { get; } =
			new(x => x.Process_NoDeprecation_Get, x => x.Process_NoDeprecation_Set);
		public ElectronReadOnlyProperty<string> ResourcesPath { get; } =
			new(x => x.Process_ResourcesPath_Get);
		public ElectronReadOnlyProperty<bool> Sandboxed { get; } =
			new(x => x.Process_Sandboxed_Get);
		public ElectronProperty<bool> ThrowDeprecation { get; } =
			new(x => x.Process_ThrowDeprecation_Get, x => x.Process_ThrowDeprecation_Set);
		public ElectronProperty<bool> TraceDeprecation { get; } =
			new(x => x.Process_TraceDeprecation_Get, x => x.Process_TraceDeprecation_Set);
		public ElectronProperty<bool> TraceProcessWarnings { get; } =
			new(x => x.Process_TraceProcessWarnings_Get, x => x.Process_TraceProcessWarnings_Set);
		public ElectronReadOnlyProperty<string> Type { get; } =
			new(x => x.Process_Type_Get);
		public ElectronReadOnlyProperty<bool> WindowsStore { get; } =
			new(x => x.Process_WindowsStore_Get);

		public Task CrashAsync() =>
			Electron.ActionAsync(x => x.Process_Crash);
		public async Task<DateTime?> GetCreationTimeAsync() {
			double? ms = await Electron.FuncAsync<double?>(x => x.Process_GetCreationTime);
			if (!ms.HasValue) {
				return null;
			}
			return DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromMilliseconds(ms.Value), DateTimeKind.Utc);
		}
		public Task<CpuUsage> GetCpuUsageAsync() =>
			Electron.FuncAsync<CpuUsage>(x => x.Process_GetCpuUsage);
		public Task<IoCounters> GetIoCountersAsync() =>
			Electron.FuncAsync<IoCounters>(x => x.Process_GetIoCounters);
		public Task<HeapStatistics> GetHeapStatisticsAsync() =>
			Electron.FuncAsync<HeapStatistics>(x => x.Process_GetHeapStatistics);
		public Task<BlinkMemoryInfo> GetBlinkMemoryInfoAsync() =>
			Electron.FuncAsync<BlinkMemoryInfo>(x => x.Process_GetBlinkMemoryInfo);
		public Task<ProcessMemoryInfo> GetProcessMemoryInfoAsync() =>
			Electron.FuncAsync<ProcessMemoryInfo>(x => x.Process_GetProcessMemoryInfo);
		public Task<SystemMemoryInfo> GetSystemMemoryInfoAsync() =>
			Electron.FuncAsync<SystemMemoryInfo>(x => x.Process_GetSystemMemoryInfo);
		public Task<string> GetSystemVersionAsync() =>
			Electron.FuncAsync<string>(x => x.Process_GetSystemVersion);
		public Task<bool> TakeHeapSnapshotAsync(string filePath) =>
			Electron.FuncAsync<bool, string>(x => x.Process_TakeHeapSnapshot, filePath);
		public Task HangAsync() =>
			Electron.ActionAsync(x => x.Process_Hang);
		public Task SetFdLimitAsync(int maxDescriptors) =>
			Electron.ActionAsync<int>(x => x.Process_SetFdLimit, maxDescriptors);
	}

	public class ElectronProcessVersions {
		internal ElectronProcessVersions() { }

		public ElectronReadOnlyProperty<string> Chrome { get; } =
			new(x => x.ProcessVersions_Chrome_Get);
		public ElectronReadOnlyProperty<string> Electron { get; } =
			new(x => x.ProcessVersions_Electron_Get);
	}
}
