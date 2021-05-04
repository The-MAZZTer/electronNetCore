using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MZZT.ElectronNetCore.Api;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Example {
	public class Startup {
		public Startup(IConfiguration configuration) {
			this.Configuration = configuration;

			Electron.Process.Loaded += (sender, e) => {
				Console.WriteLine("Loaded");
			};

			Electron.ProcessExited += (sender, e) => {
				Console.WriteLine($"ProcessExited");

				Environment.Exit(e.ExitCode);
			};

			Electron.App.WindowAllClosed += (sender, e) => {
				Console.WriteLine($"WindowAllClosed");

				if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
					Task.Run(Electron.App.QuitAsync);
				}
			};

			Electron.App.Activate += (sender, e) => {
				Console.WriteLine($"Activate");

				if (!BrowserWindow.GetAllWindows().Any()) {
					Task.Run(this.CreateWindowAsync);
				}
			};

			Electron.App.BrowserWindowBlur += (sender, e) => { 
				Console.WriteLine($"BrowserWindow Blur: {e.Window.Id}");
			};

			Electron.App.BrowserWindowCreated += (sender, e) => {
				e.Window.Closed += (sender, e) => {
					Console.WriteLine($"BrowserWindow Closed: {((BrowserWindow)sender).Id}");
				};

				Console.WriteLine($"BrowserWindow Created: {e.Window.Id}");
			};

			Electron.App.BrowserWindowFocus += (sender, e) => {
				Console.WriteLine($"BrowserWindow Focus: {e.Window.Id}");
			};

			Electron.App.WebContentsCreated += (sender, e) => {
				e.WebContents.Destroyed += (sender, e) => {
					Console.WriteLine($"WebContents Destroyed: {((WebContents)sender).Id}");
				};

				Console.WriteLine($"WebContents Created: {e.WebContents.Id}");
			};

			Electron.App.GpuInfoUpdate += (sender, e) => {
				Console.WriteLine($"GpuInfoUpdate");
			};

			Electron.App.SecondInstance += (sender, e) => {
				Console.WriteLine("SecondInstance");

				Task.Run(async () => {
					await this.CreateWindowAsync();
				});
			};

			Electron.App.Ready += (sender, e) => {
				Console.WriteLine($"Ready");

				Task.Run(async () => {
					await Electron.App.Name.SetAsync("Example");
					await Electron.App.SetAppUserModelIdAsync("Example");
					if (!await Electron.App.RequestSingleInstanceLockAsync()) {
						Environment.Exit(0);
						return;
					}

					BrowserWindow win = await this.CreateWindowAsync();
				});
			};

			Task.Run(() => Electron.App.Name.SetAsync("Example"));
		}

		private async Task<BrowserWindow> CreateWindowAsync() {
			BrowserWindow win = await BrowserWindow.CreateAsync(new() {
				Width = 1280,
				Height = 720
			});
			await win.LoadUrlAsync("/");
			return win;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddSignalR();
			services.AddControllers();

			services.AddElectron();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
				endpoints.MapElectron();
			});

			app.UseDefaultFiles(new DefaultFilesOptions() {
				DefaultFileNames = new[] { "index.html" }
			});

			app.UseStaticFiles(new StaticFileOptions() {
				DefaultContentType = "application/octet-stream",
				ServeUnknownFileTypes = true
			});

			app.UseElectron(new() {
				Paths = new() {
					[Paths.UserData] = Path.Combine(AppContext.BaseDirectory, "profile")
				}
			});
		}
	}
}
