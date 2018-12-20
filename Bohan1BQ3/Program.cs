using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchSort;

namespace Bohan1BQ3
{
    class Program
    {
        // Merge style: O(N)
        static void printShared1(int[] a1, int[] a2)
        {
            Console.Write("Shared values: ");
            int i1 = 0, i2 = 0;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                if (a1[i1] == a2[i2])
                {
                    Console.Write(" " + a1[i1]);
                    ++i1;
                    ++i2;
                }
                else if (a1[i1] < a2[i2])
                    ++i1;
                else
                    ++i2;
            }
            Console.WriteLine();
        }

        // Nested loop: O(N^2)
        static void printShared2(int[] a1, int[] a2)
        {
            Console.Write("Shared values: ");
            for (int i1 = 0; i1 < a1.Length; ++i1)
                for (int i2 = 0; i2 < a2.Length; ++i2)
                    if (a1[i1] == a2[i2])
                        Console.Write(" " + a1[i1]);
            Console.WriteLine();
        }

        // With binary search: O(N*log(N))
        static void printShared3(int[] a1, int[] a2)
        {
            Console.Write("Shared values: ");
            for (int i = 0; i < a1.Length; ++i)
            { 
                int from = 0, to = a2.Length - 1;
                while (from <= to)
                {
                    int middle = (from + to) / 2;
                    if (a2[middle] == a1[i])
                    {
                        Console.Write(" " + a1[i]);
                        break; // found and printed - get out from the search
                    }
                    if (a1[i] < a2[middle])
                        to = middle - 1;
                    else
                        from = middle + 1;
                }
            }
            Console.WriteLine();
        }

        static private void printNumbers(int[] arr)
        {
            foreach (var num in arr)
            {
                Console.Write(" " + num);
            }
            Console.WriteLine();
        }

        // Test (not a part of the Bohan)
        const int MAX = 20;
        static private Random random = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            int[] arr1 = new int[10];
            int[] arr2 = new int[15];
            for (int i = arr1.Length - 1; i >= 0; --i)
                arr1[i] = random.Next(MAX);
            for (int i = arr2.Length - 1; i >= 0; --i)
                arr2[i] = random.Next(MAX);
            SearchAndSort.SortInsertion(arr1);
            SearchAndSort.SortInsertion(arr2);
            printNumbers(arr1);
            printNumbers(arr2);
            printShared1(arr1, arr2);
        }
    }
}
