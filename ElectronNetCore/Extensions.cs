using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MZZT.ElectronNetCore;

namespace Microsoft.Extensions.DependencyInjection {
	public static class ElectronNetCoreServiceInjectorExtensions {
		public static IServiceCollection AddElectron(this IServiceCollection services) {
			return services.AddSingleton<ElectronNetCoreService>();
		}
	}
}

namespace Microsoft.AspNetCore.Builder {
	public static class ElectronNetCoreInitializerExtensions {
		public static IApplicationBuilder UseElectron(this IApplicationBuilder app, LaunchElectronOptions options = null) {
			app.ApplicationServices.GetService<ElectronNetCoreService>().LaunchElectron(app, options);
			return app;
		}

		public static IEndpointRouteBuilder MapElectron(this IEndpointRouteBuilder endpoints) {
			endpoints.MapHub<ElectronHub>("/electronnetcoreproxy", options => {
				options.ApplicationMaxBufferSize = 0;
				options.TransportMaxBufferSize = 0;
			});
			return endpoints;
		}
	}
}
