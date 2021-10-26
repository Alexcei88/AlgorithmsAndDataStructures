using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class DijkstraProblem
        : IProblem
    {
        private List<(int index, int weight)>[] _adjacencyVec;
        private (int weight, int vertex)[] _shortestLength;

        public string[] Solve(string[] input)
        {
            int N = int.Parse(input[0], CultureInfo.InvariantCulture);
            _adjacencyVec = new List<(int, int)>[N];
            for (int i = 0; i < N; ++i)
            {
                _adjacencyVec[i] = new();
                if (!string.IsNullOrEmpty(input[i + 1]))
                {
                    var line = input[i + 1].Split(' ');
                    for (int j = 0; j < line.Length; j += 2)
                    {
                        int v = int.Parse(line[j]);
                        int weight = int.Parse(line[j + 1]);
                        _adjacencyVec[i].Add((v, weight));
                    }
                }
            }

            string endVertex = input[N + 1];
            int startIndex = int.Parse(endVertex.Split(' ')[0]);
            int endIndex = int.Parse(endVertex.Split(' ')[1]);

            // initialize
            _shortestLength = new (int weight, int vertex)[N];
            for (int i = 0; i < N; ++i)
                _shortestLength[i] = (int.MaxValue, i);
            _shortestLength[startIndex] = (0, startIndex);

            bool[] visited = new bool[N];
            bool isExistPath = FindPath(startIndex, visited, endIndex);
            if (isExistPath)
            {
                var path = TraversePath(startIndex, endIndex, out int bestPathLength);
                return new[]
                {
                    bestPathLength.ToString(),
                    string.Join(" ", path.Select(g => g.ToString()))
                };
            }
            return new[] { "-1" };
        }

        private bool FindPath(int current, bool[] visited, int endIndex)
        {
            if(visited[current])
                return true;

            visited[current] = true;
            int indexWithMinPath = FindMinPath(current, visited);
            if (indexWithMinPath == -1)
                return false;
            if (current != endIndex)
                return FindPath(indexWithMinPath, visited, endIndex);

            return true;
        }

        private int FindMinPath(int current, bool[] visited)
        {
            (int weight, int index) selectedPath = (Int32.MaxValue, -1);
            foreach (var vec in _adjacencyVec[current])
            {
                if(visited[vec.index])
                    continue;
                
                int bestWeight;
                if (_shortestLength[current].weight == Int32.MaxValue)
                    bestWeight = Int32.MaxValue;
                else
                    bestWeight = _shortestLength[current].weight + vec.weight;
                
                if (bestWeight < _shortestLength[vec.index].weight)
                    _shortestLength[vec.index] = (bestWeight, current);

                if (bestWeight < selectedPath.weight )
                    selectedPath = (bestWeight, vec.index);
            }

            return selectedPath.index;
        }

        private int[] TraversePath(int startIndex, int endIndex, out int bestPathLength)
        {
            bestPathLength = _shortestLength[endIndex].weight;
            int current = endIndex;
            Stack<int> paths = new Stack<int>();
            paths.Push(current);
            
            while (current != startIndex)
            {
                current = _shortestLength[current].vertex;
                paths.Push(current);
            }

            return paths.ToArray();
        }
    }
}