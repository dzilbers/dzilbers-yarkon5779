using System;
using Unit4.TowerLib;

namespace Unit4
{
    class HanoiTowersApplication
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Please enter number of discs[3-10]: ");
			int numOfDiscs = Int32.Parse(Console.ReadLine));

			Console.Write("Loading simulation...");

			// יצירת עצם מטיפוס מגדלי הנוי עם מספר דיסקיות שהתקבל מהקלט
			HanoiTowers ht1 = new HanoiTowers(numOfDiscs);

			// הפעלת מגדלי הנוי במצב סימולציה עם השהייה של שנייה אחת  
			Unit4..HanoiTowersSimulator.simulate(ht1, 1000);

			// להפעלת מגדלי הנוי במצב משחק עם העכבר, החליפו את השורה האחרונה בשורה הבאה  
			// HanoiTowersSimulator.play(ht1);
		}
	}
}
