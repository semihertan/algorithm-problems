using System;
using System.Collections.Generic;
using System.IO;

namespace Uygulama2
{
    internal class Program
    {
        static void Main()
        {
            List<Kuyruk> kuyruklar = new List<Kuyruk>();
            IkiliAramaAgaci agac = new IkiliAramaAgaci();
            string dosya = "sayilar.txt";

            try
            {
                using (StreamReader sr = new StreamReader(dosya))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        Kuyruk kuyruk = new Kuyruk();

                        foreach (char karakter in satir) //satırdaki karakterleri tek tek kuyruğa eleman olarak ekleme
                        {
                            if (char.IsDigit(karakter))
                            {
                                kuyruk.Insert(int.Parse(karakter.ToString()));
                            }
                        }
                        kuyruklar.Add(kuyruk);
                    }
                }

                foreach (var kuyruk in kuyruklar)
                {
                    int toplam = kuyruk.Topla();
                    agac.Ekle(toplam);
                }

                Console.WriteLine("InOrder gezinti:");
                agac.InOrder();
                Console.WriteLine("\n");

                Console.WriteLine("PreOrder gezinti:");
                agac.PreOrder();
                Console.WriteLine("\n");

                Console.WriteLine("PostOrder gezinti:");
                agac.PostOrder();
                Console.WriteLine("\n");

                Console.WriteLine("KUYRUKLAR");
                for (int i = 0; i < kuyruklar.Count; i++)
                {
                    while (!kuyruklar[i].IsEmpty())
                    {
                        Console.Write(kuyruklar[i].Remove() + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("DOSYA BULUNAMADI!!" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("OKUMA SIRASINDA HATA!!" + e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("PROGRAMDAN ÇIKIŞ YAPMAK İÇİN BİR TUŞA BASIN");
            Console.ReadKey();
        }
    }
}