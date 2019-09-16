using System;
using System.Linq;

namespace SearchSort
{
    static partial class SearchAndSort
    {
        private static Random random = new Random(DateTime.Now.Millisecond);
        private static int[] numbers = new int[10];

        static void Main(string[] args)
        {
            //for (int i = numbers.Length - 1; i >= 0; --i)
            //{
            //    numbers[i] = random.Next(100);
            //}
            //Console.WriteLine("Original array: ");
            //printNumbers(numbers);
            ////int number = int.Parse(Console.ReadLine());
            ////Console.WriteLine(Search1(numbers, number));
            //Console.WriteLine("Selection sort: ");
            //SortSelection1(numbers);
            //printNumbers(numbers);

            //Console.WriteLine();

            //for (int i = numbers.Length - 1; i >= 0; --i)
            //{
            //    numbers[i] = random.Next(100);
            //}
            //Console.WriteLine("Original array: ");
            //printNumbers(numbers);
            //Console.WriteLine("Insertion sort: ");
            //SortInsertion(numbers);
            //printNumbers(numbers);

            //Console.WriteLine();

            //for (int i = numbers.Length - 1; i >= 0; --i)
            //{
            //    numbers[i] = random.Next(100);
            //}
            //Console.WriteLine("Original array: ");
            //printNumbers(numbers);
            //Console.WriteLine("Bubble sort: ");
            //BubbleSort(numbers);
            //printNumbers(numbers);

            for (int i = numbers.Length - 1; i >= 0; --i)
            {
                numbers[i] = random.Next(100);
            }
            Console.WriteLine("Original array: ");
            printNumbers(numbers);
            Console.WriteLine("Insertion sort: ");
            BubbleSort4(numbers);
            printNumbers(numbers);

            int[,] matrix =
            {
                { 1, 2, 3, 4, 5 },
                { 2, 3, 4, 5, 6 }
            };

            Console.WriteLine(matrix.GetLength(0) + " X " + matrix.GetLength(1));
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            // And now without additional variable
            //arr[i] += arr[j];
            //arr[j] = arr[i] - arr[j];
            //arr[i] -= arr[j];
        }

        private static void printNumbers(int[] arr)
        {
            foreach (var num in arr)
                Console.Write(" " + num);
            Console.WriteLine();
        }
    }
}
