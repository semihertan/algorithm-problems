using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephusProblemi
{
    public class StackNode
    {
        public DaireselBagliListe level;
        public StackNode next;

        public StackNode(DaireselBagliListe level)
        {
            this.level = level;
            next = null;
        }
    }

    public class Stack
    {
        private StackNode top;

        public Stack()
        {
            top = null;
        }

        public void Push(DaireselBagliListe level)
        {
            StackNode newNode = new StackNode(level);
            newNode.next = top;
            top = newNode;
        }

        public DaireselBagliListe Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("stack boş");

            DaireselBagliListe level = top.level;
            top = top.next;
            return level;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public DaireselBagliListe Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("stack boş");

            return top.level;
        }

        private static Random random = new Random();
        public DaireselBagliListe CreateLevel(int balloonCount)
        {
            DaireselBagliListe level = new DaireselBagliListe();
            string[] colors = { "Kırmızı", "Mavi", "Yeşil", "Sarı", "Mor", "Turuncu" };

            for (int i = 0; i < balloonCount; i++)
            {
                level.Ekle(colors[random.Next(colors.Length)]);
            }

            level.Yazdir();
            return level;
        }

        public void ProcessStack(Stack stack, int n)
        {
            int levelNumber = 1; // Hangi katta olduğumuzu tutar

            while (!stack.IsEmpty())
            {
                DaireselBagliListe currentLevel = stack.Peek();
                Node current = currentLevel.head;
                int step = 1;

                while (currentLevel.head != null)
                {
                    // n. düğüme ulaş
                    for (int i = 1; i < n; i++)
                    {
                        current = current.next;
                    }

                    // Balonu patlat
                    string removedColor;
                    current = currentLevel.Sil(current, out removedColor);

                    // İşlemi ekrana yazdır
                    Console.WriteLine($"Kat {levelNumber}, Tur {step}: Patlatılan balon -> {removedColor}");
                    Console.Write("Kalan balonlar: ");
                    currentLevel.Yazdir();

                    step++;
                }

                // Kat tamamen boşaldıysa bir alt kata geç
                stack.Pop();
                levelNumber++;
            }
        }
    }
}
