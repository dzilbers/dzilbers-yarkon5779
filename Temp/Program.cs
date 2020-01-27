using System;
using Stack;
using Queue;
using Chains;
using BinTree;

namespace Temp
{
    struct A { public int a; }
    class B { public int b; }
    class Program
    {
        public static double Sod(double[] vec, int i)
        {
            if (i == 1)
                return vec[0];
            double x;
            x = Sod(vec, i - 1) * (i - 1);
            return (vec[i - 1] + x) / i;
        }

        private static double[] getRow(double[,] matrix, int row)
        {
            double[] vec = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); ++i)
                vec[i] = matrix[row, i];
            return vec;
        }

        public static double Average2D(double[,] arr, int k)
        {
            if (k == 1) return Sod(getRow(arr, 0), arr.GetLength(1));
            double x = Average2D(arr, k - 1) * (k - 1);
            return (Sod(getRow(arr, k - 1), arr.GetLength(1)) + x) / k;
        }

        static void SpilledOn<T>(Stack<T> s1, Stack<T> s2)
        {
            while (!s2.IsEmpty())
                s1.Push(s2.Pop());
        }

        static void Page120Ex3(Stack<int> s)
        {
            int count = 0;
            bool found = false;
            Stack<int> temp = new Stack<int>();
            int num = int.Parse(Console.ReadLine());
            while (!found)
            {
                while (!found && !s.IsEmpty())
                {
                    if (s.Top() == num)
                        found = true;
                    else
                        temp.Push(s.Pop());
                }
                SpilledOn(s, temp);
                if (!found)
                    num = int.Parse(Console.ReadLine());
                ++count;
            }
            Console.WriteLine("??? " + num + " ??? " + count + " ???");
        }
        static void Main(string[] args)
        {
            //double[,] arr = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 } };
            //Console.WriteLine(Average2D(arr, 4));
            Stack<int> stk = new Stack<int>();
            for (int i = 1; i <= 5; ++i)
                stk.Push(i);
            Page120Ex3(stk);
        }
    }
}
