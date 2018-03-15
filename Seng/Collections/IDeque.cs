using System;
using System.Collections.Generic;

namespace Seng.Collections
{
    public interface IDeque<T> : IEnumerable<T>, IDisposable
    {
        void PushBack(T item);
        void PushFront(T item);
        T PopBack();
        T PopFront();
        T PeekBack();
        T PeekFront();
        void TrimExcess();
        void Clear();
    }
}
