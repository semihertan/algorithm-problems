using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephusProblemi
{
    public class Node
    {
        public string color;
        public Node next;

        public Node(string color)
        {
            this.color = color;
            next = null;
        }
    }

    public class DaireselBagliListe
    {
        public Node head;

        public DaireselBagliListe()
        {
            head = null;
        }

        public void Ekle(string color)
        {
            Node newNode = new Node(color);
            if (head == null)
            {
                head = newNode;
                head.next = head;
            }
            else
            {
                Node temp = head;
                while (temp.next != head)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
                newNode.next = head;
            }
        }

        public Node Sil(Node curr, out string removedColor)
        {
            // Eğer liste boşsa
            if (head == null)
            {
                removedColor = null;
                return null;
            }

            // Eğer listede sadece bir düğüm varsa
            if (head.next == head)
            {
                removedColor = head.color;
                head = null; // Listeyi tamamen boşalt
                return null;
            }

            // Diğer durumlarda düğümü sil
            Node temp = head;

            // Silinecek düğüm `head` ise
            if (curr == head)
            {
                // Son düğümü bul
                while (temp.next != head)
                {
                    temp = temp.next;
                }

                // Head'i güncelle
                temp.next = head.next;
                removedColor = head.color;
                head = head.next;
                return head;
            }

            // Eğer silinecek düğüm head değilse
            Node prev = null;
            while (temp != curr)
            {
                prev = temp;
                temp = temp.next;

                // Eğer düğüm bulunamazsa döngüden çık
                if (temp == head) break;
            }

            // Düğüm bulunduysa
            if (temp == curr)
            {
                removedColor = temp.color;
                prev.next = temp.next;
                return temp.next;
            }

            // Eğer düğüm bulunamadıysa
            removedColor = null;
            return null;
        }

        public void Yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("liste boş\n");
                return;
            }
            Node temp = head;
            do
            {
                Console.Write(temp.color + " ");
                temp = temp.next;
            } while (temp != head);

            Console.WriteLine();
        }
    }

}
