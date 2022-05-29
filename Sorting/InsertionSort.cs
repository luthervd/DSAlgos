using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class InsertionSort
    {
        public static IEnumerable<T> InsertSort<T>(this IEnumerable<T> target) where T : IComparable<T>
        {
            var workable = target.ToArray();
            for(var i = 0; i < workable.Count(); i++)
            {
                for(var j = 0; j < i; j++)
                {
                    if(workable[j].CompareTo(workable[i]) > 0)
                    {
                        var moveUp = workable[j];
                        workable[j] = workable[i]; 
                        workable[i] = moveUp;
                    }
                }
            }
            return workable;
        }
    }
}
