namespace MyBubleSort
{
    public class MargeSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items)
    {
        if (items.Length <= 1)
        {
            return;
        }

        int leftSize = items.Length / 2;
        int rightSize = items.Length - leftSize;
        

        T[] left = new T[leftSize];
        T[] right = new T[rightSize];

        Array.Copy(items, 0, left, 0, leftSize);//items-ի 0-րդ դիրքից վերցնում է leftSize հատ էլեմենտ, և տեղադրում է left-ի 0-րդ դիրքից սկսած"
        Array.Copy(items, leftSize, right, 0, rightSize);

        Sort(left);
        Sort(right);
        Marge(items, left, right);

    }
        private void Marge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = right.Length + left.Length;

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    Assign(items, targetIndex, right[rightIndex++]);//վերցնումա rightի ընթացիկ առաջի տարը դնումա զանգվածի մեջ և մեկ հատով առաջ է գնում 
                }
                else if (rightIndex >= right.Length)
                {
                    Assign(items, targetIndex, left[leftIndex++]);
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    Assign(items, targetIndex, left[leftIndex++]);

                }
                else
                {
                    Assign(items, targetIndex, right[rightIndex++]);
                }
                targetIndex++;
                remaining--;
            }
        }

           


            private void Assign(T[] items, int index, T Value)
    {
        items[index] = Value;
    }
}
}









//Lusine Margaryan
