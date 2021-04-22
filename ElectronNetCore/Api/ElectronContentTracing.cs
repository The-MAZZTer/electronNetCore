using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class ElectronContentTracing {
		internal ElectronContentTracing() { }

		public Task<string[]> GetCategories() =>
			Electron.FuncAsync<string[]>(x => x.ContentTracing_GetCategories);
		public Task StartRecording(TraceConfig options) =>
			Electron.ActionAsync(x => x.ContentTracing_StartRecording_TraceConfig, options);
		public Task StartRecording(TraceCategoriesAndOptions options) =>
			Electron.ActionAsync(x => x.ContentTracing_StartRecording_TraceCategoriesAndOptions, options);
		public Task<string> StopRecording(string resultFilePath = null) =>
			Electron.FuncAsync<string, string>(x => x.ContentTracing_StopRecording, resultFilePath);
		public Task<TraceBufferUsageReturnValue> GetTraceBufferUsage() =>
			Electron.FuncAsync<TraceBufferUsageReturnValue>(x => x.ContentTracing_GetTraceBufferUsage);
	}
}
