using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    public class BinTreeNode<T>
    {
        private T value;
        private BinTreeNode<T> left;
        private BinTreeNode<T> right;

        public BinTreeNode(T value)
        {
            this.value = value;
            left = right = null;
        }
        public BinTreeNode(T value, BinTreeNode<T> left, BinTreeNode<T> right)
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
        public void GetValue(T value)
        {
            this.value = value;
        }

        public BinTreeNode<T> GetLeft()
        {
            return left;
        }
        public void GetLeft(BinTreeNode<T> left)
        {
            this.left = left;
        }

        public BinTreeNode<T> GetRight()
        {
            return right;
        }
        public void GetRight(BinTreeNode<T> right)
        {
            this.right = right;
        }

        public override string ToString()
        {
            return "[" + value + "]\n/   \\";
        }
    }
}
