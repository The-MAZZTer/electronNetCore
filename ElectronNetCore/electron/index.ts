import { app, crashReporter, protocol } from "electron";
import process from "process";
import { LaunchElectronOptions } from "./models/launchElectronOptions";
import { SignalR } from "./signalr";

class ElectronNetCoreProxy {
  private constructor() {}

  private static signalR: SignalR;

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
    const url = args[0];
    if (!url) {
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
        type UserInit = {
          init(): void;
        };
        let user: UserInit = require(init.initScriptPath);
        try {
          user.init();
        } catch (e) {
          console.error(e);
        }
      }
    }
    
    this.signalR = new SignalR();
    await this.signalR.start(url);
  }
}

ElectronNetCoreProxy.main(process.argv);
