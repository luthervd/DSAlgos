using Graphs.Trees;

namespace ConsoleHost;

public class MSTRunner
{
    public void Run()
    {
        var filesToCheck = Directory.GetFiles(@".\Data\WeightedGraphs");
        foreach (var file in filesToCheck)
        {
            var argParser = new WeightedGraphArgsParser();
            var args = argParser.ReadFromFile(file);
            var weightedEdgeGraph = new EdgeWeightedGraph(args);
            Console.WriteLine("LazyPrim :");
            var lp = LazyPrimsMST.Build(weightedEdgeGraph);
            foreach(var edge in lp.Edges)
            {
                Console.WriteLine($"{edge.Either()}-{edge.Other(edge.Either())} {edge.Weight}");
            }
            Console.WriteLine(lp.Weight);

            Console.WriteLine("Prim :");
            var prim = PrimMST.Build(weightedEdgeGraph);
            foreach (var edge in prim.Edges)
            {
                Console.WriteLine($"{edge.Either()}-{edge.Other(edge.Either())} {edge.Weight}");
            }
            Console.WriteLine(prim.Weight);

            Console.WriteLine("Krukal :");
            var kruakal = new KrukalsMST(weightedEdgeGraph);
            foreach (var edge in kruakal.Edges)
            {
                Console.WriteLine($"{edge.Either()}-{edge.Other(edge.Either())} {edge.Weight}");
            }
            Console.WriteLine(kruakal.Weight);
        }
    }
}
