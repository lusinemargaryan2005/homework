namespace MyPrivatequeue;

using LinkedListBigPicture;

public class PriorityQueue<T> : System.Collections.Generic.IEnumerable<T>
    where T : IComparable<T>
{
    MyLinkedList<T> _items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        if (_items.Count == 0)
        {
            _items.AddLast(item);
            return;
        }

        var current = _items.Head;

        while (current != null && current.Value.CompareTo(item) > 0)
        {
            current = current.Next;
        }

        if (current == null)
        {
            _items.AddLast(item);
        }
        else
        {
            _items.AddBefore(current, item);
        }
    }
    public T Dequeue() 
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }
        T value = _items.Head.Value;
        _items.RemoveFirst();
        return value;
    }
    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
