using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingShop
{
	//INHERITANCE
	public class HasilPrint : AbstractHasil
	{
		//POLIMORPHISM
		//OVERRIDE
		public override int HargaTidakWarnaA3(int halaman, int hargaPerLembar)
		{
			int harga = halaman * hargaPerLembar;
			this.harga = harga;
			this.kodePesanan = 1;
			this.namaPesanan = "Print Tidak Warna A3";
			return harga;
		}
		public override int HargaTidakWarnaA4(int halaman, int hargaPerLembar)
		{
			int harga = halaman * hargaPerLembar;
			this.harga = harga;
			this.kodePesanan = 2;
			this.namaPesanan = "Print Tidak Warna A4";
			return harga;
		}
		public override int HargaWarnaA3(int halaman, int hargaPerLembar)
		{
			int harga = halaman * hargaPerLembar;
			this.harga = harga;
			this.kodePesanan = 3;
			this.namaPesanan = "Print Warna A3";
			return harga;
		}
		public override int HargaWarnaA4(int halaman, int hargaPerLembar)
		{
			int harga = halaman * hargaPerLembar;
			this.harga = harga;
			this.kodePesanan = 4;
			this.namaPesanan = "Print Warna A4";
			return harga;
		}
		public int HargaJilid ()
        {
		
			this.kodePesanan = 0;
			this.namaPesanan = "Jilid";
			this.harga=HargaPrint.hargaJilid;
			return harga;
        }
		//OVERLOAD
		//HITUNG HARGA PRINT FOTO
		public override int HargaWarnaA4(int butuh, int ukuran, int hargaPerLembar)
		{
			int harga = 0;
			int lembar = 0;
			switch (ukuran)
			{
				case 1:
					lembar = butuh / 32;
					harga = lembar * hargaPerLembar;
					harga += hargaPerLembar;
					if (butuh % 32 == 0)
					{
						harga -= hargaPerLembar;
					}
					this.harga = harga;
					this.jumlahFoto = 32 * harga / hargaPerLembar;
					this.kodePesanan = 5;
					this.namaPesanan = "Print Foto 3x4";
					return harga;

				case 2:
					lembar = butuh / 18;
					harga = lembar * hargaPerLembar;
					harga += hargaPerLembar;
					if (butuh % 18 == 0)
					{
						harga -= hargaPerLembar;
					}
					this.harga = harga;
					this.jumlahFoto = 18 * harga / hargaPerLembar;
					this.kodePesanan = 6;
					this.namaPesanan = "Print Foto 4x6";
					return harga;

				default:
					this.harga = harga;
					return harga;
			}
		}

		//ACCESS MODIFIER & ENCAPSULATION
		public int kodePesanan { get; set; }
		public int jenis { get; set; }
		public int ukuran { get; set; }
		public string namaPesanan { get; set; }
		public int halaman { get; set; }
		public int harga { get; set; }
		public int jumlahFoto { get; set; }

		//CONSTRUCTOR
		public HasilPrint(int jenis, int ukuran, int halaman)
		{
			this.jenis = jenis;
			this.ukuran = ukuran;
			this.halaman = halaman;
			this.kodePesanan = 0;
		}
	}
}
