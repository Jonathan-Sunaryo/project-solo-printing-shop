using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingShop
{
    static class HargaPrint
    {
        public static int tidakWarnaA3 { get; set; }
        public static int tidakWarnaA4 { get; set; }
        public static int warnaA3 { get; set; }
        public static int warnaA4 { get; set; }
        public static int hargaFoto { get; set; }

        static HargaPrint()
        {
            tidakWarnaA3 = 600;
            tidakWarnaA4 = 500;
            warnaA3 = 1200;
            warnaA4 = 1000;
            hargaFoto = 10000;
        }
    }
}
