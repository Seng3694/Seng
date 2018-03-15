using System;

namespace Seng.Core
{
    /// <summary>
    /// A container which stores boolean values at an given index. 32 boolean values can be stored in one unsigned integer. Setting the 33th flag will expand the backing list. It is advised to set them from zero and upwards to save memory.
    /// </summary>
    public sealed class BoolStorage
    {
        private uint[] _storage;

        public BoolStorage(string bitString)
        {
            _storage = new uint[1];

            for (int i = 0; i < bitString.Length; i++)
                SetBool(i, bitString[i] == '1' ? true : false);
        }

        public BoolStorage()
        {
            _storage = new uint[1];
        }

        public void SetBool(int id, bool value)
        {
            if (id < 0)
                throw new ArgumentException("Value have to be larger than zero.");

            var arrIndex = id / 32;
            var bitValue = 1u << (id % 32);

            if (_storage.Length - 1 < arrIndex)
                Array.Resize(ref _storage, arrIndex + 1);

            if (value) //if newValue true
            {
                _storage[arrIndex] = _storage[arrIndex] == 0 ? bitValue : _storage[arrIndex] | bitValue;
            }
            else if (GetBool(arrIndex, bitValue)) //if newValue is false and the currentValue is true
            {
                _storage[arrIndex] = _storage[arrIndex] == 0 ? 0 : _storage[arrIndex] ^ bitValue;
            }
        }

        public bool GetBool(int id)
        {
            if (id < 0)
                return false;

            var arrIndex = id / 32;
            var bitValue = 1u << (id % 32);

            return GetBool(arrIndex, bitValue);
        }

        private bool GetBool(int arrIndex, uint bitValue)
        {
            if (_storage.Length - 1 >= arrIndex && _storage[arrIndex] != 0)
                return (_storage[arrIndex] & bitValue) == bitValue;

            return false;
        }
    }
}
