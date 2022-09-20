namespace Graphs
{
    public class Topological
    {
        private IEnumerable<int> _order;

        public Topological(DiGraph graph)
        {
            var cycle = new DirectedCycle(graph);
            if(!cycle.HasCycle)
            {
                var dfsOrder = new DepthFirstOrder(graph);
                _order = dfsOrder.ReversePost;
            }
            else
            {
                _order = new int[0];
            }
        }

        public Topological(EdgeWeightedDiGraph graph)
        {
            var cycle = new EdgeWeightedDirectedCycle(graph);
            if (!cycle.HasCycle)
            {
                var dfsOrder = new DepthFirstOrder(graph);
                _order = dfsOrder.ReversePost;
            }
            else
            {
                _order = new int[0];
            }
        }

        public IEnumerable<int> Order => _order;
    }
}
