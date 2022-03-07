using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DepthFirstSearch
    {
        private bool[] _marked;
        private int _count;

        private Graph _g;
        public DepthFirstSearch(Graph g)
        {
            _marked = new bool[g.Vertices];
            _g = g;
        }

        public virtual void DFS(int s)
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
                        DFS(w);
                    }
                }
            }
            else
            {
                Console.WriteLine($"No element for {s}");
            }
          
        }
        public bool Marked(int v)
        {
            return _marked[v];
        }

        public void Reset()
        {
            _marked = new bool[_g.Vertices];
        }

        public int Count => _count;
    }
}
