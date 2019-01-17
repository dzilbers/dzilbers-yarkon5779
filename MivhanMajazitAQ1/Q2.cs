using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MivhanMajazitA
{
    class Q2
    {
    }

    public class Pole
    {
        public Pole() { }
        public void Add(Ring r) { }
        public Ring Remove() { return null; }
        public bool IsEmpty() { return true; }

        // O(n) סיבוכיות של הפונקציה היא
        // n*O(1) סובוכיות הלולאה הראשונה
        // n*O(1) סובוכיות שתי הלולאות הנוספות סה"כ
        // 2n*O(1) ביחד
        // O(n) שזה סיבוכיות
        // 10 points
        public void Sort()
        {
            Pole poleLarge = new Pole();        // 2pt
            Pole poleSmall = new Pole();        // 2pt
            Ring ring;                          // 2pt

            while(!IsEmpty())                   // 2pt
            {
                ring = Remove();                // 2pt
                if (ring.GetSize().Equals("L")) // 6pt
                    poleLarge.Add(ring);        // 4pt
                else
                    poleSmall.Add(ring);        // 4pt
            }

            while (!poleLarge.IsEmpty())        // 2pt
                Add(poleLarge.Remove());        // 6pt

            while (!poleSmall.IsEmpty())        // 2pt
                Add(poleSmall.Remove());        // 6pt
        }
    }

    public class Ring
    {
        private string size; // גודל הטבעת
        private int color; // צבע הטבעת
        public Ring()
        {
            this.size = "L";
            this.color = 0;
        }
        public Ring(string str, int c)
        {
            this.size = str;
            this.color = c;
        }
        public string GetSize()
        {
            return this.size;
        }
        public int GetColor()
        {
            return this.color;
        }
    }
}
