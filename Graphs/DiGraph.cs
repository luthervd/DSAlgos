using System.Text;

namespace Graphs
{
    public class DiGraph
    {
        private List<int>[] _nodes;

        private int _count;
        public DiGraph(int vertices)
        {
            _nodes = new List<int>[vertices];
            for (var i = 0; i < vertices; i++)
            {
                _nodes[i] = new List<int>();
            }
            _count = 0;
        }

        public DiGraph(GraphArgs args) : this(args.Vertices)
        {
            foreach(var input in args.EdgeArgs)
            {
                AddEdge(input.First, input.Second);
            }
        }

        public void AddEdge(int v, int w)
        {
            if(_nodes.Length-1 < v || v < 0)
            {
                throw new ArgumentException("Out of bounds");
            }
            _nodes[v].Add(w);
            _count++;
        }

        public int Vertices => _nodes.Length;

        public int Edges => _count;

        public IEnumerable<int> Adjacent(int vertice) => _nodes[vertice];

        public DiGraph Reverse()
        {
            var next = new DiGraph(Vertices);
            for(int i = 0; i < Vertices; i++)
            {
                foreach(var edge in Adjacent(i))
                {
                    next.AddEdge(edge, i);
                }
            }
            return next;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < Vertices; i++)
            {
                var adjacent = _nodes[i];
                var edgeDes = adjacent.Count > 0 ? string.Join(",", adjacent) : "Nothing";
                builder.AppendLine($"Vertice {i} conects to {edgeDes}");
            }
            return builder.ToString();
        }
    }
}
