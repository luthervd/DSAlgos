namespace Sorting
{
    public static class QuickSortDef
    {
        public static void QuickSort<T>(this IList<T> target) where T : IComparable<T>
        {
           Sort(target, 0, target.Count - 1);
        }

        public static void QuickSort<T>(this IList<T> target, Action<IList<T>> onChange) where T : IComparable<T>
        {
            Sort(target, 0, target.Count - 1, onChange);
        }

        private static void Sort<T>(IList<T> target, int low, int high, Action<IList<T>> onChange = null) where T : IComparable<T>
        {
            if (high <= low) return;
            var k = Partition(target, low, high, onChange);
            Sort(target, low, k - 1, onChange);
            Sort(target, k + 1, high, onChange);
        
        }
        private static int Partition<T>(IList<T> target, int low, int high, Action<IList<T>> onChange = null) where T : IComparable<T>
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
                Swap(target, i, j, onChange);
            }
            Swap(target,low, j, onChange);
            return j;
        }

        private static void Swap<T>(IList<T> target, int left, int right, Action<IList<T>> onChange = null)
        {
            var original = target[left];
            target[left] = target[right];
            if(onChange != null)
            {
                onChange.Invoke(target);
            }
            target[right] = original;
            if (onChange != null)
            {
                onChange.Invoke(target);
            }
        }
    }
}
