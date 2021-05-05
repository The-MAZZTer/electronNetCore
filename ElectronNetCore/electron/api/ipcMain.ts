import { ipcMain, IpcMainEvent, IpcMainInvokeEvent } from "electron";
import { ElectronApi, SignalRApi } from "./api";

const callbacks: Record<number, Function> = {};
const ipcMainChannelMap: Record<string, number[]> = {};
const ipcMainHandlerChannelMap: Record<string, number[]> = {};

let api: SignalRApi;
export const ElectronIpcMain: ElectronApi = {
	type: "IpcMain",
	init: x => api = x,
	handlers: {
		"On": (channel, requestId) => {
			const callback = async (e: IpcMainEvent, ...args: any[]) => {
				const id = api.store(e.reply);

				let portIds: number[] = null;
				if (e.ports) {
					portIds = [];
					for (const port of e.ports) {
						const id = api.store(port);
						portIds.push(id);
					}
				}

				await api.send("On_Callback", requestId, e.processId, e.frameId, e.sender?.id ?? 0, portIds, id, args.map((x: any) => JSON.stringify(x)));

				api.delete(id);
			};
			ipcMainChannelMap[channel] ??= []
			ipcMainChannelMap[channel].push(requestId);
			callbacks[requestId] = callback;
			ipcMain.on(channel, callback);
		},
		"Once": (channel, requestId) => {
			const callback = async (e: IpcMainEvent, ... args: any[]) => {
				const id = api.store(e.reply);

				const portIds: number[] = [];
				for (const port of e.ports) {
					const id = api.store(port);
					portIds.push(id);
				}

				ipcMainChannelMap[channel].splice(ipcMainChannelMap[channel].indexOf(requestId), 1);
				delete callbacks[requestId];

				await api.send("On_Callback", requestId, e.processId, e.frameId, e.sender?.id ?? 0, portIds, id, args.map((x: any) => JSON.stringify(x)));
				
				api.delete(id);
			};
			ipcMainChannelMap[channel] ??= []
			ipcMainChannelMap[channel].push(requestId);
			callbacks[requestId] = callback;
			ipcMain.once(channel, callback);
		},
		"RemoveListener": (channel, callbackId) => {
			if (ipcMainChannelMap[channel]) {
				const callback = callbacks[callbackId];
				ipcMainChannelMap[channel].splice(ipcMainChannelMap[channel].indexOf(callbackId), 1);
				delete callbacks[callbackId];
				ipcMain.removeListener(channel, <any>callback);	
			}
		},
		"RemoveAllListeners": channel => {
			if (ipcMainChannelMap[channel]) {
				for (const callbackId of ipcMainChannelMap[channel]) {
					delete callbacks[callbackId];
				}
				delete ipcMainChannelMap[channel];
				ipcMain.removeAllListeners(channel);
			}
		},
		"Handle": (channel, requestId) => {
			const callback = async (e: IpcMainInvokeEvent, ... args: any[]) => 
				await api.invoke("Handle_Callback", requestId, e.processId, e.frameId, e.sender?.id ?? 0,
					args.map((x: any) => JSON.stringify(x)));
			ipcMainHandlerChannelMap[channel] ??= []
			ipcMainHandlerChannelMap[channel].push(requestId);
			callbacks[requestId] = callback;
			ipcMain.handle(channel, callback);
		},
		"HandleOnce": (channel, requestId) => {
			const callback = async (e: IpcMainInvokeEvent, ... args: any[]) => {
				ipcMainHandlerChannelMap[channel].splice(ipcMainHandlerChannelMap[channel].indexOf(requestId), 1);
				delete callbacks[requestId];
				return await api.invoke("Handle_Callback", requestId, e.processId, e.frameId, e.sender?.id ?? 0,
					args.map((x: any) => JSON.stringify(x)));
			}
			ipcMainHandlerChannelMap[channel] ??= []
			ipcMainHandlerChannelMap[channel].push(requestId);
			callbacks[requestId] = callback;
			ipcMain.handle(channel, callback);
		},
		"RemoveHandler": channel => {
			if (ipcMainHandlerChannelMap[channel]) {
				for (const callbackId of ipcMainHandlerChannelMap[channel]) {
					delete callbacks[callbackId];
				}
				delete ipcMainHandlerChannelMap[channel];
				ipcMain.removeAllListeners(channel);
			}
		}
	}
};
