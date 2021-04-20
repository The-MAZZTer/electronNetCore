using System;
using System.Threading.Tasks;

namespace MZZT.ElectronNetCore.Api {
	public class Session : ElectronDisposable<Session>, IDisposable, IAsyncDisposable {
		internal Session(int id) : base(id) { }
		
	}
}
