namespace MyStack;

using LinkedListBigPicture;

public class MyStack<T>
{
    private MyLinkedList<T> _list = new MyLinkedList<T>();

    public int Count => _list.Count;

    public void Push(T item)
    {
        _list.AddFirst(item);
    }
    public T Pop()
    {

        T value = _list.Head.Value;
        _list.RemoveFirst();
        return value;
    }

    public T Peek()
    {

        return _list.Head.Value;
    }
}

