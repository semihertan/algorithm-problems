using System;

public class Kuyruk
{
    private class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    private Node front;
    private Node rear;

    public Kuyruk()
    {
        front = null;
        rear = null;
    }
    public void Insert(int data)
    {
        Node yeni_dugum = new Node(data);
        if (rear == null)
        {
            front = yeni_dugum;
            rear = yeni_dugum;
        }
        else
        {
            rear.next = yeni_dugum;
            rear = yeni_dugum;
        }
    }
    public int Remove()
    {
        if (front == null)
            throw new Exception("Stack boş");

        int data = front.data;
        front = front.next;

        if (front == null)
            rear = null;

        return data;
    }
    public bool IsEmpty()
    {
        return front == null;
    }
    public int Topla()
    {
        int toplam = 0;
        Node curr = front;

        while (curr != null)
        {
            toplam += curr.data;
            curr = curr.next;
        }
        return toplam;
    }
}