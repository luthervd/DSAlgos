namespace Sorting
{
    public static class QuickSortDef
    {
        public static void QuickSort<T>(this IList<T> target) where T : IComparable<T>
        {
           SimpleShuffle(target);
           Sort(target, 0, target.Count - 1);
        }

        private static void SimpleShuffle<T>(IList<T> target) where T : IComparable<T>
        {
            var oldLast = target.Count - 1;
            var oldMid = (target.Count - 1 )/ 2;
            var first = target[0];
            var mid = target[oldMid];
            var last = target[oldLast];
            target[0] = last;
            target[(target.Count - 1) / 2] = first;
            target[target.Count - 1] = mid;
        }

        private static void Sort<T>(IList<T> target, int low, int high) where T : IComparable<T>
        {
            if (high <= low) return;
            var k = Partition(target, low, high);
            Sort(target, low, k - 1);
            Sort(target, k + 1, high);
        
        }
        private static int Partition<T>(IList<T> target, int low, int high) where T : IComparable<T>
        {
            int i = low, j = high + 1;
            var pivot = target[low];
            while(true)
            {
                while (target[++i].CompareTo(pivot) < 0)
                {
                    if (i == high) break;
                }
                while (pivot.CompareTo(target[--j]) < 0)
                {
                    if (j == low) break;
                }
                if (i >= j) break;
                Swap(target, i, j);
            }
            Swap(target,low, j);
            return i;

        }

        private static void Swap<T>(IList<T> target, int left, int right)
        {
            var original = target[right];
            target[right] = target[left];
            target[left] = original;
        }
    }
}
