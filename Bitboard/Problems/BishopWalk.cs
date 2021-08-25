using System;
using ConsoleTester.Helpers;

namespace ConsoleTester.Problems
{
    public class BishopWalk
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            ulong pos = 1UL << Int32.Parse(input[0]);
            
            ulong posA = 0xfefefefefefefefe;
            ulong posH = 0x7f7f7f7f7f7f7f7f;

            ulong mask = 0;
            ulong tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 9 & posH;
                mask |= tempPos;
            }
            
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 7 & posA;
                mask |= tempPos;
            }
            
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos << 9 & posA;
                mask |= tempPos;
            }

            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos << 7 & posH;
                mask |= tempPos;
            }
            
            return new[] { BitBoardHelper.PopCnt(mask).ToString(), mask.ToString()};
        }
    }
}