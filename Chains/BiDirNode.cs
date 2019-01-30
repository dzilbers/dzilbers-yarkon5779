using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class BiDirNode<T>
    {
        private T value;
        private BiDirNode<T> prev;
        private BiDirNode<T> next;
        public BiDirNode(T value)
        {
            prev = null;
            next = null;
            this.value = value;
        }
        public BiDirNode(T value, BiDirNode<T> prev, BiDirNode<T> next)
        {
            this.prev = prev;
            this.next = next;
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
        public BiDirNode<T> GetPrev()
        {
            return prev;
        }
        public void SetPrev(BiDirNode<T> prev)
        {
            this.prev = prev;
        }
        public bool HasPrev()
        {
            return prev != null;
        }
        public BiDirNode<T> GetNext()
        {
            return next;
        }
        public void SetNext(BiDirNode<T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            return next != null;
        }
    }
}
