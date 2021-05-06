import { HubConnection, HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";
import { app } from "electron";
import { ElectronApi } from "./api/api";
import { ElectronApp } from "./api/app";
import { ElectronAppCommandLine } from "./api/appCommandLine";
import { ElectronAppDock } from "./api/appDock";
import { ElectronAutoUpdater } from "./api/autoUpdater";
import { ElectronBrowserView } from "./api/browserView";
import { ElectronBrowserWindow } from "./api/browserWindow";
import { ElectronClipboard } from "./api/clipboard";
import { ElectronContentTracing } from "./api/contentTracing";
import { ElectronCookies } from "./api/cookies";
import { ElectronCrashReporter } from "./api/crashReporter";
import { ElectronDebugger } from "./api/debugger";
import { ElectronDesktopCapturer } from "./api/desktopCapturer";
import { ElectronDialog } from "./api/dialog";
import { ElectronDownloadItem } from "./api/downloadItem";
import { ElectronFunction } from "./api/function";
import { ElectronGlobalShortcut } from "./api/globalShortcut";
import { ElectronInAppPurchase } from "./api/inAppPurchase";
import { ElectronIpcMain } from "./api/ipcMain";
import { ElectronMenu } from "./api/menu";
import { ElectronMenuItem } from "./api/menuItem";
import { ElectronMessagePortMain } from "./api/messagePortMain";
import { ElectronNativeImage } from "./api/nativeImage";
import { ElectronNativeTheme } from "./api/nativeTheme";
import { ElectronNet } from "./api/net";
import { ElectronNetLog } from "./api/netLog";
import { ElectronNotification } from "./api/notification";
import { ElectronPowerMonitor } from "./api/powerMonitor";
import { ElectronPowerSaveBlocker } from "./api/powerSaveBlucker";
import { ElectronProcess } from "./api/process";
import { ElectronProcessVersions } from "./api/processVersions";
import { ElectronProtocol } from "./api/protocol";
import { ElectronScreen } from "./api/screen";
import { ElectronServiceWorkers } from "./api/serviceWorkers";
import { ElectronSession } from "./api/session";
import { ElectronShell } from "./api/shell";
import { ElectronSystemPreferences } from "./api/systemPreferences";
import { ElectronTouchBar } from "./api/touchBar";
import { ElectronTouchBarButton } from "./api/touchBarButton";
import { ElectronTouchBarColorPicker } from "./api/touchBarColorPicker";
import { ElectronTouchBarGroup } from "./api/touchBarGroup";
import { ElectronTouchBarLabel } from "./api/touchBarLabel";
import { ElectronTouchBarOtherItemsProxy } from "./api/touchBarOtherItemsProxy";
import { ElectronTouchBarPopover } from "./api/touchBarPopover";
import { ElectronTouchBarScrubber } from "./api/touchBarScrubber";
import { ElectronTouchBarSegmentedControl } from "./api/touchBarSegmentedControl";
import { ElectronTouchBarSlider } from "./api/touchBarSlider";
import { ElectronTouchBarSpacer } from "./api/touchBarSpacer";
import { ElectronTray } from "./api/tray";
import { ElectronWebContents } from "./api/webContents";
import { ElectronWebFrameMain } from "./api/webFrameMain";
import { ElectronWebRequest } from "./api/webRequest";

export class SignalR {
	private nextGeneratedObjectId = 1;
	private readonly objects: Record<number | string, any> = {};

	private readonly types: ElectronApi[] = [];

	private signalr: HubConnection;

	public async start(url: string): Promise<void> {
		const signalr = this.signalr = new HubConnectionBuilder()
			.withAutomaticReconnect([0, 250, 500, null])
			.withUrl(new URL("/electronnetcoreproxy", url).href)
			.build();

		signalr.onclose(e => {
			console.error("Can't reconnect to ASP.NET Core!");
			console.error(e);
			app.quit();
		});

		signalr.on("DisposeObject", this.delete.bind(this));

		this.types.push(
			ElectronAppCommandLine,
			ElectronAppDock,
			ElectronAutoUpdater,
			ElectronBrowserView,
			ElectronBrowserWindow,
			ElectronClipboard,
			ElectronContentTracing,
			ElectronCookies,
			ElectronCrashReporter,
			ElectronDebugger,
			ElectronDesktopCapturer,
			ElectronDialog,
			ElectronDownloadItem,
			ElectronFunction,
			ElectronGlobalShortcut,
			ElectronInAppPurchase,
			ElectronIpcMain,
			ElectronMenu,
			ElectronMenuItem,
			ElectronMessagePortMain,
			ElectronNativeImage,
			ElectronNativeTheme,
			ElectronNet,
			ElectronNetLog,
			ElectronNotification,
			ElectronPowerMonitor,
			ElectronPowerSaveBlocker,
			ElectronProcessVersions,
			ElectronProcess,
			ElectronProtocol,
			ElectronScreen,
			ElectronServiceWorkers,
			ElectronSession,
			ElectronShell,
			ElectronSystemPreferences,
			ElectronTouchBar,
			ElectronTouchBarButton,
			ElectronTouchBarColorPicker,
			ElectronTouchBarGroup,
			ElectronTouchBarLabel,
			ElectronTouchBarPopover,
			ElectronTouchBarScrubber,
			ElectronTouchBarSegmentedControl,
			ElectronTouchBarSlider,
			ElectronTouchBarSpacer,
			ElectronTouchBarOtherItemsProxy,
			ElectronTray,
			ElectronWebContents,
			ElectronWebFrameMain,
			ElectronWebRequest,
			
			ElectronApp
		);
		for (const type of this.types) {
			type.init({
				send: (method, ...args) => this.send(`${type.type}_${method}`, ...args),
				invoke: (method, ...args) => this.invoke(`${type.type}_${method}`, ...args),
				store:  (...args) => this.store(...args),
				get:  (...args) => this.get(...args),
				delete:  (...args) => this.delete(...args)
			});
			for (let name in type.handlers) {
				const handler = type.handlers[name];
				signalr.on(`${type.type}_${name}`, async (...args: any[]) => {
					try {
						if (type.fromId) {
							args[1] = type.fromId(args[1]);
						}
		
						let ret = handler(...args.slice(1), args[0]);
						if (ret instanceof Promise) {
							ret = await ret;
						}
						if (ret === undefined) {
							await this.send("Return", args[0], "undefined");
						} else {
							for (const type of this.types) {
								if (type.instanceOf && type.instanceOf(ret)) {
									ret = type.toId(ret);
									break;
								}
							}

							await this.send("Return", args[0], JSON.stringify(ret));
						}
					} catch (e) {
						console.error(e);
						await this.send("Error", args[0], {
							name: e.name,
							message: e.message,
							stack: e.stack
						});
					}
				});
			}
		}

		try {
			await signalr.start();
		} catch (e) {
			console.error("Can't connect to ASP.NET Core!");
			console.error(e);
			app.quit();
		}
	}

	private async invoke<T>(method: string, ...args: any[]): Promise<T> {
		while (this.signalr.state !== HubConnectionState.Connected) {
			await new Promise(resolve => setTimeout(resolve, 5));
		}

		return await this.signalr.invoke<T>(method, ...args);
	}

	private async send(method: string, ...args: any[]): Promise<void> {
		while (this.signalr.state !== HubConnectionState.Connected) {
			await new Promise(resolve => setTimeout(resolve, 5));
		}

		await this.signalr.send(method, ...args);
	}
	
	private store(obj: any): number {
		if (obj === null || obj === undefined) {
			return 0;
		}

		let id = 0;
		for (const x in this.objects) {
			const value = this.objects[x];
			if (value === obj) {
				id = parseInt(x, 10);
				break;
			}
		}
		
		if (id === 0) {
			id = this.nextGeneratedObjectId++;
			this.objects[id] = obj;

			for (const type of this.types) {
				if (type.instanceOf && type.instanceOf(obj) && type.onStore) {
					type.onStore(obj, id);
					break;
				}
			}

			let type = obj.constructor?.name;
			switch (type) {
				case "Tray":
					break;
			}
		}

		return id;
	}
	private get<T>(id: number): T {
		return id ? <T>this.objects[id] : null;
	}
	private delete(id: number): void {
		if (!id) {
			return;
		}
		let obj = this.objects[id];
		delete this.objects[id];

		if (obj.removeAllListeners) {
			obj.removeAllListeners();
		}
	}
}
