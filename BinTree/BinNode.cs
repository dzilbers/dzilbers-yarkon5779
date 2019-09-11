using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    public class BinNode<T>
    {
        private T value;
        private BinNode<T> left;
        private BinNode<T> right;

        public BinNode(T value)
        {
            this.value = value;
            left = right = null;
        }
        public BinNode(T value, BinNode<T> left, BinNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public bool HasLeft()
        {
            return left != null;
        }
        public bool HasRight()
        {
            return right != null;
        }

        public T GetValue()
        {
            return value;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }

        public BinNode<T> GetLeft()
        {
            return left;
        }
        public void SetLeft(BinNode<T> left)
        {
            this.left = left;
        }

        public BinNode<T> GetRight()
        {
            return right;
        }
        public void SetRight(BinNode<T> right)
        {
            this.right = right;
        }

        public override string ToString()
        {
            return "[" + value + "]\n/   \\";
        }
    }
}
