using System;
using System.Collections;
using System.Collections.Generic;

namespace zad2
{
    public class GenericList<TX> : IGenericList<TX>
    {
        private TX[] _internalStorage;
        private int _size;
        private int _lastIndex;

        public GenericList()
        {
            _size = 4;
            _internalStorage = new TX[_size];
            _lastIndex = -1;
        }

        public GenericList(int initialSize)
        {
            _size = initialSize;
            _internalStorage = new TX[_size];
            _lastIndex = -1;
        }

        public void Add(TX item)
        {
            if (_lastIndex + 1 == _size)
            {
                TX[] hepler = _internalStorage;
                _internalStorage = new TX[_size * 2];
                _lastIndex = -1;

                foreach (TX element in hepler)
                {
                    if (element == null) break;
                    _lastIndex++;
                    _internalStorage[_lastIndex] = element;
                }
            }

            _lastIndex++;
            _internalStorage[_lastIndex] = item;
        }

        public bool Remove(TX item)
        {
            int i = -1;
            foreach (TX element in _internalStorage)
            {
                if (element == null) break;
                i++;
                if (element.Equals(item))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index + 1 >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            TX[] helper = _internalStorage;
            for (int i = index + 1; i < _size; i++)
            {
                _internalStorage[index] = helper[i];
                index++;
            }
            return true;
        }

        public TX GetElement(int index)
        {
            if (index < _size && index >= -1)
            {
                return _internalStorage[index];
            }
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(TX item)
        {
            int i = -1;
            foreach (TX element in _internalStorage)
            {
                if(element == null) break;
                i++;
                if (element.Equals(item)) return i;
            }
            return -1;
        }

        public int Count => _lastIndex + 1;

        public void Clear()
        {
            _internalStorage = new TX[_size];
            _lastIndex = -1;
        }

        public bool Contains(TX item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
        }

        public IEnumerator<TX> GetEnumerator()
        {
            return new GenericListEnumerator<TX>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
