using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    class Program
    {
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
