using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
				string swc;
				swc = Console.ReadLine();
				Console.Clear();
				
				switch (swc)
				{
					case "1":
						BayarTidakWarna();
						break;
					case "2":
						BayarWarna();
						break;
					case "3":
						BayarFoto();
						break;
					case "4":
						BayarJilid();
						break;
					case "5":
						Console.WriteLine("Input nomor list yang ingin dihapus");
						int remov = Convert.ToInt32(Console.ReadLine());
						try
						{
							ListObject.RemoveAt(remov-1);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
						break;
					case "6":
						Console.WriteLine("==========================");
						Console.WriteLine("Melakukan Checkout");
						Console.WriteLine("Terimakasih telah berbelanja");
						
						Console.ReadKey();
						System.Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Salah input ulangi lagi");
						break;
				}
				int total = 0;
				
				for (int i = 0; i < ListObject.Count; i++)
				{
					
					Console.WriteLine((i+1)+". "+ ListObject[i].namaPesanan);
					if (ListObject[i].kodePesanan == 1 || ListObject[i].kodePesanan == 2 || ListObject[i].kodePesanan == 3 || ListObject[i].kodePesanan == 4)
					{
						Console.WriteLine("Jumlah Halaman = " + ListObject[i].halaman);
					}
					if (ListObject[i].kodePesanan==5 || ListObject[i].kodePesanan == 6 )
                    {
                        Console.WriteLine("Jumlah Foto = "+ListObject[i].jumlahFoto);
                    }
					Console.WriteLine(" HARGA:Rp" + ListObject[i].harga);
					total += ListObject[i].harga;
				}

				Console.WriteLine("HARGA TOTAL:Rp" + total);
				Console.WriteLine("");
			}
		}

		public static bool IsNumeric(string input)
		{
			return Regex.IsMatch(input, @"^\d+$");
		}

		public static void BayarJilid()
		{
			HasilPrint myHasil = new HasilPrint(0, 0, 0);
			myHasil.HargaJilid();
			ListObject.Add(myHasil);
		}

		public static int BayarTidakWarna()
		{
			Console.WriteLine("Menghitung pembayaran print halaman tidak berwarna");
			int jenis = 1;
			int retur = 0;
			
			Console.WriteLine("Masukkan kode menu ukuran halaman ");
			Console.WriteLine("1.Print ukuran A3 @Rp" + HargaPrint.tidakWarnaA3);
			Console.WriteLine("2.Print ukuran A4 @Rp" + HargaPrint.tidakWarnaA4);
			
			int ukuran = InputUkuran();
			int halaman = InputHalaman();

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

			ClearScreen();
			Console.WriteLine("List Harga");

			return retur;
		}

		static int BayarWarna()
		{
			Console.WriteLine("Menghitung pembayaran print halaman berwarna");
			int jenis = 1;
			int retur = 0;
			
			Console.WriteLine("Masukkan kode menu ukuran halaman ");
			Console.WriteLine("1.Print ukuran A3 @Rp" + HargaPrint.warnaA3);
			Console.WriteLine("2.Print ukuran A4 @Rp" + HargaPrint.warnaA4);
			
			int ukuran = InputUkuran();
			int halaman = InputHalaman();

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

			ClearScreen();
			
			Console.WriteLine("List Harga");

			return retur;
		}

		public static void ClearScreen()
        {
			Console.WriteLine("");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		static int BayarFoto()
		{
			Console.WriteLine("Menghitung pembayaran print halaman berwarna");
			int jenis = 1;
			int retur = 0;
			
			Console.WriteLine("Masukkan kode menu ukuran foto yang ingin di print ");
			Console.WriteLine("1.Print ukuran 3x4 per halaman Rp" + HargaPrint.hargaFoto + " dapat 32 lembar");
			Console.WriteLine("2.Print ukuran 4x6 per halaman Rp" + HargaPrint.hargaFoto + " dapat 18 lembar");

			int ukuran = InputUkuran();
			int halaman = InputFoto();
			HasilPrint myHasil = new HasilPrint(jenis, ukuran, halaman);
			ListObject.Add(myHasil);
			Console.Write("Harga print adalah Rp");
			Console.WriteLine(myHasil.HargaWarnaA4(myHasil.halaman, myHasil.ukuran, HargaPrint.hargaFoto));
			retur = myHasil.HargaWarnaA4(myHasil.halaman, myHasil.ukuran ,HargaPrint.hargaFoto);
			ClearScreen();
			Console.WriteLine("List Harga");
			return retur;
		}

		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}

		static int InputUkuran()
		{
			string ukuranString;
			do
			{
				ukuranString = Console.ReadLine();
				if (ukuranString != "1" && ukuranString != "2")
				{
					Console.WriteLine("Salah input");
					Console.SetCursorPosition(0, Console.CursorTop - 2);
					ClearCurrentConsoleLine();
				}
			} while (ukuranString != "1" && ukuranString != "2");
			return Convert.ToInt32(ukuranString);
		}
		static int InputHalaman()
		{
			string halamanString;
			Console.WriteLine("Masukkan jumlah halaman ");
			do
			{
				halamanString = Console.ReadLine();
				if (!IsNumeric(halamanString))
				{
					Console.WriteLine("Salah input");
					Console.SetCursorPosition(0, Console.CursorTop - 2);
					ClearCurrentConsoleLine();
				}
			} while (!IsNumeric(halamanString));
			return Convert.ToInt32(halamanString);
		}

		static int InputFoto()
		{
			string halamanString;
			Console.WriteLine("Masukkan jumlah lembar foto yang dibutuhkan ");
			do
			{
				halamanString = Console.ReadLine();
				if (!IsNumeric(halamanString))
				{
					Console.WriteLine("Salah input");
					Console.SetCursorPosition(0, Console.CursorTop - 2);
					ClearCurrentConsoleLine();
				}
			} while (!IsNumeric(halamanString));
			return Convert.ToInt32(halamanString);
		}

	}





}
