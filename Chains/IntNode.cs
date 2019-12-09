using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class IntNode
    {
        int value;
        IntNode next;

        public IntNode(int x)
        {
            value = x;
            next = null;
        }
        public IntNode(int x, IntNode next)
        {
            value = x;
            this.next = next;
        }

        public int GetValue()
        {
            return value;
        }
        public void SetValue(int x)
        {
            value = x;
        }

        public IntNode GetNext()
        {
            return next;
        }
        public void SetNext(IntNode next)
        {
            this.next = next;
        }

        public override string ToString()
        {
            return "(" + value + ")";
        }

        public void InsertAfter(IntNode temp)
        {
            temp.SetNext(this.GetNext());
            this.SetNext(temp);
        }
    }
}
