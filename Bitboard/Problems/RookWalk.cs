using System;
using ConsoleTester.Helpers;

namespace ConsoleTester.Problems
{
    public class RookWalk
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            ulong pos = 1UL << Int32.Parse(input[0]);
            
            ulong mask = 0;

            ulong posA = 0xfefefefefefefefe;
            ulong posH = 0x7f7f7f7f7f7f7f7f;

            // row
            ulong tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos << 1 & posA;
                mask |= tempPos;
            }
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 1 & posH;
                mask |= tempPos;
            }
          
            // column
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos << 8;
                mask |= tempPos;
            }
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 8;
                mask |= tempPos;
            }

            return new[] { BitBoardHelper.PopCnt(mask).ToString(), mask.ToString()};
        }
    }
}