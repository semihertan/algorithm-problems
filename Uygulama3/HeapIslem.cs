using System;

namespace Uygulama3
{
    public class Heap
    {
        private int currSize = 0;
        private int maxSize = 0;
        private HeapDugumu[] heapArray;

        public Heap(int maxSize)
        {
            this.maxSize = maxSize;
            this.currSize = 0;
            heapArray = new HeapDugumu[maxSize];
        }

        public class HeapDugumu
        {
            public int value;
            public HeapDugumu(int value)
            {
                this.value = value;
            }
        }

        public bool Insert(int value)
        {
            if (currSize == maxSize)
                return false;

            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currSize] = newHeapDugumu;
            MoveToUp(currSize++);
            return true;
        }

        public HeapDugumu RemoveMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap boş!!");

            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currSize];
            MoveToDown(0);
            return root;
        }

        private void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];

            while (index > 0 && heapArray[parent].value > bottom.value)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }

        private void MoveToDown(int index)
        {
            int smallerChild;
            HeapDugumu top = heapArray[index];
            while (index < currSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currSize && heapArray[leftChild].value > heapArray[rightChild].value)
                {
                    smallerChild = rightChild;
                }
                else
                {
                    smallerChild = leftChild;
                }

                if (top.value <= heapArray[smallerChild].value)
                    break;

                heapArray[index] = heapArray[smallerChild];
                index = smallerChild;
            }
            heapArray[index] = top;
        }

        public bool IsEmpty()
        {
            return currSize == 0;
        }
        public void PrintHeap()
        {
            for (int i = 0; i < currSize; i++)
            {
                Console.Write(heapArray[i].value + " ");
            }
            Console.WriteLine();
        }

        public int[] ToArray()
        {
            int[] array = new int[currSize];
            for (int i = 0; i < currSize; i++)
            {
                array[i] = heapArray[i].value;
            }
            return array;
        }

        public class HeapSort
        {
            private int[] array;

            public HeapSort(int[] array)
            {
                this.array = array;
            }

            public int[] Sort()
            {
                Heap h = new Heap(array.Length);
                int[] sorted = new int[array.Length];

                foreach (var item in array)
                {
                    h.Insert(item);
                }

                int i = 0;
                while (!h.IsEmpty())
                {
                    sorted[i++] = h.RemoveMin().value;
                }

                return sorted;
            }
        }
    }
}
