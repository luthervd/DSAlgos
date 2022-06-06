using System.Text;

namespace Sorting.Queues
{
    public enum QueueWeighting
    {
        Max,
        Min
    }
    public class PriorityQueue<T> where T: IComparable<T>
    {
        private T[] _queue;
        private int N = 0;
        private QueueWeighting _weighting;

        public PriorityQueue(int size, QueueWeighting weighting)
        {
            _queue = new T[size+1];
            _weighting = weighting;
        }

        public T Dequeue()
        {
            var item = _queue[1];
            Exchange(1, N--);
            _queue[N + 1] = default(T);
            Sink(1);
            return item;
        }

        public void Insert(T item)
        {
            _queue[++N] = item;
            Swim(N);
        }

        public T Peek()
        {
            return _queue[1];
        }

        public int Size()
        {
            return N;
        }

        private void Swim(int index)
        {
            while (index > 1 && Check(index/2,index))
            {
                Exchange(index/2, index);
                index = index/2;
            }
        }


        public override string ToString()
        {
            var result = new StringBuilder();
            var index = 0;
            foreach(var item in _queue)
            {
                if(index > 0 && index < N)
                {
                    result.AppendLine(item.ToString());
                }
                index++;
            }
            return result.ToString();
        }

       
        private void Sink(int index)
        {
            while (2 * index <= N)
            {
                int j = 2 * index;
                if (j < N && Check(j,j + 1)) j++;
                if (!Check(index, j)) break;
                Exchange(index, j);
                index = j;
            }
        }
        private bool Check(int v, int w)
        {
            if(_weighting == QueueWeighting.Max)
            {
                return _queue[v].CompareTo(_queue[w]) < 0;
            }
            else
            {
                return _queue[v].CompareTo(_queue[w]) > 0;
            }
            
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            var parent = _queue[leftIndex];
            _queue[leftIndex] = _queue[rightIndex];
            _queue[rightIndex] = parent;
        }

        public bool IsEmpty()
        {
            return N < 1;
        }
    }
}
