using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class Collection<T> : IReadOnlyCollection<T>
    {
        private const int DefaultCount = 4;
        private T[] _array;
        private int _capacity;
        public Collection(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
        }

        public Collection()
            : this(DefaultCount)
        {
        }

        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (!ValidateCapacity(value))
                {
                    return;
                }

                _capacity = value;
            }
        }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                var isSuccess = CreateNewArray();
                if (!isSuccess)
                {
                    return;
                }
            }

            AddItem(item);
        }

        public void AddRange(IReadOnlyCollection<T> array)
        {
            var capacity = Count + array.Count;

            if (capacity >= Capacity)
            {
                var isSuccess = CreateNewArray(capacity);
                if (!isSuccess)
                {
                    return;
                }
            }

            foreach (T item in array)
            {
                AddItem(item);
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            var lastIndext = Count - 1;

            for (var i = index; i < lastIndext; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[lastIndext] = default(T);
            Count--;

            return true;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    var isSuccess = RemoveAt(i);
                    if (!isSuccess)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private bool ValidateCapacity(int capacity)
        {
            return capacity > Count;
        }

        private void AddItem(T item)
        {
            _array[Count] = item;
            Count++;
        }

        private bool CreateNewArray(int? capacity = null)
        {
            var tempArray = _array;
            if (capacity == null)
            {
                _capacity = _capacity * 2;
            }
            else
            {
                var isValidCapacity = ValidateCapacity(capacity.Value);
                if (!isValidCapacity)
                {
                    return false;
                }

                _capacity = capacity.Value;
            }

            _array = new T[Capacity];

            for (var i = 0; i < tempArray.Length; i++)
            {
                _array[i] = tempArray[i];
            }

            return true;
        }

        private IEnumerator<T> GetGenericEnumerator()
        {
            foreach (var item in _array)
            {
                if (!item.Equals(default(T)))
                {
                    yield return item;
                }
            }
        }
    }
}
