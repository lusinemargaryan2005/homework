using MyStack;

class Program
{
    static void Main()
    {
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Count: " + stack.Count);
            Console.WriteLine("Top element: " + stack.Peek());

            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());

            Console.WriteLine("Count after pop: " + stack.Count);
        }
    }
}
