using System;
using Queue;
using Stack;

namespace BinTree
{
    public class Program
    {
        public static void TraverseByLevel<T>(BinNode<T> bt)
        {
            Queue<BinNode<T>> q = new Queue<BinNode<T>>();
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

        public static void PrintPreOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                Console.Write(bt.GetValue() + " ");
                PrintPreOrder(bt.GetLeft());
                PrintPreOrder(bt.GetRight());
            }
        }

        public static void PrintInOrder<T>(BinNode<T> bt)
        {
            if (bt != null)
            {
                PrintInOrder(bt.GetLeft());
                Console.Write(bt.GetValue() + " ");
                PrintInOrder(bt.GetRight());
            }
        }

        public static void PrintPostOrder<T>(BinNode<T> bt)
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

        public static int ComputeExprTree(BinNode<Char> expr)
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

        public static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        // expression string is always correct
        // digits and operations, while any expression or sub-expression is in ()
        // ((2*3)+((8/2)*4))
        public static BinNode<char> BuildExprTree(string expr)
        {
            Stack<BinNode<char>> nodes = new Stack<BinNode<char>>();
            foreach (var c in expr)
            {
                if (c == ')')
                {
                    BinNode<char> right = nodes.Pop();
                    BinNode<char> oper = nodes.Pop();
                    BinNode<char> left = nodes.Pop();
                    oper.SetLeft(left);
                    oper.SetRight(right);
                    nodes.Push(oper);
                }
                else if (c != '(')
                {
                    nodes.Push(new BinNode<char>(c));
                }
            }
            return nodes.Pop();
        }

        static void Main(string[] args)
        {
            Console.Write("Press a key (enter a char): ");
            char ch1 = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine(ch1);
            ch1 = (char)(ch1 + 1);
            Console.WriteLine(ch1);
            BinNode<char> a = new BinNode<char>('a');
            BinNode<char> b = new BinNode<char>('b');
            BinNode<char> c = new BinNode<char>('c');
            BinNode<char> d = new BinNode<char>('d');
            BinNode<char> e = new BinNode<char>('e');
            BinNode<char> f = new BinNode<char>('f');
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
            Console.WriteLine();

            //Console.WriteLine(ComputeExprTree(BuildExprTree("((2*3)+((8/2)*4))")));
        }
    }
}
