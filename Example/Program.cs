using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MZZT.ElectronNetCore.Api;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Example {
	public class Program {
		public static void Main(string[] args) {
			Electron.Process.Loaded += (sender, e) => {
				Console.WriteLine("Loaded");
			};

			Electron.ProcessExited += (sender, e) => {
				Console.WriteLine($"ProcessExited");

				Environment.Exit(e.ExitCode);
			};

			Electron.App.WindowAllClosed += (sender, e) => {
				Console.WriteLine($"WindowAllClosed");

				/*if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
					await Electron.App.QuitAsync();
				}*/
			};

			Electron.App.Activate += async (sender, e) => {
				Console.WriteLine($"Activate");

				if (!BrowserWindow.GetAllWindows().Any()) {
					await CreateWindowAsync();
				}
			};

			Electron.App.BrowserWindowCreated += async (sender, e) => {
				e.Window.Blur += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("blur");
				};

				e.Window.Focus += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("focus");
				};

				e.Window.Minimize += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("minimize");
				};

				e.Window.Restore += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("restore");
				};

				e.Window.Unmaximize += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("restore");
				};

				e.Window.Maximize += async (sender, e) => {
					BrowserWindow win = (BrowserWindow)sender;
					WebContents contents = await win.WebContents.GetAsync();
					await contents.SendAsync("maximize");
				};

				e.Window.Closed += (sender, e) => {
					Console.WriteLine($"BrowserWindow Closed: {((BrowserWindow)sender).Id}");
				};

				Console.WriteLine($"BrowserWindow Created: {e.Window.Id}");

				string appPath = AppPath;
				await e.Window.SetAppDetailsAsync(new() {
					AppId = "Example",
					AppIconIndex = 0,
					AppIconPath = appPath,
					RelaunchCommand = appPath,
					RelaunchDisplayName = "Example"
				});

				/*WebContents contents = await e.Window.WebContents.GetAsync();
				await contents.OpenDevToolsAsync();*/
			};

			Electron.App.SecondInstance += async (sender, e) => {
				Console.WriteLine("SecondInstance");

				int skip = 2;
				string[] argv = e.ArgV.SkipWhile(x => {
					if (x == "--") {
						skip--;
						return skip >= 0;
					}
					return skip > 0;
				}).ToArray();

				if (argv.Length > 0) {
					Console.WriteLine(string.Join(", ", argv));
				} else {
					await CreateWindowAsync();
				}
			};

			Electron.App.Ready += async (sender, e) => {
				Console.WriteLine($"Ready");

				await Electron.App.Name.SetAsync("Example");
				await Electron.App.SetAppUserModelIdAsync("Example");

				await Electron.IpcMain.OnAsync("maximize", async e => {
					WebContents contents = e.Sender;
					BrowserWindow window = await BrowserWindow.FromWebContentsAsync(contents);
					await window.MaximizeAsync();
				});
				await Electron.IpcMain.OnAsync("restore", async e => {
					WebContents contents = e.Sender;
					BrowserWindow window = await BrowserWindow.FromWebContentsAsync(contents);
					await window.UnmaximizeAsync();
					await window.RestoreAsync();
				});
				await Electron.IpcMain.OnAsync("minimize", async e => {
					WebContents contents = e.Sender;
					BrowserWindow window = await BrowserWindow.FromWebContentsAsync(contents);
					await window.MinimizeAsync();
				});
				await Electron.IpcMain.OnAsync("ready", async e => {
					WebContents contents = e.Sender;
					BrowserWindow window = await BrowserWindow.FromWebContentsAsync(contents);
					if (await window.IsFocusedAsync()) {
						await e.Sender.SendAsync("focus");
					} else {
						await e.Sender.SendAsync("blur");
					}
					if (await window.IsMinimizedAsync()) {
						await e.Sender.SendAsync("minimize");
					} else if (await window.IsMaximizedAsync()) {
						await e.Sender.SendAsync("maximize");
					} else {
						await e.Sender.SendAsync("restore");
					}
				});

				await Menu.SetApplicationMenuAsync(null);

				Tray tray = await Tray.CreateAsync(@"C:\Windows\WebManagement\www\default\favicon.ico");
				tray.DoubleClick += async (sender, e) => {
					await CreateWindowAsync();
				};

				await tray.SetToolTipAsync("Example");
				Menu menu = await Menu.BuildFromTemplateAsync(new MenuItemConstructorOptions[] {
					new() {
						Type = MenuItemTypes.Normal,
						Label = "Open new window",
						Click = async (e, win, contents) => {
							await CreateWindowAsync();
						}
					},
					new() {
						Type = MenuItemTypes.Normal,
						Label = "Test notification",
						Click = async (e, win, contents) => {
							Notification notification = await Notification.CreateAsync(new() {
								IconPath = @"C:\Windows\WebManagement\www\default\favicon.ico",
								Title = "Title",
								Body = "Body"
							});
							notification.Close += async (sender, e) => {
								await notification.DisposeAsync();
							};
							await notification.ShowAsync();
						}
					},
					new() {
						Type = MenuItemTypes.Separator
					},
					new() {
						Type = MenuItemTypes.Normal,
						Label = "Quit",
						Role = MenuItemRoles.Quit
					}
				});
				await tray.SetContextMenuAsync(menu);

				string appPath = AppPath;
				await Electron.App.SetUserTasksAsync(new JumpListTask[] {
					new() {
						IconPath = @"C:\Windows\WebManagement\www\default\favicon.ico",
						IconIndex = 0,
						Title = "Task Test",
						Program = appPath,
						Arguments = "--taskTest"
					}
				});

				await CreateWindowAsync();
			};

			CreateHostBuilder(args).Build().Run();
		}

		private static string AppPath {
			get {
				string path = Assembly.GetEntryAssembly().Location;
				if (Path.GetExtension(path).ToLower() == ".dll") {
					path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
						path += ".exe";
					}
				}
				return path;
			}
		}

		private static async Task<BrowserWindow> CreateWindowAsync() {
			BrowserWindow win = await BrowserWindow.CreateAsync(new() {
				Width = 1280,
				Height = 720,
				UseContentSize = true,
				Frame = false,
				WebPreferences = new() {
					NodeIntegration = true,
					ContextIsolation = false
				}
			});
			await win.LoadUrlAsync("/");
			return win;
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => webBuilder
					.UseElectron(new() {
						SingleInstance = true,
						SecondInstanceArgv = args,
						Paths = new() {
							[Paths.UserData] = Path.Combine(AppContext.BaseDirectory, "profile")
						},
						InitScriptPath = Path.Combine(AppContext.BaseDirectory, "user.js")
					})
					.UseUrls("http://127.0.0.1:0")
					.UseStartup<Startup>()
				);
	}
}
