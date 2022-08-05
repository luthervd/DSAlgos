using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    public class InterceptingSortRunner
    {
        public void Run()
        {
            var original = new List<int>() { 11, 8, 4, 22, 345, 6, 2, 3, 77, 897, 45, 2, 3, 2 };
            var input = new List<int>() { 11, 8, 4, 22, 345, 6, 2, 3, 77, 897, 45, 2, 3, 2 };
            var listHandler = new Action<IList<int>>(x =>
            {
                for(var i = 0; i < x.Count; i++)
                {
                    if(x[i] == original[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if(i == (x.Count-1))
                    {
                        Console.Write($"{x[i]}");
                    }
                    else
                    {
                        Console.Write($"{x[i]},");
                    }
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

            });
          
            Console.WriteLine($"{string.Join(',', input)}");
            input.QuickSort(listHandler);
        }
    }
}
