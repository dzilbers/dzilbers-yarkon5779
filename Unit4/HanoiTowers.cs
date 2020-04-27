using Stack;

namespace Unit4
{
    class HanoiTowers
    {
        Stack<int>[] poles = { new Stack<int>(), new Stack<int>(), new Stack<int>() };
        int amount;

        public HanoiTowers(int numOfDiscs)
        {
            amount = numOfDiscs;
            poles = new Stack<int>[3];
            for (int i = 2; i >= 0; --i)
                poles[i] = new Stack<int>();
            for (int i = numOfDiscs; i > 0; --i)
                poles[0].Push(i);
        }

        public bool MoveDisc(int fromPoleNum, int toPoleNum)
        {
            if (IsEmpty(fromPoleNum)) return false;
            bool check = IsEmpty(toPoleNum) || (GetSizeTopDisc(fromPoleNum) < GetSizeTopDisc(toPoleNum));
            poles[toPoleNum].Push(poles[fromPoleNum].Pop());
            return check;
        }

        public int GetNumOfDiscs()
        {
            return GetNumOfDiscs(0) + GetNumOfDiscs(1) + GetNumOfDiscs(2);
        }

        public int GetNumOfDiscs(int poleNum)
        {
            if (IsEmpty(poleNum)) return 0;
            int temp = poles[poleNum].Pop();
            int count = 1 + GetNumOfDiscs(poleNum);
            poles[poleNum].Push(temp);
            return count;
        }

        public int GetSizeTopDisc(int poleNum)
        {
            return poles[poleNum].Top();
        }

        public bool IsEmpty(int poleNum)
        {
            return poles[poleNum].IsEmpty();
        }

        public override string ToString()
        {
            Stack<int> temp = new Stack<int>();
            string str = "";
            for (int i = 0; i < 3; ++i)
            {
                int count = 0;
                while (!poles[i].IsEmpty()) temp.Push(poles[i].Pop());
                while (!temp.IsEmpty())
                {
                    ++count;
                    str += string.Format("{0,2}, ", temp.Top());
                    poles[i].Push(temp.Pop()); 
                }
                while (count++ < amount)
                    str += "    ";
                str += '\n';
            }
            return str;
        }
    }
}
