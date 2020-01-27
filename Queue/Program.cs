using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueArray<int> q = new QueueArray<int>();
            for (int i = 0; i < 20; ++i)
                q.Insert(i);
            Console.WriteLine(q);
            Console.Write("Remove: ");
            for (int i = 0; i < 5; ++i)
                Console.Write("" + q.Remove() + ", ");
            Console.WriteLine();
            Console.WriteLine(q);
            for (int i = 20; i < 30; ++i)
                q.Insert(i);
            for (int i = 0; i < 5; ++i)
                Console.Write("" + q.Remove() + ", ");
            Console.WriteLine();
            Console.WriteLine(q);
        }
    }
}