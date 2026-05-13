using System.Collections;

public class MySet<T> : IEnumerable<T>
{
    private List<T> _items;

    public MySet()
    {
        _items = new List<T>();
    }

    public MySet(IEnumerable<T> items)
    {
        _items = new List<T>();
        AddRange(items);
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void Add(T item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("item already");
        }
        _items.Add(item);
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public MySet<T> Union(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_items);
        result.AddRangeSkipDuplicates(other._items);
        return result;
    }

    public MySet<T> Intersection(MySet<T> other)
    {
        MySet<T> result = new MySet<T>();
        foreach (T item in _items)
        {
            if (other._items.Contains(item))//եթե itemsԻ տարրը կա otherի մեջ
            {
                result.Add(item);
            }
        }
        return result;
    }

    public MySet<T> Difference(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_items);
        foreach (T item in other._items)
        {
            result.Remove(item);
        }
        return result;
    }

    public MySet<T> SymmetricDifference(MySet<T> other)
    {
        MySet<T> union = Union(other); //միավորում է բոլոր տարրեը
        MySet<T> intersection = Intersection(other);//հատումն է
        return union.Difference(intersection); //Միավորումից հանում է հատումը։
    }

    private void AddSkipDuplicates(T item)
    {
        if (!Contains(item))
        {
            _items.Add(item);
        }
    }

    private void AddRangeSkipDuplicates(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            AddSkipDuplicates(item);
        }
    }

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

















//Lusine Margaryan
