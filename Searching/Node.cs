using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Node<TKey,TValue>
    {

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public Node<TKey,TValue>? Left {  get; set; }

        public Node<TKey,TValue>? Right {  get; set; }

        public TKey Key {  get; set; }

        public TValue Value {  get; set; }
    }
}
