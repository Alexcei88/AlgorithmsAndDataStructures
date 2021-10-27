using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class BellmanFordProblem
        : IProblem
    {
        private List<(int index, int weight)>[] _adjacencyVec;
        private (int weight, int fromVertex)[] _shortestLength;

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
            _shortestLength = new (int, int)[N];
            for (int i = 0; i < N; ++i)
                _shortestLength[i] = (int.MaxValue, i);
            _shortestLength[startIndex] = (0, startIndex);

            for (int i = 0; i < N - 1; ++i)
            {
                var wasRelax = false;
                for (int j = 0; j < _adjacencyVec.Length; ++j)
                {
                    foreach (var e in _adjacencyVec[j])
                    {
                        if (_shortestLength[j].weight < int.MaxValue)
                        {
                            int newWeight = _shortestLength[j].weight + e.weight;
                            if (_shortestLength[e.index].weight > newWeight)
                            {
                                _shortestLength[e.index] = (newWeight, j);
                                wasRelax = true;
                            }
                        }
                    }
                }
                if(!wasRelax)
                    break;;
            }

            var path = TraversePath(startIndex, endIndex, out int bestPathLength);
            return new[]
            {
                bestPathLength.ToString(),
                string.Join(" ", path.Select(g => g.ToString()))
            };
        }
        
        private int[] TraversePath(int startIndex, int endIndex, out int bestPathLength)
        {
            bestPathLength = _shortestLength[endIndex].weight;
            int current = endIndex;
            Stack<int> paths = new Stack<int>();
            paths.Push(current);
            
            while (current != startIndex)
            {
                current = _shortestLength[current].fromVertex;
                paths.Push(current);
            }

            return paths.ToArray();
        }
    }
}