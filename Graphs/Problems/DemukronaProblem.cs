using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class DemukronaProblem
        : IProblem
    {
        private List<int>[] _adjacencyVec;
        
        public string[] Solve(string[] input)
        {
            int N = int.Parse(input[0], CultureInfo.InvariantCulture);
            _adjacencyVec = new List<int>[N];
            for (int i = 0; i < N; ++i)
            {
                _adjacencyVec[i] = new();
                if (!string.IsNullOrEmpty(input[i + 1]))
                {
                    foreach (var v in input[i + 1].Split(' '))
                        _adjacencyVec[i].Add(int.Parse(v));
                }
            }

            List<List<int>> result = new();
            int[] visitedVec = new int[_adjacencyVec.Length];
            while (visitedVec.Any(g => g == 0))
            {
                List<int> indexes = new List<int>();
                for(int i = 0; i < _adjacencyVec.Length; ++i)
                    if (visitedVec[i] != 1 && _adjacencyVec[i].Count == 0)
                        indexes.Add(i);

                result.Add(indexes);
                
                foreach (var idx in indexes)
                {
                    visitedVec[idx] = 1;
                    for (int i = 0; i < _adjacencyVec.Length; ++i)
                    {
                        if(visitedVec[i] != 1)
                            _adjacencyVec[i].Remove(idx);
                    }
                }
            }

            result.Reverse();
            return result.Select(g => string.Join(' ', g)).ToArray();
        }
    }
}