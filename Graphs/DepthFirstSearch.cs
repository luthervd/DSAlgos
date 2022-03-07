using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DepthFirstSearch : GraphSearch
    {
     
        public DepthFirstSearch(Graph g) : base(g) { }

        public override void Search(int s)
        {
            if (s < _marked.Length)
            {
                Console.WriteLine($"DFS for {s}");
                _marked[s] = true;
                _count++;
                foreach (var w in _g.Adjacent(s))
                {
                    var logMessage = $"Checking {w} in {s}";
                    logMessage += $"{Environment.NewLine}Marked is ";
                    for (var i = 0; i < _marked.Length; i++)
                    {
                        logMessage += ($"{Environment.NewLine}{i}: {_marked[i]}");
                    }
                    Console.WriteLine(logMessage);
                    if (!_marked[w])
                    {
                        Search(w);
                    }
                }
            }
            else
            {
                Console.WriteLine($"No element for {s}");
            }
        }
    }
}
