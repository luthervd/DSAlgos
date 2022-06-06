namespace Graphs.Trees;

public class EdgeWeightedGraph
{
    private List<WeightedEdge> _edges;

    private LinkedList<WeightedEdge>[] _adjacent;

    public EdgeWeightedGraph(int v)
    {
        V = v;
        _edges = new List<WeightedEdge>();
        _adjacent = new LinkedList<WeightedEdge>[v];
        for(var i = 0 ; i < v; i++)
        {
            _adjacent[i] = new LinkedList<WeightedEdge>();
        }
    }

    public EdgeWeightedGraph(WeightedGraphArgs args) : this(args.Vertices)
    {
        foreach(var edge in args.EdgeItems)
        {
            AddEdge(edge);
        }
    }

    public int V { get; }

    public int E { get; private set; }

    public void AddEdge(WeightedEdge edge)
    {
        _edges.Add(edge);
        var i = edge.Either();
        var w = edge.Other(i);
        _adjacent[i].AddLast(edge);
        _adjacent[w].AddLast(edge);
        E++;
    }
    public IEnumerable<WeightedEdge> Adj(int v)
    {
        if(v > _adjacent.Length - 1)
        {
            throw new ArgumentOutOfRangeException("Arg higher than number of vertices");
        }
        return _adjacent[v];
    }

    public IEnumerable<WeightedEdge> Edges()
    {
        return _edges;
    }

    public override string ToString()
    {
        return base.ToString();
    }


}
