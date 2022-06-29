using Sorting.Queues;

namespace Graphs.Trees
{
    public class PrimMST
    {
        private WeightedEdge[] _edgeTo; // shortest edge from tree vertex
        private double[] _distTo; // distTo[w] = edgeTo[w].weight()
        private bool[] _marked; // true if v on tree
        private IndexMinPq<double> _pq;
        private EdgeWeightedGraph _graph;

        private PrimMST(EdgeWeightedGraph graph)
        {
            _graph = graph;
            _edgeTo = new WeightedEdge[graph.V];
            _distTo = new double[graph.V];
            _marked = new bool[graph.V];
            _pq = new IndexMinPq<double>(graph.V);
            for(var i =0; i < _distTo.Length; i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _distTo[0] = 0.0;
            _pq.Insert(0, 0.0);

        }

        public static PrimMST Build(EdgeWeightedGraph graph)
        {
            var primMst = new PrimMST(graph);
            while (primMst._pq.Size() > 0)
            {
                primMst.Visit(primMst._pq.DelMin());
            }
            return primMst;
        }
        private void Visit(int v)
        {
            _marked[v] = true;
            foreach(var edge in _graph.Adj(v))
            {
                var w = edge.Other(v);
                if (_marked[w])
                {
                    continue;
                }
                if (edge.Weight < _distTo[w])
                {
                    _edgeTo[w] = edge;
                    _distTo[w] = edge.Weight;
                    if (_pq.Contains(w)) _pq.Change(w, _distTo[w]);
                    else _pq.Insert(w, _distTo[w]);
                }
            }
        }

        public IEnumerable<WeightedEdge> Edges => _edgeTo;

        public decimal Weight => (decimal)_distTo.Sum(x => x);

    }
}
