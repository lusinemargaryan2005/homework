namespace StackArray
{
    public class StackArray
    {
        private int[] arr;
        private int maximum;
        private int top;


        public StackArray(int size)
        {
            maximum = size;
            arr = new int[maximum];
            top = -1;
        }
        public void push(int x)
        {
            if (top == maximum - 1)
            {
                Console.WriteLine("\"Stack Overflow");
                return;
            }
            arr[++top] = x;
        }
        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("\" Stack Overflow");
                return -1;
            }
            return arr[top--];
        }

        public int peek()
        {
            if (top == -1)
            {
                Console.WriteLine("\" Stack Overflow");
                return -1;
            }
            return arr[top];
        }

    }


    }
