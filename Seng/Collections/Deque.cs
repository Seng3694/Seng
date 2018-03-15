using System;
using System.Collections;
using System.Collections.Generic;

namespace Seng.Collections
{
    /// <summary>
    /// Represents a double-ended queue. Combines the functionality of a stack and a queue.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the deque.</typeparam>
    public class Deque<T> : IDeque<T>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float RESIZE_FACTOR = 2;

        private T[] _array;
        private Enumerator _enumerator;

        private int _head;
        private int _tail;

        private int _count;

        /// <summary>
        /// Gets the number of elements contained in the Seng.Collections.Deque`1.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get { return _array.Length; }
        }

        /// <summary>
        /// Initializes a new instance of the Seng.Collections.Deque`1 class that is empty and has the default initial capacity.
        /// </summary>
        public Deque()
            : this(DEFAULT_CAPACITY)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Seng.Collections.Deque`1 class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new deque can initially store</param>
        public Deque(uint capacity)
        {
            _array = new T[capacity == 0 ? DEFAULT_CAPACITY : capacity];
            _enumerator = new Enumerator(this);
        }

        /// <summary>
        /// Adds an object to the end of the Seng.Collections.Deque`1.
        /// </summary>
        /// <param name="item">The object to add to the Seng.Collections.Deque`1.</param>
        public void PushBack(T item)
        {
            EnsureCapacity(_count);
            _array[_tail] = item;

            _tail = (_tail + 1) % (_array.Length);

            _count++;
        }

        /// <summary>
        /// Adds an object to the front of the Seng.Collections.Deque`1.
        /// </summary>
        /// <param name="item">The object to add to the Seng.Collections.Deque`1.</param>
        public void PushFront(T item)
        {
            EnsureCapacity(_count);

            if (--_head < 0) _head = _array.Length - 1;

            _array[_head] = item;

            _count++;
        }

        /// <summary>
        /// Removes and returns the object at the back of the Seng.Collections.Deque`1.
        /// </summary>
        public T PopBack()
        {
            if (_count == 0) throw new IndexOutOfRangeException();
            if (--_tail < 0) _tail = _array.Length - 1;
            var v = _array[_tail];
            _count--;
            _array[_tail] = default(T);
            return v;
        }
        /// <summary>
        /// Removes and returns the object at the front of the Seng.Collections.Deque`1.
        /// </summary>
        public T PopFront()
        {
            if (_count == 0) throw new IndexOutOfRangeException();
            var v = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % (_array.Length);
            _count--;
            return v;
        }

        /// <summary>
        /// Returns the object at the back of the Seng.Collections.Deque`1 without removing it.
        /// </summary>
        public T PeekBack()
        {
            if (_count == 0) throw new IndexOutOfRangeException();
            return _array[_tail - 1];
        }

        /// <summary>
        /// Returns the object at the front of the Seng.Collections.Deque`1 without removing it.
        /// </summary>
        public T PeekFront()
        {
            if (_count == 0) throw new IndexOutOfRangeException();
            return _array[_head];
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the Seng.Collections.Deque`1.
        /// </summary>
        public void TrimExcess()
        {
            var newArr = new T[_count == 0 ? DEFAULT_CAPACITY : _count];

            if (_head >= _tail)
            {
                Array.Copy(_array, _head, newArr, 0, _array.Length - _head);
                Array.Copy(_array, 0, newArr, _array.Length - _head, _tail);
                _tail = _array.Length - _head + _tail;
                _head = 0;
                _array = newArr;
            }
            else
            {
                Array.Copy(_array, _head, newArr, 0, _tail - _head);
                _tail = _tail - _head;
                _head = 0;
                _array = newArr;
            }
        }

        /// <summary>
        /// Removes all objects from the Seng.Collections.Deque`1.
        /// </summary>
        public void Clear()
        {
            _array = new T[DEFAULT_CAPACITY];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Disposes all IDisposables and then clears the Seng.Collections.Deque`1.
        /// </summary>
        public void Dispose()
        {
            if (typeof(IDisposable).IsAssignableFrom(typeof(T)))
            {
                foreach (var item in this)
                {
                    (item as IDisposable).Dispose();
                }
            }

            Clear();
        }

        private void EnsureCapacity(int capacity)
        {
            while (capacity >= _array.Length)
            {
                Resize((int)(_array.Length * RESIZE_FACTOR));
            }
        }

        private void Resize(int size)
        {
            if (_head >= _tail)
            {
                var newArr = new T[size];
                Array.Copy(_array, _head, newArr, 0, _array.Length - _head);
                Array.Copy(_array, 0, newArr, _array.Length - _head, _tail);
                _tail = _array.Length - _head + _tail;
                _head = 0;
                _array = newArr;
            }
            else
            {
                Array.Resize(ref _array, size);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            _enumerator.Reset();
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            _enumerator.Reset();
            return _enumerator;
        }

        private struct Enumerator : IEnumerator<T>
        {
            private Deque<T> _deque;
            private int _index;

            public T Current { get { return _deque._array[_index]; } }
            object IEnumerator.Current { get { return _deque._array[_index]; } }

            public Enumerator(Deque<T> list)
            {
                _deque = list;
                _index = (_deque._head - 1) < 0 ? _deque._array.Length - 1 : _deque._head - 1;
            }

            public bool MoveNext()
            {
                if (_deque.Count == 0) return false;
                if (_index == _deque._tail - 1) return false;
                if (++_index > _deque._array.Length) _index = 0;
                return true;
            }

            public void Reset()
            {
                _index = (_deque._head - 1) < 0 ? _deque._array.Length - 1 : _deque._head - 1;
            }

            public void Dispose()
            {
                _index = (_deque._head - 1) < 0 ? _deque._array.Length - 1 : _deque._head - 1;
            }
        }
    }
}
