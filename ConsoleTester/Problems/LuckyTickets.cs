using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class LuckyTickets
        : IProblem
    {
        public string Solve(string[] input)
        {
            int n = Int32.Parse(input[0]);
            
            List<long> arr = new List<long>();
            arr = CalculateLuckyTicket(n, arr);

            long result = 0;
            arr.ForEach(x => result += x * x);
            return result.ToString();
        }

        private List<long> CalculateLuckyTicket(int n, List<long> curArr)
        {
            if (n <= 0)
                return curArr;

            if (n == 1)
                return new List<long>(10) {1, 1, 1, 1, 1, 1, 1, 1, 1, 1};

            curArr = CalculateLuckyTicket(n - 1, curArr);

            var newLength = curArr.Count + 9;
            var newArr = new List<long>(newLength);
            for (int i = 0; i < newLength; ++i)
            {
                long q = 0;
                for (int j = 0; j < 10; ++j)
                {
                    if(i - j >= 0 && i - j < curArr.Count)
                        q += curArr[i - j];
                }

                newArr.Add(q);
            }

            return newArr;
        }
    }
}