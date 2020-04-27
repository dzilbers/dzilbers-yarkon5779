using System;
using Unit4.TowerLib;

namespace Unit4
{
    class HanoiTowersApplication
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("Please enter number of discs[3-10]: ");
			int numOfDiscs = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Loading simulation...");
			HanoiTowers ht1 = new HanoiTowers(numOfDiscs);
			//Console.WriteLine($"Towers before the play:\n{ht1}");
			HanoiTowersSimulator.Play(ht1);
			//Console.WriteLine($"Towers after the play:\n{ht1}");
		}
	}
}
