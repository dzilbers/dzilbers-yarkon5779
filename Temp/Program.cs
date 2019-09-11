using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (k == 1) return Sod(getRow(arr,0), arr.GetLength(1));
            double x = Average2D(arr, k - 1) * (k - 1);
            return (Sod(getRow(arr, k-1), arr.GetLength(1)) + x)/k;
        }

        static void Main(string[] args)
        {
            double[,] arr = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 } };
            Console.WriteLine(Average2D(arr, 4));

        }
    }
}
