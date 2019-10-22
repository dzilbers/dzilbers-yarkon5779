using Queue;
using System;
using Chains;
using BinTree;

namespace Bagrut5779
{
    /// <summary>
    /// מחלקת הפנסים
    /// </summary>
    class Flashlight
    {
        /// <summary>
        /// שם מודל הפנס
        /// </summary>
        string model;

        /// <summary>
        /// מחיר הפנס
        /// </summary>
        double price;

        public string GetModel() { return model; } // אינו חללק מהתשובה לשאלון
        public double GetPrice() { return price; } // אינו חללק מהתשובה לשאלון

        /// <summary>
        /// בנאי של פנס המקבל את שם הדגם ואת מחירו
        /// </summary>
        /// <param name="model">שם דגם הפנס</param>
        /// <param name="price">מחיר הפנס</param>
        public Flashlight(string model, double price)
        {
            this.model = model;
            this.price = price;
        }
    }

    class Car
    {
        string licenseNum;
        int price;
        bool hadAccident;
        public Car(string license, int price)
        {
            this.licenseNum = license;
            this.price = price;
        }
        public string GetLicenseNum() { return licenseNum; }
        public int GetPrice() { return price; }
        public bool GetHadAccident() { return hadAccident; }

        // הפעולה בודקת האם מחיר הרכב נמצא בין מינימום למקסימום (כולל) שהתקבלו בפרמטרים
        public bool Range(int min, int max)
        {
            return this.price >= min && this.price <= max;
        }
    }

    class AllCars
    {
        Car[] cars;
        int num;
        public AllCars(int max)
        {
            this.cars = new Car[max];
            this.num = 0;
        }

        public bool AddCar(Car car)
        {
            if (this.num >= this.cars.Length)
            {
                return false;
            }

            this.cars[num++] = car;
            return true;
        }

        public void Print(int min, int max)
        {
            for (int i = 0; i < cars.Length; ++i)
            {
                if (cars[i].Range(min, max) && !cars[i].GetHadAccident())
                {
                    Console.WriteLine(cars[i].GetLicenseNum());
                }
            }
        }
    }

    class Range
    {
        int low;
        int high;
        public int GetLow() { return low;  }
        public int GetHigh() { return high; }
    }

    class Program
    {
        /// <summary>
        /// בגרות תשע"ט
        /// פרק 1
        /// שאלה 1 - חובה
        ///  הפונקציה מקבלת מערך מחרוזות ומספר ומחזירה כמות המחרוזות שבמערך שאורכיהן שווה למספר הזה
        /// </summary>
        /// <param name="arr">מערך המחרוזות</param>
        /// <param name="num">מספר להשוואה עם אורך המחרוזות</param>
        /// <returns>כמות מחרוזות מהמערך באורך נתון</returns>
        public static int Exact(string[] arr, int num)
        {
            int counter = 0;
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                // for (int i = 0; i < arr.Length; ++i) // אפשרות אחרת
                if (arr[i].Length == num)
                {
                    ++counter;
                }
            }

            return counter;
        }

        // פרק 1
        // שאלה 2
        // הפונקציה מדפיסה שלישית מודלים של פנסים שסום מחירם שוה למספר שבפרמטר שלה
        public static void ThreeFlashlights(Flashlight[] arr, double total)
        {
            for (int i = arr.Length - 1; i >= 2; --i)
            {
                for (int j = i - 1; j >= 1; --j)
                {
                    for (int k = j - 1; k >= 0; --k)
                    {
                        if (arr[i].GetPrice() + arr[j].GetPrice() + arr[k].GetPrice() == total)
                        {
                            Console.WriteLine("{1}, {2}, {3}", arr[i].GetModel(), arr[j].GetModel(), arr[k].GetModel());
                            // ניתן גם לא לעשות חזרה מהפונקציה כאן מכיוון שבשאלה נאמר שניתן
                            // להניח שיש רק שלשת מודלים אחת כזו במערך
                            return;
                        }
                    }
                }
            }
        }

        public static int ToNumber(Queue<int> q)
        {
            int num = 0;
            int mult = 1;
            while (!q.IsEmpty())
            {
                num += q.Remove() * mult;
                mult *= 10;
            }
            return num;
        }

        public static int ToNumberRecursive(Queue<int> q)
        {
            return ToNumberRecursive(q, 1);
        }
        private static int ToNumberRecursive(Queue<int> q, int m)
        {
            if (q.IsEmpty()) return 0;
            int num = q.Remove() * m;
            return num + ToNumberRecursive(q, m * 10);
        }

        public static int BigNumber(Node<Queue<int>> lst)
        {
            int max = ToNumber(lst.GetValue());
            for (Node<Queue<int>> cur = lst.GetNext(); cur != null; cur = cur.GetNext())
            {
                int num = ToNumber(lst.GetValue());
                if (num > max)
                    max = num;
            }
            return max;
        }

        public static bool IsLeaf(BinTree.BinNode<Range> tree)
        {
            return !tree.HasLeft() && !tree.HasRight();
        }
        public static bool Order(BinTree.BinNode<Range> tree)
        {
            if (tree == null) return true;
            // if (tree == null || IsLeaf(tree)) return true; // לא חובה לבדוק האם זה עלה
            Range current = tree.GetValue();
            int min = current.GetLow(), max = current.GetHigh();
            Range left = tree.HasLeft() ? tree.GetLeft().GetValue() : null;
            Range right = tree.HasRight() ? tree.GetRight().GetValue() : null;
            if (left != null && (left.GetLow() != min || left.GetHigh() > max)) return false;
            if (right != null && (right.GetHigh() != max || right.GetLow() < min)) return false;
            if (left != null && right != null && left.GetHigh() >= right.GetLow()) return false;
            return Order(tree.GetLeft()) && Order(tree.GetRight());
        }

        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
