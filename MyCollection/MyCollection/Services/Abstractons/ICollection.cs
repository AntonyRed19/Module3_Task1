using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Services.Abstractons
{
    public interface ICollection
    {
        public void Sort();
        public void RemoveAt();
        public void Remove();
        public void Add();
        public void AddRange();
    }
}
