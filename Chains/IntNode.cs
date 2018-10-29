using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chains
{
    public class IntNode
    {
        int info;
        IntNode next;

        public IntNode(int x)
        {
            info = x;
            next = null;
        }
        public IntNode(int x, IntNode next)
        {
            info = x;
            this.next = next;
        }

        public int GetInfo()
        {
            return info;
        }
        public void SetInfo(int x)
        {
            info = x;
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
            return "(" + info + ")";
        }

        public void InsertAfter(IntNode temp)
        {
            temp.SetNext(this.GetNext());
            this.SetNext(temp);
        }
    }
}
