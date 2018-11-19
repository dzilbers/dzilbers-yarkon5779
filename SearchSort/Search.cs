using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarkon5779
{
    static partial class SearchAndSort
    {
        public static int SearchLinearLoop1(int[] arr, int number)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                if (number == arr[i])
                    return i;
            }
            return -1;
        }

        // Improve performance (efficiency)
        public static int SearchLinearLoop2(int[] arr, int number)
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

        public static int SearchLinearRecursiveHelper(int[] arr, int number)
        {
            return SearchLinearRecursive(arr, number, 0);
        }
        // Converted from SearchLinearLoop1
        // Additional parameter index ~ loop variable i
        private static int SearchLinearRecursive(int[] arr, int number, int index)
        {
            // Stop condition 1 ~ loop condition: end of array
            if (index == arr.Length)
                return -1;

            // Stop condition 2 - we have found the value
            if (arr[index] == number) // stop condition 1
                return index;

            // Recursive call ~ recall the loop body including index increment
            return SearchLinearRecursive(arr, number, index + 1);
        }

        private static int findMax2(int[] arr, int last)
        {
            if (last == 0)
                return 0;

            int max1 = arr[last];
            int index = findMax2(arr, last - 1);
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

        public static int BinSearchRecursiveHelper(int[] arr, int number)
        {
            return BinSearchRecursive(arr, number, 0, arr.Length - 1);
        }
        private static int BinSearchRecursive(int[] arr, int number, int from, int to)
        {
            if (from > to) // recursion stop condition #1
                return -1;

            int middle = (from + to) / 2;
            if (arr[middle] == number) // recursion stop condition #2
                return middle;

            if (number < arr[middle])
                return BinSearchRecursive(arr, number, from, middle - 1);
            else
                return BinSearchRecursive(arr, number, middle + 1, to);
        }

        public static int BinSearchLoop(int[] arr, int number)
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
