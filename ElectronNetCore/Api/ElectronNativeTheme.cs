using System.Threading.Tasks;
using System;

namespace MZZT.ElectronNetCore {
	public partial interface IElectronInterface {
		Task NativeTheme_ShouldUseDarkColors_Get(int requestId);
		Task NativeTheme_ThemeSource_Get(int requestId);
		Task NativeTheme_ThemeSource_Set(int requestId, string value);
		Task NativeTheme_ShouldUseHighContrastColors_Get(int requestId);
		Task NativeTheme_ShouldUseInvertedColorScheme_Get(int requestId);
	}

	internal partial class ElectronHub {
		public Task NativeTheme_Updated_Event() =>
			Api.Electron.NativeTheme.OnUpdated();
	}
}

namespace MZZT.ElectronNetCore.Api {
	public class ElectronNativeTheme {
		internal ElectronNativeTheme() { }

		public event EventHandler Updated;
		internal Task OnUpdated() {
			this.Updated?.Invoke(this, new());
			return Task.CompletedTask;
		}

		public ElectronReadOnlyProperty<bool> ShouldUseDarkColors { get; } = new(x => x.NativeTheme_ShouldUseDarkColors_Get);
		public ElectronProperty<string> ThemeSource { get; } = new(x => x.NativeTheme_ThemeSource_Get, x => x.NativeTheme_ThemeSource_Set);
		public ElectronReadOnlyProperty<bool> ShouldUseHighContrastColors { get; } = new(x => x.NativeTheme_ShouldUseHighContrastColors_Get);
		public ElectronReadOnlyProperty<bool> ShouldUseInvertedColorScheme { get; } = new(x => x.NativeTheme_ShouldUseInvertedColorScheme_Get);
	}
}