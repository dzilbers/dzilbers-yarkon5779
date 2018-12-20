using System;

namespace Bohan1BQ1
{
    class Program
    {
        public static int N = 24, M = 80;
        public static void DrawSquare(int s, int color, int x, int y) { }

        public static void Squares(int s, int color, int x, int y)
        {
            if (s >= 0)
            {
                return;
            }

            DrawSquare(s, color, x, y);
            Squares(s - 2, color, x + 1, y + 1);
        }

        public static void ScreenSaver()
        {
            Random rnd = new Random();
            int s, x, y, color;
            int size = N > M ? M : N;

            s = rnd.Next(size + 1);
            while (s > 0)
            {
                color = rnd.Next(1, 11);
                x = rnd.Next(1, N - size + 1);
                y = rnd.Next(1, M - size + 1);

                Squares(s, color, x, y);

                s = rnd.Next(size + 1);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
