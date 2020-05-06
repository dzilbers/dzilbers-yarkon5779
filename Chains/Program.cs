using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    class Program
    {
        public static void InsertIntoSortedChain(IntNode chain, int x) // BAD ONE
        {
            if (chain.GetValue() > x)
                chain = new IntNode(x, chain);
            else
            {
                while (chain.GetNext() != null && chain.GetNext().GetValue() < x)
                    chain = chain.GetNext();
                chain.SetNext(new IntNode(x, chain.GetNext()));
            }
            Console.Write("Inside: ");
            PrintChain(chain);
        }

        static Random rand = new Random();
        static IntNode chain = null;
        static void Main1(string[] args)
        {
            IntNode myChain = new IntNode(4);
            InsertIntoSortedChain(myChain, 5);
            InsertIntoSortedChain(myChain, 7);
            Console.Write("Before: ");
            PrintChain(myChain);
            InsertIntoSortedChain(myChain, 2);
            Console.Write("After: ");
            PrintChain(myChain);
        }

        static void Insert(int x)
        {
            if (null == chain)
            {
                chain = new IntNode(x);
                return;
            }
            IntNode temp = new IntNode(x, chain.GetNext());
            chain.SetNext(temp);
        }

        public static void PrintChain(IntNode chain)
        {
            for (; chain != null; chain = chain.GetNext())
                Console.Write("" + chain + "->");
            Console.WriteLine("#");
        }

        private static bool CheckCyclicH1<T>(Node<T> cycList, Node<T> test)
        {  // cycList –השרשרת, test – חוליה נוכחית
           //              הפעולה תחזיר אמת האם חוליית הבדיקה מפנה לאחת החוליות שלפניה
            if (!test.HasNext()) return false;
            if (test.GetNext() == cycList) return true;
            if (test == cycList) return false;
            return CheckCyclicH1(cycList.GetNext(), test);
        }

        private static bool CheckCyclicH2<T>(Node<T> cycList, Node<T> test)
        {
            if (!test.HasNext()) return false;
            if (CheckCyclicH1(cycList, test)) return true;
            return CheckCyclicH2(cycList, test.GetNext());
        }

        public static bool CheckCyclic<T>(Node<T> cycList)
        {
            return CheckCyclicH2(cycList, cycList);
        }

        public static bool CheckCyclic1<T>(Node<T> cycList)
        {
            if (cycList == null) return false;
            return CheckCyclic1Help(cycList, cycList.GetNext());
        }

        public static bool CheckCyclic1Help<T>(Node<T> list1, Node<T> list2)
        {
            if (list2 == null || !list2.HasNext()) return false;
            if (list1 == list2) return true;
            return CheckCyclic1Help(list1.GetNext(), list2.GetNext().GetNext());
        }

        static void Main(string[] args)
        {
            Node<int> list = new Node<int>(4);
            Node<int> last = list;
            list = new Node<int>(9, list);
            list = new Node<int>(6, list);
            list = new Node<int>(3, list);
            list = new Node<int>(4, list);
            list = new Node<int>(12, list);
            list = new Node<int>(29, list);
            list = new Node<int>(10, list);
            list = new Node<int>(27, list);
            //last.SetNext(list);
            list = new Node<int>(8, list);
            list = new Node<int>(25, list);

            if (CheckCyclic1(list))
                Console.WriteLine("The long list is cyclic");
            else
                Console.WriteLine("The long list is plain");

            Node<string> node = new Node<string>("asdasd");
            if (CheckCyclic1(node))
                Console.WriteLine("The single node is cyclic");
            else
                Console.WriteLine("The long node is plain");
            node.SetNext(node);
            if (CheckCyclic1(node))
                Console.WriteLine("The cycled node is cyclic");
            else
                Console.WriteLine("The cycled node is plain");
        }

    }
}
