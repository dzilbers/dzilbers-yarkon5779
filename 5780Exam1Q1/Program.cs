using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5780Exam1Q1
{
    // חלק ב' שאלה 2
    public class Worker
    {
        string name;
        int seniority;

        public Worker(string name, int seniority)
        {
            this.name = name;
            this.seniority = seniority;
        }

        public string GetName()
        {
            return this.name;
        }
        public int GetSeniority()
        {
            return this.seniority;
        }
    }

    public class Program
    {
        // חלק א', שאלה 1
        public static int Exact(string[] arr, int num)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i].Length == num)
                    ++counter;
            return counter;
        }

        // חלק ב' שאלה 2
        
        // חלק ב' שאלה 3
        public static int[] What(int[] arr, int k)
        {
            int n = arr.Length;
            int[] b = new int[n];
            int[] c = new int[k + 1];

            for (int i = 0; i < k + 1; ++i) c[i] = 0;
            for (int j = 0; j < n; ++j) c[arr[j]] = c[arr[j]] + 1;    //*
            for (int i = 1; i < k + 1; ++i) c[i] = c[i] + c[i - 1];   //**

            for (int j = n - 1; j >= 0; --j)                          //*** 
            {
                b[c[arr[j]] - 1] = arr[j];
                c[arr[j]] = c[arr[j]] - 1;
            }
            return b;
        }
        public static void Main(string[] args)
        {
            // חלק א', שאלה 1
            int[] arr = { 5, 0, 2, 1, 3, 0, 5 };
            arr = What(arr, 5);
            for (int i = 0; i < arr.Length; ++i) Console.WriteLine(arr[i]);

            // חלק ב' שאלה 2
            Worker[] workers = new Worker[500];
            for (int i = 0; i < workers.Length; ++i)
            {
                Console.Write("Enter worker name: ");
                string name = Console.ReadLine();
                Console.Write("Enter " + name + "'s serniority: ");
                int seniority = int.Parse(Console.ReadLine());
            }
        }
    }
}
