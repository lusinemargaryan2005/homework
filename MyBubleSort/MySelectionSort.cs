namespace MyBubleSort
{
    public class MySelectionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)//միչև նախավերջին տարրը մեկով առաջ գնա
            {
                int minIndex = i; //հետո Minindexին տալիս են այն տարրը որի վրայով որ անցել ենք 

                for (int j = i + 1; j < n; j++) //զնցնումենք միչև վերջին տարրը 
                {
                    if (array[j].CompareTo(array[minIndex]) < 0) //եթե j փոքր է մեր mindexից
                    {
                        minIndex = j;
                    }
                }

                T temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}














//Lusine Margaryan