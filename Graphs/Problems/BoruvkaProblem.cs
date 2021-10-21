#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class BoruvkaProblem
        : IProblem
    {
        private record Edge
        {
            public int V1 { get; init; }
            public int V2 { get; init; }
            public int Weight { get; init; }
        }

        private List<Edge> _edges = new();

        public string[] Solve(string[] input)
        {
            int N = int.Parse(input[0], CultureInfo.InvariantCulture);
            if (N < 1)
                return Array.Empty<string>();

            for (int i = 0; i < N; ++i)
            {
                if (!string.IsNullOrEmpty(input[i + 1]))
                {
                    var line = input[i + 1].Split(' ');
                    for (int j = 0; j < line.Length; j += 2)
                    {
                        int v = int.Parse(line[j]);
                        int weight = int.Parse(line[j + 1]);
                        _edges.Add(new Edge
                        {
                            V1 = i,
                            V2 = v,
                            Weight = weight
                        });
                    }
                }
            }

            _edges = _edges.OrderBy(g => g.Weight).ToList();

            int[] powerOfVertex = new int[N];
            int[] nodes = new int[N];
            for (int i = 0; i < N; ++i)
                nodes[i] = i;
            
            int visitedEdgeCount = 0;

            List<Edge> result = new();
            while (result.Count < N - 1)
            {
                Edge nextEdge = _edges[visitedEdgeCount++];
                if (powerOfVertex[nextEdge.V1] == 0 || powerOfVertex[nextEdge.V2] == 0)
                {
                    if (powerOfVertex[nextEdge.V1] == 0 && powerOfVertex[nextEdge.V2] == 0)
                    {
                        Union(nodes, nextEdge.V1, nextEdge.V2);
                        result.Add(nextEdge);
                    }
                    else
                    {
                        if(powerOfVertex[nextEdge.V1] == 0)
                            Union(nodes, nextEdge.V2, nextEdge.V1);
                        else
                            Union(nodes, nextEdge.V1, nextEdge.V2);
                        result.Add(nextEdge);
                    }
                    ++powerOfVertex[nextEdge.V1];
                    ++powerOfVertex[nextEdge.V2];
                }
                else
                {
                    if (!Connected(nodes, nextEdge.V1, nextEdge.V2))
                    {
                        Union(nodes, nextEdge.V1, nextEdge.V2);
                        result.Add(nextEdge);
                    }
                }
            }

            var result0 = result.OrderBy(g => g.V1).ThenBy(g=> g.V2).Select(g => g.V1.ToString() +  ' ' + g.V2);
            return new[] { string.Join(' ', result0) };
        }

        private bool Connected(int[] nodes, int p, int q)
        {
            return Root(nodes, p) == Root(nodes, q);  
        }

        private int Root(int[] nodes, int p)
        {
            while (p != nodes[p])
                p = nodes[p];

            return p;
        }
        
        private void Union(int[] nodes, int p, int q)
        {
            int pRoot = Root(nodes, p);
            int qRoot = Root(nodes, q);

            nodes[qRoot] = pRoot;
        }
    }
}