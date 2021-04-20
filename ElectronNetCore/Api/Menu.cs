using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class Menu : ElectronDisposable<Menu>, IDisposable, IAsyncDisposable {
		internal Menu(int id) : base(id) { }
		
	}
}
