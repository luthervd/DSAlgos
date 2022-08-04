using Sorting;
using System.Diagnostics;

namespace ConsoleHost
{
    internal class SortRunner
    {
        public void Run()
        {
            var input1 = "MERGESORTEXAMPLE".ToList();
            var input2 = new List<int> { 11, 8, 4, 22, 345, 6, 2, 3, 77, 897, 45, 2, 3, 2 };
            
            Console.WriteLine($"Input is {string.Join(',', input1)}");

            var sorted = input1.ToList();
            var numberSort = input2.ToList();

            sorted.MergeSort();
            numberSort.MergeSort();

            Console.WriteLine($"MERGESORT CHAR Output is {string.Join(',', sorted)}");
            Console.WriteLine($"INPUTSORT INTS Output is {string.Join(',', numberSort)}");

            var forInsertSort1 = input1.ToList();
            var forInsertSort2 = input2.ToList();
            forInsertSort1.InsertSort();
            forInsertSort2.InsertSort();
            
            Console.WriteLine($"INSERSORT Ouput for CHARS is {string.Join(',', forInsertSort1)}");
            Console.WriteLine($"INSERSORT Ouput for INTS is {string.Join(',', forInsertSort2)}");

            var forQuickSort1 = input1.ToList();
            var forQuickSort2 = input2.ToList();

            forQuickSort1.QuickSort();
            forQuickSort2.QuickSort();
            Console.WriteLine($"QUICKSORT Ouput for CHARS is {string.Join(',', forQuickSort1)}");
            Console.WriteLine($"QUICKSORT Ouput for INTS is {string.Join(',', forQuickSort2)}");

            var mergeSortLoad = new List<int>();
            var insertSortLoad = new List<int>();
            var quickSortLoad = new List<int>();
            var random = new Random(10);
            Console.WriteLine("Seeding data");
            for(var i = 0; i < 10000000; i++)
            {
                var next = random.Next();
                mergeSortLoad.Add(next);
                insertSortLoad.Add(next);
                quickSortLoad.Add(next);
            }
            Console.WriteLine("Starting load tests");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            mergeSortLoad.MergeSort();
            stopWatch.Stop();
            Console.WriteLine($"Merge sort for 10 million took {stopWatch.ElapsedMilliseconds}");
            stopWatch.Reset();
            stopWatch.Start();
            quickSortLoad.QuickSort();
            stopWatch.Stop();
            Console.WriteLine($"Quick sort for 10 million took {stopWatch.ElapsedMilliseconds}");
            stopWatch.Reset();
            stopWatch.Start();
            var result = quickSortLoad.OrderBy(x => x).ToList();
            stopWatch.Stop();
            Console.WriteLine($"Linq sort for 10 million took {stopWatch.ElapsedMilliseconds}");
            stopWatch.Reset();
            stopWatch.Start();
            var result1 = quickSortLoad.ToList();
            stopWatch.Stop();
            Console.WriteLine($"List copy for 10 million took {stopWatch.ElapsedMilliseconds}");

        }
    }
}
