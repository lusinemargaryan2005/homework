using MyLinkedList.Internal;
using System.Collections;

namespace LinkedListBigPicture;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }
  

    public int Count { get; private set; }
    public bool IsReadOnly => false;

    public void Add(T item)
    {
        AddLast(item);
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void AddFirst(T item) => AddFirst(new MyLinkedListNode<T>(item));

    public void AddFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head;
        Head = node;
        Head.Next = temp;
        Count++;
        if (Count == 1)
            Tail = Head;
    }

    public void AddLast(T item)
    {
        AddLast(new MyLinkedListNode<T>(item));
    }


    public void AddLast(MyLinkedListNode<T> node)
    {
        if (Count == 0)
            Head = node;
        else
            Tail.Next = node;

        Tail = node;
        Count++;
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveFirst()
    {
        if (Count != 0)
        {
            Head = Head.Next;
            Count--;
            if (Count == 0)
                Tail = null;
        }
    }

    public void RemoveLast()
    {
        if (Count != 0)
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                MyLinkedListNode<T> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Count--;
        }
    }
}