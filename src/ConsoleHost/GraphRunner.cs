using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    internal class GraphRunner
    {
        internal void Run()
        {
            var content = @"C:\Users\lukem\source\DSAlgos\Inputs\Tiny.txt";
            var graphArgsParser = new GraphArgsParser();
            var args = graphArgsParser.ReadFromFile(content);
            var graph = new Graph(args);
            var dfs = new DepthFirstSearch(graph, 5);
        }
    }
}
