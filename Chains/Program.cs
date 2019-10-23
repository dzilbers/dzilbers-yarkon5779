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
            if (chain.GetInfo() > x)
                chain = new IntNode(x, chain);
            else
                while (chain.GetNext() != null && chain.GetNext().GetInfo() < x)
                    chain = chain.GetNext();
            chain.SetNext(new IntNode(x, chain.GetNext()));
        }

        static Random rand = new Random();
        static IntNode chain = null;
        static void Main(string[] args)
        {
            
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

    }
}
