using Graphs.Trees;

namespace ConsoleHost;

public class WeightedGraphRunner
{
    public void Run()
    {
        var filesToCheck = Directory.GetFiles(@".\Data\WeightedGraphs");
        foreach (var file in filesToCheck)
        {
            var argParser = new WeightedGraphArgsParser();
            var args = argParser.ReadFromFile(file);
            var weightedEdgeGraph = new EdgeWeightedGraph(args);
            var lp = LazyPrimsMST.Build(weightedEdgeGraph);
            foreach(var edge in lp.Edges)
            {
                Console.WriteLine($"{edge.Either()}-{edge.Other(edge.Either())} {edge.Weight}");
            }
            Console.WriteLine(lp.Weight);
        }
    }
}
