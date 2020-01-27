using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinTree;

namespace MivhanMajazitA
{
    // Using BinNode instead of BinNode because that is what I have defined in Chains project
    class Q3
    {
        public static BinNode<int> FirstLeft(BinNode<int> pos)
        { // A: total 10pt
            while (pos.GetLeft() != null)   // 4pt
                pos = pos.GetLeft();        // 4pt
            return pos;                     // 2pt
        }

        public static BinNode<int> FirstRight(BinNode<int> pos)
        {
            while (pos.GetRight() != null)
                pos = pos.GetRight();
            return pos;
        }

        public static bool What(BinNode<int> pos)
        {
            BinNode<int> left = FirstLeft(pos);
            BinNode<int> right = FirstRight(pos);

            int sum = left.GetValue() + right.GetValue();
            left = left.GetRight();
            right = right.GetLeft();

            while ((left != right) && (left.GetRight() != right) &&
                   (left.GetValue() + right.GetValue() != sum))
            {
                left = left.GetRight();
                right = right.GetLeft();
            }
            if (left == right)
                return right.GetValue() == sum;

            if (left.GetRight() == right)
                return left.GetValue() + right.GetValue() == sum;
            return false;
            // return left.GetValue() + right.GetValue() == sum;
        }
        // B1 30pt מעקב ביצוע
        // B2 10pt

    }
}
