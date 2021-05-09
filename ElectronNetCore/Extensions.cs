using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MZZT.ElectronNetCore;
using System;

namespace Microsoft.AspNetCore.Hosting {
	public static class ElectronNetCoreBuilderExtensions {
		public static IWebHostBuilder UseElectron(this IWebHostBuilder builder, LaunchElectronOptions options = null) =>
			builder.ConfigureServices(services => {
				ElectronNetCoreService.options = options;
				services.AddHostedService<ElectronNetCoreService>();
				services.AddTransient<IStartupFilter, ElectronStartupFilter>();
			});
	}

	internal class ElectronStartupFilter : IStartupFilter {
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) =>
			builder => {
				builder.UseRouting();
				builder.UseEndpoints(endpoints => {
					endpoints.MapHub<ElectronHub>("/electronnetcoreproxy", options => {
						options.ApplicationMaxBufferSize = 0;
						options.TransportMaxBufferSize = 0;
					});
				});
				next?.Invoke(builder);
			};
	}
}
