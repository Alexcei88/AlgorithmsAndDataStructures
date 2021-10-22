using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class KosarajuWithRecursiveDFS
        : IProblem
    {
        private List<int>[] _adjacencyVec;
        private List<(int, bool)> _weights;
        private List<int[]> _components;

        public string[] Solve(string[] input)
        {
            _components = new List<int[]>();
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

            var reverseAdjacencyVec = CreateReverseAdjacencyVec();
            Stack<int> paths = new Stack<int>();
            FullDepthRoundTree(reverseAdjacencyVec, paths, new byte[reverseAdjacencyVec.Length]);
            FillWeight(new Stack<int>(new Stack<int>(paths)));

            while (_weights.Any(g => g.Item2 == false))
            {
                var notVisited = _weights.Where(g => g.Item2 == false);
                var maxWeight = _weights.IndexOf(notVisited.Min());
                var component = new List<int>();
                DepthRoundTree(_adjacencyVec, maxWeight, component);
                if (component.Count > 2)
                    _components.Add(component.ToArray());
            }

            var result = new List<string> { _components.Count.ToString() };
            foreach (var component in _components)
                result.Add(string.Join(' ', component.OrderBy(g => g)));

            return result.ToArray();
        }

        private void FillWeight(Stack<int> paths)
        {
            var weights = new (int, bool)[paths.Count];
            int accWeight = 0;
            while (paths.TryPop(out int next))
            {
                weights[next] = (accWeight, false);
                ++accWeight;
            }
            _weights = weights.ToList();
        }

        private void FullDepthRoundTree(List<int>[] vec, Stack<int> paths, byte[] visited)
        {
            while (visited.Any(g => g == 0))
            {
                int index = 0;
                while (index < visited.Length && visited[index] == 1)
                    ++index;

                DepthRoundTree(vec, index, paths, visited);
            }
        }

        private void DepthRoundTree(List<int>[] vec, int current, Stack<int> paths, byte[] visited)
        {
            if (visited[current] == 1)
                return;

            visited[current] = 1;
            foreach (var v in vec[current])
                DepthRoundTree(vec, v, paths, visited);

            paths.Push(current);
        }

        private void DepthRoundTree(List<int>[] vec, int current, List<int> graph)
        {
            if (_weights[current].Item2)
                return;

            _weights[current] = (_weights[current].Item1, true);
            graph.Add(current);

            var adjacencyEdges = vec[current].Where(g => _weights[g].Item2 == false)
                .OrderBy(g => _weights[g].Item1);
            foreach (var v in adjacencyEdges)
                DepthRoundTree(vec, v, graph);
        }

        private List<int>[] CreateReverseAdjacencyVec()
        {
            var reverseAdjacencyVec = new List<int>[_adjacencyVec.Length];
            for (int i = 0; i < reverseAdjacencyVec.Length; i++)
                reverseAdjacencyVec[i] = new();

            for (int i = 0; i < _adjacencyVec.Length; ++i)
            {
                foreach (var a in _adjacencyVec[i])
                    reverseAdjacencyVec[a].Add(i);
            }

            return reverseAdjacencyVec;
        }
    }
}