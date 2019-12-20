using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chains;

namespace Stack
{
    public class Stack<T>
    {
        private Node<T> first;

        public Stack()
        {
            first = null;
        }
        public bool IsEmpty()
        {
            return first == null;
        }
        public void Push(T x) {
            first = new Node<T>(x, first);
        }
        public T Pop()
        {
            if (IsEmpty())
                return default(T);
            T tmp = Top();         // T tmp = first.GetValue();
            first = first.GetNext();
            return tmp;
        }
        public T Top() {
            return IsEmpty() ? default(T) : first.GetValue();
        }

        override public string ToString()
        {
            string s = "]";
            for (Node<T> curr = first; curr != null; curr = curr.GetNext())
            {
                s += " " + curr.GetValue();
                s += curr.GetNext() == null ? " ]" : ",";
            }
            return s;
        }
    }
}
