using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(T value)
        {
            next = null;
            this.value = value;
        }
        public Node(T value, Node<T> next)
        {
            this.next = next;
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
        public void SetInfo(T value)
        {
            this.value = value;
        }
        public Node<T> GetNext()
        {
            return next;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

        public bool HasNext()
        {
            return next != null;
        }
    }
}
