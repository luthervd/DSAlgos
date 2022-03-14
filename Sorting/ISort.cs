using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface ISort<T> where T : IComparable<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> items);

    }
}
