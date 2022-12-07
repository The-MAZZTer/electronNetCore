using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MZZT.ElectronNetCore;
using System;

namespace Microsoft.AspNetCore.Hosting {
	public static class ElectronNetCoreBuilderExtensions {
		public static IWebHostBuilder UseElectron(this IWebHostBuilder builder, Action<LaunchElectronOptions> options = null) =>
			builder.ConfigureServices(services => {
				services.Configure(options);

				services.AddHostedService<ElectronNetCoreService>();
				services.AddTransient<IStartupFilter, ElectronStartupFilter>();
			});
	}

	internal class ElectronStartupFilter : IStartupFilter {
		public ElectronStartupFilter(IOptions<LaunchElectronOptions> options) : base() {
			this.options = options;
		}
		private readonly IOptions<LaunchElectronOptions> options;

		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) =>
			builder => {
				builder.UseRouting();
				builder.UseEndpoints(endpoints => {
					endpoints.MapHub<ElectronHub>(this.options.Value.SignalRHubPath, options => {
						options.ApplicationMaxBufferSize = 0;
						options.TransportMaxBufferSize = 0;
					});
				});
				next?.Invoke(builder);
			};
	}
}
