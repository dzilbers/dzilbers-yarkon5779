using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chains;

namespace Queue
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            first = last = null;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T>(value);
            last.SetNext(node);
            last = node;
        }

        public T Remove()
        {
            T temp = first.GetValue();
            first = first.GetNext();
            return temp;
        }

        public T Head()
        {
            return first.GetValue();
        }

        public override string ToString()
        {
            return "queue";
        }
    }
}
