using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
   public class Collection : IEnumerable
    {
        private readonly CollectionEnumerator _enumerator;
        private int[] _numbers = { 1, 2, 3, 4 };
        public Collection(int[] numbers)
        {
            numbers = _numbers;
        }

        public IEnumerator GetEnumerator()
        {
            return new CollectionEnumerator(_numbers);
        }
    }
}
