using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unit4
{
    class HanoiTowersSimulator
    {
        private static int counter;
        private static int amount;

        public static void Play(HanoiTowers ht)
        {
            amount = ht.GetNumOfDiscs();
            counter = 0;
            //Console.Clear();
            //Console.WriteLine(ht);
            if (HanoiTowersMove(ht, 0, 1, amount))
                if (ht.IsEmpty(0) && ht.IsEmpty(2) && ht.GetNumOfDiscs(1) == amount)
                {
                    Console.WriteLine("Successful Hanoi Towers solution");
                    return;
                }
            Console.WriteLine($"Wrong Hanoi Towers solution after {counter} movements");
        }

        private static bool HanoiTowersMove(HanoiTowers ht, int from, int to, int count)
        {
            if (count == 1)
            {
                counter++;
                bool check = ht.MoveDisc(from, to);
                //Thread.Sleep(500);
                //Console.SetCursorPosition(0, 0);
                //Console.WriteLine(ht);
                return check;
            }

            int help = 3 - from - to;
            if (!HanoiTowersMove(ht, from, help, count - 1))
                return false;
            if (!HanoiTowersMove(ht, from, to, 1))
                return false;
            return HanoiTowersMove(ht, help, to, count - 1);
        }
    }
}
