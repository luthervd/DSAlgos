using Sorting.Queues;

namespace Graphs.Trees
{
    public class DijkstraSP
    {
        private DirectedWeightedEdge[] _edgeTo;
        private double[] _distTo;
        private IndexMinPq<double> _pq;

        private DijkstraSP(EdgeWeightedDiGraph g)
        {
            _edgeTo = new DirectedWeightedEdge[g.V];
            _distTo = new double[g.V];
            _pq = new IndexMinPq<double>(g.V);

            for (int v = 0; v < g.V; v++)
                _distTo[v] = double.PositiveInfinity;
        }

        public static DijkstraSP Build(EdgeWeightedDiGraph g, int s)
        {
            var dijk = new DijkstraSP(g);
            dijk.Run(g, s);
            return dijk;
        }

        private void Run(EdgeWeightedDiGraph g, int s)
        {
            _distTo[s] = 0.0;
            _pq.Insert(s, 0.0);
            while(!_pq.IsEmpty())
            {
                Relax(g, _pq.DelMin());
            }
        }

        private void Relax(EdgeWeightedDiGraph g, int v)
        {
            foreach(var e in g.Adj(v))
            {
                int w = e.To;
                if (_distTo[w] > _distTo[v] + e.Weight)
                {
                    _distTo[w] = _distTo[v] + e.Weight;
                    _edgeTo[w] = e;
                    if (_pq.Contains(w)) _pq.Change(w, _distTo[w]);
                    else _pq.Insert(w, _distTo[w]);
                }
            }
        }

        public double DistTo(int v)
        {
            return _distTo[v];
        }

        public bool HasPath(int v)
        {
            return _distTo[v] < double.PositiveInfinity;
        }

        public IEnumerable<DirectedWeightedEdge> PathTo(int v)
        {
            if (!HasPath(v))
            {
                return new DirectedWeightedEdge[0];
            }
            else
            {
                var result = new Stack<DirectedWeightedEdge>();
                for(var edge = _edgeTo[v]; edge != null; edge = _edgeTo[edge.From])
                {
                    result.Push(edge);
                }
                return result;
            }
        }
    }
}
