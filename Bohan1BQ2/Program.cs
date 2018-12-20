using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bohan1BQ2
{
    class Program
    {
        public static int secret1 (int x, int n)
        {
            if (x == 0)
                return 0;
            return secret1(x - 1, n) + secret2(x - 1, n);
        }

        public static int secret2(int x, int n)
        {
            if (x == 0)
                return 1;
            if (x > n)
            {
                x = n;
                return secret1(x, n) + secret2(x, n);
            }
            else
                return secret1(x - 1, n) + secret2(x - 1, n);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("A: {0}", secret2(3, 10)); // 4
            Console.WriteLine("B: {0}", secret1(secret2(3, 10), 10)); // 8
            Console.WriteLine("C: {0}", secret2(11, 10) == secret2(12, 10)); // TRUE
            // equal because if (x>n) x=n and then the same code
        }
    }
}
