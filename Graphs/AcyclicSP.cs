namespace Graphs;

public class AcyclicSP
{
    private DirectedWeightedEdge[] _edgeTo;
    private double[] _distTo;

    public AcyclicSP(EdgeWeightedDiGraph graph, int s)
    {
        _edgeTo = new DirectedWeightedEdge[graph.Vertices];
        _distTo = new double[graph.Vertices];

        for(int i = 0; i < graph.Vertices; i++)
        {
            _distTo[i] = double.PositiveInfinity;
        }
        _distTo[s] = 0;
        var top = new Topological(graph);
        foreach(var t in top.Order)
        {
            Relax(graph, t);
        }
    }
    public double DistTo(int v) => _distTo[v];
    
    public bool HasPath(int v) => _distTo[v] < double.PositiveInfinity;
    
    public IEnumerable<DirectedWeightedEdge> PathTo(int v)
    {
        if (!HasPath(v))
        {
            return new DirectedWeightedEdge[0];
        }
        else
        {
            var result = new Stack<DirectedWeightedEdge>();
            for (var edge = _edgeTo[v]; edge != null; edge = _edgeTo[edge.From])
            {
                result.Push(edge);
            }
            return result;
        }
    }
    
    private void Relax(EdgeWeightedDiGraph G, int v)
    {
        foreach(var e in G.Adjacent(v))
        {
            int w = e.To;
            if (_distTo[w] > _distTo[v] + e.Weight)
            {
                _distTo[w] = _distTo[v] + e.Weight;
                _edgeTo[w] = e;
            }
        }
    }
}
