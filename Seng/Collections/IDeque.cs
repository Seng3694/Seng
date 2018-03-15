using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
