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
                Console.WriteLine(bt.GetValue());
                if (bt.HasLeft())
                    q.Insert(bt.GetLeft());
                if (bt.HasRight())
                    q.Insert(bt.GetRight());
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Press a key (enter a char): ");
            char ch1 = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine(ch1);
            ch1 = (char)(ch1 + 1);
            Console.WriteLine(ch1);
        }
    }
}
