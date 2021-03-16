using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class CollectionEnumerator : IEnumerator<int>
    {
        private int[] _numbers;
        private int _position = -1;
        public CollectionEnumerator(int[] numbers)
        {
            _numbers = numbers;
        }

        public int Current
        {
            get
            {
                if (_position == -1 || _position >= _numbers.Length)
                {
                    throw new InvalidOperationException();
                }

                return _numbers[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_position < _numbers.Length - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
