using System;
using System.Diagnostics;

namespace JosephusProblemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack balonStack = new Stack();

            int m = 500;
            for (int i = 0; i < m; i++) // m = kat sayısı
            {
                DaireselBagliListe level = balonStack.CreateLevel(10); // Her kat 10 balon içeriyor
                balonStack.Push(level);
                Console.WriteLine();
            }

            Console.WriteLine("Balon yığını oluşturuldu.");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = 2; // n = kaçıncı sıradaki balon patlatılacak
            balonStack.ProcessStack(balonStack, n);

            Console.WriteLine("Tüm balonlar patlatıldı!\n");

            double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;

            double averageSpeed = m / elapsedTimeInSeconds;
            Console.WriteLine($"Ortalama hız: {averageSpeed} balon problemi / saniye cinsinden");
        }
    }
}
