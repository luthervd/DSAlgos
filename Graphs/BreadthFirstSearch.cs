namespace Graphs
{
    public class BreadthFirstSearch : GraphSearch
    {
        private int _s = -1;
        public BreadthFirstSearch(Graph g) : base(g)
        {
        }

        public override void Search(int s)
        {
            if(_s == -1)
            {
                _s = s;
            }

        }
    }
}
