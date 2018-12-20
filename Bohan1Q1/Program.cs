using System;

namespace Bohan1Q1
{
    class Program
    {
        static bool checkSimSum(int[] arr)
        {
            return checkSimSum(arr, 0);
        }
        static bool checkSimSum(int[] arr, int index)
        {
            if (index >= arr.Length / 2 - 1)
                return true;

            return arr[index] + arr[arr.Length - 1 - index] == arr[index + 1] + arr[arr.Length - 2 - index]
                && checkSimSum(arr, index + 1);
        }

        static void Main(string[] args)
        {
            int[] array = { 7, 3, 5, 4, 6, 2 };
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());
            if (size > 0)
            {
                array = new int[size];
                Console.WriteLine("Enter numbers:");
                for (int i = 0; i < size; ++i)
                    array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(checkSimSum(array) ? "Yes" : "No");
        }
    }
}
