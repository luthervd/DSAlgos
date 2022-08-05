namespace Graphs
{
    public class EdgeWeightedDiGraph
    {
        private LinkedList<DirectedWeightedEdge>[] _adjacent;

        public EdgeWeightedDiGraph(int v)
        {
            V = v;
            _adjacent = new LinkedList<DirectedWeightedEdge>[v];
            for (var i = 0; i < v; i++)
            {
                _adjacent[i] = new LinkedList<DirectedWeightedEdge>();
            }
        }

        public EdgeWeightedDiGraph(WeightedDirectedGraphArgs args) : this(args.Vertices)
        {
            foreach (var edge in args.EdgeItems)
            {
                AddEdge(edge);
            }
        }

        public int V { get; }

        public int E { get; private set; }

        public void AddEdge(DirectedWeightedEdge edge)
        {
            _adjacent[edge.From].AddLast(edge);
            E++;
        }
        public IEnumerable<DirectedWeightedEdge> Adj(int v)
        {
            if (v > _adjacent.Length - 1)
            {
                throw new ArgumentOutOfRangeException("Arg higher than number of vertices");
            }
            return _adjacent[v];
        }

        public IEnumerable<DirectedWeightedEdge> Edges()
        {
            return _adjacent.SelectMany(x => x);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
