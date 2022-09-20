namespace Graphs
{
    public class DirectedCycle
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private Stack<int> _cycle;
        private bool[] _onStack;

        public DirectedCycle(DiGraph digraph)
        {
            _onStack = new bool[digraph.Vertices];
            _cycle = new Stack<int>();
            _marked = new bool[digraph.Vertices];
            _edgeTo = new int[digraph.Vertices];
            for (var i = 0; i < digraph.Vertices; i++)
            {
                if (!_marked[i])
                {
                    Dfs(digraph, i);
                }
            }
        }

      

        private void Dfs(DiGraph digraph, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach(var node in digraph.Adjacent(v))
            {
                if (HasCycle) { 
                    return; 
                }
                else if (!_marked[node]) {
                    _edgeTo[node] = v;
                    Dfs(digraph, node);
                }
                else if (_onStack[node]) {
                    
                    for (int x = v; x != node; x = _edgeTo[x])
                        _cycle.Push(x);
                    _cycle.Push(node);
                    _cycle.Push(v);
                }
            }
        }


        private void Dfs(EdgeWeightedDiGraph digraph, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (var node in digraph.Adjacent(v))
            {
                var i = node.To;
                if (HasCycle)
                {
                    return;
                }
                else if (!_marked[i])
                {
                    _edgeTo[i] = v;
                    Dfs(digraph, i);
                }
                else if (_onStack[i])
                {

                    for (int x = v; x != i; x = _edgeTo[x])
                        _cycle.Push(x);
                    _cycle.Push(i);
                    _cycle.Push(v);
                }
            }
        }

        public bool HasCycle => _cycle.Any();

        public IEnumerable<int> Cycle => _cycle;
    }
    
}
