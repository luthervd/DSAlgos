using Searching;

namespace Graphs
{
    public class KrukalsMST
    {
        private Queue<WeightedEdge> _edges;
        private EdgeWeightedGraph _graph;
        private bool _built;
        public KrukalsMST(EdgeWeightedGraph graph)
        {
            _edges = new Queue<WeightedEdge>();
            _graph = graph;
        }

        public IEnumerable<WeightedEdge> Edges => Fill();

        public double Weight => _edges.Sum(x => x.Weight);

        private IEnumerable<WeightedEdge> Fill()
        {
            if (!_built)
            {
                var pq = new PriorityQueue<WeightedEdge, double>(_graph.Edges().Select(x => (x, x.Weight)));
                var uf = new UnionFind(_graph.V);

                while (pq.Count != 0 && _edges.Count < _graph.V - 1)
                {
                    var edge = pq.Dequeue();
                    int v = edge.Either(), w = edge.Other(v);
                    if (uf.Connected(v, w)) continue;
                    uf.Union(v, w);
                    _edges.Enqueue(edge);
                }
                _built = true;
            }
            return _edges;
        }


    }
}
