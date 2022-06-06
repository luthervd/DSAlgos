namespace Graphs.Trees;

public abstract class MSTree
{
    protected EdgeWeightedGraph _graph;
    protected PriorityQueue<WeightedEdge, double> QueuedEdges = new PriorityQueue<WeightedEdge, double>();
    protected Queue<WeightedEdge> Nodes = new Queue<WeightedEdge>();

    public MSTree(EdgeWeightedGraph graph)
    {
        _graph = graph;
    }

    public IEnumerable<WeightedEdge> Edges => Nodes;

    public double Weight => Nodes.Sum(x => x.Weight);
}
