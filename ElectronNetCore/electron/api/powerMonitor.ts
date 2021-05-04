import { powerMonitor } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let powerMonitorShutdownPreventDefault = false;

let api: SignalRApi;
export const ElectronPowerMonitor: ElectronApi = {
	type: "PowerMonitor",
	init: x => {
		api = x;

		powerMonitor.on("suspend", () =>
			api.send("Suspend_Event"));

		powerMonitor.on("resume", () =>
			api.send("Resume_Event"));

		powerMonitor.on("on-ac", () =>
			api.send("OnAc_Event"));

		powerMonitor.on("on-battery", () =>
			api.send("OnBattery_Event"));

		powerMonitor.on("shutdown", (e: Event) => {
			if (powerMonitorShutdownPreventDefault) {
				e.preventDefault();
			}
			return api.send("OnBattery_Event");
		});

		powerMonitor.on("lock-screen", () =>
			api.send("LockScreen_Event"));

		powerMonitor.on("unlock-screen", () =>
			api.send("UnlockScreen_Event"));

		powerMonitor.on("user-did-become-active", () =>
			api.send("UserDidBecomeActive_Event"));

		powerMonitor.on("user-did-resign-active", () =>
			api.send("UserDidResignActive_Event"));

	},
	handlers: {
		"Shutdown_PreventDefault": value => { powerMonitorShutdownPreventDefault = value; },

		"GetSystemIdleState": idleThreshold => powerMonitor.getSystemIdleState(idleThreshold),
		"GetSystemIdleTime": () => powerMonitor.getSystemIdleTime(),
		"IsOnBatteryPower": () => powerMonitor.isOnBatteryPower(),

		"OnBatteryPower_Get": () => powerMonitor.onBatteryPower
	}
};
