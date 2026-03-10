using LinkedListBigPicture;
using MyLinkedList.Internal;
using System.Collections;
using System.Globalization;

namespace MyQueue;

public class MyQueue_projects<T> : IEnumerable<T>
{
    MyLinkedList<T> items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        var node = new MyLinkedListNode<T>(item);
        items.AddLast(node);
    }

    public T Dequeue()
    {
        if (items.Head == null)
            throw new InvalidOperationException("empty");
        {
            T value = items.Head.Value;
            items.RemoveFirst();
            return value;
        }
   public T Peek() 
    {
        T value = items.Head.Value;
        return value;
    }
    public int Count
    { 
        get
        { 
            return items.Count; 
        
         }

    }

    public void Clear()
        { 
        items.Clear();
        }
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

