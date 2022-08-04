namespace Searching
{
    public class BinarySearchTree<TKey, TValue> : Tree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BinarySearchTree() { _count = 0; }

        private int _leftFromRoot = 0;
        private int _rightFromRoot = 0;

        public BinarySearchTree(TKey key, TValue value) : this()
        {
            Root = new Node<TKey, TValue>(key, value);
        }

        public override int LeftFromRootCount => _leftFromRoot;

        public override int RightFromRootCount => _rightFromRoot;

        public override int Height => MaxDepth(Root);

        public override bool HasKey(TKey key)
        {
            var steps = 0;
            (bool found, _) = Sink(key, Root, ref steps);
            return found;
        }

        public override bool TryAdd(TKey key, TValue value)
        {
            if (Root != null)
            {
                var comparison = key.CompareTo(Root.Key);
                if (comparison == -1)
                {
                    _leftFromRoot++;
                }
                else if (comparison == 1)
                {
                    _rightFromRoot++;
                }
            }
            (Root, bool result) = Insert(Root, key, value);
            return result;
        }

        private (Node<TKey, TValue>, bool) Insert(Node<TKey, TValue>? node, TKey key, TValue value)
        {
            if (node == null)
            {
                node = new Node<TKey, TValue>(key, value);
                _count++;
                return (node, true);
            }
            bool result = false;
            var comparison = key.CompareTo(node.Key);
            if (comparison == -1)
            {
                (node.Left, result) = Insert(node.Left, key, value);
            }
            else if (comparison == 1)
            {
                (node.Right, result) = Insert(node.Right, key, value);
            }
            return (node, result);
        }

        public override void Delete(TKey key)
        {
            (Root,bool success) = Delete(Root, key);
            if (success)
            {
                _count--;
            }
        }

        public override bool TryGetValue(TKey key, out TValue? value, ref int numberOfSearchSteps)
        {
            numberOfSearchSteps = 0;
            (bool found, value) = Sink(key, Root, ref numberOfSearchSteps);
            return found;
        }

        private (bool, TValue?) Sink(TKey key, Node<TKey, TValue>? node, ref int steps)
        {
            if (node == null)
            {
                return (false, default(TValue));
            }
            var comparison = key.CompareTo(node.Key);
            if (comparison == 0)
            {
                return (true, node.Value);
            }
            steps++;
            return comparison == -1 ? Sink(key, node.Left, ref steps) : Sink(key, node.Right, ref steps);
        }

        private int MaxDepth(Node<TKey, TValue>? node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                var lDepth = MaxDepth(node.Left);
                var rDepth = MaxDepth(node.Right);
                return lDepth > rDepth ? lDepth + 1 : rDepth + 1;
            }
        }

        private Node<TKey, TValue> Min(Node<TKey, TValue> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            else
            {
                return Min(node.Left);
            }
        }

        private Node<TKey, TValue>? DeleteMin(Node<TKey,TValue> node)
        {
            if (node.Left == null) return node.Right;
            node.Left = DeleteMin(node.Left);
            return node;
        }

        private (Node<TKey,TValue>?, bool) Delete(Node<TKey, TValue>? node, TKey key)
        {

            if (node == null) return (null, false);
            var match = key.CompareTo(node.Key);
            if (match < 0) (node.Left,_) = Delete(node.Left, key);
            else if (match > 0) (node.Right,_) = Delete(node.Right, key);
            else
            {
                if (node.Right == null) return (node.Left, true);
                else if (node.Left == null) return (node.Right, true);
                var oldNode = new Node<TKey, TValue>(node.Key, node.Value);
                oldNode.Left = node.Left;
                oldNode.Right = node.Right;
                node = Min(oldNode.Right);
                (node.Right, _) = Delete(node.Right, node.Key);
                node.Left = oldNode.Left;
            }
            return (node, true);
        }
    }
}
