namespace Graphs;

public class WeightedGraphArgs
{
    public int Vertices { get; set; }

    public int Edges { get; set; }

    public ICollection<(int First, int Second, double Weight)> EdgeArgs { get; set; } = new List<(int First, int Second, double weight)>();

    public IEnumerable<WeightedEdge> EdgeItems => EdgeArgs.Select(x => new WeightedEdge(x.First, x.Second, x.Weight)).ToList();
}
