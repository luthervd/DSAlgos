using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public abstract class Tree<TKey, TValue>
    {
        public Node<TKey, TValue>? Root { get; protected set; }

        protected int _count = 0;

        public abstract bool TryAdd(TKey key, TValue value);

        public abstract bool HasKey(TKey key);

        public abstract bool TryGetValue(TKey key, out TValue? value, ref int numberOfSearchSteps);

        public abstract void Delete(TKey key);

        public abstract int Height { get; }

        public virtual int Count => _count;
        
        public abstract int LeftFromRootCount { get; }
        
        public abstract int RightFromRootCount { get; }
    }
}
