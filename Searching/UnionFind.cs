namespace Searching
{
    public class UnionFind
    {
        private int[] _id;
        private int[] _sz;
        private int _count;

        public UnionFind(int n)
        {
            _count = n;
            _id = new int[n];
            _sz = new int[n];
            for (int i = 0; i < n; i++)
            {
                _id[i] = i;
                _sz[i] = 1;
            }
        }

        public int Count => _count;

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int p)
        {
            while (p != _id[p]) p = _id[p];
            return p;

        }

        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;

            if (_sz[i] < _sz[j]) { _id[i] = j; _sz[j] += _sz[i]; }
            else { _id[j] = i; _sz[i] += _sz[j]; }
            _count--;
        }
    }
}
