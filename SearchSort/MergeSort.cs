namespace SearchSort
{
    static partial class SearchAndSort
    {

        public static void SortMerge(int[] arr)
        {
            sortMerge(arr, 0, arr.Length - 1);
        }
   
        private static void sortMerge(int[] arr, int start, int end)
        {
            // Recursion stop condition - array of size 1 (or 0) is already sorted
            if (start >= end)
                return;

            // Split the array slice into two subslices
            int middle = (start + end) / 2;
            // Sort each one of the subslices by SortMerge
            sortMerge(arr, start, middle);
            sortMerge(arr, middle + 1, end);

            // Merge two [already sorted] subslices into temporary array holding sorted original slice
            int[] temp = MergeSorted(arr, start, middle, arr, middle + 1, end);
            // Copy from temporary array into original slice of the array
            for (int i = 0; i < temp.Length; ++i)
                arr[start++] = temp[i];
        }

        public static int[] MergeSorted(int[] arr1, int start1, int end1, int[] arr2, int start2, int end2)
        {
            // The resulting array length will be sum of two original arrays' length
            int[] result = new int[end1 - start1 + 1 + end2 - start2 + 1];

            // Merge elements from original arrays according to their order into
            // the result array
            int index = 0; // index of the next free element of result array
            // while we did not finish one of original arrays
            while (start1 <= end1 && start2 <= end2)
            {
                // if current element of first array is <= than current element of second array
                if (arr1[start1] <= arr2[start2])
                    result[index] = arr1[start1++]; // move from first array to result array
                else
                    result[index] = arr2[start2++]; // move from second array to result array

                ++index; // increment the index of the next free element of result array
            }

            // NB: One of the two original arrays is finished!!!
            // if we did not finish the first array - move its tail to the end of the result array
            while (start1 <= end1)
                result[index++] = arr1[start1++];
            // if we did not finish the second array - move its tail to the end of the result array
            while (start2 <= end2)
                result[index++] = arr2[start2++];

            // return the result array
            return result;
        }
    }
}