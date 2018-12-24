using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st1 = new Stack<int>();
            st1.Push(4);
            st1.Push(2);
            st1.Push(9);
            Console.WriteLine(st1);
        }
    }
}
