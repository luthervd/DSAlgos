using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    internal class SortRunner
    {
        public void Run()
        {
            var input = "MERGESORTEXAMPLE".ToList();

            Console.WriteLine($"Input is {string.Join(',', input)}");

            var sorted = input.MergeSort();

            Console.WriteLine($"Output is {string.Join(',', sorted)}");
        }
    }
}
