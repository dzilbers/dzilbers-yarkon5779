using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targil1
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
    }
}
