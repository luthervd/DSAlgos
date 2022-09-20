using Graphs;

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
            for (var i = 0; i < weightedEdgeDiGraph.Vertices; i++)
            {
                Console.Write($"0 to {i} ({dijkstra.DistTo(i):0.##}) : ");
                if (dijkstra.HasPath(i))
                {
                    foreach (var edge in dijkstra.PathTo(i))
                    {
                        Console.Write(edge + " ");
                    }
                    Console.WriteLine();
                }
            }
            

            Console.WriteLine("AcyclicSP shortest path :");
            var args2 = argParser.ReadDirectedFromFile(@".\Data\WeightedGraphs\tinyEWDAG.txt");
            var weighted2 = new EdgeWeightedDiGraph(args2);
            var sp = new AcyclicSP(weighted2, 5);
            for (var i = 0; i < weightedEdgeDiGraph.Vertices; i++)
            {
                if (sp.HasPath(i))
                {
                    Console.Write($"5 to {i} ({sp.DistTo(i):0.##}) : ");
                    foreach (var edge in sp.PathTo(i))
                    {
                        Console.Write(edge + " ");

                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            var sp2 = new AcyclicSP(weighted2, 6);
            for (var i = 0; i < weightedEdgeDiGraph.Vertices; i++)
            {
                if (sp2.HasPath(i))
                {
                    Console.Write($"6 to {i} ({sp2.DistTo(i):0.##}) : ");
                    foreach (var edge in sp2.PathTo(i))
                    {
                        Console.Write(edge + " ");

                    }

                }
                Console.WriteLine();
            }
        }
    }
}
