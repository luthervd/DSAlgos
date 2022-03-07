using Graphs;
using Microsoft.Extensions.Logging;

namespace ConsoleHost
{
    internal class GraphRunner
    {
       

        public GraphRunner()
        {

        }

        internal void Run()
        {
            var filesToCheck = Directory.GetFiles(@"C:\Src\DSAlgos\Data");
            foreach(var file in filesToCheck)
            {
                Console.WriteLine($"Checking for file {file}");
                var graphArgsParser = new GraphArgsParser();
                var args = graphArgsParser.ReadFromFile(file);
                var graph = new Graph(args);
                var dfs = new DepthFirstSearch(graph);
                foreach(var arg in new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 })
                {
                    Console.WriteLine($"Starting DFS with {arg}");
                    dfs.Reset();
                    dfs.DFS(arg);
                }
                
            }
           
        }
    }
}
