using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinkedList.Internal;

class MyLinkedListNode<T>
{
    public T Value { get; set; }
    public MyLinkedListNode<T> Next { get; set; }

    public MyLinkedListNode(T value)
    {
        Value = value;
    }
}
