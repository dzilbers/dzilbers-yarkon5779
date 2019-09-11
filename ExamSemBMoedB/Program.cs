using BinTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSemBMoedB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q2
            BinNode<int> t1 = new BinNode<int>(1);
            BinNode<int> t1l1n1 = new BinNode<int>(2);
            BinNode<int> t1l1n2 = new BinNode<int>(3);
            t1.SetLeft(t1l1n1);
            t1.SetRight(t1l1n2);
            BinNode<int> t1l2n1 = new BinNode<int>(4);
            BinNode<int> t1l2n2 = new BinNode<int>(5);
            t1l1n1.SetLeft(t1l2n1);
            t1l1n1.SetRight(t1l2n2);
            BinNode<int> t1l2n4 = new BinNode<int>(6);
            t1l1n2.SetRight(t1l2n4);
            BinNode<int> t1l3n3 = new BinNode<int>(7);
            BinNode<int> t1l3n7 = new BinNode<int>(8);
            t1l2n2.SetLeft(t1l3n3);
            t1l2n4.SetLeft(t1l3n7);
            BinNode<int> t1l4n9 = new BinNode<int>(9);
            BinNode<int> t1l4n10 = new BinNode<int>(10);
            t1l3n7.SetLeft(t1l4n9);
            t1l3n7.SetRight(t1l4n10);
            Console.WriteLine(Secret1(t1));
            Console.WriteLine(Secret2(t1));

            // Q2
            BinNode<int> tr = new BinNode<int>(5);
            BinNode<int> lvl1n1 = new BinNode<int>(11);
            BinNode<int> lvl1n2 = new BinNode<int>(11);
            tr.SetLeft(lvl1n1);
            tr.SetRight(lvl1n2);
            BinNode<int> lvl2n1 = new BinNode<int>(8);
            BinNode<int> lvl2n2 = new BinNode<int>(6);
            lvl1n1.SetLeft(lvl2n1);
            lvl1n1.SetRight(lvl2n2);
            BinNode<int> lvl2n3 = new BinNode<int>(7);
            BinNode<int> lvl2n4 = new BinNode<int>(8);
            lvl1n2.SetLeft(lvl2n3);
            lvl1n2.SetRight(lvl2n4);
            BinNode<int> lvl3n1 = new BinNode<int>(3);
            BinNode<int> lvl3n3 = new BinNode<int>(4);
            BinNode<int> lvl3n4 = new BinNode<int>(1);
            BinNode<int> lvl3n8 = new BinNode<int>(3);
            lvl2n1.SetLeft(lvl3n1);
            lvl2n2.SetLeft(lvl3n3);
            lvl2n2.SetRight(lvl3n4);
            lvl2n4.SetRight(lvl3n8);
            Console.WriteLine(Wrap(tr));

            // Q3
            BinNode<int> t3 = new BinNode<int>(3);
            BinNode<int> t3l1n1 = new BinNode<int>(5);
            BinNode<int> t3l1n2 = new BinNode<int>(4);
            t3.SetLeft(t3l1n1);
            t3.SetRight(t3l1n2);
            BinNode<int> t3l2n1 = new BinNode<int>(9);
            BinNode<int> t3l2n2 = new BinNode<int>(-2);
            t3l1n1.SetLeft(t3l2n1);
            t3l1n1.SetRight(t3l2n2);
            BinNode<int> t3l3n4 = new BinNode<int>(8);
            t3l2n2.SetRight(t3l3n4);
            AddLeaves(t3, 7);
            Console.WriteLine();
        }

        public static bool Wrap(BinNode<int> tr)
        {
            return Branch(tr.GetLeft(), tr.GetRight(), " ");
        }

        public static bool Branch(BinNode<int> t1, BinNode<int> t2, string ident)
        {
            if (t1 == null && t2 == null) return true;
            Console.WriteLine(ident + t1.GetValue() + "/" + t2.GetValue());
            if ((t1 != null && t2 == null) || (t1 == null && t2 != null)) return false;
            return t1.GetValue() == t2.GetValue() && Branch(t1.GetLeft(), t2.GetRight(), ident + " ");
        }

        public static int Secret1(BinNode<int> t)
        {
            if (t == null) return 0;
            int x = Secret1(t.GetLeft());
            int y = Secret1(t.GetRight());
            int z;
            if ((t.HasLeft() && t.HasRight()) ||
                (!t.HasLeft() && !t.HasRight()))
                z = 0;
            else
                z = 1;
            return x + y + z;
        }

        public static int Secret2(BinNode<int> t)
        {
            if (t == null) return 0;
            int z = 0;
            if (t.GetLeft() == t.GetRight())
               z = 1;
            int x = Secret2(t.GetLeft());
            int y = Secret2(t.GetRight());
            return x + y + z;
        }

        public static void AddLeaves(BinNode<int> t, int n)
        {
            if (t == null) return;
            if (t.HasLeft() || t.HasRight())
            {
                AddLeaves(t.GetLeft(), n);
                AddLeaves(t.GetRight(), n);
            }
            else if (t.GetValue() > n)
            {
                Console.Write(t.GetValue() + ",");
                t.SetRight(new BinNode<int>(n));
            }
        }


    }
}
