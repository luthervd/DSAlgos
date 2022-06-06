using Sorting;

namespace ConsoleHost
{
    internal class SortRunner
    {
        public void Run()
        {
            var input1 = "MERGESORTEXAMPLE".ToList();
            var input2 = new List<int> { 11, 8, 4, 22, 345, 6, 2, 3, 77, 897, 45, 2, 3, 2 };
            
            Console.WriteLine($"Input is {string.Join(',', input1)}");

            var sorted = input1.MergeSort();
            var numberSort = input2.MergeSort();

            Console.WriteLine($"MERGESORT CHAR Output is {string.Join(',', sorted)}");
            Console.WriteLine($"INPUTSORT INTS Output is {string.Join(',', numberSort)}");

            var sorted2 = input1.InsertSort();
            var sorted3 = input2.InsertSort();
            
            Console.WriteLine($"INSERSORT Ouput for CHARS is {string.Join(',', sorted2)}");
            Console.WriteLine($"INSERSORT Ouput for INTS is {string.Join(',', sorted3)}");
        }
    }
}
