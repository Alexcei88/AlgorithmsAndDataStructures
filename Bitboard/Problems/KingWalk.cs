using System;
using ConsoleTester.Helpers;

namespace ConsoleTester.Problems
{
    public class KingWalk
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            ulong pos = 1UL << Int32.Parse(input[0]);
            ulong posA = 0xfefefefefefefefe & pos;
            ulong posH = 0x7f7f7f7f7f7f7f7f & pos;

            ulong availablePosition = posA << 7 | pos << 8 | posH << 9 |
                                      posA >> 1 |            posH << 1 |
                                      posA >> 9 | pos >> 8 | posH >> 7;
            
            return new[] { BitBoardHelper.PopCnt(availablePosition).ToString(), availablePosition.ToString()};

        }
    }
}