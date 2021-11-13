using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingShop
{
	//ABSTRACTION
	public abstract class AbstractHasil
	{
		public abstract int HargaTidakWarnaA3(int halaman, int hargaPerLembar);
		public abstract int HargaTidakWarnaA4(int halaman, int hargaPerLembar);
		public abstract int HargaWarnaA3(int halaman, int hargaPerLembar);
		public abstract int HargaWarnaA4(int halaman, int hargaPerLembar);
		//OVERLOAD
		public abstract int HargaWarnaA4(int butuh, int ukuran, int hargaPerLembar);
	}
}
