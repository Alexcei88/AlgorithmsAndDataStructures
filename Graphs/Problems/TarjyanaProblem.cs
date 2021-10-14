using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class TarjyanaProblem
        : IProblem
    {
        private List<int[]> _components = new();
        private enum Color
        {
            White = 0,
            Gray = 1,
        }
        private List<int>[] _adjacencyVec;
        private Color[] _vertexColors; // 0 - white 1 - gray // 2 - black
        
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

            _vertexColors = new Color[_adjacencyVec.Length];
            Stack<int> blackNodes = new Stack<int>();
            int[] lowLink = new int[_adjacencyVec.Length];
            for (int i = 0; i < _adjacencyVec.Length; ++i)
            {
                if (_vertexColors[i] == 0)
                {
                    DepthRoundTree(i, blackNodes, _vertexColors, lowLink);
                }
            }

            return _components.Select(g => string.Join(' ', g)).ToArray();
        }
        
        private void DepthRoundTree(int current, Stack<int> nodes, Color[] colors, int[] lowLink)
        {
            colors[current] = Color.Gray;
            nodes.Push(current);
            lowLink[current] = current;
            
            foreach (var v in _adjacencyVec[current])
            {
                if (colors[v] == Color.White)
                {
                    DepthRoundTree(v, nodes, colors, lowLink);
                    lowLink[current] = Math.Min(lowLink[current], lowLink[v]);
                }
                else if (colors[v] == Color.Gray)
                    lowLink[current] = Math.Min(lowLink[v], current);
            }

            if (lowLink[current] == current)
            {
                List<int> result = new();
                int w;
                do
                {
                    w = nodes.Pop();
                    result.Add(w);
                } while (current != w);
                if(result.Count > 2)
                    _components.Add(result.OrderBy(g => g).ToArray());
            }
        }
    }
}