using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Edge {
    public Edge(int a, int b, int c)
    {
        this.From = a;
        this.To = b;
        this.Weighting = c;
    }
    public int From { get; set; }
    public int To { get; set; }
    public int Weighting { get; set; }
}
class Solutions {

    static int[] floyd(int n, int[][] edges, int[][] queries) {
        var results = new List<int>();
        var graph = createGraph(edges);
        foreach(var query in queries){
            results.Add(GetShortestDistance(query[0], query[1], edges, graph));
        }
        return results.ToArray();
    }

    private static int GetShortestDistance(int to, int from, int[][] edges, IEnumerable<Edge> graph)
    {
        var nodes = graph.Select(x => x.From).Distinct();

        var results = getResultsTable(nodes, to);
        var doItAgain = true;
        while(doItAgain == true){}
        foreach(var node in nodes)
        {
            doItAgain = false;
            var outgoingEdges = graph.Where(x => x.From == node);
            foreach(var edge in outgoingEdges)
            {
                var potentialCost = results[edge.From] = edge.Weighting;
                if(potentialCost < results[edge.To])
                {
                    results[edge.To] = potentialCost;
                    doItAgain = true;
                }
            }
        }
        var shortestDistance  = results[from];
        return double.IsPositiveInfinity(shortestDistance) ? -1 : (int)shortestDistance;
    }
        
    private static IEnumerable<Edge> createGraph(int[][] edges)
    {
        foreach(var edge in edges)
        {
            yield return new Edge(edge[0], edge[1], edge[2]);
        }
    }

    private static Dictionary<int, double> getResultsTable(IEnumerable<int> edges, int to)
    {
        var results = new Dictionary<int, double>();
        foreach(var edge in edges)
        {
            results.Add(edge, double.PositiveInfinity);
        }
        results[to] = 0;
        return results;
    }

    static void Start() {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        int[][] edges = new int[m][];
        for(int edges_i = 0; edges_i < m; edges_i++){
           string[] edges_temp = Console.ReadLine().Split(' ');
           edges[edges_i] = Array.ConvertAll(edges_temp,Int32.Parse);
        }
        int q = Convert.ToInt32(Console.ReadLine());
        int[][] queries = new int[q][];
        for(int queries_i = 0; queries_i < q; queries_i++){
           string[] queries_temp = Console.ReadLine().Split(' ');
           queries[queries_i] = Array.ConvertAll(queries_temp,Int32.Parse);
        }
        int[] result = floyd(n, edges, queries);
        Console.WriteLine(String.Join("\n", result));


    }
}
