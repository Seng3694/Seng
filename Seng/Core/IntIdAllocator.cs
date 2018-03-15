using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Core
{
    public class IntIdAllocator
    {
        private int _currentID;
        private Queue<int> _reallocationQueue;

        public int MaxID
        {
            get { return _currentID - 1; }
        }

        public IntIdAllocator()
        {
            _currentID = 0;
            _reallocationQueue = new Queue<int>();
        }

        public int GetID()
        {
            if (_reallocationQueue.Count > 0)
                return _reallocationQueue.Dequeue();
            return _currentID++;
        }

        public void RemoveID(int id)
        {
            _reallocationQueue.Enqueue(id);
        }

        public void Reset()
        {
            _currentID = 0;
            _reallocationQueue = new Queue<int>();
        }
    }
}
