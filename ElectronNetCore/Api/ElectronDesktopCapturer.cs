using MZZT.ElectronNetCore.Api;
using System.Linq;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task DesktopCapturer_GetSources(int requestId, SourcesOptions options);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronDesktopCapturer {
		internal ElectronDesktopCapturer() { }

		public async Task<DesktopCapturerSource[]> GetSourcesAsync(SourcesOptions options) =>
			(await Electron.FuncAsync<DesktopCapturerSourceDto[], SourcesOptions>(x => x.DesktopCapturer_GetSources, options))?.Select(x => x.ToDesktopCapturerSource()).ToArray();
	}
}