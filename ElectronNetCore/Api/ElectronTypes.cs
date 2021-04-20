using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace MZZT.ElectronNetCore.Api {
	public static class ActivatiobPolicies {
		public const string Regular = "regular";
		public const string Accessory = "accessory";
		public const string Prohibited = "prohibited";
	}

	public static class AutoplayPolicies {
		public const string NoUserGestureRequired = "no-user-gesture-required";
		public const string UserGestureRequired = "user-gesture-required";
		public const string DocumentUserActivationRequired = "document-user-activation-required";
	}

	public static class BounceTypes {
		public const string Critical = "critical";
		public const string Informational = "informational";
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

	public static class ConflictTypes {
		public static string Exists = "exists";
		public static string ExistsAndRunning = "existsAndRunning";
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

	public class GpuInfoTypes {
		public const string Basic = "basic";
		public const string Complete = "complete";
	}

	public class ImageDecodeAcceleratorTypes {
		public const string Jpeg = "JPEG";
		public const string Unknown = "Unknown";
	}

	public class ImageDecideAcceleratorSubsamplings {
		public const string Subsampling420 = "4:2:0";
		public const string Subsampling422 = "4:2:2";
		public const string Subsampling444 = "4:4:4";
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

	public static class SwipeDirections {
		public const string Up = "up";
		public const string Right = "right";
		public const string Down = "down";
		public const string Left = "left";
	}

	public static class V8CacheOptions {
		public const string None = "none";
		public const string Code = "code";
		public const string BypassHeatCheck = "bypassHeatCheck";
		public const string BypassHeatCheckAndEagerCompile = "bypassHeatCheckAndEagerCompile";
	}

	public class MoveToApplicationsFolderOptions {
		public Func<string, bool> ConflictHandler { get; set; }
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
		public string Authors { get; set; }
		public string Website { get; set; }
		public string IconPath { get; set; }
	}

	internal class ApplicationInfoForProtocolReturnValueInternal {
		public int Icon { get; set; }
		public string Path { get; set; }
		public string Name { get; set; }

		public ApplicationInfoForProtocolReturnValue ToApplicationInfoForProtocolReturnValue() => new() {
			Icon = (NativeImage)ElectronDisposable.FromId(typeof(NativeImage), this.Icon),
			Name = this.Name,
			Path = this.Path
		};
	}

	public class ApplicationInfoForProtocolReturnValue {
		public NativeImage Icon { get; set; }
		public string Path { get; set; }
		public string Name { get; set; }
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

	public class BlinkMemoryInfo {
		public int Allocated { get; set; }
		public int Marked { get; set; }
		public int Total { get; set; }
	}

	public class BrowserViewConstructorOptions {
		public WebPreferences WebPreferences { get; set; }

		internal BrowserViewConstructorOptionsInternal ToBrowserViewConstructorOptionsInternal() => new() {
			WebPreferences = WebPreferences?.ToWebPreferencesInternal()
		};
	}

	internal class BrowserViewConstructorOptionsInternal {
		public WebPreferencesInternal WebPreferences { get; set; }
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

		internal BrowserWindowConstructorOptionsInternal ToBrowserWindowConstructorOptionsInternal() => new() {
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
			IconImage = this.IconImage?.Id ?? 0,
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
			WebPreferences = this.WebPreferences?.ToWebPreferencesInternal()
		};
	}

	internal class BrowserWindowConstructorOptionsInternal {
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
		public WebPreferencesInternal WebPreferences { get; set; }
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
		public DateTime ValidStartDateTime => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ValidStart), DateTimeKind.Utc);
		[JsonIgnore]
		public DateTime ValidExpiryDateTime => DateTime.SpecifyKind(DateTime.UnixEpoch + TimeSpan.FromSeconds(this.ValidExpiry), DateTimeKind.Utc);
	}

	public class CertificatePrincipal {
		public string CommonName { get; set; }
		public string[] Organizations { get; set; }
		public string[] OrganizationUnits { get; set; }
		public string Locality { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}

	public class ChildProcessGone : RenderProcessGone {
		public string Type { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
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

	public class Error {
		public string Message { get; set; }
		public string Name { get; set; }
		public string Stack { get; set; }
	}

	public class FeedUrlOptions {
		public string Url { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public string ServerType { get; set; }
	}

	public class FileIconOptions {
		public string Size { get; set; }
	}

	public class FocusOptions {
		public bool Steal { get; set; }
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

	public class LaunchItems {
		public string Name { get; set; }
		public string Path { get; set; }
		public string[] Args { get; set; }
		public string Scope { get; set; }
		public bool Enabled { get; set; }
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

	public class OverlayInfo {
		public bool DirectComposition { get; set; }
		public bool SupportsOverlays { get; set; }
		public string Yuy2OverlaySupport { get; set; }
		public string Nv12OverlaySupport { get; set; }
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

	public class RelaunchOptions {
		public string Args { get; set; }
		public string ExecPath { get; set; }
	}

	public class RenderProcessGone {
		public string Reason { get; set; }
		public int ExitCode { get; set; }
	}

	public class Settings {
		public bool OpenAtLogin { get; set; }
		public bool OpenAsHidden { get; set; }
		public string Path { get; set; }
		public string[] Args { get; set; }
		public bool Enabled { get; set; }
		public string Name { get; set; }
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

	public class ToDataUrlOptions {
		public double ScaleFactor { get; set; }
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

		internal WebPreferencesInternal ToWebPreferencesInternal() => new() {
			DevTools = this.DevTools,
			NodeIntegration = this.NodeIntegration,
			NodeIntegrationInWorker = this.NodeIntegrationInWorker,
			NodeIntegrationInSubFrames = this.NodeIntegrationInSubFrames,
			Preload = this.Preload,
			Sandbox = this.Sandbox,
			EnableRemoteModule = this.EnableRemoteModule,
			Session = this.Session?.Id ?? 0,
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

	internal class WebPreferencesInternal {
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