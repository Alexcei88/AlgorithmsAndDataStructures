#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleTester.Problems
{
    public class KrascalaProblem
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
            int visitedEdgeCount = 0;
            Edge nextEdge = _edges[visitedEdgeCount++];
            List<List<Edge>> result = new()
            {
                new()
                {
                    nextEdge
                }
            };
            ++powerOfVertex[nextEdge.V1];
            ++powerOfVertex[nextEdge.V2];
            
            while (result[0].Count < N - 1)
            {
                nextEdge = _edges[visitedEdgeCount++];
                if (powerOfVertex[nextEdge.V1] == 0 || powerOfVertex[nextEdge.V2] == 0)
                {
                    var newComponent = new List<Edge> { nextEdge };
                    if (powerOfVertex[nextEdge.V1] == 0 && powerOfVertex[nextEdge.V2] == 0)
                    {
                        result.Add(newComponent);
                    }
                    else
                    {
                        FindSet(result, powerOfVertex[nextEdge.V1] == 0 ? nextEdge.V2 : nextEdge.V1,
                            out int index);
                        UnionEdges(result[index], newComponent);
                    }
                    ++powerOfVertex[nextEdge.V1];
                    ++powerOfVertex[nextEdge.V2];
                }
                else
                {
                    var isFirstFindSet = FindSet(result, nextEdge.V1, out int firstIndex);
                    FindSet(result, nextEdge.V2, out int secondIndex);
                    if (firstIndex >= 0 && firstIndex != secondIndex)
                    {
                        if (isFirstFindSet)
                            result[firstIndex].Add(nextEdge);
                        else
                            result[secondIndex].Add(nextEdge);
                        ++powerOfVertex[nextEdge.V1];
                        ++powerOfVertex[nextEdge.V2];

                        if (UnionEdges(result[firstIndex], result[secondIndex]))
                            result.Remove(result[secondIndex]);
                    }
                }
            }

            var result0 = result[0].OrderBy(g => g.V1).Select(g => g.V1.ToString() +  ' ' + g.V2);
            return new[] { string.Join(' ', result0) };
        }

        private bool FindSet(List<List<Edge>> edges, int searchVertex, out int index)
        {
            for (int i = 0; i < edges.Count; ++i)
            {
                for (int j = 0; j < edges[i].Count; ++j)
                {
                    if (edges[i][j].V1 == searchVertex || edges[i][j].V2 == searchVertex)
                    {
                        index = i;
                        return true;
                    }
                }
            }

            index = -1;
            return false;
        }

        private bool UnionEdges(List<Edge> edges, List<Edge> edgesToConnect)
        {
            for (int i = 0; i < edges.Count; ++i)
            {
                foreach (var edgeToConnect in edgesToConnect)
                {
                    if (edges[i].V1 == edgeToConnect.V1
                        || edges[i].V1 == edgeToConnect.V2)
                    {
                        for(int j = 0; j < edgesToConnect.Count; ++j)
                            edges.Insert(i + j, edgesToConnect[j]);
                        return true;
                    }

                    if (edges[i].V2 == edgeToConnect.V1
                        || edges[i].V2 == edgeToConnect.V2)
                    {
                        if (i == edgesToConnect.Count - 1)
                            for(int j = 0; j < edgesToConnect.Count; ++j)
                                edges.Insert(i + j + 1, edgesToConnect[j]);
                        else
                            edges.AddRange(edgesToConnect);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}