using MZZT.ElectronNetCore.Api;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task ContentTracing_GetCategories(int requestId);
		Task ContentTracing_StartRecording_TraceConfig(int requestId, TraceConfig options);
		Task ContentTracing_StartRecording_TraceCategoriesAndOptions(int requestId, TraceCategoriesAndOptions options);
		Task ContentTracing_StopRecording(int requestId, string resultFilePath);
		Task ContentTracing_GetTraceBufferUsage(int requestId);
	}
}

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
