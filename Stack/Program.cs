using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        // to אל ראש המסנית  from הפעולה תעביר בסדר הפוך את כל התוכן של מחסנית
        // :למשל אם תוכן המחסניות לפני זימון הפעולה
        // from: [1,2,3[     to: [4, 5[
        // :אחרי הזימון יהיה
        // from: [1,2,3,5,4[     to: [  (empty)
        public static void RevertStack<T>(Stack<T> from, Stack<T> to)
        {
            while (!from.IsEmpty())
                to.Push(from.Pop());
        }

        // to אל ראש המסנית  from הפעולה תעביר באותו את כל התוכן של מחסנית
        // :למשל אם תוכן המחסניות לפני זימון הפעולה
        // from: [1,2,3[     to: [4, 5[
        // :אחרי הזימון יהיה
        // from: [1,2,3,4,5[     to: [  (empty)
        public static void PutOnTop<T>(Stack<T> from, Stack<T> to)
        {
            Stack<T> temp = new Stack<T>();
            RevertStack(from, temp);
            RevertStack(temp, to);
        }

        // תרגיל בדיקת הסוגריים בביטוי מתמטי
        public static bool CheckParenthesis(string expression)
        {
            Stack<char> stk = new Stack<char>();
            foreach (char ch in expression)
            // for (int i = 0; i < expression.Length; ++i) { char ch = expression[i]; ...
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                    case '{':
                        stk.Push(ch);
                        break;
                    case ')':
                        if (stk.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (stk.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (stk.Pop() != '{')
                            return false;
                        break;
                }
            }
            return stk.IsEmpty();
        }

        static Dictionary<char, char> parenthesis = new Dictionary<char, char>()
                                                        { { ')', '(' }, { ']', '[' }, { '}', '{' } };
        public static bool CheckParenthesisAdvanced(string expression)
        {
            Stack<char> stk = new Stack<char>();
            foreach (char ch in expression)
            // for (int i = 0; i < expression.Length; ++i) { char ch = expression[i]; ...
            {
                switch (ch)
                {
                    case '(':
                    case '[':
                    case '{':
                        stk.Push(ch);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (stk.IsEmpty() || stk.Pop() != parenthesis[ch])
                            return false;
                        break;
                }
            }
            return stk.IsEmpty();
        }

        static void Main(string[] args)
        {
            Stack<int> st1 = new Stack<int>();
            st1.Push(4);
            st1.Push(2);
            st1.Push(9);
            Console.WriteLine(st1);

            Console.WriteLine(CheckParenthesis("(2+3-[1*3])+{3*2}"));
            Console.WriteLine(CheckParenthesis("(2+3-[1*3]))+{3*2}"));
            Console.WriteLine(CheckParenthesis("(2+3-[1*3]+{3*2}"));
            Console.WriteLine(CheckParenthesis("(2+3-[1*3)]+{3*2}"));
        }
    }
}
