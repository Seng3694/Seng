using System.Collections.Generic;

namespace Seng.Core
{
    public class UintIdAllocator
    {
        private uint _currentID;
        private Queue<uint> _reallocationQueue;

        public uint MaxID
        {
            get { return _currentID - 1; }
        }

        public UintIdAllocator()
        {
            _currentID = 0;
            _reallocationQueue = new Queue<uint>();
        }

        public uint GetID()
        {
            if (_reallocationQueue.Count > 0)
                return _reallocationQueue.Dequeue();
            return _currentID++;
        }

        public void RemoveID(uint id)
        {
            _reallocationQueue.Enqueue(id);
        }

        public void Reset()
        {
            _currentID = 0;
            _reallocationQueue = new Queue<uint>();
        }
    }
}
