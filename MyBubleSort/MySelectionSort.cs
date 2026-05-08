using System;
using System.Collections.Generic;
using System.Text;

namespace MyBubleSort
{
    public class MySelectionSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
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