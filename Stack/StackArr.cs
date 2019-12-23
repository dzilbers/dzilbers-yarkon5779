using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chains;

namespace Stack
{
    public class StackArr<T>
    {
        private const int STACK_SIZE = 100;
        private T [] data;
        private int top;

        public StackArr()
        {
            data = new T [STACK_SIZE];
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void Push(T x) {
            if (++top == data.Length)
            {
                T[] temp = new T[data.Length + STACK_SIZE];
                Array.Copy(data, 0, temp, 0, data.Length);
                data = temp;
            }
            data[top] = x;
        }

        public T Pop()
        {
            if (top == -1)
                return default(T);
            return data[top--];
        }

        public T Top() {
            return top == -1 ? default(T) : data[top];
        }

        override public string ToString()
        {
            string s = "]";
            for (int i = top; i >=0; --i)
            {
                s += " " + data[i];
                s += i == 0 ? " ]" : ",";
            }
            return s;
        }
    }
}
