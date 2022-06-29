using System.Text;

namespace Sorting.Queues
{
    public class IndexMinPq<T> where T : IComparable<T>
    {
        private int[] _pq;
        private int[] _qp;
        private T?[] _queue;
        private int N = 0;
        private int _size;

        public IndexMinPq(int size)
        {
            _queue = new T[size + 1];
            _pq = new int[size + 1];
            _qp = new int[size + 1];
            for(var i = 0; i < size; i++)
            {
                _qp[i] = -1;
            }
            _size = size;
        }

        //TODO
        public int DelMin()
        {
            if (N == 0) throw new ArgumentOutOfRangeException("PQueue underflow");
            int min = _pq[1];
            Exchange(1, N--);
            Sink(1);
            if(min != _pq[N+1]) throw new ArgumentOutOfRangeException();
            _qp[min] = -1;
            _queue[min] = default(T);
            _pq[N+1] = -1;
            return min;
        }

        public T? GetItem(int index)
        {
            ValidateIndex(index);
            if(!Contains(index)) throw new ArgumentOutOfRangeException("index");
            return _queue[index];
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            if (Contains(index))
            {
                throw new ArgumentException("Index is already in queue");
            }
            N++;
            _qp[index] = N;
            _pq[N] = index;
            _queue[index] = item;
            Swim(N);
        }

        public void Change(int index, T item)
        {
            ValidateIndex(index);
            if (!Contains(index)) throw new ArgumentOutOfRangeException("index");
            _queue[index] = item;
            Swim(_qp[index]);
            Sink(_qp[index]);
        }

        public T? Peek()
        {
            return _queue[1];
        }

        public int Size()
        {
            return N;
        }

       
        public bool Contains(int index)
        {
            ValidateIndex(index);
            return _qp[index] != -1;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            var index = 0;
            foreach (var item in _queue)
            {
                if (index > 0 && index < N)
                {
                    result.AppendLine(item?.ToString() ?? string.Empty);
                }
                index++;
            }
            return result.ToString();
        }

        private void Swim(int index)
        {
            while (index > 1 && Check(index / 2, index))
            {
                Exchange(index / 2, index);
                index = index / 2;
            }
        }

        private void Sink(int index)
        {
            while (2 * index <= N)
            {
                int j = 2 * index;
                if (j < N && Check(j, j + 1)) j++;
                if (!Check(index, j)) break;
                Exchange(index, j);
                index = j;
            }
        }

        private void Exchange(int leftIndex, int rightIndex)
        {

            var swap = _pq[leftIndex];
            _pq[leftIndex] = _pq[rightIndex];
            _pq[rightIndex] = swap;
            _qp[_pq[leftIndex]] = leftIndex;
            _qp[_pq[rightIndex]] = rightIndex;
        }

        private bool Check(int v, int w)
        {
            return _queue[_pq[v]]?.CompareTo(_queue[_pq[w]]) > 0;
        }

        public bool IsEmpty()
        {
            return N < 1;
        }

        private void ValidateIndex(int index)
        {
            if(index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }
    }
}
