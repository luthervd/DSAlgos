﻿namespace Sorting
{
    public  static partial class SortExtenstions
    {
        public static void MergeSort<T>(this IList<T> items) where T : IComparable<T>
        {
            var aux = new T[items.Count()];
            SortInternal(items, 0, items.Count() - 1, aux);
        }

        private static void SortInternal<T>(IList<T>? toSort, int lo, int hi, T[] aux)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            SortInternal(toSort, lo, mid, aux); 
            SortInternal(toSort, mid + 1, hi, aux);
            Merge(toSort ?? new List<T>(), lo, mid, hi, aux);
        }

        private static void Merge<T>(IList<T> toMerge, int lo, int mid, int hi, T[] aux)
        {
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) // Copy a[lo..hi] to aux[lo..hi].
            {
                aux[k] = toMerge[k];
            }
            for (int k = lo; k <= hi; k++)// Merge back to a[lo..hi].
            {
                if (i > mid)
                {
                    toMerge[k] = aux[j++];
                }
                else if (j > hi) 
                { 
                    toMerge[k] = aux[i++]; 
                }
                else
                {
                    var left = aux[j] as IComparable<T>;
                    var right = aux[i];
                    if (left?.CompareTo(right) < 0)
                    {
                        toMerge[k] = aux[j++];
                    }
                    else
                    {
                        toMerge[k] = aux[i++];
                    }
                }
            } 
                
        }
    }
}