namespace MZZT.ElectronNetCore.Api {
	public class ElectronProcessVersions {
		internal ElectronProcessVersions() { }

		public ElectronReadOnlyProperty<string> Chrome { get; } =
			new(x => x.ProcessVersions_Chrome_Get);
		public ElectronReadOnlyProperty<string> Electron { get; } =
			new(x => x.ProcessVersions_Electron_Get);
	}
}
