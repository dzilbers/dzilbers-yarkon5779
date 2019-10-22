using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class BinNode<T>
    {
        private T value;
        private BinNode<T> prev;
        private BinNode<T> next;
        public BinNode(T value)
        {
            prev = null;
            next = null;
            this.value = value;
        }
        public BinNode(T value, BinNode<T> prev, BinNode<T> next)
        {
            this.prev = prev;
            this.next = next;
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
        public BinNode<T> GetPrev()
        {
            return prev;
        }
        public void SetPrev(BinNode<T> prev)
        {
            this.prev = prev;
        }
        public bool HasPrev()
        {
            return prev != null;
        }
        public BinNode<T> GetNext()
        {
            return next;
        }
        public void SetNext(BinNode<T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            return next != null;
        }
    }
}
