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
        //static void Main(string[] args)
        //{
        //    //double[,] arr = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 } };
        //    //Console.WriteLine(Average2D(arr, 4));
        //    Stack<int> stk = new Stack<int>();
        //    for (int i = 1; i <= 5; ++i)
        //        stk.Push(i);
        //    Page120Ex3(stk);
        //}

        public static void TRG9(BinNode<char> tree) // O(n)
        {
            if (tree != null)
            {
                char CharToChange = tree.GetValue();
                if (CharToChange == 'z')
                    CharToChange = 'a';
                else
                    CharToChange++;
                tree.SetValue(CharToChange);
                TRG9(tree.GetLeft());
                TRG9(tree.GetRight());
            }
        }

        public static void TRG10<T>(BinNode<T> tree) // O(n)
        {
            if (tree != null)
            {
                if (!tree.HasLeft() && !tree.HasRight())
                    Console.WriteLine(tree);
                else
                {
                    TRG10(tree.GetLeft());
                    TRG10(tree.GetLeft());
                }
            }
        }

        public static void TRG11(BinNode<int> tree) // O(n)
        {
            if (tree != null)
            {
                if (tree.GetValue() % 2 == 0)
                    if ((!tree.HasLeft() || tree.GetLeft().GetValue() % 2 == 0) &&
                        (!tree.HasRight() || tree.GetRight().GetValue() % 2 == 0))
                        Console.WriteLine(tree);
                TRG11(tree.GetLeft());
                TRG11(tree.GetRight());

            }
        }

        public static int TRG14<T>(BinNode<T> tree) // O(n)
        {
            if (tree != null)
            {
                if (tree.HasLeft() || tree.HasRight())
                    return TRG14(tree.GetLeft()) + TRG14(tree.GetRight());
                else return 1;
            }
            return 0;
        }

        public static bool TRG18(BinNode<int> t1, BinNode<int> t2) // O(n*m)
        {
            if (t2 != null)
            {
                int temp = t2.GetValue();
                return TRG18(t1, temp) && TRG18(t1, t2.GetLeft()) && TRG18(t1, t2.GetRight());
            }
            return true;
        }

        public static bool TRG18(BinNode<int> t1, int temp) // Returns True if temp is in t1. 
        {
            if (t1 != null)
            {
                if (temp == t1.GetValue())
                {
                    return true;
                }
                else
                {
                    return TRG18(t1.GetLeft(), temp) || TRG18(t1.GetRight(), temp);
                }
            }
            return false;
        }

        public static bool TRG20(BinNode<int> tree, int n) // O(n*m) 
        {
            if (n == 0)
                return true;
            if (TRG20Counter(tree, n) != 1)
                return false;
            return TRG20(tree, n - 1);
        }

        public static int TRG20Counter(BinNode<int> tree, int temp)
        {
            if (tree != null)
            {
                if (tree.GetValue() == temp)
                    return 1 + TRG20Counter(tree.GetRight(), temp) + TRG20Counter(tree.GetLeft(), temp);
                else return TRG20Counter(tree.GetRight(), temp) + TRG20Counter(tree.GetLeft(), temp);

            }
            return 0;
        }

        public static bool TRG21(BinNode<int> tree) // O(n^2)
        {
            if (tree == null)
                return true;
            if (Math.Abs(TRG21High(tree.GetLeft()) - TRG21High(tree.GetRight())) > 1)
                return false;
            return TRG21(tree.GetLeft()) && TRG21(tree.GetRight());
        }

        public static int TRG21High(BinNode<int> tree)
        {
            if (tree == null)
                return 0;
            return 1 + Math.Max(TRG21High(tree.GetLeft()), TRG21High(tree.GetRight()));

        }

        public static bool TRG22<T>(BinNode<T> tree)
        {
            if (tree == null)
                return true;
            if ((tree.HasLeft() && !tree.HasRight()) || tree.HasRight() && !tree.HasLeft()) // If there is only 1 child
                return false;
            return TRG22(tree.GetRight()) && TRG22(tree.GetLeft());
        }

        public static double TRG23(BinNode<double> tree) // O(n)
        {
            double Max = tree.GetValue();
            return Math.Max(TRG23(tree.GetRight(), Max), TRG23(tree.GetLeft(), Max));
        }

        public static double TRG23(BinNode<double> tree, double Max)
        {
            if (tree == null)
                return Max;
            if (tree.GetValue() > Max)
                Max = tree.GetValue();
            return Math.Max(TRG23(tree.GetRight(), Max), TRG23(tree.GetLeft(), Max));

        }

        public static double TRG23b(BinNode<double> tree) // O(n)
        {
            double Min = tree.GetValue();
            return Math.Min(TRG23b(tree.GetRight(), Min), TRG23b(tree.GetLeft(), Min));
        }

        public static double TRG23b(BinNode<double> tree, double Min)
        {
            if (tree == null)
                return Min;
            if (tree.GetValue() < Min)
                Min = tree.GetValue();
            return Math.Min(TRG23(tree.GetRight(), Min), TRG23(tree.GetLeft(), Min));
        }

        public static void BuildTree(BinNode<double> tree) // Enter -1 To End
        {
            Console.WriteLine("Current Root Is: " + tree.GetValue());
            Console.Write("Enter Left Num: ");
            double leftValue = double.Parse(Console.ReadLine());
            if (leftValue == -1)
                return;
            BinNode<double> left = new BinNode<double>(leftValue);
            Console.Write("Enter Right Num: ");
            double rightValue = double.Parse(Console.ReadLine());
            if (rightValue == -1)
                return;
            BinNode<double> right = new BinNode<double>(rightValue);
            tree.SetRight(right);
            tree.SetLeft(left);
            BuildTree(left);
            BuildTree(right);
        }

        public static bool TRG26Guy<T>(BinNode<T> tree) // O(n)
        {
            int x = 2 ^ TRG27(tree); // 2^N
            if (x == TRG14(tree))
                return true;
            return false;
        }

        public static int TRG27<T>(BinNode<T> tree) // O(n)
        {
            if (tree == null)
                return 0;
            return 1 + Math.Max(TRG27(tree.GetRight()), TRG27(tree.GetLeft()));
        }

        public static bool TRG26<T> (BinNode<T> tree)
        {
            if (tree == null) return true;
            int left = TRG27(tree.GetLeft());
            int right = TRG27(tree.GetRight());
            return left == right && TRG26(tree.GetLeft()) && TRG26(tree.GetRight());
        }

        public static bool IsLeaf<T>(BinNode<T> tr)
        {
            return !tr.HasLeft() && !tr.HasRight();
        }

        public static int Calc(BinNode<int> exp)
        {
            // 1+, 2-, 3*, 4/
            if (IsLeaf(exp))
                return exp.GetValue();
            // כאן זה לא עלה אלא פעולה ולכן יש בודאות שני הבנים
            int left = Calc(exp.GetLeft());
            int right = Calc(exp.GetRight());
            int oper = exp.GetValue();
            if (oper == 1)
                return left + right;
            if (oper == 2)
                return left - right;
            if (oper == 3)
                return left * right;
            // if (oper == 4) - זה מה שנשאר
            return left / right;
        }

        public static int CountNodes1<T>(BinNode<T> tr)
        {
            if (tr == null) return 0;
            return 1 + CountNodes1(tr.GetLeft()) + CountNodes1(tr.GetRight());
        }

        public static int CountNodes2<T>(BinNode<T> tr)
        { // there must not be tr == null
            if (IsLeaf(tr)) return 1;
            int sum = 1;
            if (tr.HasLeft()) sum = sum + CountNodes2(tr.GetLeft());
            if (tr.HasRight()) sum = sum + CountNodes2(tr.GetRight());
            return sum;
        }

        public static void PrintInorder<T>(BinNode<T> tr)
        { // סריקה תוכית
            if (tr == null) return;
            PrintInorder(tr.GetLeft());
            Console.WriteLine(tr.GetValue());
            PrintInorder(tr.GetRight());
        }

        public static void PrintPreorder<T>(BinNode<T> tr)
        { // סריקה תחילית
            if (tr == null) return;
            Console.WriteLine(tr.GetValue());
            PrintInorder(tr.GetLeft());
            PrintInorder(tr.GetRight());
        }

        public static void PrintPostorder<T>(BinNode<T> tr)
        { // סריקה סופית
            if (tr == null) return;
            PrintPostorder(tr.GetLeft());
            PrintPostorder(tr.GetRight());
            Console.WriteLine(tr.GetValue());
        }

        public static double AverageDigit(int num)
        {
            return averageDigit(num, 0, 0);
                }

        private static double averageDigit(int num, int sum, int count)
        {
            if (num < 10) return (double)(sum + num) / (count + 1);
            return averageDigit( num / 10, sum + num % 10, count + 1);
        }

        public static bool TestArithProgr(int[] arr)
        {
            return testArithProgr(arr, arr.Length - 2, arr[arr.Length - 1] - arr[arr.Length - 2]);
        }

        private static bool testArithProgr(int[] arr, int last, int d)
        {
            if (last == 0) return true;
            if (arr[last] - arr[last - 1] != d) return false;
            return testArithProgr(arr, last - 1, d);
        }


            static void Main(string[] args)
        {
            BinNode<double> tree = new BinNode<double>(1);
            BuildTree(tree);
            Console.WriteLine(TRG23(tree) - TRG23b(tree));


        }
    }
}
