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
            var filesToCheck = Directory.GetFiles(@".\Data");
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
                    dfs.Search(arg);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                    Console.WriteLine($"Starting Depth FIrst Path search with {arg}");
                    var pathSearch = new DepthFirstPaths(graph, arg);
                    pathSearch.Search(arg);
                    for (int v = 0; v < graph.Vertices; v++)
                    {
                        Console.Write(arg + " to " + v + ": ");
                        if (pathSearch.HasPathTo(v))
                        {
                            foreach (var x in pathSearch.PathTo(v))
                            {
                                if (x == arg) Console.Write(x);
                                else Console.Write("-" + x);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    
                    Console.WriteLine($"Starting Breadth first search with {arg}");
                    var bfs = new BreadthFirstSearch(graph);
                    bfs.Search(arg);
                    for (int v = 0; v < graph.Vertices; v++)
                    {
                        Console.Write(arg + " to " + v + ": ");
                        if (bfs.HasPathTo(v))
                        {
                            foreach (var x in bfs.PathTo(v))
                            {
                                if (x == arg) Console.Write(x);
                                else Console.Write("-" + x);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}
