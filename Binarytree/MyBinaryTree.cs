using Binarytree;
using System.Collections;

namespace BinaryTree
{
    public class MyBinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private MyBinarytreeNode<T> _head;
        private int _count;

        public int Count => _count;

        #region Add
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new MyBinarytreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        private void AddTo(MyBinarytreeNode<T> node, T value)
        {
            if (node.CompareTo(value) > 0)
            {
                if (node.Left == null)
                    node.Left = new MyBinarytreeNode<T>(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new MyBinarytreeNode<T>(value);
                else
                    AddTo(node.Right, value);
            }
        }
        #endregion

        #region Contains
        public bool Contains(T value)
        {
            MyBinarytreeNode<T> current = _head;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return false;
        }
        #endregion

        #region Traversal (InOrder)
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(_head).GetEnumerator();
        }

        private IEnumerable<T> InOrder(MyBinarytreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var left in InOrder(node.Left))
                    yield return left;

                yield return node.Value;

                foreach (var right in InOrder(node.Right))
                    yield return right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
