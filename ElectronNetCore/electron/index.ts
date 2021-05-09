import fs from "fs/promises";
import process from "process";
import { app, crashReporter, CrashReporterStartOptions, CustomScheme, protocol } from "electron";
import { SignalR } from "./signalr";

const delay = (time: number): Promise<void> => 
  new Promise(resolve => setTimeout(resolve, time));

type LaunchElectronOptions = {
  singleInstance?: boolean;
	chromiumCommandLineFlags?: Record<string, string>;
	paths?: Record<string, string>;
	hardwareAcceleration?: boolean;
	unstableDomainBlockingFor3dApis?: boolean;
	forceSandbox?: boolean;
	privilegedSchemes?: CustomScheme[];
	crashReporterOptions?: CrashReporterStartOptions;
	initScriptPath?: string
};

type UserInit = {
  init?(): void;
  onSignalRConnect?(): void;
};

class ElectronNetCoreProxy {
  private constructor() {}

  private static signalR: SignalR;

  private static user: UserInit;

  private static getArgs(args: string[]): string[] {
    for (let i = 1; i < args.length; i++) {
      const arg = args[i];
      if (arg.startsWith("-")) {
        continue;
      }
      return args.slice(i + 1);
    }
    return [];
  }

  public static async main(argv: string[]): Promise<void> {
    const args = this.getArgs(argv);
    const urlFile = args[0];
    if (!urlFile) {
      console.log("This component is part of a larger application, please do not run it directly.");
      app.quit();
      return;
    }

    if (args[1]) {
      const init: LaunchElectronOptions = JSON.parse(args[1]);
      if (init.chromiumCommandLineFlags) {
        for (const flag in init.chromiumCommandLineFlags) {
          const value = init.chromiumCommandLineFlags[flag];
          if (value !== null) {
            app.commandLine.appendSwitch(flag, value);
          } else {
            app.commandLine.appendArgument(flag);
          }
        }
      }
      if (init.paths) {
        for (const name in init.paths) {
          const value = init.paths[name];
          app.setPath(name, value);
        }
      }
      if (init.singleInstance) {
        if (!app.requestSingleInstanceLock()) {
          app.quit();
          return;
        }
      }
      if (init.hardwareAcceleration === false) {
        app.disableHardwareAcceleration();
      }
      if (init.unstableDomainBlockingFor3dApis === false) {
        app.disableDomainBlockingFor3DAPIs();
      }
      if (init.forceSandbox) {
        app.enableSandbox();
      }
      if (init.privilegedSchemes) {
        protocol.registerSchemesAsPrivileged(init.privilegedSchemes);
      }
      if (init.crashReporterOptions) {
        crashReporter.start(init.crashReporterOptions);
      }
      if (init.initScriptPath) {
        this.user = require(init.initScriptPath);
        if (this.user.init) {
          try {
            this.user.init();
          } catch (e) {
            console.error(e);
          }  
        }
      }
    }

    this.signalR = new SignalR();

    while (!(await fs.stat(urlFile)).size) {
      await delay(25);
    }

    let url: string = null;
    while (!url) {
      try {
        url = await fs.readFile(urlFile, { encoding: "utf-8", flag: "r"});
        await fs.unlink(urlFile);
      } catch {
      }  

      if (!url) {
        await delay(25);
      }
    }
    
    if (await this.signalR.start(url)) {
      if (this.user?.onSignalRConnect) {
        try {
          this.user.onSignalRConnect();
        } catch (e) {
          console.error(e);
        }  
      }
    }
  }
}

ElectronNetCoreProxy.main(process.argv);
