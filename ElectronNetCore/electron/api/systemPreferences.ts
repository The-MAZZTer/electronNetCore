import { systemPreferences } from "electron";
import { ElectronApi, SignalRApi } from "./api";

let api: SignalRApi;
export const ElectronSystemPreferences : ElectronApi = {
	type: "SystemPreferences",
	init: x => {
		api = x;

		systemPreferences.on("accent-color-changed", (_, newColor) =>
			api.send("AccentColorChanged_Event", newColor));

		systemPreferences.on("color-changed", _ =>
			api.send("ColorChanged_Event"));
	},
	handlers: {
		"IsSwipeTrackingFromScrollEventsEnabled": () => systemPreferences.isSwipeTrackingFromScrollEventsEnabled(),
		"PostNotification": (event, userInfo, deliverImmediately) => systemPreferences.postNotification(event, userInfo, deliverImmediately),
		"PostLocalNotification": (event, userInfo) => systemPreferences.postLocalNotification(event, userInfo),
		"PostWorkspaceNotification": (event, userInfo) => systemPreferences.postWorkspaceNotification(event, userInfo),
		"SubscribeNotification": event => {
			const id = systemPreferences.subscribeNotification(event, (event, userInfo, object) =>
				api.send("SubscribeNotification_Callback", id, event, userInfo, object));
			return id;
		},
		"SubscribeLocalNotification": event => {
			const id = systemPreferences.subscribeLocalNotification(event, (event, userInfo, object) =>
				api.send("SubscribeLocalNotification_Callback", id, event, userInfo, object));
			return id;
		},
		"SubscribeWorkspaceNotification": event => {
			const id = systemPreferences.subscribeWorkspaceNotification(event, (event, userInfo, object) =>
				api.send("SubscribeWorkspaceNotification_Callback", id, event, userInfo, object));
			return id;
		},
		"UnsubscribeNotification": id => systemPreferences.unsubscribeNotification(id),
		"UnsubscribeLocalNotification": id => systemPreferences.unsubscribeLocalNotification(id),
		"UnsubscribeWorkspaceNotification": id => systemPreferences.unsubscribeWorkspaceNotification(id),
		"RegisterDefaults": defaults => systemPreferences.registerDefaults(defaults),
		"GetUserDefault": (key, type) => systemPreferences.getUserDefault(key, type),
		"SetUserDefault": (key, type, value) => systemPreferences.setUserDefault(key, type, value),
		"RemoveUserDefault": key => systemPreferences.removeUserDefault(key),
		"IsAeroGlassEnabled": () => systemPreferences.isAeroGlassEnabled(),
		"GetAccentColor": () => systemPreferences.getAccentColor(),
		"GetColor": color => systemPreferences.getColor(color),
		"GetSystemColor": color => systemPreferences.getSystemColor(color),
		"GetEffectiveAppearance": () => systemPreferences.getEffectiveAppearance(),
		"CanPromptTouchId": () => systemPreferences.canPromptTouchID(),
		"PromptTouchId": reason => systemPreferences.promptTouchID(reason),
		"IsTrustedAccessibilityClient": prompt => systemPreferences.isTrustedAccessibilityClient(prompt),
		"GetMediaAccessStatus": mediaType => systemPreferences.getMediaAccessStatus(mediaType),
		"AskForMediaAccess": mediaType => systemPreferences.askForMediaAccess(mediaType),
		"GetAnimationSettings": () => systemPreferences.getAnimationSettings(),

		"AppLevelAppearance_Get": () => systemPreferences.appLevelAppearance,
		"AppLevelAppearance_Set": value => { systemPreferences.appLevelAppearance = value; },
		"EffectiveAppearance_Get": () => systemPreferences.effectiveAppearance
	}
};
