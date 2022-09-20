namespace Graphs;

public class DepthFirstOrder
{
    private bool[] _marked;
    private Queue<int> _pre;
    private Queue<int> _post;
    private Stack<int> _reversePost;

    public DepthFirstOrder(DiGraph digraph)
    {
        _pre = new Queue<int>();
        _post = new Queue<int>();
        _reversePost = new Stack<int>();
        _marked = new bool[digraph.Vertices];
        for(var i = 0; i < digraph.Vertices; i++)
        {
            if (!_marked[i]) Dfs(digraph, i);
        }
    }

    public DepthFirstOrder(EdgeWeightedDiGraph digraph)
    {
        _pre = new Queue<int>();
        _post = new Queue<int>();
        _reversePost = new Stack<int>();
        _marked = new bool[digraph.Vertices];
        for (var i = 0; i < digraph.Vertices; i++)
        {
            if (!_marked[i]) Dfs(digraph, i);
        }
    }

    private void Dfs(DiGraph G, int v)
    {
        _pre.Enqueue(v);
        _marked[v] = true;
        foreach(int w in G.Adjacent(v))
            if (!_marked[w])
                Dfs(G, w);
        _post.Enqueue(v);
        _reversePost.Push(v);
    }

    private void Dfs(EdgeWeightedDiGraph G, int v)
    {
        _pre.Enqueue(v);
        _marked[v] = true;
        foreach (var edge in G.Adjacent(v))
            if (!_marked[edge.To])
                Dfs(G, edge.To);
        _post.Enqueue(v);
        _reversePost.Push(v);
    }
    public IEnumerable<int> Pre => _pre;

    public IEnumerable<int> Post => _post;

    public IEnumerable<int> ReversePost => _reversePost;
   
}
