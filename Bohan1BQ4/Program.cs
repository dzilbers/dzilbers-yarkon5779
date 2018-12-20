using System;

namespace Bohan1BQ4
{
    public class Program
    {
        public static void WhoAmI(int[] a, int p1, int p2)
        {
            while (p1 < p2)
            {
                int p = Find(a, p1, p2, 1);
                Swap(a, p1, p);
                p = Find(a, p1, p2, 2);
                Swap(a, p2, p);
                ++p1; --p2;
            }
        }

        public static void Swap(int[] a, int n1, int n2)
        {
            int temp = a[n1];
            a[n1] = a[n2];
            a[n2] = temp;
        }

        public static int Find(int[] a, int p1, int p2, int k)
        {
            int v = p1;
            for (int i = p1 + 1; i <= p2; ++i)
            {
                if (k == 1 && a[i] < a[v])
                    v = i;
                if (k == 2 && a[i] > a[v])
                    v = i;
            }
            return v;
        }

        public static void Main(string[] args)
        {
            int[] arr = { 10, 3, 0, -6, 7 };
            WhoAmI(arr, 0, 4);
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(" " + arr[i]);
            Console.WriteLine();
            // A: -6 0 3 7 10
            // B: find index of min (1) or max (2) value in array between two elements (incl.)
            // C: it will sort the array
            // D: it will sort the middle of the array not including first and last pairs of elements
        }
    }

}
