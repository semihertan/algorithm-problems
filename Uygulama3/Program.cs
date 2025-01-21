using System;
using System.IO;
using static Uygulama3.Heap;

namespace Uygulama3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sayilar_dosya = "sayilar.txt";
            string sirali_dosya = "sirali.txt";

            Heap heap = new Heap(10);
            Sayi sayiIslem = new Sayi();

            heap = sayiIslem.DosyaOku(sayilar_dosya, heap);
            sayiIslem.DosyaYaz(sirali_dosya, heap);

            Console.WriteLine();
            Console.WriteLine("PROGRAMDAN ÇIKIŞ YAPMAK İÇİN BİR TUŞA BASIN...");
            Console.ReadKey();
        }
    }
}
