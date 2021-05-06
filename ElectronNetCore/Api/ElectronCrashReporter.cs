using MZZT.ElectronNetCore.Api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task CrashReporter_Start(int requestId, CrashReporterStartOptions options);
		Task CrashReporter_GetLastCrashReport(int requestId);
		Task CrashReporter_GetUploadedReports(int requestId);
		Task CrashReporter_GetUploadToServer(int requestId);
		Task CrashReporter_SetUploadToServer(int requestId, bool uploadToServer);
		Task CrashReporter_AddExtraParameter(int requestId, string key, string value);
		Task CrashReporter_RemoveExtraParameter(int requestId, string key);
		Task CrashReporter_GetParameters(int requestId);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronCrashReporter {
		internal ElectronCrashReporter() { }

		public Task StartAsync(CrashReporterStartOptions options) =>
			Electron.ActionAsync(x => x.CrashReporter_Start, options);
		public async Task<CrashReport> GetLastCrashReportAsync() =>
			(await Electron.FuncAsync<CrashReportDto>(x => x.CrashReporter_GetLastCrashReport))?.ToCrashReport();
		public async Task<CrashReport[]> GetUploadedReportsAsync() =>
			(await Electron.FuncAsync<CrashReportDto[]>(x => x.CrashReporter_GetUploadedReports))?.Select(x => x.ToCrashReport()).ToArray();
		public Task<bool> GetUploadToServerAsync() =>
			Electron.FuncAsync<bool>(x => x.CrashReporter_GetUploadToServer);
		public Task SetUploadToServerAsync(bool uploadToServer) =>
			Electron.ActionAsync(x => x.CrashReporter_SetUploadToServer, uploadToServer);
		public Task AddExtraParameterAsync(string key, string value) =>
			Electron.ActionAsync(x => x.CrashReporter_AddExtraParameter, key, value);
		public Task RemoveExtraParameterAsync(string key) =>
			Electron.ActionAsync(x => x.CrashReporter_RemoveExtraParameter, key);
		public Task<Dictionary<string, string>> GetParametersAsync() =>
			Electron.FuncAsync<Dictionary<string, string>>(x => x.CrashReporter_GetParameters);
	}
}