using System;
using BinaryTree;
using LinkedListBigPicture;
using MyQueue;
using MyStack;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        TestBinaryTree();
        TestLinkedList();
        TestQueue();
        TestStack();

        Console.WriteLine("\nԱվարտված է:");
        Console.ReadKey();
    }


    static void TestBinaryTree()
    {
        Console.WriteLine("=== 1. My Binary Tree Test ===");
        MyBinaryTree<int> tree = new MyBinaryTree<int>();
        tree.Add(50);
        tree.Add(30);
        tree.Add(70);
        tree.Add(20);
        tree.Add(40);
        tree.Add(60);
        tree.Add(80);

        Console.WriteLine($"Does tree contain 40? {tree.Contains(40)}");
        Console.WriteLine($"Does tree contain 99? {tree.Contains(99)}");

        Console.WriteLine("Elements in InOrder (Sorted):");
        foreach (int value in tree)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine($"\nTree Count: {tree.Count}");
    }

    static void TestLinkedList()
    {
        Console.WriteLine("\n=== 2. My LinkedList Test ===");
        MyLinkedList<int> myList = new MyLinkedList<int>();
        myList.AddLast(10);
        myList.AddLast(20);
        myList.AddLast(30);
        myList.AddFirst(5);

        Console.WriteLine($"Count after adding: {myList.Count}");
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        myList.RemoveLast();
        myList.RemoveFirst();

        Console.WriteLine("Final List elements:");
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }
    }

    static void TestQueue()
    {
        Console.WriteLine("\n=== 3. My Queue Test (FIFO) ===");
        MyQueue_projects<int> queue = new MyQueue_projects<int>();
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Enqueue(300);

        while (queue.Count > 0)
        {
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }
    }

    static void TestStack()
    {
        Console.WriteLine("\n=== 4. My Stack Test (LIFO) ===");
        MyStack<int> stack = new MyStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        while (stack.Count > 0)
        {
            Console.WriteLine($"Popped: {stack.Pop()}");
        }
    }
}