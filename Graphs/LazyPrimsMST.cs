namespace Graphs
{
    public sealed class LazyPrimsMST : MSTree
    {
        private bool[] _marked;
        public LazyPrimsMST(EdgeWeightedGraph graph) : base(graph)
        {
            _marked = new bool[graph.V];
        }

        public static LazyPrimsMST Build(EdgeWeightedGraph graph)
        {
            var tree = new LazyPrimsMST(graph);
            tree.ReadGraph();
            return tree;

        }

        private void ReadGraph()
        {
            Visit(0);
            while (QueuedEdges.Count > 0)
            {
                var edge = QueuedEdges.Dequeue();
                var i = edge.Either();
                var w = edge.Other(i);
                if (_marked[i] && _marked[w]) continue;
                Nodes.Enqueue(edge);
                if (!_marked[i]) Visit(i);
                if (!_marked[w]) Visit(w);
            }
        }

        private void Visit(int v)
        {
            _marked[v] = true;
            foreach (var edge in _graph.Adj(v))
            {
                if (!_marked[edge.Other(v)])
                {
                    QueuedEdges.Enqueue(edge, edge.Weight);
                }
            }
        }
    }
}
