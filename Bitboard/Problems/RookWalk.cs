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
            ulong rowMask = 0xff;
            // for (int i = 0; i < 8; ++i)
            // {
            //     rowMask = rowMask << 8;
            //     var value = rowMask & pos;
            //     if (value > 0)
            //     {
            //         rowMask = rowMask ^ pos;
            //         break;
            //     }
            // }

            // ulong rowMask2 = rowMask << 8;
            // ulong rowMask3 = rowMask << 16;
            // ulong rowMask4 = rowMask << 32;
            // ulong rowMask5 = rowMask << 64;
            // ulong rowMask6 = rowMask << 128;
            // ulong rowMask7 = rowMask << 256;
            // ulong rowMask8 = rowMask << 512;

            //for(int i = 0; i < 8; ++)


            /*
            // row
            int rowNumber = 0;
            ulong tempPos = pos >> 8;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 8;
                rowNumber++;
            }

            ulong rowMask = 0xffUL << 8 * rowNumber & ~pos;
            
            tempPos = pos;
            // column
            
            ulong columnMask = 0;
            while (tempPos != 0)
            {
                tempPos = tempPos << 8;
                columnMask |= tempPos;
            }
            tempPos = pos;
            while (tempPos != 0)
            {
                tempPos = tempPos >> 8;
                columnMask |= tempPos;
            }

            ulong result = columnMask | rowMask;
            return new[] { BitBoardHelper.PopCnt(result).ToString(), result.ToString()};
            
*/
            return new[] {"dfd", "dfd"};
        }
    }
}