using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataP51Ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 40;
            int[] grades = new int[num];

            Random r = new Random(new DateTime().Millisecond);
            for (int i = 0; i < num; ++i)
                grades[i] = r.Next() % 40 + 61;

            foreach (int grade in grades)
                Console.Write(" " + grade);
            Console.WriteLine();

            //int counter;
            //for (int x = 0; x <= 100; ++x)
            //{
            //    counter = 0;
            //    for (int i = 0; i < num; ++ i)
            //        if (grades[i] == x)
            //            ++counter;
            //    if (counter > 0)
            //        Console.WriteLine("" + x + ": " + counter + " students");
            //}

            int[] counters = new int[101];
            for (int i = 0; i <= 100; ++i)
                counters[i] = 0;

            for (int i = 0; i < num; ++i)
                ++counters[grades[i]];

            for (int i = 0; i <= 100; ++i)
                if (counters[i] > 0)
                    Console.WriteLine("" + i + ": " + counters[i] + " students");
        }
    }
}
