namespace Graphs
{
    public class BreadthFirstSearch : GraphSearch
    {
        private int _source;
        private int[] _edgeTo;
        public BreadthFirstSearch(Graph g) : base(g)
        {
            _edgeTo = new int[g.Vertices];
        }

        public override void Search(int s)
        {
            if(_marked.Length > s)
            {
                _source = s;
                _marked[s] = true;
                var queue = new Queue<int>();
                queue.Enqueue(s);
                while (queue.Count > 0)
                {
                    int v = queue.Dequeue();
                    foreach (var node in _g.Adjacent(v))
                    {
                        if (!_marked[node])
                        {
                            _edgeTo[node] = v;
                            _marked[node] = true;
                            queue.Enqueue(node);
                        }
                    }
                }
            }
       
        }

        public bool HasPathTo(int v)
        {
            return _marked[v] == true;
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return Enumerable.Empty<int>();
            var path = new Stack<int>();
            for (int x = v; x != _source; x = _edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(_source);
            return path;
        }
    }
}
