using Graphs.Trees;

namespace ConsoleHost
{
    public class SPRunner
    {
        public void Run()
        {
           
            var argParser = new WeightedGraphArgsParser();
            var args = argParser.ReadDirectedFromFile(@".\Data\WeightedGraphs\TinyEWD.txt");
            var weightedEdgeDiGraph = new EdgeWeightedDiGraph(args);
            Console.WriteLine("Dijkstra :");
            var dijkstra = DijkstraSP.Build(weightedEdgeDiGraph, 0);
            for(var i = 0; i < weightedEdgeDiGraph.V; i++)
            {
                Console.Write($"0 to {i} ({dijkstra.DistTo(i):0.##}) : ");
                if (dijkstra.HasPath(i))
                {
                    foreach(var edge in dijkstra.PathTo(i))
                    {
                        Console.Write(edge + " ");

                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
