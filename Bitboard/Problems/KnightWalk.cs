using System;
using ConsoleTester.Helpers;

namespace ConsoleTester.Problems
{
    public class KnightWalk
        : IProblem
    {
        public string[] Solve(string[] input)
        {
            ulong pos = 1UL << Int32.Parse(input[0]);
            ulong posA = 0xfefefefefefefefe & pos;
            ulong posH = 0x7f7f7f7f7f7f7f7f & pos;
            ulong posAB = 0xfcfcfcfcfcfcfcfc & pos;
            ulong posGH = 0x3f3f3f3f3f3f3f3f & pos;

            ulong availablePosition = posAB <<  6 | posAB >> 10 | 
                                      posA << 15 | posA >> 17 | 
                                      posH << 17 | posH >> 15 | 
                                      posGH << 10 | posGH >>  6; 
            
            return new[] { BitBoardHelper.PopCnt(availablePosition).ToString(), availablePosition.ToString()};

        }
    }
}