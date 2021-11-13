using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingShop
{

	public class Program
	{
		static bool mainMenu = true;
		public static List<HasilPrint> ListObject = new List<HasilPrint>();

		public static void Main()
		{
			List<int> listHarga = new List<int>();
			Console.WriteLine("Program Jonathan Sunaryo");
			
		
			while (mainMenu == true)
			{
				Console.WriteLine("Aplikasi Pembayaran Toko Percetakan Printing");
				Console.WriteLine("Pilih menu percetakan yang ingin digunakan dengan menginput kode angka");
				Console.WriteLine("1.Print hitam putih");
				Console.WriteLine("2.Print warna");
				Console.WriteLine("3.Print foto");
				Console.WriteLine("4.Jilid Karton");
				Console.WriteLine("5.Hapus list pembayaran");
				Console.WriteLine("6.Checkout");
				Console.WriteLine("");
				int swc;
				swc = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("");
				switch (swc)
				{
					case 1:
						listHarga.Add(BayarTidakWarna());
						break;
					case 2:
						listHarga.Add(BayarWarma());
						break;
					case 3:
						listHarga.Add(BayarFoto());
						break;
					case 4:
						listHarga.Add(5000);
						break;
					case 5:
						Console.WriteLine("Input index list yang ingin dihapus");
						int remov = Convert.ToInt32(Console.ReadLine());
						try
						{
							listHarga.RemoveAt(remov);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
						break;
					default:
						Console.WriteLine("Salah input ulangi lagi");
						break;
				}
				int total = 0;
				foreach (int x in listHarga)
				{

					Console.Write("Rp");
					Console.WriteLine(x);
					total += x;
				}
				Console.WriteLine("");
				Console.WriteLine("Harga total ");
				Console.Write("Rp");
				Console.WriteLine(total);
				Console.WriteLine("");
			}
		}

		public static int BayarTidakWarna()
		{
			Console.WriteLine("Menghitung pembayaran print halaman tidak berwarna");
			int jenis = 1;
			int retur = 0;
			int ukuran = 0;
			Console.WriteLine("Masukkan kode menu ukuran halaman ");
			Console.WriteLine("1.Print ukuran A3 @Rp" + HargaPrint.tidakWarnaA3);
			Console.WriteLine("2.Print ukuran A4 @Rp" + HargaPrint.tidakWarnaA4);
			do
			{
				ukuran = Convert.ToInt32(Console.ReadLine());
				if (ukuran != 1 && ukuran != 2)
					Console.WriteLine("Salah input ulangi lagi");

			} while (ukuran != 1 && ukuran != 2);
			Console.WriteLine("Masukkan jumlah halaman ");
			int halaman = Convert.ToInt32(Console.ReadLine());

			HasilPrint myHasil = new HasilPrint(jenis, ukuran, halaman);
			ListObject.Add(myHasil);

			Console.Write("Harga print adalah Rp");

			switch (ukuran)
			{
				case 1:
					Console.WriteLine(myHasil.HargaTidakWarnaA3(myHasil.halaman, HargaPrint.tidakWarnaA3));
					retur = myHasil.HargaTidakWarnaA3(myHasil.halaman, HargaPrint.tidakWarnaA3);
					break;
				case 2:
					Console.WriteLine(myHasil.HargaTidakWarnaA4(myHasil.halaman, HargaPrint.tidakWarnaA4));
					retur = myHasil.HargaTidakWarnaA4(myHasil.halaman, HargaPrint.tidakWarnaA4);
					break;
				default:
					Console.WriteLine("Error salah input");
					break;
			}

			Console.WriteLine("");
			Console.WriteLine("List Harga");

			return retur;
		}

		static int BayarWarma()
		{
			Console.WriteLine("Menghitung pembayaran print halaman berwarna");
			int jenis = 1;
			int retur = 0;
			int ukuran = 0;
			Console.WriteLine("Masukkan kode menu ukuran halaman ");
			Console.WriteLine("1.Print ukuran A3 @Rp" + HargaPrint.warnaA3);
			Console.WriteLine("2.Print ukuran A4 @Rp" + HargaPrint.warnaA4);
			do
			{
				ukuran = Convert.ToInt32(Console.ReadLine());
				if (ukuran != 1 && ukuran != 2)
					Console.WriteLine("Salah input ulangi lagi");

			} while (ukuran != 1 && ukuran != 2);
			Console.WriteLine("Masukkan jumlah halaman ");
			int halaman = Convert.ToInt32(Console.ReadLine());
			HasilPrint myHasil = new HasilPrint(jenis, ukuran, halaman);
			ListObject.Add(myHasil);
			Console.Write("Harga print adalah Rp");

			switch (ukuran)
			{
				case 1:
					Console.WriteLine(myHasil.HargaWarnaA3(myHasil.halaman, HargaPrint.warnaA3));
					retur = myHasil.HargaWarnaA3(myHasil.halaman, HargaPrint.warnaA3);
					break;
				case 2:
					Console.WriteLine(myHasil.HargaWarnaA4(myHasil.halaman, HargaPrint.warnaA4));
					retur = myHasil.HargaWarnaA4(myHasil.halaman, HargaPrint.warnaA4);
					break;
				default:
					Console.WriteLine("Error salah input");
					break;
			}
			Console.WriteLine("");
			Console.WriteLine("List Harga");

			return retur;
		}

		static int BayarFoto()
		{
			Console.WriteLine("Menghitung pembayaran print halaman berwarna");
			int jenis = 1;
			int retur = 0;
			int ukuran = 0;
			Console.WriteLine("Masukkan kode menu ukuran foto yang ingin di print ");
			Console.WriteLine("1.Print ukuran 3x4 per halaman Rp" + HargaPrint.hargaFoto + " dapat 32 lembar");
			Console.WriteLine("2.Print ukuran 4x6 per halaman Rp" + HargaPrint.hargaFoto + " dapat 18 lembar");
			do
			{
				ukuran = Convert.ToInt32(Console.ReadLine());
				if (ukuran != 1 && ukuran != 2)
					Console.WriteLine("Salah input ulangi lagi");
			} while (ukuran != 1 && ukuran != 2);
			Console.WriteLine("Masukkan jumlah lembar yang dibutuhkan ");
			int halaman = Convert.ToInt32(Console.ReadLine());
			HasilPrint myHasil = new HasilPrint(jenis, ukuran, halaman);
			ListObject.Add(myHasil);
			Console.Write("Harga print adalah Rp");

			Console.WriteLine(myHasil.HargaWarnaA4(myHasil.halaman, myHasil.ukuran, HargaPrint.hargaFoto));
			retur = myHasil.HargaWarnaA4(myHasil.halaman, myHasil.ukuran);

			Console.WriteLine("");
			Console.WriteLine("List Harga");

			return retur;
		}


	}





}
