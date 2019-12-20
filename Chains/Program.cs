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
        static void Main(string[] args)
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

    }
}
