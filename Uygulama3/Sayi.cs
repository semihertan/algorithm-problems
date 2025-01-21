using System;
using System.IO;
using static Uygulama3.Heap;

namespace Uygulama3
{
    public class Sayi
    {
        public Heap DosyaOku(string dosya, Heap heap)
        {
            try
            {
                using (StreamReader sr = new StreamReader(dosya))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(satir, out int sayi))
                        {
                            heap.Insert(sayi);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Dosya bulunamadı: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bir hata oluştu: " + e.Message);
            }
            return heap;
        }
        public void DosyaYaz(string dosya, Heap heap)
        {
            try
            {
                int[] heapArray = heap.ToArray();
                HeapSort sorter = new HeapSort(heapArray);
                int[] sortedArray = sorter.Sort();

                using (StreamWriter sw = new StreamWriter(dosya))
                {
                    foreach (int number in sortedArray)
                    {
                        sw.WriteLine(number);
                    }
                }
                Console.WriteLine("Sıralı dizi dosyaya yazıldı");
                Console.WriteLine("Heap'teki en büyük eleman: " + sortedArray[sortedArray.Length - 1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("hata oluştu" + e.Message);
            }
        }
    }
}
