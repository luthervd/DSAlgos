using System;
using System.Security.AccessControl;

namespace Sorting
{
    public static class QuickSortDef
    {
        public static void QuickSort<T>(this IList<T> target) where T : IComparable<T>
        {
           Sort(target, 0, target.Count - 1);
        }

        public static void QuickSort<T>(this IList<T> target, Action<IList<T>>? onChange = null) where T : IComparable<T>
        {
            Sort(target, 0, target.Count - 1, onChange);
        }

        private static void Sort<T>(IList<T> target, int left, int right, Action<IList<T>>? onChange = null) where T : IComparable<T>
        {
            do
            {
                int i = left;
                int j = right;
                var pivot = target[i + ((j - i)/2)];
                do
                {
                    while (i < target.Count && pivot.CompareTo(target[i]) > 0) i++;
                    while (j > 0 && pivot.CompareTo(target[j]) < 0) j--;
                    if (i > j) break;
                    if(i < j)
                    {
                        var temp = target[i];
                        target[i] = target[j];
                        target[j] = temp;
                        if (onChange != null)
                        {
                            onChange.Invoke(target);
                        }
                    }
                    i++;
                    j--;
                } while (i <= j);
                if(j - left <= right - i)
                {
                    if (left < j) Sort(target, left, j, onChange);
                    left = i;
                }
                else
                {
                    if(i < right) Sort(target, i, right, onChange);
                    right = j;
                }
            } while (left < right);
            
        }
    }
}
