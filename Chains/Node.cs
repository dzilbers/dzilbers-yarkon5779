using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class Node<T>
    {
        private T info;
        private Node<T> next;
        public Node(T value)
        {
            next = null;
            this.info = value;
        }
        public Node(T info, Node<T> next)
        {
            this.next = next;
            this.info = info;
        }

        public T GetInfo()
        {
            return info;
        }
        public void SetInfo(T info)
        {
            this.info = info;
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
