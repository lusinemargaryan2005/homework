namespace Binarytree;

public class MyBinarytreeNode<T> : IComparable<T>
    where T : IComparable<T>
{
    public T Value { get; private set; }
    public MyBinarytreeNode<T> Left { get; set;}
    public MyBinarytreeNode<T> Right { get; set; }

    public MyBinarytreeNode(T value) 
    { 
        Value = value;
    }
    public int CompareTo(T other) 
    { 
        return Value.CompareTo(other);
    }
}

