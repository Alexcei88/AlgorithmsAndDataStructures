using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class RecursiveKosaraju
        : IProblem
    {
        private int[][] _adjacencyVec;
        private int[] _weights;
        private int maxAdjPow = 5;
        private List<int[]> _components;

        public string[] Solve(string[] input)
        {
            _components = new List<int[]>();
            int N = int.Parse(input[0], CultureInfo.InvariantCulture);
            _adjacencyVec = new int[N][];
            for (int i = 0; i < N; ++i)
            {
                _adjacencyVec[i] = new int[maxAdjPow];
                Array.Fill(_adjacencyVec[i], -1);
            }

            for (int i = 0; i < N; ++i)
            {
                int j = 0;
                if (!string.IsNullOrEmpty(input[i + 1]))
                {
                    foreach (var v in input[i + 1].Split(' '))
                        _adjacencyVec[i][j++] = int.Parse(v);
                }
            }

            var reverseAdjacencyVec = CreateReverseAdjacencyVec();
            Stack<int> paths = new Stack<int>();
            FullDepthRoundTree(reverseAdjacencyVec, paths, new byte[reverseAdjacencyVec.Length]);
            FillWeight(new Stack<int>(new Stack<int>(paths)));
            
            var visited = new byte[_adjacencyVec.Length];
            while (paths.TryPop(out int current))
            {
                var component = new List<int>();
                DepthRoundTree(_adjacencyVec, current, visited, component);
                if(component.Count > 2)
                    _components.Add(component.ToArray());
                while (paths.TryPeek(out int next))
                {
                    if (visited[next] == 1)
                        paths.Pop();
                    else
                        break;
                }
            }
            
            var result = new List<string>();
            result.Add(_components.Count.ToString());
            foreach (var component in _components)
            {
                result.Add(string.Join(' ', component.OrderBy(g => g)));
            }
            
            return result.ToArray();
        }

        private void FillWeight(Stack<int> paths)
        {
            _weights = new int[_adjacencyVec.Length];
            int weight = 0;
            while (paths.TryPop(out int next))
            {
                _weights[next] = weight;
                ++weight;
            }
        }
        
        private void FullDepthRoundTree(int[][] vec, Stack<int> paths, byte[] visited)
        {
            while (visited.Any(g => g == 0))
            {
                int index = 0;
                while (index < visited.Length && visited[index] == 1)
                    ++index;

                DepthRoundTree(vec, index, paths, visited);
            }
        }
        
        private void DepthRoundTree(int[][] vec, int current, Stack<int> paths, byte[] visited)
        {
            if(visited[current] == 1) 
                return;
            
            visited[current] = 1;
            foreach (var v in vec[current].Where(g => g >= 0))
                DepthRoundTree(vec, v, paths, visited);
            
            paths.Push(current);
        }
        
        private void DepthRoundTree(int[][] vec, int current, byte[] visited, List<int> graph)
        {
            if(visited[current] == 1)
                return;
            
            visited[current] = 1;
            graph.Add(current);

            var adjacencyEdges = vec[current].Where(g => g >= 0 && visited[g] == 0).OrderBy(g=> _weights[g]);
            foreach (var v in adjacencyEdges)
                DepthRoundTree(vec, v, visited, graph);
        }

        private int[][] CreateReverseAdjacencyVec()
        {
            var reverseAdjacencyVec = new int[_adjacencyVec.Length][];
            for (int i = 0; i < _adjacencyVec.Length; ++i)
            {
                reverseAdjacencyVec[i] = new int[maxAdjPow];
                Array.Fill(reverseAdjacencyVec[i], -1);
            }

            int[] index = new int[_adjacencyVec.Length];
            for (int i = 0; i < _adjacencyVec.Length; ++i)
            {
                foreach (var a in _adjacencyVec[i].Where(g => g >= 0))
                    reverseAdjacencyVec[a][index[a]++] = i;
            }
            return reverseAdjacencyVec;
        }
    }
}