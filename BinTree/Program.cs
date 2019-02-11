using System;
using Queue;

namespace BinTree
{
    public class Program
    {
        public static void TraverseByLevel<T>(BinTreeNode<T> bt)
        {
            Queue<BinTreeNode<T>> q = new Queue<BinTreeNode<T>>();
            q.Insert(bt);
            while (!q.IsEmpty())
            {
                bt = q.Remove();
                // Action on bt
                Console.Write(bt.GetValue() + " ");
                if (bt.HasLeft())
                    q.Insert(bt.GetLeft());
                if (bt.HasRight())
                    q.Insert(bt.GetRight());
            }
        }

        public static void PrintPreOrder<T>(BinTreeNode<T> bt)
        {
            if (bt != null)
            {
                Console.Write(bt.GetValue() + " ");
                PrintPreOrder(bt.GetLeft());
                PrintPreOrder(bt.GetRight());
            }
        }

        public static void PrintInOrder<T>(BinTreeNode<T> bt)
        {
            if (bt != null)
            {
                PrintInOrder(bt.GetLeft());
                Console.Write(bt.GetValue() + " ");
                PrintInOrder(bt.GetRight());
            }
        }

        public static void PrintPostOrder<T>(BinTreeNode<T> bt)
        {
            if (bt != null)
            {
                PrintPostOrder(bt.GetLeft());
                PrintPostOrder(bt.GetRight());
                Console.Write(bt.GetValue() + " ");
            }
        }

        private static bool isDigit(Char c)
        {
            return c >= '0' && c <= '9';
        }

        public static int ComputeExprTree(BinTreeNode<Char> expr)
        {
            Char ch = expr.GetValue();
            if (isDigit(ch))
                return (int)(ch - '0');
            int left = ComputeExprTree(expr.GetLeft());
            int right = ComputeExprTree(expr.GetRight());
            switch (ch)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Press a key (enter a char): ");
            char ch1 = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine(ch1);
            ch1 = (char)(ch1 + 1);
            Console.WriteLine(ch1);
            BinTreeNode<char> a = new BinTreeNode<char>('a');
            BinTreeNode<char> b = new BinTreeNode<char>('b');
            BinTreeNode<char> c = new BinTreeNode<char>('c');
            BinTreeNode<char> d = new BinTreeNode<char>('d');
            BinTreeNode<char> e = new BinTreeNode<char>('e');
            BinTreeNode<char> f = new BinTreeNode<char>('f');
            a.SetLeft(b);
            a.SetRight(c);
            b.SetRight(d);
            c.SetLeft(e);
            c.SetRight(f);
            Console.WriteLine("Preorder:");
            PrintPreOrder(a);
            Console.WriteLine();
            Console.WriteLine("Inorder:");
            PrintInOrder(a);
            Console.WriteLine();
            Console.WriteLine("Postorder:");
            PrintPostOrder(a);
            Console.WriteLine();
            Console.WriteLine("Travers by Levels:");
            TraverseByLevel(a);
        }
    }
}
