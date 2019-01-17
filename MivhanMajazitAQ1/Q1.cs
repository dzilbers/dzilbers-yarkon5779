using Stack;

namespace MivhanMajazitA
{
    class Q1
    {
        // 25pt
        public static int LastAndRemove(Stack<int> stk) // 4pt
        {
            Stack<int> stkTemp = new Stack<int>(); // 4 pt
            while (!stk.IsEmpty()) // 2pt
                stkTemp.Push(stk.Pop()); // 4pt
            int number = stkTemp.Pop(); // 4pt
            while (!stkTemp.IsEmpty()) // 2pt
                stk.Push(stkTemp.Pop()); // 4pt
            return number; // 1pt
        }

        // 25pt
        public static Stack<TwoItems> StackTwoItems(Stack<int> stk1) // 6pt
        {
            Stack<TwoItems> result = new Stack<TwoItems>(); // 6pt
            while (!stk1.IsEmpty()) // 2pt
                result.Push(new TwoItems(stk1.Pop(), LastAndRemove(stk1))); // 10pt
                    // may be few lines:
                //  {
                //      int n1 = stk1.Pop();                    2pt
                //      int n2 = LastAndRemove(stk1);           2pt
                //      TwoItems item = new TwoItems(n1, n2);   4pt
                //      result.Push(item);                      2pt
                //  }
            return result; // 1pt
        }
    }

    class TwoItems
    {
        int num1, num2;
        public int GetNum1()
        {
            return num1;
        }
        public int GetNum2()
        {
            return num2;
        }
        public TwoItems(int number1, int number2)
        {
            num1 = number1;
            num2 = number2;
        }
    }

}