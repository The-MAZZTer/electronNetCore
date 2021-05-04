using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task SystemPreferences_IsSwipeTrackingFromScrollEventsEnabled(int requestId);
		Task SystemPreferences_PostNotification(int requestId, string @event, Dictionary<string, object> userInfo, bool deliverImmediately);
		Task SystemPreferences_PostLocalNotification(int requestId, string @event, Dictionary<string, object> userInfo);
		Task SystemPreferences_PostWorkspaceNotification(int requestId, string @event, Dictionary<string, object> userInfo);
		Task SystemPreferences_SubscribeNotification(int requestId, string @event);
		Task SystemPreferences_SubscribeLocalNotification(int requestId, string @event);
		Task SystemPreferences_SubscribeWorkspaceNotification(int requestId, string @event);
		Task SystemPreferences_UnsubscribeNotification(int requestId, int id);
		Task SystemPreferences_UnsubscribeLocalNotification(int requestId, int id);
		Task SystemPreferences_UnsubscribeWorkspaceNotification(int requestId, int id);
		Task SystemPreferences_RegisterDefaults(int requestId, Dictionary<string, object> defaults);
		Task SystemPreferences_GetUserDefault(int requestId, string key, object type);
		Task SystemPreferences_SetUserDefault(int requestId, string key, object type, object value);
		Task SystemPreferences_RemoveUserDefault(int requestId, string key);
		Task SystemPreferences_IsAeroGlassEnabled(int requestId);
		Task SystemPreferences_GetAccentColor(int requestId);
		Task SystemPreferences_GetColor(int requestId, string color);
		Task SystemPreferences_GetSystemColor(int requestId, string color);
		Task SystemPreferences_GetEffectiveAppearance(int requestId);
		Task SystemPreferences_CanPromptTouchId(int requestId);
		Task SystemPreferences_PromptTouchId(int requestId, string reason);
		Task SystemPreferences_IsTrustedAccessibilityClient(int requestId, bool prompt);
		Task SystemPreferences_GetMediaAccessStatus(int requestId, string mediaType);
		Task SystemPreferences_AskForMediaAccess(int requestId, string mediaType);
		Task SystemPreferences_GetAnimationSettings(int requestId);

		Task SystemPreferences_AppLevelAppearance_Get(int requestId);
		Task SystemPreferences_AppLevelAppearance_Set(int requestId, string value);
		Task SystemPreferences_EffectiveAppearance_Get(int requestId);
	}

	internal partial class ElectronHub {
		public Task SystemPreferences_AccentColorChanged_Event(string newColor) =>
			Api.Electron.SystemPreferences.OnAccentColorChanged(newColor);
		public Task SystemPreferences_ColorChanged_Event() =>
			Api.Electron.SystemPreferences.OnColorChanged();

		public Task SystemPreferences_SubscribeNotification_Callback(int id, string @event, Dictionary<string, object> userInfo, string @object) =>
			Api.Electron.SystemPreferences.OnSubscribeNotificationCallback(id, @event, userInfo, @object);
		public Task SystemPreferences_SubscribeLocalNotification_Callback(int id, string @event, Dictionary<string, object> userInfo, string @object) =>
			Api.Electron.SystemPreferences.OnSubscribeLocalNotificationCallback(id, @event, userInfo, @object);
		public Task SystemPreferences_SubscribeWorkspaceNotification_Callback(int id, string @event, Dictionary<string, object> userInfo, string @object) =>
			Api.Electron.SystemPreferences.OnSubscribeWorkspaceNotificationCallback(id, @event, userInfo, @object);
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronSystemPreferences {
		internal ElectronSystemPreferences() { }

		public event EventHandler<SystemPreferenceAccentColorChangedEventArgs> AccentColorChanged;
		internal Task OnAccentColorChanged(string newColor) {
			this.AccentColorChanged?.Invoke(this, new(newColor));
			return Task.CompletedTask;
		}

		public event EventHandler ColorChanged;
		internal Task OnColorChanged() {
			this.ColorChanged?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public Task<bool> IsSwipeTrackingFromScrollEventsEnabledAsync() =>
			Electron.FuncAsync<bool>(x => x.SystemPreferences_IsSwipeTrackingFromScrollEventsEnabled);
		public Task PostNotificationAsync(string @event, Dictionary<string, object> userInfo, bool deliverImmediately = false) =>
			Electron.ActionAsync(x => x.SystemPreferences_PostNotification, @event, userInfo, deliverImmediately);
		public Task PostLocalNotificationAsync(string @event, Dictionary<string, object> userInfo) =>
			Electron.ActionAsync(x => x.SystemPreferences_PostLocalNotification, @event, userInfo);
		public Task PostWorkspaceNotificationAsync(string @event, Dictionary<string, object> userInfo) =>
			Electron.ActionAsync(x => x.SystemPreferences_PostWorkspaceNotification, @event, userInfo);
		private readonly Dictionary<int, Action<string, Dictionary<string, object>, string>> notificationCallbacks = new();
		internal Task OnSubscribeNotificationCallback(int id, string @event, Dictionary<string, object> userInfo, string @object) {
			this.notificationCallbacks[id](@event, userInfo, @object);
			return Task.CompletedTask;
		}
		public async Task<int> SubscribeNotificationAsync(string @event, Action<string, Dictionary<string, object>, string> callback) {
			int id = await Electron.FuncAsync<int, string>(x => x.SystemPreferences_SubscribeNotification, @event);
			this.notificationCallbacks[id] = callback;
			return id;
		}
		private readonly Dictionary<int, Action<string, Dictionary<string, object>, string>> localNotificationCallbacks = new();
		internal Task OnSubscribeLocalNotificationCallback(int id, string @event, Dictionary<string, object> userInfo, string @object) {
			this.localNotificationCallbacks[id](@event, userInfo, @object);
			return Task.CompletedTask;
		}
		public async Task<int> SubscribeLocalNotificationAsync(string @event, Action<string, Dictionary<string, object>, string> callback) {
			int id = await Electron.FuncAsync<int, string>(x => x.SystemPreferences_SubscribeLocalNotification, @event);
			this.localNotificationCallbacks[id] = callback;
			return id;
		}
		private readonly Dictionary<int, Action<string, Dictionary<string, object>, string>> workspaceNotificationCallbacks = new();
		internal Task OnSubscribeWorkspaceNotificationCallback(int id, string @event, Dictionary<string, object> userInfo, string @object) {
			this.workspaceNotificationCallbacks[id](@event, userInfo, @object);
			return Task.CompletedTask;
		}
		public async Task<int> SubscribeWorkspaceNotificationAsync(string @event, Action<string, Dictionary<string, object>, string> callback) {
			int id = await Electron.FuncAsync<int, string>(x => x.SystemPreferences_SubscribeWorkspaceNotification, @event);
			this.workspaceNotificationCallbacks[id] = callback;
			return id;
		}
		public Task UnsubscribeNotificationAsync(int id) {
			this.notificationCallbacks.Remove(id);
			return Electron.ActionAsync(x => x.SystemPreferences_UnsubscribeNotification, id);
		}
		public Task UnsubscribeLocalNotificationAsync(int id) {
			this.localNotificationCallbacks.Remove(id);
			return Electron.ActionAsync(x => x.SystemPreferences_UnsubscribeLocalNotification, id);
		}
		public Task UnsubscribeWorkspaceNotificationAsync(int id) {
			this.workspaceNotificationCallbacks.Remove(id);
			return Electron.ActionAsync(x => x.SystemPreferences_UnsubscribeWorkspaceNotification, id);
		}
		public Task RegisterDefaultsAsync(Dictionary<string, object> defaults) =>
			Electron.ActionAsync(x => x.SystemPreferences_RegisterDefaults, defaults);
		public Task<T> GetUserDefaultAsync<T>(string key, string type) =>
			Electron.FuncAsync<T, string, string>(x => x.SystemPreferences_GetUserDefault, key, type);
		public Task SetUserDefaultAsync(string key, string type, object value) =>
			Electron.ActionAsync(x => x.SystemPreferences_SetUserDefault, key, type, value);
		public Task RemoveUserDefaultAsync(string key) =>
			Electron.ActionAsync(x => x.SystemPreferences_RemoveUserDefault, key);
		public Task<bool> IsAeroGlassEnabledAsync() =>
			Electron.FuncAsync<bool>(x => x.SystemPreferences_IsAeroGlassEnabled);
		public Task<string> GetAccentColorAsync() =>
			Electron.FuncAsync<string>(x => x.SystemPreferences_GetAccentColor);
		public async Task<Color> GetAccentColorColorAsync() {
			string color = await this.GetAccentColorAsync();
			if (color == null) {
				return default;
			}

			int parsed = int.Parse(color[1..], NumberStyles.HexNumber);
			byte a = (byte)(parsed & 0xFF);
			parsed >>= 8;
			parsed &= 0xFFFFFF;
			parsed |= a << 24;

			return Color.FromArgb(parsed);
		}
		public Task<string> GetColorAsync(string color) =>
			Electron.FuncAsync<string, string>(x => x.SystemPreferences_GetColor, color);
		public async Task<Color> GetColorColorAsync(string color) {
			color = await this.GetColorAsync(color);
			if (color == null) {
				return default;
			}
			return Color.FromArgb(-16777216 | int.Parse(color[1..], NumberStyles.HexNumber));
		}
		public Task<string> GetSystemColorAsync(string color) =>
			Electron.FuncAsync<string, string>(x => x.SystemPreferences_GetSystemColor, color);
		public async Task<Color> GetSystemColorColorAsync(string color) {
			color = await this.GetSystemColorAsync(color);
			if (color == null) {
				return default;
			}

			int parsed = int.Parse(color[1..], NumberStyles.HexNumber);
			byte a = (byte)(parsed & 0xFF);
			parsed >>= 8;
			parsed &= 0xFFFFFF;
			parsed |= a << 24;

			return Color.FromArgb(parsed);
		}
		public Task<string> GetEffectiveAppearanceAsync() =>
			Electron.FuncAsync<string>(x => x.SystemPreferences_GetEffectiveAppearance);
		public Task<bool> CanPromptTouchId() =>
			Electron.FuncAsync<bool>(x => x.SystemPreferences_CanPromptTouchId);
		public Task PromptTouchId(string reason) =>
			Electron.ActionAsync(x => x.SystemPreferences_PromptTouchId, reason);
		public Task<bool> IsTrustedAccessibilityClient(bool prompt) =>
			Electron.FuncAsync<bool, bool>(x => x.SystemPreferences_IsTrustedAccessibilityClient, prompt);
		public Task<string> GetMediaAccessStatus(string mediaType) =>
			Electron.FuncAsync<string, string>(x => x.SystemPreferences_GetMediaAccessStatus, mediaType);
		public Task<bool> AskForMediaAccess(string mediaType) =>
			Electron.FuncAsync<bool, string>(x => x.SystemPreferences_AskForMediaAccess, mediaType);
		public Task<AnimationSettings> GetAnimationSettings() =>
			Electron.FuncAsync<AnimationSettings>(x => x.SystemPreferences_GetAnimationSettings);

		public ElectronProperty<string> AppLevelAppearance { get; } = new(x => x.SystemPreferences_AppLevelAppearance_Get,
			x => x.SystemPreferences_AppLevelAppearance_Set);
		public ElectronReadOnlyProperty<string> EffectiveAppearance { get; } = new(x => x.SystemPreferences_EffectiveAppearance_Get);
	}
}