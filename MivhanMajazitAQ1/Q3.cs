using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chains;

namespace MivhanMajazitA
{
    // Using BiDirNode instead of BinNode because that is what I have defined in Chains project
    class Q3
    {
        public static BiDirNode<int> FirstLeft(BiDirNode<int> pos)
        { // A: total 10pt
            while (pos.GetPrev() != null)   // 4pt
                pos = pos.GetPrev();        // 4pt
            return pos;                     // 2pt
        }

        public static BiDirNode<int> FirstRight(BiDirNode<int> pos)
        {
            while (pos.GetNext() != null)
                pos = pos.GetNext();
            return pos;
        }

        public static bool What(BiDirNode<int> pos)
        {
            BiDirNode<int> left = FirstLeft(pos);
            BiDirNode<int> right = FirstRight(pos);

            int sum = left.GetValue() + right.GetValue();
            left = left.GetNext();
            right = right.GetPrev();

            while ((left != right) && (left.GetNext() != right) &&
                   (left.GetValue() + right.GetValue() != sum))
            {
                left = left.GetNext();
                right = right.GetPrev();
            }
            if (left == right)
                return right.GetValue() == sum;

            if (left.GetNext() == right)
                return left.GetValue() + right.GetValue() == sum;
            return false;
            // return left.GetValue() + right.GetValue() == sum;
        }
        // B1 30pt מעקב ביצוע
        // B2 10pt

    }
}
