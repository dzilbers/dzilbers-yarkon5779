using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarkon5779
{
    static partial class SearchAndSort
    {
        public static void SortSelection(int[] arr)
        {
            SortSelection(arr, arr.Length - 1);
        }
        private static void SortSelection(int[] arr, int last)
        {
            if (last <= 0) // recurs. stop cond.
                return;

            int index = findMax1(arr, last);
            if (index != last)
                swap(arr, index, last);
            SortSelection(arr, last - 1);
        }

        public static int[] SortInsertion(int[] arr)
        {
            int [] newArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; ++i)
                insertToSortedArray(newArr, i, arr[i]);

            return newArr;
        }

        private static void insertToSortedArray(int[] arr, int n, int num)
        {
            int i;
            for (i = 0; i < n && arr[i] < num; ++i);

            for (int j = n - 1; j >= i; --j)
                arr[j + 1] = arr[j];

            arr[i] = num;
        }
        
        public static void BubbleSort(int[] arr)
        {
            bool done = false;
            for (int i = arr.Length - 1; i >= 0 && !done; --i)
            {
                done = true;
                for (int j = 0; j < i; ++j)
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                        done = false;
                    }
            }
        }
    }
}
