namespace MyBubleSort
{
    public class MyQuickSort<T> where T : IComparable<T>
    {
        public void Sort(T[] arr)
        {
            if (arr == null || arr.Length <= 1) return;
            QuickSort(arr, 0, arr.Length - 1);
        }

        private void QuickSort(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);// մեր վերջի տարրի ինդեքսն է 
                QuickSort(arr, left, pivotIndex - 1);//arrՈւմ դասավորիր այնպես որ սկսի ձախից միչև pivotIndexի նախորդը
                    QuickSort(arr, pivotIndex + 1, right);//arrի մեջ դասավորիր այնպես որ սկսի pivonindexԻց հետո գտնվող տարից գնա աջ
            }
        }

        private int Partition(T[] arr, int left, int right)
        {
            T pivot = arr[right];//վերցնում է մեր վերջի էլեմենտը
            int i = left - 1; //Ձախի նախավերջին էլեմենտը

            for (int j = left; j < right; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)//եթե jին ավելի փոքր է քան մեր վերջին տարը 
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private void Swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}










//Lusine Margaryan