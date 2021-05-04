using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public static class ActivationPolicies {
		public const string Regular = "regular";
		public const string Accessory = "accessory";
		public const string Prohibited = "prohibited";
	}

	public static class AlwaysOnTopLevels {
		public const string Normal = "normal";
		public const string Floating = "floating";
		public const string TornOffMenu = "torn-off-menu";
		public const string ModalPanel = "modal-panel";
		public const string MainMenu = "main-menu";
		public const string Status = "status";
		public const string PopUpMenu = "pop-up-menu";
		public const string ScreenSaver = "screen-saver";
	}

	public static class AppearanceSettings {
		public const string Light = "light";
		public const string Dark = "dark";
		public const string Unknown = "unknown";
	}

	public static class AutoplayPolicies {
		public const string NoUserGestureRequired = "no-user-gesture-required";
		public const string UserGestureRequired = "user-gesture-required";
		public const string DocumentUserActivationRequired = "document-user-activation-required";
	}

	public static class BalloonIconTypes {
		public const string None = "none";
		public const string Info = "info";
		public const string Warning = "warning";
		public const string Error = "error";
		public const string Custom = "custom";
	}

	public static class BounceTypes {
		public const string Critical = "critical";
		public const string Informational = "informational";
	}

	public static class BrowserWindowDispositions {
		public const string Default = "default";
		public const string ForegroundTab = "foreground-tab";
		public const string BackgroundTab = "background-tab";
		public const string NewWindow = "new-window";
		public const string SaveToDisk = "save-to-disk";
		public const string Other = "other";
	}

	public static class BrowserWindowTitleBarStyles {
		public const string Default = "default";
		public const string Hidden = "hidden";
		public const string HiddenInset = "hiddenInset";
	}

	public static class BrowserWindowTypes {
		public const string Desktop = "desktop";
		public const string Dock = "dock";
		public const string Toolbar = "toolbar";
		public const string Splash = "splash";
		public const string Notification = "notification";
		public const string Textured = "textured";
	}

	public static class BrowserWindowVibrancyTypes {
		public const string AppearanceBased = "appearance-based";
		public const string Light = "light";
		public const string Dark = "dark";
		public const string Titlebar = "titlebar";
		public const string Selection = "selection";
		public const string Menu = "menu";
		public const string Popover = "popover";
		public const string Sidebar = "sidebar";
		public const string MediumLight = "medium-light";
		public const string UltraDark = "ultra-dark";
		public const string Header = "header";
		public const string Sheet = "sheet";
		public const string Window = "window";
		public const string Hud = "hud";
		public const string FullscreenUi = "fullscreen-ui";
		public const string Tooltip = "tooltip";
		public const string Content = "content";
		public const string UnderWindow = "under-window";
		public const string UnderPage = "under-page";
	}

	public static class BrowserWindowVisualEffectStates {
		public const string FollowWindow = "followWindow";
		public const string Active = "active";
		public const string Inactive = "inactive";
	}

	public static class ChildProcessTypes {
		public const string Utility = "Utility";
		public const string Zygote = "Zygote";
		public const string SandboxHelper = "Sandbox helper";
		public const string Gpu = "GPU";
		public const string PepperPlugin = "Pepper Plugin";
		public const string PepperPluginBroker = "Pepper Plugin Broker";
		public const string Unknown = "Unknown";
	}

	public static class ColorNames {
		public const string ThreeDDarkShadow = "3d-dark-shadow";
		public const string ThreeDFace = "3d-face";
		public const string ThreeDHighlight = "3d-highlight";
		public const string ThreeDLight = "3d-light";
		public const string ThreeDShadow = "3d-shadow";
		public const string ActiveBorder = "active-border";
		public const string ActiveCaption = "active-caption";
		public const string ActiveCaptionGradient = "active-caption-gradient";
		public const string AppWorkspace = "app-workspace";
		public const string ButtonText = "button-text";
		public const string CaptionText = "caption-text";
		public const string Desktop = "desktop";
		public const string DisabledText = "disabled-text";
		public const string Highlight = "highlight";
		public const string HighlightText = "highlight-text";
		public const string Hotlight = "hotlight";
		public const string InactiveBorder = "inactive-border";
		public const string InactiveCaption = "inactive-caption";
		public const string InactiveCaptionGradient = "inactive-caption-gradient";
		public const string InactiveCaptionText = "inactive-caption-text";
		public const string InfoBackground = "info-background";
		public const string InfoText = "info-text";
		public const string Menu = "menu";
		public const string MenuHighlight = "menu-highlight";
		public const string Menubar = "menubar";
		public const string MenuText = "menu-text";
		public const string Scrollbar = "scrollbar";
		public const string Window = "window";
		public const string WindowFrame = "window-frame";
		public const string WindowText = "window-text";
		public const string AlternateSelectedControlText = "alternate-selected-control-text";
		public const string ControlBackground = "control-background";
		public const string Control = "control";
		public const string ControlTextTheTextOfAControlThatIsntDisabled = "control-text -The text of a control that isn’t disabled.";
		public const string DisabledControlText = "disabled-control-text";
		public const string FindHighlight = "find-highlight";
		public const string Grid = "grid";
		public const string HeaderText = "header-text";
		public const string KeyboardFocusIndicator = "keyboard-focus-indicator";
		public const string Label = "label";
		public const string Link = "link";
		public const string PlaceholderText = "placeholder-text";
		public const string QuaternaryLabel = "quaternary-label";
		public const string ScrubberTexturedBackground = "scrubber-textured-background";
		public const string SecondaryLabel = "secondary-label";
		public const string SelectedContentBackground = "selected-content-background";
		public const string SelectedControl = "selected-control";
		public const string SelectedControlText = "selected-control-text";
		public const string SelectedMenuItemText = "selected-menu-item-text";
		public const string SelectedTextBackground = "selected-text-background";
		public const string SelectedText = "selected-text";
		public const string Separator = "separator";
		public const string Shadow = "shadow";
		public const string TertiaryLabel = "tertiary-label";
		public const string TextBackground = "text-background";
		public const string Text = "text";
		public const string UnderPageBackground = "under-page-background";
		public const string UnemphasizedSelectedContentBackground = "unemphasized-selected-content-background";
		public const string UnemphasizedSelectedTextBackground = "unemphasized-selected-text-background";
		public const string UnemphasizedSelectedText = "unemphasized-selected-text";
		public const string WindowBackground = "window-background";
		public const string WindowFrameText = "window-frame-text";
	}

	public static class ConflictTypes {
		public static string Exists = "exists";
		public static string ExistsAndRunning = "existsAndRunning";
	}

	public static class ConsoleMessageLevels {
		public const int Verbose = 0;
		public const int Info = 1;
		public const int Warning = 2;
		public const int Error = 3;
	}

	public static class ConsoleMessageSources {
		public const string Javascript = "javascript";
		public const string Xml = "xml";
		public const string Network = "network";
		public const string ConsoleApi = "console-api";
		public const string Storage = "storage";
		public const string AppCache = "app-cache";
		public const string Rendering = "rendering";
		public const string Security = "security";
		public const string Deprecation = "deprecation";
		public const string Worker = "worker";
		public const string Violation = "violation";
		public const string Intervention = "intervention";
		public const string Recommendation = "recommendation";
		public const string Other = "other";
	}

	public static class ContextMenuMediaTypes {
		public static string None = "none";
		public static string Image = "image";
		public static string Audio = "audio";
		public static string Video = "video";
		public static string Canvas = "canvas";
		public static string File = "file";
		public static string Plugin = "plugin";
	}

	public static class ContextMenuSourceTypes {
		public static string None = "none";
		public static string Mouse = "mouse";
		public static string Keyboard = "keyboard";
		public static string Touch = "touch";
		public static string TouchMenu = "touchMenu";
	}

	public static class CookieChangeCauses {
		public static string Explicit = "explicit";
		public static string Overwrite = "overwrite";
		public static string Expired = "expired";
		public static string Evicted = "evicted";
		public static string ExpiredOverwrite = "expired-overwrite";
	}

	public static class CookieSameSitePolicies {
		public static string Unspecified = "unspecified";
		public static string NoRestriction = "no_restriction";
		public static string Lax = "lax";
		public static string Strict = "strict";
	}

	public static class CursorTypes {
		public static string Default = "default";
		public static string Crosshair = "crosshair";
		public static string Pointer = "pointer";
		public static string Text = "text";
		public static string Wait = "wait";
		public static string Help = "help";
		public static string EResize = "e-resize";
		public static string NResize = "n-resize";
		public static string NeResize = "ne-resize";
		public static string NwResize = "nw-resize";
		public static string SResize = "s-resize";
		public static string SeResize = "se-resize";
		public static string SwResize = "sw-resize";
		public static string WResize = "w-resize";
		public static string NsResize = "ns-resize";
		public static string EwResize = "ew-resize";
		public static string NeswResize = "nesw-resize";
		public static string NwseResize = "nwse-resize";
		public static string ColResize = "col-resize";
		public static string RowResize = "row-resize";
		public static string MPanning = "m-panning";
		public static string EPanning = "e-panning";
		public static string NPanning = "n-panning";
		public static string NePanning = "ne-panning";
		public static string NwPanning = "nw-panning";
		public static string SPanning = "s-panning";
		public static string SePanning = "se-panning";
		public static string SwPanning = "sw-panning";
		public static string WPanning = "w-panning";
		public static string Move = "move";
		public static string VerticalText = "vertical-text";
		public static string Cell = "cell";
		public static string ContextMenu = "context-menu";
		public static string Alias = "alias";
		public static string Progress = "progress";
		public static string Nodrop = "nodrop";
		public static string Copy = "copy";
		public static string None = "none";
		public static string NotAllowed = "not-allowed";
		public static string ZoomIn = "zoom-in";
		public static string ZoomOut = "zoom-out";
		public static string Grab = "grab";
		public static string Grabbing = "grabbing";
		public static string Custom = "custom";
	}

	public static class DisplayMetrics {
		public static string Bounds = "bounds";
		public static string WorkArea = "workArea";
		public static string ScaleFactor = "scaleFactor";
		public static string Rotation = "rotation";
	}

	public static class DisplaySupportValues {
		public static string Available = "available";
		public static string Unavailable = "unavailable";
		public static string Unknown = "unknown";
	}

	public static class DownloadStates {
		public static string Progressing = "progressing";
		public static string Interrupted = "interrupted";
		public static string Completed = "completed";
		public static string Cancelled = "cancelled";
	}

	public static class FeedServerTypes {
		public static string Default = "default";
		public static string Json = "json";
	}

	public static class FileIconSizes {
		public const string Small = "small";
		public const string Normal = "normal";
		public const string Large = "large";
	}

	public static class GpuFeatureStatuses {
		public const string DisabledSoftware = "disabled_software";
		public const string DisabledOff = "disabled_off";
		public const string DisabledOffOk = "disabled_off_ok";
		public const string UnavailableSoftware = "unavailable_software";
		public const string UnavailableOff = "unavailable_off";
		public const string UnavailableOffOk = "unavailable_off_ok";
		public const string EnabledReadback = "enabled_readback";
		public const string EnabledForce = "enabled_force";
		public const string Enabled = "enabled";
		public const string EnabledOn = "enabled_on";
		public const string EnabledForceOn = "enabled_force_on";
	}

	public static class GpuInfoTypes {
		public const string Basic = "basic";
		public const string Complete = "complete";
	}

	public static class ImageDecodeAcceleratorTypes {
		public const string Jpeg = "JPEG";
		public const string Unknown = "Unknown";
	}

	public static class ImageDecideAcceleratorSubsamplings {
		public const string Subsampling420 = "4:2:0";
		public const string Subsampling422 = "4:2:2";
		public const string Subsampling444 = "4:4:4";
	}

	public static class InputFieldTypes {
		public const string None = "none";
		public const string PlainText = "plainText";
		public const string Password = "password";
		public const string Other = "other";
	}

	public static class IntegrityLevels {
		public const string Untrusted = "untrusted";
		public const string Low = "low";
		public const string Medium = "medium";
		public const string High = "high";
		public const string Unknown = "unknown";
	}

	public static class JumpListCategoryTypes {
		public const string Tasks = "tasks";
		public const string Frequent = "frequent";
		public const string Recent = "recent";
		public const string Custom = "custom";
	}

	public static class JumpListItemTypes {
		public const string Task = "task";
		public const string Separator = "separator";
		public const string File = "file";
	}

	public static class JumpListSetResults {
		public const string Ok = "ok";
		public const string Error = "error";
		public const string InvalidSeparatorError = "invalidSeparatorError";
		public const string FileTypeRegistrationError = "fileTypeRegistrationError";
		public const string CustomCategoryAccessDeniedError = "customCategoryAccessDeniedError";
	}

	public static class LoginItemScopes {
		public const string User = "user";
		public const string Machine = "machine";
	}

	public static class MediaAccessTypes {
		public const string Microphone = "microphone";
		public const string Camera = "camera";
		public const string Screen = "screen";
	}

	public static class MediaTypes {
		public const string Audio = "audio";
		public const string Video = "video";
		public const string Unknown = "unknown";
	}

	public static class MenuItemsRoles {
		public const string Undo = "undo";
		public const string Redo = "redo";
		public const string Cut = "cut";
		public const string Copy = "copy";
		public const string Paste = "paste";
		public const string PasteAndMatchStyle = "pasteAndMatchStyle";
		public const string Delete = "delete";
		public const string SelectAll = "selectAll";
		public const string Reload = "reload";
		public const string ForceReload = "forceReload";
		public const string ToggleDevTools = "toggleDevTools";
		public const string ResetZoom = "resetZoom";
		public const string ZoomIn = "zoomIn";
		public const string ZoomOut = "zoomOut";
		public const string Togglefullscreen = "togglefullscreen";
		public const string Window = "window";
		public const string Minimize = "minimize";
		public const string Close = "close";
		public const string Help = "help";
		public const string About = "about";
		public const string Services = "services";
		public const string Hide = "hide";
		public const string HideOthers = "hideOthers";
		public const string Unhide = "unhide";
		public const string Quit = "quit";
		public const string StartSpeaking = "startSpeaking";
		public const string StopSpeaking = "stopSpeaking";
		public const string Zoom = "zoom";
		public const string Front = "front";
		public const string AppMenu = "appMenu";
		public const string FileMenu = "fileMenu";
		public const string EditMenu = "editMenu";
		public const string ViewMenu = "viewMenu";
		public const string ShareMenu = "shareMenu";
		public const string RecentDocuments = "recentDocuments";
		public const string ToggleTabBar = "toggleTabBar";
		public const string SelectNextTab = "selectNextTab";
		public const string SelectPreviousTab = "selectPreviousTab";
		public const string MergeAllWindows = "mergeAllWindows";
		public const string ClearRecentDocuments = "clearRecentDocuments";
		public const string MoveTabToNewWindow = "moveTabToNewWindow";
		public const string WindowMenu = "windowMenu";
	}

	public static class MenuItemTypes {
		public const string Normal = "normal";
		public const string Separator = "separator";
		public const string Submenu = "submenu";
		public const string Checkbox = "checkbox";
		public const string Radio = "radio";
	}

	public static class MessageBoxTypes {
		public const string None = "none";
		public const string Info = "info";
		public const string Error = "error";
		public const string Question = "question";
		public const string Warning = "warning";
	}

	public static class NativeThemeSources {
		public const string System = "system";
		public const string Light = "light";
		public const string Dark = "dark";
	}

	public static class NetLogCaptureModes {
		public const string Default = "default";
		public const string IncludeSensitive = "includeSensitive";
		public const string Everything = "everything";
	}

	public static class NotificationActionTypes {
		public const string Button = "button";
	}

	public static class NotificationTimeoutTypes {
		public const string Default = "default";
		public const string Never = "never";
	}

	public static class NotificationUrgencies {
		public const string Normal = "normal";
		public const string Critical = "critical";
		public const string Low = "low";
	}

	public static class OpenDialogProperties {
		public const string OpenFile = "openFile";
		public const string OpenDirectory = "openDirectory";
		public const string MultiSelections = "multiSelections";
		public const string ShowHiddenFiles = "showHiddenFiles";
		public const string CreateDirectory = "createDirectory";
		public const string PromptToCreate = "promptToCreate";
		public const string NoResolveAliases = "noResolveAliases";
		public const string TreatPackageAsDirectory = "treatPackageAsDirectory";
		public const string DontAddToRecent = "dontAddToRecent";
	}

	public static class OverlaySupports {
		public const string None = "NONE";
		public const string Direct = "DIRECT";
		public const string Scaling = "SCALING";
	}

	public static class Paths {
		public const string Home = "home"; // User's home directory.
		public const string AppData = "appData"; // Per-user application data directory, which by default points to:
		public const string UserData = "userData"; // The directory for storing your app's configuration files, which by default it is the appData directory appended with your app's name.
		public const string Cache = "cache";
		public const string Temp = "temp"; // Temporary directory.
		public const string Exe = "exe"; // The current executable file.
		public const string Module = "module"; // The libchromiumcontent library.
		public const string Desktop = "desktop"; // The current user's Desktop directory.
		public const string Documents = "documents"; // Directory for a user's "My Documents".
		public const string Downloads = "downloads"; // Directory for a user's downloads.
		public const string Music = "music"; // Directory for a user's music.
		public const string Pictures = "pictures"; // Directory for a user's pictures.
		public const string Videos = "videos"; // Directory for a user's videos.
		public const string Recent = "recent"; // Directory for the user's recent files (Windows only).
		public const string Logs = "logs"; // Directory for your app's log folder.
		public const string CrashDumps = "crashDumps"; // Directory where crash dumps are stored.
	}

	public static class Permissions {
		public const string ClipboardRead = "clipboard-read";
		public const string Media = "media";
		public const string DisplayCapture = "display-capture";
		public const string MediaKeySystem = "mediaKeySystem";
		public const string Geolocation = "geolocation";
		public const string Notifications = "notifications";
		public const string Midi = "midi";
		public const string MidiSysex = "midiSysex";
		public const string PointerLock = "pointerLock";
		public const string Fullscreen = "fullscreen";
		public const string OpenExternal = "openExternal";
		public const string Serial = "serial";
	}

	public static class PowerSaveBlockerTypes {
		public const string PreventAppSuspension = "prevent-app-suspension";
		public const string PreventDisplaySleep = "prevent-display-sleep";
	}

	public static class ProcessGoneReasons {
		public const string CleanExit = "clean-exit";
		public const string AbnormalExit = "abnormal-exit";
		public const string Killed = "killed";
		public const string Crashed = "crashed";
		public const string Oom = "oom";
		public const string LaunchFailed = "launch-failed";
		public const string IntegrityFailed = "integrity-failure";
	}

	public static class ProcessMetricTypes {
		public const string Browser = "Browser";
		public const string Tab = "Tab";
		public const string Utility = "Utility";
		public const string Zygote = "Zygote";
		public const string SandboxHelper = "Sandbox helper";
		public const string Gpu = "GPU";
		public const string PepperPlugin = "Pepper Plugin";
		public const string PepperPluginBroker = "Pepper Plugin Broker";
		public const string Unknown = "Unknown";
	}

	public static class ProcessTypes {
		public const string Browser = "browser";
		public const string Renderer = "renderer";
		public const string Worker = "worker";
	}

	public static class ProgressBarModes {
		public const string None = "none";
		public const string Normal = "normal";
		public const string Indeterminate = "indeterminate";
		public const string Error = "error";
		public const string Paused = "paused";
	}

	public static class ProxyModes {
		public const string Direct = "direct";
		public const string AutoDectect = "auto__detect";
		public const string PacScript = "pac_script";
		public const string FixedServers = "fixed_servers";
		public const string System = "system";
	}

	public static class RecordingModes {
		public const string RecordUntilFull = "record-until-full";
		public const string RecordContinuously = "record-continuously";
		public const string RecordAsMuchAsPossible = "record-as-much-as-possible";
		public const string TraceToConsole = "trace-to-console";
	}

	public static class ReferrerPolicies {
		public const string Default = "default";
		public const string UnsafeUrl = "unsafe-url";
		public const string NoReferrerWhenDowngrade = "no-referrer-when-downgrade";
		public const string NoReferrer = "no-referrer";
		public const string Origin = "origin";
		public const string StrictOriginWhenCrossOrigin = "strict-origin-when-cross-origin";
		public const string SameOrigin = "same-origin";
		public const string StrictOrigin = "strict-origin";
	}

	public static class SaveDialogProperties {
		public const string ShowHiddenFiles = "showHiddenFiles";
		public const string CreateDirectory = "createDirectory";
		public const string TreatPackageAsDirectory = "treatPackageAsDirectory";
		public const string ShowOverwriteConfirmation = "showOverwriteConfirmation";
		public const string DontAddToRecent = "dontAddToRecent";
	}

	public static class SslVersions {
		public const string Tls1 = "tls1";
		public const string Tls11 = "tls1.1";
		public const string Tls12 = "tls1.2";
		public const string Tls13 = "tls1.3";
	}

	public static class StorageQuotaTypes {
		public const string Temporary = "temporary";
		public const string Persistent = "persistent";
		public const string Syncable = "syncable";
	}

	public static class StorageTypes {
		public const string AppCache = "appcache";
		public const string Cookies = "cookies";
		public const string FileSystem = "filesystem";
		public const string IndexDb = "indexdb";
		public const string LocalStorage = "localstorage";
		public const string ShaderCache = "shadercache";
		public const string WebSql = "websql";
		public const string ServiceWorkers = "serviceworkers";
		public const string CacheStorage = "cachestorage";
	}

	public static class SwipeDirections {
		public const string Up = "up";
		public const string Right = "right";
		public const string Down = "down";
		public const string Left = "left";
	}

	public static class SystemColors {
		public const string Blue = "blue";
		public const string Brown = "brown";
		public const string Gray = "gray";
		public const string Green = "green";
		public const string Orange = "orange";
		public const string Pink = "pink";
		public const string Purple = "purple";
		public const string Red = "red";
		public const string Yellow = "yellow";
	}

	public static class SystemIdleStates {
		public const string Active = "active";
		public const string Idle = "idle";
		public const string Locked = "locked";
		public const string Unknown = "unknown";
	}

	public static class ThumbarButtonFlags {
		public const string Enabled = "enabled";
		public const string Disabled = "disabled";
		public const string DismissOnClick = "dismissonclick";
		public const string NoBackground = "nobackground";
		public const string Hidden = "hidden";
		public const string NonInteractive = "noninteractive";
	}

	public static class TouchBarButtonIconPositions {
		public const string Left = "left";
		public const string Right = "right";
		public const string Overlay = "overlay";
	}

	public static class TouchBarScrubberItemStyles {
		public const string Background = "background";
		public const string Outline = "outline";
		public const string None = "none";
	}

	public static class TouchBarScrubberModes {
		public const string Fixed = "fixed";
		public const string Free = "free";
	}

	public static class TouchBarSegmentedControlModes {
		public const string Single = "single";
		public const string Multiple = "multiple";
		public const string Buttons = "buttons";
	}

	public static class TouchBarSegmentStyles {
		public const string Automatic = "automatic";
		public const string Rounded = "rounded";
		public const string TexturedRounded = "textured-rounded";
		public const string RoundRect = "round-rect";
		public const string TexturedSquare = "textured-square";
		public const string Capsule = "capsule";
		public const string SmallSquare = "small-square";
		public const string Separated = "separated";
	}

	public static class TouchBarSpacerSizes {
		public const string Small = "small";
		public const string Large = "large";
		public const string Flexible = "flexible";
	}

	public static class TraceOptions {
		public const string EnableSampling = "enable-sampling";
		public const string EnableSystrace = "enable-systrace";
	}

	public static class TransactionStates {
		public const string Purchasing = "purchasing";
		public const string Purchased = "purchased";
		public const string Failed = "failed";
		public const string Restored = "restored";
		public const string Deferred = "deferred";
	}

	public static class TrayTextFontTypes {
		public const string Monospaced = "monospaced";
		public const string MonospacedDigit = "monospacedDigit";
	}

	public static class UploadRawDataOrFileTypes {
		public const string File = "file";
		public const string RawData = "rawData";
	}

	public static class UserDefaultTypes {
		public const string String = "string";
		public const string Boolean = "boolean";
		public const string Integer = "integer";
		public const string Float = "float";
		public const string Double = "double";
		public const string Url = "url";
		public const string Array = "array";
		public const string Dictionary = "dictionary";
	}

	public static class V8CacheOptions {
		public const string None = "none";
		public const string Code = "code";
		public const string BypassHeatCheck = "bypassHeatCheck";
		public const string BypassHeatCheckAndEagerCompile = "bypassHeatCheckAndEagerCompile";
	}

	public static class WindowOpenHandlerActions {
		public const string Allow = "allow";
		public const string Deny = "deny";
	}

	public static class ZoomDirections {
		public const string In = "in";
		public const string Out = "out";
	}

	public class MoveToApplicationsFolderOptions {
		public Func<string, bool> ConflictHandler { get; set; }
	}

	public class WebFrameMainId {
		public int ProcessId { get; set; }
		public int RoutingId { get; set; }
	}

	public class ElectronException : Exception {
		public ElectronException(Error error) : base($"{error.Name}: {error.Message}") {
			this.error = error;
		}
		private readonly Error error;

		public override string StackTrace {
			get {
				int index = this.error.Stack.IndexOf("\n");
				return this.error.Stack[(index + 1)..];
			}
		}
	}

	public class AboutPanelOptionsOptions {
		public string ApplicationName { get; set; }
		public string ApplicationVersion { get; set; }
		public string Copyright { get; set; }
		public string Version { get; set; }
		public string Credits { get; set; }
		public string[] Authors { get; set; }
		public string Website { get; set; }
		public string IconPath { get; set; }
	}

	public class AnimationSettings {
		public bool ShouldRenderRichAnimation { get; set; }
		public bool ScrollAnimationsEnabledBySystem { get; set; }
		public bool PrefersReducedMotion { get; set; }
	}

	public class AppDetailsOptions {
		public string AppId { get; set; }
		public string AppIconPath { get; set; }
		public int AppIconIndex { get; set; }
		public string RelaunchCommand { get; set; }
		public string RelaunchDisplayName { get; set; }
	}

	public class ApplicationInfoForProtocolReturnValue {
		public NativeImage Icon { get; set; }
		public string Path { get; set; }
		public string Name { get; set; }
	}

	internal class ApplicationInfoForProtocolReturnValueDto {
		public int Icon { get; set; }
		public string Path { get; set; }
		public string Name { get; set; }

		public ApplicationInfoForProtocolReturnValue ToApplicationInfoForProtocolReturnValue() => new() {
			Icon = ElectronDisposable.FromId<NativeImage>(this.Icon),
			Name = this.Name,
			Path = this.Path
		};
	}

	public class AuthenticationResponseDetails {
		public string Url { get; set; }
	}

	public class AuthInfo {
		public bool IsProxy { get; set; }
		public string Scheme { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }
		public string Realm { get; set; }
	}

	public class AutoResizeOptions {
		public bool Width { get; set; }
		public bool Height { get; set; }
		public bool Horizontal { get; set; }
		public bool Vertical { get; set; }
	}

	public class BeforeSendResponse {
		public bool Cancel { get; set; }
		public Dictionary<string, object> RequestHeaders { get; set; }
	}

	public class BlinkMemoryInfo {
		public int Allocated { get; set; }
		public int Marked { get; set; }
		public int Total { get; set; }
	}

	public class Buffer {
		public string Type { get; set; }
		public short[] Data { get; set; }

		[JsonIgnore]
		public byte[] Bytes => this.Data.Select(x => (byte)x).ToArray();
	}

	public class BrowserViewConstructorOptions {
		public WebPreferences WebPreferences { get; set; }

		internal BrowserViewConstructorOptionsDto ToBrowserViewConstructorOptionsDto() => new() {
			WebPreferences = this.WebPreferences?.ToWebPreferencesDto()
		};
	}

	public class BrowserViewConstructorOptionsDto {
		public WebPreferencesDto WebPreferences { get; set; }
	}

	public class BrowserWindowConstructorOptions {
		public int Width { get; set; } = 800;
		public int Height { get; set; } = 600;
		public int? X { get; set; }
		public int? Y { get; set; }
		public bool UseContentSize { get; set; }
		public bool Center { get; set; }
		public int MinWidth { get; set; }
		public int MinHeight { get; set; }
		public int? MaxWidth { get; set; }
		public int? MaxHeight { get; set; }
		public bool Resizable { get; set; } = true;
		public bool Movable { get; set; } = true;
		public bool Minimizable { get; set; } = true;
		public bool Mazimizable { get; set; } = true;
		public bool Closable { get; set; } = true;
		public bool Focusable { get; set; } = true;
		public bool AlwaysOnTop { get; set; }
		public bool Fullscreen { get; set; }
		public bool Fullscreenable { get; set; } = true;
		public bool SimpleFullscreen { get; set; }
		public bool SkipTaskbar { get; set; }
		public bool Kiosk { get; set; }
		public string Title { get; set; }
		public NativeImage IconImage { get; set; }
		public string IconPath { get; set; }
		public bool Show { get; set; } = true;
		public bool PaintWhenInitiallyHidden { get; set; } = true;
		public bool Frame { get; set; } = true;
		public BrowserWindow Parent { get; set; }
		public bool Modal { get; set; }
		public bool AcceptFirstMouse { get; set; }
		public bool DisableAutoHideCursor { get; set; }
		public bool AutoHideMenuBar { get; set; }
		public bool EnableLargerThanScreen { get; set; }
		public string BackgroundColor { get; set; }
		public bool HasShadow { get; set; } = true;
		public double Opacity { get; set; } = 1d;
		public bool DarkTheme { get; set; }
		public bool Transparent { get; set; }
		public string Type { get; set; }
		public string VisualEffectState { get; set; }
		public string TitleBarStyle { get; set; }
		public bool CustomButtonsOnHover { get; set; }
		public Point TrafficLightPosition { get; set; }
		public bool FullscreenWindowTitle { get; set; }
		public bool ThickFrame { get; set; } = true;
		public string Vibrancy { get; set; }
		public bool ZoomToPageWidth { get; set; }
		public string TabbingIdentifier { get; set; }
		public WebPreferences WebPreferences { get; set; }

		internal BrowserWindowConstructorOptionsDto ToBrowserWindowConstructorOptionsDto() => new() {
			Width = this.Width,
			Height = this.Height,
			X = this.X,
			Y = this.Y,
			UseContentSize = this.UseContentSize,
			Center = this.Center,
			MinWidth = this.MinWidth,
			MinHeight = this.MinHeight,
			MaxWidth = this.MaxWidth,
			MaxHeight = this.MaxHeight,
			Resizable = this.Resizable,
			Movable = this.Movable,
			Minimizable = this.Minimizable,
			Mazimizable = this.Mazimizable,
			Closable = this.Closable,
			Focusable = this.Focusable,
			AlwaysOnTop = this.AlwaysOnTop,
			Fullscreen = this.Fullscreen,
			Fullscreenable = this.Fullscreenable,
			SimpleFullscreen = this.SimpleFullscreen,
			SkipTaskbar = this.SkipTaskbar,
			Kiosk = this.Kiosk,
			Title = this.Title,
			IconImage = this.IconImage?.InternalId ?? 0,
			IconPath = this.IconPath,
			Show = this.Show,
			PaintWhenInitiallyHidden = this.PaintWhenInitiallyHidden,
			Frame = this.Frame,
			Parent = this.Parent?.Id ?? 0,
			Modal = this.Modal,
			AcceptFirstMouse = this.AcceptFirstMouse,
			DisableAutoHideCursor = this.DisableAutoHideCursor,
			AutoHideMenuBar = this.AutoHideMenuBar,
			EnableLargerThanScreen = this.EnableLargerThanScreen,
			BackgroundColor = this.BackgroundColor,
			HasShadow = this.HasShadow,
			Opacity = this.Opacity,
			DarkTheme = this.DarkTheme,
			Transparent = this.Transparent,
			Type = this.Type,
			VisualEffectState = this.VisualEffectState,
			TitleBarStyle = this.TitleBarStyle,
			CustomButtonsOnHover = this.CustomButtonsOnHover,
			TrafficLightPosition = this.TrafficLightPosition,
			FullscreenWindowTitle = this.FullscreenWindowTitle,
			ThickFrame = this.ThickFrame,
			Vibrancy = this.Vibrancy,
			ZoomToPageWidth = this.ZoomToPageWidth,
			TabbingIdentifier = this.TabbingIdentifier,
			WebPreferences = this.WebPreferences?.ToWebPreferencesDto()
		};
	}

	public class BrowserWindowConstructorOptionsDto {
		public int Width { get; set; } = 800;
		public int Height { get; set; } = 600;
		public int? X { get; set; }
		public int? Y { get; set; }
		public bool UseContentSize { get; set; }
		public bool Center { get; set; }
		public int MinWidth { get; set; }
		public int MinHeight { get; set; }
		public int? MaxWidth { get; set; }
		public int? MaxHeight { get; set; }
		public bool Resizable { get; set; } = true;
		public bool Movable { get; set; } = true;
		public bool Minimizable { get; set; } = true;
		public bool Mazimizable { get; set; } = true;
		public bool Closable { get; set; } = true;
		public bool Focusable { get; set; } = true;
		public bool AlwaysOnTop { get; set; }
		public bool Fullscreen { get; set; }
		public bool Fullscreenable { get; set; } = true;
		public bool SimpleFullscreen { get; set; }
		public bool SkipTaskbar { get; set; }
		public bool Kiosk { get; set; }
		public string Title { get; set; }
		public int IconImage { get; set; }
		public string IconPath { get; set; }
		public bool Show { get; set; } = true;
		public bool PaintWhenInitiallyHidden { get; set; } = true;
		public bool Frame { get; set; } = true;
		public int Parent { get; set; }
		public bool Modal { get; set; }
		public bool AcceptFirstMouse { get; set; }
		public bool DisableAutoHideCursor { get; set; }
		public bool AutoHideMenuBar { get; set; }
		public bool EnableLargerThanScreen { get; set; }
		public string BackgroundColor { get; set; }
		public bool HasShadow { get; set; } = true;
		public double Opacity { get; set; } = 1d;
		public bool DarkTheme { get; set; }
		public bool Transparent { get; set; }
		public string Type { get; set; }
		public string VisualEffectState { get; set; }
		public string TitleBarStyle { get; set; }
		public bool CustomButtonsOnHover { get; set; }
		public Point TrafficLightPosition { get; set; }
		public bool FullscreenWindowTitle { get; set; }
		public bool ThickFrame { get; set; } = true;
		public string Vibrancy { get; set; }
		public bool ZoomToPageWidth { get; set; }
		public string TabbingIdentifier { get; set; }
		public WebPreferencesDto WebPreferences { get; set; }
	}

	public class Certificate {
		public string Data { get; set; }
		public CertificatePrincipal Issuer { get; set; }
		public string IssuerName { get; set; }
		public Certificate IssuerCert { get; set; }
		public CertificatePrincipal Subject { get; set; }
		public string SubjectName { get; set; }
		public string SerialNumber { get; set; }
		public double ValidStart { get; set; }
		public double ValidExpiry { get; set; }
		public string Fingerprint { get; set; }

		[JsonIgnore]
		public DateTime ValidStartDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ValidStart), DateTimeKind.Utc);
			set => this.ValidStart = (value - DateTime.UnixEpoch).TotalSeconds;
		}
		[JsonIgnore]
		public DateTime ValidExpiryDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ValidExpiry), DateTimeKind.Utc);
			set => this.ValidExpiry = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class CertificatePrincipal {
		public string CommonName { get; set; }
		public string[] Organizations { get; set; }
		public string[] OrganizationUnits { get; set; }
		public string Locality { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}

	public class CertificateTrustDialogOptions {
		public Certificate Certificate { get; set; }
		public string Message { get; set; }
	}

	public class ChildProcessGone : RenderProcessGone {
		public string Type { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
	}

	public class ClearStorageDataOptions {
		public string Origin { get; set; }
		public string Storages { get; set; }
		public string Quotas { get; set; }
	}

	public class Config {
		public string Mode { get; set; }
		public string PacScript { get; set; }
		public string ProxyRules { get; set; }
		public string ProxyBypassRules { get; set; }
	}

	public class Cookie {
		public string Name { get; set; }
		public string Value { get; set; }
		public string Domain { get; set; }
		public bool HostOnly { get; set; }
		public string Path { get; set; }
		public bool Secure { get; set; }
		public bool HttpOnly { get; set; }
		public bool Session { get; set; }
		public double ExpirationDate { get; set; }
		public string SameSite { get; set; }

		[JsonIgnore]
		public DateTime ExpirationDateDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ExpirationDate), DateTimeKind.Utc);
			set => this.ExpirationDate = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class CookiesGetFilter {
		public string Url { get; set; }
		public string Name { get; set; }
		public string Domain { get; set; }
		public string Path { get; set; }
		public bool Secure { get; set; }
		public bool Session { get; set; }
	}

	public class CookiesSetDetails {
		public string Url { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public string Domain { get; set; }
		public string Path { get; set; }
		public bool Secure { get; set; }
		public bool HttpOnly { get; set; }
		public double ExpirationDate { get; set; }
		public string SameSite { get; set; }

		[JsonIgnore]
		public DateTime ExpirationDateDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ExpirationDate), DateTimeKind.Utc);
			set => this.ExpirationDate = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class CpuUsage {
		[JsonPropertyName("percentCPUUsage")]
		public double PercentCpuUsage { get; set; }
		public double IdleWakeupsPerSecond { get; set; }
	}

	public class CrashReporterStartOptions {
		[JsonPropertyName("submitURL")]
		public string SubmitUrl { get; set; }
		public string ProductName { get; set; }
		public bool UploadToServer { get; set; } = true;
		public bool IgnoreSystemCrashHandler { get; set; }
		public bool RateLimit { get; set; }
		public bool Compress { get; set; } = true;
		public Dictionary<string, string> Extra { get; set; }
		public Dictionary<string, string> GlobalExtra { get; set; }
	}

	public class CreateInterruptedDownloadOptions {
		public string Path { get; set; }
		public string[] UrlChain { get; set; }
		public string MimeType { get; set; }
		public int Offset { get; set; }
		public int Length { get; set; }
		public string LastModified { get; set; }
		public string ETag { get; set; }
		public double StartTime { get; set; }

		[JsonIgnore]
		public DateTime? LastModifiedDateTime {
			get {
				if (string.IsNullOrEmpty(this.LastModified)) {
					return null;
				}
				if (!DateTime.TryParse(this.LastModified, out DateTime dateTime)) {
					return null;
				}
				return dateTime;
			}
			set => this.LastModified = value?.ToUniversalTime().ToString("R") ?? null;
		}
		[JsonIgnore]
		public DateTime StartTimeDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.StartTime), DateTimeKind.Utc);
			set => this.StartTime = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class CustomScheme {
		public string Scheme { get; set; }
		public CustomSchemePrivileges Privileges { get; set; } = new CustomSchemePrivileges();
	}

	public class CustomSchemePrivileges {
		public bool Standard { get; set; }
		public bool Secure { get; set; }
		[JsonPropertyName("bypassCSP")]
		public bool BypassCsp { get; set; }
		public bool AllowServiceWorkers { get; set; }
		[JsonPropertyName("supportFetchAPI")]
		public bool SupportFetchApi { get; set; }
		public bool CorsEnabled { get; set; }
		public bool Stream { get; set; }
	}

	public class DefaultFontFamily {
		public string Standard { get; set; }
		public string Serif { get; set; }
		public string SansSerif { get; set; }
		public string Monospace { get; set; }
		public string Cursive { get; set; }
		public string Fantasy { get; set; }
	}

	public class Display {
		public long Id { get; set; }
		public int Rotation { get; set; }
		public double ScaleFactor { get; set; }
		public string TouchSupport { get; set; }
		public bool Monochrome { get; set; }
		public string AccelerometerSupport { get; set; }
		public string ColorSpace { get; set; }
		public int ColorDepth { get; set; }
		public int DepthPerComponent { get; set; }
		public double DisplayFrequency { get; set; }
		public Rectangle Bounds { get; set; }
		public Size Size { get; set; }
		public Rectangle WorkArea { get; set; }
		public Size WorkAreaSize { get; set; }
		public bool Internal { get; set; }
	}

	public class DisplayBalloonOptions {
		public NativeImage IconImage { get; set; }
		public string IconPath { get; set; }
		public string IconType { get; set; } = BalloonIconTypes.Custom;
		public string Title { get; set; }
		public string Content { get; set; }
		public bool LargeIcon { get; set; } = true;
		public bool NoSound { get; set; }
		public bool RespectQuietTime { get; set; }

		internal DisplayBalloonOptionsDto ToDisplayBalloonOptionsDto() => new() {
			IconImage = this.IconImage?.InternalId ?? 0,
			IconPath = this.IconPath,
			Title = this.Title,
			Content = this.Content,
			LargeIcon = this.LargeIcon,
			NoSound = this.NoSound,
			RespectQuietTime = this.RespectQuietTime
		};
	}

	public class DisplayBalloonOptionsDto {
		public int IconImage { get; set; }
		public string IconPath { get; set; }
		public string IconType { get; set; } = BalloonIconTypes.Custom;
		public string Title { get; set; }
		public string Content { get; set; }
		public bool LargeIcon { get; set; } = true;
		public bool NoSound { get; set; }
		public bool RespectQuietTime { get; set; }
	}

	public class EnableNetworkEmulationOptions {
		public bool Offline { get; set; }
		public double Latency { get; set; }
		public double DownloadThroughput { get; set; }
		public double UploadThroughput { get; set; }
	}

	public class Error {
		public string Message { get; set; }
		public string Name { get; set; }
		public string Stack { get; set; }
	}

	public class Extension {
		public string Id { get; set; }
		public object Manifest { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string Version { get; set; }
		public string Url { get; set; }
	}

	public class FeedUrlOptions {
		public string Url { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public string ServerType { get; set; }
	}

	public class FileIconOptions {
		public string Size { get; set; }
	}

	public class FileFilter {
		public string Name { get; set; }
		public string[] Extensions { get; set; }
	}

	public class Filter {
		public string[] Urls { get; set; }
	}

	public class FocusOptions {
		public bool Steal { get; set; }
	}

	public class FromPartitionOptions {
		public bool Cache { get; set; }
	}

	public class GpuDevice {
		public int VendorId { get; set; }
		public int DeviceId { get; set; }
		public bool Active { get; set; }
		public string VendorString { get; set; }
		public string DeviceString { get; set; }
		public string DriverVendor { get; set; }
		public string DriverVersion { get; set; }
		public string DriverDate { get; set; }
		public int CudaComputeCapabilityMajor { get; set; }
		public int Revision { get; set; }
		public int SubSysId { get; set; }
	}

	public class GpuFeatureStatus {
		[JsonPropertyName("2d_canvas")]
		public string Canvas2d { get; set; }
		[JsonPropertyName("flash_3d")]
		public string Flash3d { get; set; }
		[JsonPropertyName("flash_stage3d")]
		public string FlashStage3d { get; set; }
		[JsonPropertyName("flash_stage3d_baseline")]
		public string FlashStage3dBastline { get; set; }
		[JsonPropertyName("gpu_compositing")]
		public string GpuCompositing { get; set; }
		[JsonPropertyName("multiple_raster_threads")]
		public string MultipleRasterThreads { get; set; }
		[JsonPropertyName("native_gpu_memory_buffers")]
		public string NativeGpuMemoryBuffers { get; set; }
		[JsonPropertyName("oop_rasterization")]
		public string OopRasterization { get; set; }
		[JsonPropertyName("opengl")]
		public string OpenGl { get; set; }
		public string Rasterization { get; set; }
		[JsonPropertyName("skia_renderer")]
		public string SkiaRenderer { get; set; }
		[JsonPropertyName("video_decode")]
		public string VideoDecode { get; set; }
		[JsonPropertyName("video_encode")]
		public string VideoEncode { get; set; }
		[JsonPropertyName("vpx_decode")]
		public string VpxDecode { get; set; }
		public string Vulkan { get; set; }
		[JsonPropertyName("webgl")]
		public string WebGl { get; set; }
		[JsonPropertyName("webgl2")]
		public string WebGl2 { get; set; }
	}

	public class GpuInfo {
		public GpuInfoAuxAttributes AuxAttributes { get; set; }
		public GpuDevice[] GpuDevice { get; set; }
		public string MachineModelName { get; set; }
		public string MachineModelVersion { get; set; }
	}

	public class GpuInfoAuxAttributes {
		public double InitializationTime { get; set; }

		[JsonIgnore]
		public TimeSpan InitializationTimeSpan => TimeSpan.FromSeconds(this.InitializationTime);

		public bool Optimus { get; set; }
		public bool AmdSwitchable { get; set; }
		public string PixelShaderVerison { get; set; }
		public string VertexShaderVerison { get; set; }
		public string MaxMsaaSamples { get; set; }
		public string GlVersion { get; set; }
		public string GlVendor { get; set; }
		public string GlRenderer { get; set; }
		public string GlExtensions { get; set; }
		public string GlWsVendor { get; set; }
		public string GlWsVersion { get; set; }
		public string GlWsExtensions { get; set; }
		public int GlResetNotificationStrategy { get; set; }
		public bool SoftwareRendering { get; set; }
		public string DirectRenderingVersion { get; set; }
		public bool Sandboxed { get; set; }
		public bool InProcessGpu { get; set; }
		public bool PassthroughCmdDecoder { get; set; }
		public bool CanSupportThreadedTextureMailbox { get; set; }
		public OverlayInfo OverlayInfo { get; set; }
		public bool SupportsDx12 { get; set; }
		public bool SupportsVulkan { get; set; }
		public string Dx12FeatureLevel { get; set; }
		public string VulkanVersion { get; set; }
		public int VideoDecodeAcceleratorFlags { get; set; }
		public VideoDecodeAcceleratorSupportedProfile VideoDecodeAcceleratorSupportedProfile { get; set; }
		public VideoEncodeAcceleratorSupportedProfile VideoEncodeAcceleratorSupportedProfile { get; set; }
		public bool JpegDecodeAcceleratorSupported { get; set; }
		public ImageDecodeAcceleratorSupportedProfile ImageDecodeAcceleratorSupportedProfile { get; set; }
		public long SystemVisual { get; set; }
		public long RgbaVisual { get; set; }
		public bool OopRasterizationSupported { get; set; }
		public bool SubpixelFontRendering { get; set; }
	}

	public class HeadersReceivedResponse : BeforeSendResponse {
		public string StatusLine { get; set; }
	}

	public class HeapStatistics {
		public int TotalHeapSize { get; set; }
		public int TotalHeapSizeExecutable { get; set; }
		public int TotalPhysicalSize { get; set; }
		public int TotalAvailableSize { get; set; }
		public int UsedHeapSize { get; set; }
		public int HeapSizeLimit { get; set; }
		public int MallocedMemory { get; set; }
		public int PeakMallocedMemory { get; set; }
		public bool DoesZapGarbage { get; set; }
	}

	public class IgnoreMouseEventsOptions {
		public bool Forward { get; set; }
	}

	public class ImageDecodeAcceleratorSupportedProfile {
		public string ImageType { get; set; }
		public string MinEncodedDimensions { get; set; }
		public string MaxEncodedDimensions { get; set; }
		public string Subsamplings { get; set; }
	}

	public class ImportCertificateOptions {
		public string Certificate { get; set; }
		public string Password { get; set; }
	}

	public class IoCounters {
		public double ReadOperationCount { get; set; }
		public double WriteOperationCount { get; set; }
		public double OtherOperationCount { get; set; }
		public double ReadTransferCount { get; set; }
		public double WriteTransferCount { get; set; }
		public double OtherTransferCount { get; set; }
	}

	public class IpcMainEvent : IpcMainInvokeEvent {
		public MessagePortMain[] Ports { get; internal set; }
		internal int Reply { get; set; }
		public Task ReplyAsync(string channel, object[] args) =>
			Electron.ActionAsync(x => x.Function_Invoke, this.Reply, args.Prepend(channel).ToArray());
	}

	public class IpcMainInvokeEvent {
		public int ProcessId { get; internal set; }
		public int FrameId { get; internal set; }
		public WebContents Sender { get; internal set; }
		public WebFrameMain SenderFrame { get; internal set; }
	}

	public class JumpListCategory {
		public string Type { get; set; }
		public string Name { get; set; }
		public JumpListItem[] Items { get; set; }
	}

	public class JumpListItem {
		public string Type { get; set; }
		public string Path { get; set; }
		public string Program { get; set; }
		public string Args { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconPath { get; set; }
		public int IconIndex { get; set; }
		public string WorkingDirectory { get; set; }
	}

	public class JumpListSettings {
		public int MinItems { get; set; }
		public JumpListItem[] RemovedItems { get; set; }
	}

	public class KeyboardEvent {
		public bool CtrlKey { get; set; }
		public bool MetaKey { get; set; }
		public bool ShiftKey { get; set; }
		public bool AltKey { get; set; }
		public bool TriggeredByAccelerator { get; set; }
	}

	public class LaunchItems {
		public string Name { get; set; }
		public string Path { get; set; }
		public string[] Args { get; set; }
		public string Scope { get; set; }
		public bool Enabled { get; set; }
	}

	public class LoadExtensionOptions {
		public bool AllowFileAccess { get; set; }
	}

	public class LoadFileOptions {
		public Dictionary<string, string> Query { get; set; }
		public string Search { get; set; }
		public string Hash { get; set; }
	}

	public class LoadUrlOptions {
		public string HttpReferrerString { get; set; }
		public Referrer HttpReferrerReferrer { get; set; }
		public string UserAgent { get; set; }
		public string ExtraHeaders { get; set; }
		public UploadRawDataOrFile[] PostData { get; set; }
		public string BaseUrlForDataUrl { get; set; }

		public LoadUrlOptionsDto ToLoadUrlOptionsDto() => new() {
			HttpReferrerString = this.HttpReferrerString,
			HttpReferrerReferrer = this.HttpReferrerReferrer,
			UserAgent = this.UserAgent,
			ExtraHeaders = this.ExtraHeaders,
			PostData = this.PostData?.Select(x => x.ToUploadRawDataOrFileDto()).ToArray(),
			BaseUrlForDataUrl = this.BaseUrlForDataUrl
		};
	}

	public class LoadUrlOptionsDto {
		public string HttpReferrerString { get; set; }
		public Referrer HttpReferrerReferrer { get; set; }
		public string UserAgent { get; set; }
		public string ExtraHeaders { get; set; }
		public UploadRawDataOrFileDto[] PostData { get; set; }
		[JsonPropertyName("baseURLForDataURL")]
		public string BaseUrlForDataUrl { get; set; }
	}

	public class LoginItemSettings {
		public bool OpenAtLogin { get; set; }
		public bool OpenAsHidden { get; set; }
		public bool WasOpenedAtLogin { get; set; }
		public bool WasOpenedAsHidden { get; set; }
		public bool RestoreState { get; set; }
		public bool ExecutableWillLaunchAtLogin { get; set; }
		public LaunchItems[] LaunchItems { get; set; }
	}

	public class LoginItemSettingsOptions {
		public string Path { get; set; }
		public string[] Args { get; set; }
	}

	public class MemoryInfo {
		public int WorkingSetSize { get; set; }
		public int PeakWorkingSetSize { get; set; }
		public int PrivateBytes { get; set; }
	}

	public class MenuItemConstructorOptions {
		public Action<KeyboardEvent, BrowserWindow, WebContents> Click { get; set; }
		public string Role { get; set; }
		public string Type { get; set; }
		public string Label { get; set; }
		public string Sublabel { get; set; }
		public string ToolTip { get; set; }
		public string Accelerator { get; set; }
		public NativeImage IconImage { get; set; }
		public string IconPath { get; set; }
		public bool Enabled { get; set; } = true;
		public bool AcceleratorWorksWhenHidden { get; set; }
		public bool Visible { get; set; } = true;
		public bool Checked { get; set; }
		public bool RegisterAccelerator { get; set; } = true;
		public SharingItem SharingItem { get; set; }
		public Menu SubmenuMenu { get; set; }
		public MenuItemConstructorOptions[] SubmenuTemplate { get; set; }
		public string Id { get; set; }
		public string Before { get; set; }
		public string After { get; set; }
		public string BeforeGroupContaining { get; set; }
		public string AfterGroupContaining { get; set; }

		internal MenuItemConstructorOptionsDto ToMenuItemConstructorOptionsDto() => new() {
			Click = this.Click != null,
			Role = this.Role,
			Type = this.Type,
			Label = this.Label,
			Sublabel = this.Sublabel,
			ToolTip = this.ToolTip,
			Accelerator = this.Accelerator,
			IconImage = this.IconImage?.InternalId ?? 0,
			IconPath = this.IconPath,
			Enabled = this.Enabled,
			AcceleratorWorksWhenHidden = this.AcceleratorWorksWhenHidden,
			Visible = this.Visible,
			Checked = this.Checked,
			RegisterAccelerator = this.RegisterAccelerator,
			SharingItem = this.SharingItem,
			SubmenuMenu = this.SubmenuMenu?.InternalId ?? 0,
			SubmenuTemplate = this.SubmenuTemplate?.Select(x => x.ToMenuItemConstructorOptionsDto()).ToArray(),
			Id = this.Id,
			Before = this.Before,
			After = this.After,
			BeforeGroupContaining = this.BeforeGroupContaining,
			AfterGroupContaining = this.AfterGroupContaining
		};
	}

	public class MenuItemConstructorOptionsDto {
		public bool Click { get; set; }
		public string Role { get; set; }
		public string Type { get; set; }
		public string Label { get; set; }
		public string Sublabel { get; set; }
		public string ToolTip { get; set; }
		public string Accelerator { get; set; }
		public int IconImage { get; set; }
		public string IconPath { get; set; }
		public bool Enabled { get; set; } = true;
		public bool AcceleratorWorksWhenHidden { get; set; }
		public bool Visible { get; set; } = true;
		public bool Checked { get; set; }
		public bool RegisterAccelerator { get; set; } = true;
		public SharingItem SharingItem { get; set; }
		public int SubmenuMenu { get; set; }
		public MenuItemConstructorOptionsDto[] SubmenuTemplate { get; set; }
		public string Id { get; set; }
		public string Before { get; set; }
		public string After { get; set; }
		public string BeforeGroupContaining { get; set; }
		public string AfterGroupContaining { get; set; }
	}

	public class MessageBoxOptions {
		public string Message { get; set; }
		public string Type { get; set; }
		public string[] Buttons { get; set; }
		public int? DefaultId { get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
		public string CheckboxLabel { get; set; }
		public bool CheckboxChecked { get; set; }
		public NativeImage Icon { get; set; }
		public int? CancelId { get; set; }
		public bool NoLink { get; set; }
		public bool NormalizeAccessKeys { get; set; }

		internal MessageBoxOptionsDto ToMessageBoxOptionsDto() => new() {
			Message = this.Message,
			Type = this.Type,
			Buttons = this.Buttons,
			DefaultId = this.DefaultId,
			Title = this.Title,
			Detail = this.Detail,
			CheckboxLabel = this.CheckboxLabel,
			CheckboxChecked = this.CheckboxChecked,
			Icon = this.Icon?.InternalId ?? 0,
			CancelId = this.CancelId,
			NoLink = this.NoLink,
			NormalizeAccessKeys = this.NormalizeAccessKeys
		};
	}

	public class MessageBoxOptionsDto {
		public string Message { get; set; }
		public string Type { get; set; }
		public string[] Buttons { get; set; }
		public int? DefaultId { get; set; }
		public string Title { get; set; }
		public string Detail { get; set; }
		public string CheckboxLabel { get; set; }
		public bool CheckboxChecked { get; set; }
		public int Icon { get; set; }
		public int? CancelId { get; set; }
		public bool NoLink { get; set; }
		public bool NormalizeAccessKeys { get; set; }
	}

	public class MessageBoxReturnValue {
		public int Response { get; set; }
		public bool CheckboxChecked { get; set; }
	}

	public class MessageDetails {
		public string Message { get; set; }
		public int VersionId { get; set; }
		public string Source { get; set; }
		public int Level { get; set; }
		public string SourceUrl { get; set; }
		public int LineNumber { get; set; }
	}

	public class NotificationAction {
		public string Type { get; set; }
		public string Text { get; set; }
	}

	public class NotificationConstructorOptions {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Body { get; set; }
		public bool Silent { get; set; }
		public NativeImage IconImage { get; set; }
		public string IconPath { get; set; }
		public bool HasReply { get; set; }
		public string TimeoutType { get; set; }
		public string ReplyPlaceholder { get; set; }
		public string Sound { get; set; }
		public string Urgency { get; set; }
		public NotificationAction[] Actions { get; set; }
		public string CloseButtonText { get; set; }
		public string ToastXml { get; set; }

		internal NotificationConstructorOptionsDto ToNotificationConstructorOptionsDto() => new() {
			Title = this.Title,
			Subtitle = this.Subtitle,
			Body = this.Body,
			Silent = this.Silent,
			IconImage = this.IconImage?.InternalId ?? 0,
			IconPath = this.IconPath,
			HasReply = this.HasReply,
			TimeoutType = this.TimeoutType,
			ReplyPlaceholder = this.ReplyPlaceholder,
			Sound = this.Sound,
			Urgency = this.Urgency,
			Actions = this.Actions,
			CloseButtonText = this.CloseButtonText,
			ToastXml = this.ToastXml
		};
	}

	public class NotificationConstructorOptionsDto {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Body { get; set; }
		public bool Silent { get; set; }
		public int IconImage { get; set; }
		public string IconPath { get; set; }
		public bool HasReply { get; set; }
		public string TimeoutType { get; set; }
		public string ReplyPlaceholder { get; set; }
		public string Sound { get; set; }
		public string Urgency { get; set; }
		public NotificationAction[] Actions { get; set; }
		public string CloseButtonText { get; set; }
		public string ToastXml { get; set; }
	}

	public class OnBeforeRedirectListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		[JsonPropertyName("redirectURL")]
		public string RedirectUrl { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }
		public string Ip { get; set; }
		public bool FromCache { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }

		public OnBeforeRedirectListenerDetails ToOnBeforeRedirectListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			RedirectUrl = this.RedirectUrl,
			StatusCode = this.StatusCode,
			StatusLine = this.StatusLine,
			Ip = this.Ip,
			FromCache = this.FromCache,
			ResponseHeaders = this.ResponseHeaders
		};
	}

	public class OnBeforeRedirectListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public string RedirectUrl { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }
		public string Ip { get; set; }
		public bool FromCache { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnBeforeRequestListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public UploadDataDto[] UploadData { get; set; }

		public OnBeforeRequestListenerDetails ToOnBeforeRequestListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			UploadData = this.UploadData?.Select(x => x.ToUploadData()).ToArray()
		};
	}

	public class OnBeforeRequestListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public UploadData[] UploadData { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnBeforeSendHeadersListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string> RequestHeaders { get; set; }

		public OnBeforeSendHeadersListenerDetails ToOnBeforeSendHeadersListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			RequestHeaders = this.RequestHeaders
		};
	}

	public class OnBeforeSendHeadersListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string> RequestHeaders { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnCompletedListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }
		public bool FromCache { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }
		public string Error { get; set; }

		public OnCompletedListenerDetails ToOnCompletedListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			ResponseHeaders = this.ResponseHeaders,
			FromCache = this.FromCache,
			StatusCode = this.StatusCode,
			StatusLine = this.StatusLine,
			Error = this.Error
		};
	}

	public class OnCompletedListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }
		public bool FromCache { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }
		public string Error { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnErrorOccurredListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public bool FromCache { get; set; }
		public string Error { get; set; }

		public OnErrorOccurredListenerDetails ToOnErrorOccurredListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			FromCache = this.FromCache,
			Error = this.Error
		};
	}

	public class OnErrorOccurredListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public bool FromCache { get; set; }
		public string Error { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnHeadersReceivedListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public string StatusLine { get; set; }
		public int StatusCode { get; set; }
		public Dictionary<string, string> RequestHeaders { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }

		public OnHeadersReceivedListenerDetails ToOnHeadersReceivedListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			StatusLine = this.StatusLine,
			StatusCode = this.StatusCode,
			RequestHeaders = this.RequestHeaders,
			ResponseHeaders = this.ResponseHeaders
		};
	}

	public class OnHeadersReceivedListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public string StatusLine { get; set; }
		public int StatusCode { get; set; }
		public Dictionary<string, string> RequestHeaders { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OnResponseStartedListenerDetailsDto {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public int WebContents { get; set; }
		public WebFrameMainId Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }
		public bool FromCache { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }

		public OnResponseStartedListenerDetails ToOnResponseStartedListenerDetails() => new() {
			Id = this.Id,
			Url = this.Url,
			Method = this.Method,
			WebContentsId = this.WebContentsId,
			WebContents = Api.WebContents.FromId(this.WebContents),
			Frame = WebFrameMain.FromId(this.Frame),
			ResourceType = this.ResourceType,
			Referrer = this.Referrer,
			TimeStamp = this.TimeStamp,
			ResponseHeaders = this.ResponseHeaders,
			FromCache = this.FromCache,
			StatusCode = this.StatusCode,
			StatusLine = this.StatusLine
		};
	}

	public class OnResponseStartedListenerDetails {
		public int Id { get; set; }
		public string Url { get; set; }
		public string Method { get; set; }
		public int WebContentsId { get; set; }
		public WebContents WebContents { get; set; }
		public WebFrameMain Frame { get; set; }
		public string ResourceType { get; set; }
		public string Referrer { get; set; }
		public double TimeStamp { get; set; }
		public Dictionary<string, string[]> ResponseHeaders { get; set; }
		public bool FromCache { get; set; }
		public int StatusCode { get; set; }
		public string StatusLine { get; set; }

		[JsonIgnore]
		public DateTime TimeStampDateTime {
			get => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.TimeStamp), DateTimeKind.Utc);
			set => this.TimeStamp = (value - DateTime.UnixEpoch).TotalSeconds;
		}
	}

	public class OpenDialogOptions {
		public string Title { get; set; }
		public string DefaultPath { get; set; }
		public string ButtonLabel { get; set; }
		public FileFilter[] Filters { get; set; }
		public string[] Properties { get; set; }
		public string Message { get; set; }
		public bool SecurityScopedBookmarks { get; set; }
	}

	public class OpenDialogReturnValue {
		public bool Canceled { get; set; }
		public string[] FilePaths { get; set; }
		public string[] Bookmarks { get; set; }
	}

	public class OverlayInfo {
		public bool DirectComposition { get; set; }
		public bool SupportsOverlays { get; set; }
		public string Yuy2OverlaySupport { get; set; }
		public string Nv12OverlaySupport { get; set; }
	}

	public class Payment {
		public string ProductIdentifier { get; set; }
		public int Quantity { get; set; }
	}

	public class PermissionCheckHanddlerHandlerDetails {
		public string SecurityOrigin { get; set; }
		public string MediaType { get; set; }
		public string RequestingUrl { get; set; }
		public bool IsMainFrame { get; set; }
	}

	public class PermissionRequestHandlerHandlerDetails {
		[JsonPropertyName("externalURL")]
		public string ExternalUrl { get; set; }
		public string[] MediaTypes { get; set; }
		public string RequestingUrl { get; set; }
		public bool IsMainFrame { get; set; }
	}

	public class Point {
		public double X { get; set; }
		public double Y { get; set; }

		public static implicit operator PointF(Point x) => new() {
			X = (float)x.X,
			Y = (float)x.Y
		};
		public static implicit operator Point(PointF x) => new() {
			X = x.X,
			Y = x.Y
		};
	}

	public class PopupOptions {
		public BrowserWindow Window { get; set; }
		public int? X { get; set; }
		public int? Y { get; set; }
		public int PositioningItem { get; set; } = -1;
		public Action Callback { get; set; }

		internal PopupOptionsDto ToPopupOptionsDto() => new() {
			Window = this.Window?.Id ?? 0,
			X = this.X,
			Y = this.Y,
			PositioningItem = this.PositioningItem
		};
	}

	public class PopupOptionsDto {
		public int Window { get; set; }
		public int? X { get; set; }
		public int? Y { get; set; }
		public int PositioningItem { get; set; } = -1;
	}

	public class PreconnectOptions {
		public string Url { get; set; }
		public int NumSockets { get; set; } = 1;
	}

	public class ProcessMemoryInfo {
		public int ResidentSet { get; set; }
		public int Private { get; set; }
		public int Shared { get; set; }
	}

	public class ProcessMetric {
		[JsonPropertyName("pid")]
		public int PId { get; set; }
		public string Type { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
		public CpuUsage Cpu { get; set; }
		public double CreationTime { get; set; }

		[JsonIgnore]
		public DateTime CreationDateTime =>
			DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromMilliseconds(this.CreationTime), DateTimeKind.Utc);

		public MemoryInfo Memory { get; set; }
		public bool Sandboxed { get; set; }
		public string IntegrityLevel { get; set; }
	}

	public class Product {
		public string ProductIdentifier { get; set; }
		public string LocalizedDescription { get; set; }
		public string LocalizedTitle { get; set; }
		public string ContentVersion { get; set; }
		public int[] ContentLengths { get; set; }
		public double Price { get; set; }
		public string FormattedPrice { get; set; }
		public string CurrencyCode { get; set; }
		public bool IsDownloadable { get; set; }
	}

	public class ProgressBarOptions {
		public string Mode { get; set; }
	}

	public abstract class ProtocolResponse {
		public int Error { get; set; }
		public int StatusCode { get; set; }
		public string Charset { get; set; }
		public string MimeType { get; set; }
		public Dictionary<string, object> Headers { get; set; }
	}

	public class ProtocolFileResponse : ProtocolResponse {
		public string Path { get; set; }
		public string Referrer { get; set; }
		public string Method { get; set; }
	}

	public class ProtocolBufferResponse : ProtocolResponse {
		public byte[] Data { get; set; }

		internal virtual ProtocolBufferResponseDto ToProtocolBufferResponseDto() => new() {
			Error = this.Error,
			StatusCode = this.StatusCode,
			Charset = this.Charset,
			MimeType = this.MimeType,
			Headers = this.Headers,
			Data = Convert.ToBase64String(this.Data)
		};
	}

	public class ProtocolBufferResponseDto : ProtocolResponse {
		public string Data { get; set; }
	}

	public class ProtocolStringResponse : ProtocolResponse {
		public string Data { get; set; }
	}

	public class ProtocolHttpResponse : ProtocolResponse {
		public string Url { get; set; }
		public string Referrer { get; set; }
		public string Method { get; set; }
		public Session Session { get; set; }
		public ProtocolResponseUploadData UploadData { get; set; }

		internal virtual ProtocolHttpResponseDto ToProtocolHttpResponseDto() => new() {
			Error = this.Error,
			StatusCode = this.StatusCode,
			Charset = this.Charset,
			MimeType = this.MimeType,
			Headers = this.Headers,
			Url = this.Url,
			Referrer = this.Referrer,
			Method = this.Method,
			Session = this.Session?.InternalId ?? 0,
			UploadData = this.UploadData?.ToProtocolResponseUploadDataDto()
		};
	}

	public class ProtocolHttpResponseDto : ProtocolResponse {
		public string Url { get; set; }
		public string Referrer { get; set; }
		public string Method { get; set; }
		public int Session { get; set; }
		public ProtocolResponseUploadDataDto UploadData { get; set; }
	}

	public class ProtocolResponseUploadData {
		public string ContentType { get; set; }
		public string DataText { get; set; }
		public byte[] DataRaw { get; set; }

		internal ProtocolResponseUploadDataDto ToProtocolResponseUploadDataDto() => new() {
			ContentType = this.ContentType,
			DataText = this.DataText,
			DataRaw = Convert.ToBase64String(this.DataRaw)
		};
	}

	public class ProtocolResponseUploadDataDto {
		public string ContentType { get; set; }
		public string DataText { get; set; }
		public string DataRaw { get; set; }
	}

	public class ProtocolRequestDto {
		public string Url { get; set; }
		public string Referrer { get; set; }
		public string Method { get; set; }
		public UploadDataDto[] UploadData { get; set; }
		public Dictionary<string, string> Headers { get; set; }

		internal ProtocolRequest ToProtocolRequest() => new() {
			Url = this.Url,
			Referrer = this.Referrer,
			Method = this.Method,
			UploadData = this.UploadData?.Select(x => x.ToUploadData()).ToArray(),
			Headers = this.Headers
		};
	}

	public class ProtocolRequest {
		public string Url { get; set; }
		public string Referrer { get; set; }
		public string Method { get; set; }
		public UploadData[] UploadData { get; set; }
		public Dictionary<string, string> Headers { get; set; }
	}

	public class Rectangle {
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		public static implicit operator RectangleF(Rectangle x) => new() {
			X = (float)x.X,
			Y = (float)x.Y,
			Width = (float)x.Width,
			Height = (float)x.Height
		};
		public static implicit operator Rectangle(RectangleF x) => new() {
			X = x.X,
			Y = x.Y,
			Width = x.Width,
			Height = x.Height
		};
	}

	public class PartialRectangle {
		public double? X { get; set; }
		public double? Y { get; set; }
		public double? Width { get; set; }
		public double? Height { get; set; }
	}

	public class Referrer {
		public string Url { get; set; }
		public string Policy { get; set; }
	}

	public class RelaunchOptions {
		public string Args { get; set; }
		public string ExecPath { get; set; }
	}

	public class RenderProcessGone {
		public string Reason { get; set; }
		public int ExitCode { get; set; }
	}

	public class Request {
		public string Hostname { get; set; }
		public Certificate Certificate { get; set; }
		public Certificate ValidatedCertificate { get; set; }
		public string VerificationResult { get; set; }
		public int ErrorCode { get; set; }
	}

	public class Response {
		public bool Cancel { get; set; }
		[JsonPropertyName("redirectURL")]
		public string RedirectUrl { get; set; }
	}

	public class SaveDialogOptions {
		public string Title { get; set; }
		public string DefaultPath { get; set; }
		public string ButtonLabel { get; set; }
		public FileFilter[] Filters { get; set; }
		public string Message { get; set; }
		public string NameFieldLabel { get; set; }
		public bool ShowsTagField { get; set; } = true;
		public string[] Properties { get; set; }
		public bool SecurityScopedBookmarks { get; set; }
	}

	public class SaveDialogReturnValue {
		public bool Canceled { get; set; }
		public string FilePath { get; set; }
		public string Bookmark { get; set; }
	}

	public class ScrubberItem {
		public string Label { get; set; }
		public NativeImage Icon { get; set; }

		internal ScrubberItemDto ToScrubberItemDto() => new() {
			Label = this.Label,
			Icon = this.Icon?.InternalId ?? 0
		};
	}

	public class ScrubberItemDto {
		public string Label { get; set; }
		public int Icon { get; set; }

		internal ScrubberItem ToScrubberItem() => new() {
			Label = this.Label,
			Icon = ElectronDisposable.FromId<NativeImage>(this.Icon)
		};
	}

	public class SegmentedControlSegment {
		public string Label { get; set; }
		public NativeImage Icon { get; set; }
		public bool Enabled { get; set; } = true;

		internal SegmentedControlSegmentDto ToSegmentedControlSegmentDto() => new() {
			Label = this.Label,
			Icon = this.Icon?.InternalId ?? 0,
			Enabled = this.Enabled
		};
	}

	public class SegmentedControlSegmentDto {
		public string Label { get; set; }
		public int Icon { get; set; }
		public bool Enabled { get; set; } = true;

		internal SegmentedControlSegment ToSegmentedControlSegment() => new() {
			Label = this.Label,
			Icon = ElectronDisposable.FromId<NativeImage>(this.Icon),
			Enabled = this.Enabled
		};
	}

	public class SerialPort {
		public string PortId { get; set; }
		public string PortName { get; set; }
		public string DisplayName { get; set; }
		public string VendorId { get; set; }
		public string ProductId { get; set; }
		public string SerialNumber { get; set; }
		public string UsbDriverName { get; set; }
		public string DeviceInstanceId { get; set; }
	}

	public class ServiceWorkerInfo {
		public string ScriptUrl { get; set; }
		public string Scope { get; set; }
		public int RenderProcessId { get; set; }
	}

	public class Settings {
		public bool OpenAtLogin { get; set; }
		public bool OpenAsHidden { get; set; }
		public string Path { get; set; }
		public string[] Args { get; set; }
		public bool Enabled { get; set; }
		public string Name { get; set; }
	}

	public class SharingItem {
		public string[] Texts { get; set; }
		public string[] FilePaths { get; set; }
		public string[] Urls { get; set; }
	}

	public class Size {
		public double Width { get; set; }
		public double Height { get; set; }

		public static implicit operator SizeF(Size x) => new() {
			Width = (float)x.Width,
			Height = (float)x.Height
		};
		public static implicit operator Size(SizeF x) => new() {
			Width = x.Width,
			Height = x.Height
		};
	}

	public class SslConfigConfig {
		public string MinVersion { get; set; }
		public string MaxVersion { get; set; }
		public int DisabledCipherSuites { get; set; }
	}

	public class StartLoggingOptions {
		public string CaptureMode { get; set; }
		public long? MaxFileSize { get; set; }
	}

	public class SystemMemoryInfo {
		public int Total { get; set; }
		public int Free { get; set; }
		public int SwapTotal { get; set; }
		public int SwapFree { get; set; }
	}

	public class JumpListTask {
		public string Program { get; set; }
		public string Arguments { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconPath { get; set; }
		public int IconIndex { get; set; }
		public string WorkingDirectory { get; set; }
	}

	public class ThumbarButton {
		public NativeImage Icon { get; set; }
		public Action Click { get; set; }
		public string Tooltip { get; set; }
		public string[] Flags { get; set; }

		internal ThumbarButtonDto ToThumbarButtonDto() => new() {
			Icon = this.Icon?.InternalId ?? 0,
			Tooltip = this.Tooltip,
			Flags = this.Flags
		};
	}

	public class ThumbarButtonDto {
		public int Icon { get; set; }
		public string Tooltip { get; set; }
		public string[] Flags { get; set; }
	}

	public class TitleOptions {
		public string FontType { get; set; }
	}

	public class ToDataUrlOptions {
		public double ScaleFactor { get; set; }
	}

	public class TouchBarButtonConstructorOptions {
		public string Label { get; set; }
		public string AccessibilityLabel { get; set; }
		public string BackgroundColor { get; set; }
		public NativeImage IconImage { get; set; }
		public string IconPath { get; set; }
		public string IconPosition { get; set; } = TouchBarButtonIconPositions.Overlay;
		public Action Click { get; set; }
		public bool Enabled { get; set; } = true;

		internal TouchBarButtonConstructorOptionsDto ToTouchBarButtonConstructorOptionsDto() => new() {
			Label = this.Label,
			AccessibilityLabel = this.AccessibilityLabel,
			BackgroundColor = this.BackgroundColor,
			IconImage = this.IconImage?.InternalId ?? 0,
			IconPath = this.IconPath,
			IconPosition = this.IconPosition,
			Enabled = this.Enabled
		};
	}

	public class TouchBarButtonConstructorOptionsDto {
		public string Label { get; set; }
		public string AccessibilityLabel { get; set; }
		public string BackgroundColor { get; set; }
		public int IconImage { get; set; }
		public string IconPath { get; set; }
		public string IconPosition { get; set; } = TouchBarButtonIconPositions.Overlay;
		public bool Enabled { get; set; } = true;
	}

	public class TouchBarColorPickerConstructorOptions {
		public string[] AvailableColors { get; set; }
		public string SelectedColor { get; set; }
		public Action<string> Change { get; set; }
	
		internal TouchBarColorPickerConstructorOptionsDto ToTouchBarColorPickerConstructorOptionsDto() => new() {
			AvailableColors = this.AvailableColors,
			SelectedColor = this.SelectedColor
		};
	}

	public class TouchBarColorPickerConstructorOptionsDto {
		public string[] AvailableColors { get; set; }
		public string SelectedColor { get; set; }
	}

	public class TouchBarConstructorOptions {
		public ITouchBarComponent[] Items { get; set; }
		public ITouchBarComponent EscapeItem { get; set; }

		internal TouchBarConstructorOptionsDto ToTouchBarConstructorOptionsDto() => new() {
			Items = this.Items?.Select(x => x.InternalId).ToArray(),
			EscapeItem = this.EscapeItem?.InternalId ?? 0
		};
	}
	
	public class TouchBarConstructorOptionsDto {
		public int[] Items { get; set; }
		public int EscapeItem { get; set; }
	}

	public class TouchBarGroupConstructorOptions {
		public TouchBar Items { get; set; }

		internal TouchBarGroupConstructorOptionsDto ToTouchBarGroupConstructorOptionsDto() => new() {
			Items = this.Items?.InternalId ?? 0
		};
	}

	public class TouchBarGroupConstructorOptionsDto {
		public int Items { get; set; }
	}

	public class TouchBarLabelConstructorOptions {
		public string Label { get; set; }
		public string AccessibilityLabel { get; set; }
		public string TextColor { get; set; }
	}

	public class TouchBarPopoverConstructorOptions {
		public string Label { get; set; }
		public NativeImage Icon { get; set; }
		public TouchBar Items { get; set; }
		public bool ShowCloseButton { get; set; }

		internal TouchBarPopoverConstructorOptionsDto ToTouchBarPopoverConstructorOptionsDto() => new() {
			Label = this.Label,
			Icon = this.Icon?.InternalId ?? 0,
			Items = this.Items?.InternalId ?? 0,
			ShowCloseButton = this.ShowCloseButton
		};
	}

	public class TouchBarPopoverConstructorOptionsDto {
		public string Label { get; set; }
		public int Icon { get; set; }
		public int Items { get; set; }
		public bool ShowCloseButton { get; set; }
	}

	public class TouchBarScrubberConstructorOptions {
		public ScrubberItem[] Items { get; set; }
		public Action<int> Select { get; set; }
		public Action<int> Highlight { get; set; }
		public string SelectedStyle { get; set; } = "none";
		public string OverlayStyle { get; set; } = "none";
		public bool ShowArrowButtons { get; set; }
		public string Mode { get; set; } = "free";
		public bool Continuous { get; set; } = true;

		internal TouchBarScrubberConstructorOptionsDto ToTouchBarScrubberConstructorOptionsDto() => new() {
			Items = this.Items?.Select(x => x.ToScrubberItemDto()).ToArray(),
			SelectedStyle = this.SelectedStyle,
			OverlayStyle = this.OverlayStyle,
			ShowArrowButtons = this.ShowArrowButtons,
			Mode = this.Mode,
			Continuous = this.Continuous
		};
	}

	public class TouchBarScrubberConstructorOptionsDto {
		public ScrubberItemDto[] Items { get; set; }
		public string SelectedStyle { get; set; } = TouchBarScrubberItemStyles.None;
		public string OverlayStyle { get; set; } = TouchBarScrubberItemStyles.None;
		public bool ShowArrowButtons { get; set; }
		public string Mode { get; set; } = TouchBarScrubberModes.Free;
		public bool Continuous { get; set; } = true;
	}

	public class TouchBarSegmentedControlConstructorOptions {
		public string SegmentStyle { get; set; } = TouchBarSegmentStyles.Automatic;
		public string Mode { get; set; } = TouchBarSegmentedControlModes.Single;
		public SegmentedControlSegment[] Segments { get; set; }
		public int SelectedIndex { get; set; }
		public Action<int, bool> Change { get; set; }

		internal TouchBarSegmentedControlConstructorOptionsDto ToTouchBarSegmentedControlConstructorOptionsDto() => new() {
			SegmentStyle = this.SegmentStyle,
			Mode = this.Mode,
			Segments = this.Segments?.Select(x => x.ToSegmentedControlSegmentDto()).ToArray(),
			SelectedIndex = this.SelectedIndex
		};
	}

	public class TouchBarSegmentedControlConstructorOptionsDto {
		public string SegmentStyle { get; set; } = TouchBarSegmentStyles.Automatic;
		public string Mode { get; set; } = TouchBarSegmentedControlModes.Single;
		public SegmentedControlSegmentDto[] Segments { get; set; }
		public int SelectedIndex { get; set; }
	}

	public class TouchBarSliderConstructorOptions {
		public string Label { get; set; }
		public int Value { get; set; }
		public int MinValue { get; set; }
		public int MaxValue { get; set; }
		public Action<int> Change { get; set; }

		internal TouchBarSliderConstructorOptionsDto ToTouchBarSliderConstructorOptionsDto() => new() {
			Label = this.Label,
			Value = this.Value,
			MinValue = this.MinValue,
			MaxValue = this.MaxValue
		};
	}

	public class TouchBarSliderConstructorOptionsDto {
		public string Label { get; set; }
		public int Value { get; set; }
		public int MinValue { get; set; }
		public int MaxValue { get; set; }
	}
	
	public class TouchBarSpacerConstructorOptions {
		public string Size { get; set; } = TouchBarSpacerSizes.Small;
	}

	public class TraceBufferUsageReturnValue {
		public double Value { get; set; }
		public double Percentage { get; set; }
	}

	public class TraceCategoriesAndOptions {
		public string CategoryFilter { get; set; }
		public string TraceOptions { get; set; }
	}

	public class TraceConfig {
		[JsonPropertyName("recording__mode")]
		public string RecordingMode { get; set; }
		[JsonPropertyName("trace_buffer_size_in_kb")]
		public double TraceBufferSizeInKb { get; set; }
		[JsonPropertyName("enable_argument_filter")]
		public bool EnableArgumentFilter { get; set; }
		[JsonPropertyName("included_categories")]
		public string[] IncludedCategories { get; set; }
		[JsonPropertyName("excluded_categories")]
		public string[] ExcludedCategories { get; set; }
		[JsonPropertyName("included_process_ids")]
		public int[] IncludedProcessIds { get; set; }
		[JsonPropertyName("histogram_names")]
		public string[] HistogramsNames { get; set; }
		[JsonPropertyName("memory_dump_config")]
		public Dictionary<string, object> MemoryDumpConfig { get; set; }
	}

	public class Transaction {
		public string TransactionIdentifier { get; set; }
		public string TransactionDate { get; set; }
		public string OriginalTransactionIdentifier { get; set; }
		public string TransactionState { get; set; }
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }
		public Payment Payment { get; set; }
}

	public class UploadDataDto {
		public string Bytes { get; set; }
		public string File { get; set; }
		[JsonPropertyName("blobUUID")]
		public string BlobUuid { get; set; }

		internal UploadData ToUploadData() => new() {
			Bytes = Convert.FromBase64String(this.Bytes),
			File = this.File,
			BlobUuid = this.BlobUuid
		};
	}

	public class UploadData {
		public byte[] Bytes { get; set; }
		public string File { get; set; }
		public string BlobUuid { get; set; }
	}

	public class UploadRawDataOrFile {
		public string Type { get; set; }
		public byte[] Bytes { get; set; }
		public string FilePath { get; set; }
		public long Offset { get; set; }
		public long Length { get; set; }
		public DateTime ModificationTime { get; set; }

		internal UploadRawDataOrFileDto ToUploadRawDataOrFileDto() => new() {
			Type = this.Type,
			Bytes = this.Bytes != null ? Convert.ToBase64String(this.Bytes) : null,
			FilePath = this.FilePath,
			Offset = this.Offset,
			Length = this.Length,
			ModificationTime = (this.ModificationTime.ToUniversalTime() - DateTime.UnixEpoch).TotalSeconds
		};
	}

	public class UploadRawDataOrFileDto {
		public string Type { get; set; }
		public string Bytes { get; set; }
		public string FilePath { get; set; }
		public long Offset { get; set; }
		public long Length { get; set; }
		public double ModificationTime { get; set; }
	}

	public class VideoDecodeAcceleratorSupportedProfile {
		public int Profile { get; set; }
		public int MaxResolutionWidth { get; set; }
		public int MaxResolutionHeight { get; set; }
		public int MinResolutionWidth { get; set; }
		public int MinResolutionHeight { get; set; }
		[JsonPropertyName("encrypted_only")]
		public bool EncryptedOnly { get; set; }
	}

	public class VideoEncodeAcceleratorSupportedProfile {
		public int Profile { get; set; }
		public int MaxResolutionWidth { get; set; }
		public int MaxResolutionHeight { get; set; }
		public int MinResolutionWidth { get; set; }
		public int MinResolutionHeight { get; set; }
		public int MaxFramerateNumerator { get; set; }
		public int MaxFramerateDenominator { get; set; }
	}

	public class VisibleOnAllWorkspacesOptions {
		public bool VisibleOnFullScreen { get; set; }
	}

	public class WebContentsSetWindowOpenHandlerReturnValue {
		public string Action { get; set; }
		public BrowserWindowConstructorOptions OverrideBrowserWindowOptions { get; set; }

		internal WebContentsSetWindowOpenHandlerReturnValueDto ToWebContentsSetWindowOpenHandlerReturnValueDto() => new() {
			Action = this.Action,
			OverrideBrowserWindowOptions = this.OverrideBrowserWindowOptions?.ToBrowserWindowConstructorOptionsDto()
		};
	}

	public class WebContentsSetWindowOpenHandlerReturnValueDto {
		public string Action { get; set; }
		public BrowserWindowConstructorOptionsDto OverrideBrowserWindowOptions { get; set; }
	}

	public class WebPreferences {
		public bool DevTools { get; set; } = true;
		public bool NodeIntegration { get; set; }
		public bool NodeIntegrationInWorker { get; set; }
		public bool NodeIntegrationInSubFrames { get; set; }
		public string Preload { get; set; }
		public bool Sandbox { get; set; }
		public bool EnableRemoteModule { get; set; }
		public Session Session { get; set; }
		public string Partition { get; set; }
		public double ZoomFactor { get; set; }
		public bool JavaScript { get; set; } = true;
		public bool WebSecurity { get; set; } = true;
		public bool AllowRunningInsecureContent { get; set; }
		public bool Images { get; set; } = true;
		public bool TextAreasAreResizable { get; set; } = true;
		public bool WebGl { get; set; } = true;
		public bool Plugins { get; set; }
		public bool ExperimentalFeatures { get; set; }
		public bool ScrollBounce { get; set; }
		public string EnableBlinkFeatures { get; set; }
		public string DisableBlinkFeatures { get; set; }
		public DefaultFontFamily DefaultFontFamily { get; set; }
		public int DefaultFontSize { get; set; } = 16;
		public int DefaultMonospaceFontSize { get; set; } = 13;
		public int MinimumFontSize { get; set; }
		public string DefaultEncoding { get; set; }
		public bool BackgroundThrottling { get; set; } = true;
		public bool Offscreen { get; set; }
		public bool ContextIsolation { get; set; } = true;
		public bool WebviewTag { get; set; }
		public string AdditionalArguments { get; set; }
		public bool SafeDialogs { get; set; }
		public string SafeDialogMessage { get; set; }
		public bool DisableDialogs { get; set; }
		public bool NavigateOnDragDrop { get; set; }
		public string AutoplayPolicy { get; set; }
		public bool DisableHtmlFullscreenWindowResize { get; set; }
		public string AccessibleTitle { get; set; }
		public bool Spellcheck { get; set; } = true;
		public bool EnableWebSql { get; set; } = true;
		public string V8CacheOptions { get; set; }
		public bool EnablePreferredSizeMode { get; set; }

		internal WebPreferencesDto ToWebPreferencesDto() => new() {
			DevTools = this.DevTools,
			NodeIntegration = this.NodeIntegration,
			NodeIntegrationInWorker = this.NodeIntegrationInWorker,
			NodeIntegrationInSubFrames = this.NodeIntegrationInSubFrames,
			Preload = this.Preload,
			Sandbox = this.Sandbox,
			EnableRemoteModule = this.EnableRemoteModule,
			Session = this.Session?.InternalId ?? 0,
			Partition = this.Partition,
			ZoomFactor = this.ZoomFactor,
			JavaScript = this.JavaScript,
			WebSecurity = this.WebSecurity,
			AllowRunningInsecureContent = this.AllowRunningInsecureContent,
			Images = this.Images,
			TextAreasAreResizable = this.TextAreasAreResizable,
			WebGl = this.WebGl,
			Plugins = this.Plugins,
			ExperimentalFeatures = this.ExperimentalFeatures,
			ScrollBounce = this.ScrollBounce,
			EnableBlinkFeatures = this.EnableBlinkFeatures,
			DisableBlinkFeatures = this.DisableBlinkFeatures,
			DefaultFontFamily = this.DefaultFontFamily,
			DefaultFontSize = this.DefaultFontSize,
			DefaultMonospaceFontSize = this.DefaultMonospaceFontSize,
			MinimumFontSize = this.MinimumFontSize,
			DefaultEncoding = this.DefaultEncoding,
			BackgroundThrottling = this.BackgroundThrottling,
			Offscreen = this.Offscreen,
			ContextIsolation = this.ContextIsolation,
			WebviewTag = this.WebviewTag,
			AdditionalArguments = this.AdditionalArguments,
			SafeDialogs = this.SafeDialogs,
			SafeDialogMessage = this.SafeDialogMessage,
			DisableDialogs = this.DisableDialogs,
			NavigateOnDragDrop = this.NavigateOnDragDrop,
			AutoplayPolicy = this.AutoplayPolicy,
			DisableHtmlFullscreenWindowResize = this.DisableHtmlFullscreenWindowResize,
			AccessibleTitle = this.AccessibleTitle,
			Spellcheck = this.Spellcheck,
			EnableWebSql = this.EnableWebSql,
			V8CacheOptions = this.V8CacheOptions,
			EnablePreferredSizeMode = this.EnablePreferredSizeMode
		};
	}

	public class WebPreferencesDto {
		public bool DevTools { get; set; } = true;
		public bool NodeIntegration { get; set; }
		public bool NodeIntegrationInWorker { get; set; }
		public bool NodeIntegrationInSubFrames { get; set; }
		public string Preload { get; set; }
		public bool Sandbox { get; set; }
		public bool EnableRemoteModule { get; set; }
		public int Session { get; set; }
		public string Partition { get; set; }
		public double ZoomFactor { get; set; }
		public bool JavaScript { get; set; } = true;
		public bool WebSecurity { get; set; } = true;
		public bool AllowRunningInsecureContent { get; set; }
		public bool Images { get; set; } = true;
		public bool TextAreasAreResizable { get; set; } = true;
		[JsonPropertyName("webgl")]
		public bool WebGl { get; set; } = true;
		public bool Plugins { get; set; }
		public bool ExperimentalFeatures { get; set; }
		public bool ScrollBounce { get; set; }
		public string EnableBlinkFeatures { get; set; }
		public string DisableBlinkFeatures { get; set; }
		public DefaultFontFamily DefaultFontFamily { get; set; }
		public int DefaultFontSize { get; set; } = 16;
		public int DefaultMonospaceFontSize { get; set; } = 13;
		public int MinimumFontSize { get; set; }
		public string DefaultEncoding { get; set; }
		public bool BackgroundThrottling { get; set; } = true;
		public bool Offscreen { get; set; }
		public bool ContextIsolation { get; set; } = true;
		public bool WebviewTag { get; set; }
		public string AdditionalArguments { get; set; }
		public bool SafeDialogs { get; set; }
		public string SafeDialogMessage { get; set; }
		public bool DisableDialogs { get; set; }
		public bool NavigateOnDragDrop { get; set; }
		public string AutoplayPolicy { get; set; }
		public bool DisableHtmlFullscreenWindowResize { get; set; }
		public string AccessibleTitle { get; set; }
		public bool Spellcheck { get; set; } = true;
		[JsonPropertyName("enableWebSQL")]
		public bool EnableWebSql { get; set; } = true;
		public string V8CacheOptions { get; set; }
		public bool EnablePreferredSizeMode { get; set; }
	}
}