namespace Graphs
{
    public abstract class GraphSearch
    {
        protected bool[] _marked;
        protected int _count;

        protected Graph _g;

        

        public GraphSearch(Graph g)
        {
            _marked = new bool[g.Vertices];
            _g = g;
            _count = 0;
        }

        public abstract void Search(int s);

        public bool Marked(int v)
        {
            return _marked[v];
        }

        public void Reset()
        {
            _marked = new bool[_g.Vertices];
        }

        public int Count => _count;
    }
}
