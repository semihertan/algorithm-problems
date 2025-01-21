using System;
using static Uygulama3.Heap;

namespace Uygulama3
{
    public interface IHeap
    {
        bool Insert(int value);
        bool IsEmpty();
        void PrintHeap();
        void ToArray();
        HeapDugumu RemoveMin();
    }
}
