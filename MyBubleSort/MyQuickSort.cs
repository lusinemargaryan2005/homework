using System;
using System.Collections.Generic;
using System.Text;

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
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        private int Partition(T[] arr, int left, int right)
        {
            T pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
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