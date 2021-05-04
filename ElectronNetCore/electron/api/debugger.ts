import { Debugger } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronDebugger : ElectronApi = {
	type: "Debugger",
	instanceOf: x => x?.constructor?.name === "Debugger",
	fromId: x => api.get<Debugger>(x),
	toId: (x: Debugger) => api.store(x),
	init: x => api = x,
	onStore: (x: Debugger, id) => {
		x.on("detach", (_, reason) => 
			api.send("Deatch_Event", id, reason));

		x.on("message", (_, method, params, sessionId) => 
			api.send("Message_Event", id, method, params, sessionId));
	},
	handlers: {
		"Attach": (self: Debugger, protocolVersion) => self.attach(protocolVersion),
		"IsAttached": (self: Debugger) => self.isAttached(),
		"Detach": (self: Debugger) => self.detach(),
		"SendCommand": (self: Debugger, method, commandParams, sessionId) => self.sendCommand(method, commandParams, sessionId)
	}
};
