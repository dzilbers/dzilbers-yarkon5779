using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil1
{
    static partial class SearchAndSort
    {
        public static int Search1(int[] arr, int number)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                if (number == arr[i])
                    return i;
            }
            return -1;
        }

        public static int Search2(int[] arr, int number)
        {
            int last = arr.Length - 1;

            if (arr[last] == number)
                return last;

            int temp = arr[last];
            arr[last] = number;

            int index = 0;
            while (arr[index] != number)
                ++index;

            arr[last] = temp;
            return (index < last) ? index : -1;
        }

        public static int Search3(int[] arr, int number)
        {
            return search3(arr, number, arr.Length - 1);
        }

        private static int search3(int[] arr, int number, int last)
        {
            if (last == 0)
                return arr[0] == number ? 0 : -1;

            return arr[last] == number ? number : search3(arr, number, last - 1);
        }

        private static int findMax2(int[] arr, int last)
        {
            if (last == 0)
                return 0;

            int max1 = arr[last];
            int index = findMax(arr, last - 1);
            int max2 = arr[index];

            return max1 >= max2 ? last : index;
        }

        private static int findMax1(int[] arr, int last)
        {
            int index = 0;
            int max = arr[0];

            for (int i = 1; i <=last; ++i)
            {
                if (max < arr[i])
                {
                    index = i;
                    max = arr[i];
                }
            }

            return index;
        }

        public static int BinSearch2(int[] arr, int number)
        {
            return BinSearch2(arr, number, 0, arr.Length - 1);
        }
        private static int BinSearch2(int[] arr, int number, int from, int to)
        {
            if (from > to) // recursion stop condition #1
                return -1;

            int middle = (from + to) / 2;
            if (arr[middle] == number) // recursion stop condition #2
                return middle;

            if (number < arr[middle])
                return BinSearch2(arr, number, from, middle - 1);
            else
                return BinSearch2(arr, number, middle + 1, to);
        }

        public static int BinSearch1(int[] arr, int number)
        {
            int from = 0, to = arr.Length - 1;

            while (from <= to)
            {
                int middle = (from + to) / 2;
                if (arr[middle] == number)
                    return middle;
                if (number < arr[middle])
                    to = middle - 1;
                else
                    from = middle + 1;
            }
            return -1;
        }



    }
}
