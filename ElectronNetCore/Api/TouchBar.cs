using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class TouchBar : ElectronDisposable<TouchBar>, IDisposable, IAsyncDisposable {
		internal TouchBar(int id) : base(id) { }
		
	}
}
