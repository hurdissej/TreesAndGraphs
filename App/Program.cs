using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Solution {

    static int[] bfs(int n, int m, int[][] edges, int s) {
        var vertices = new List<int>();
        for(var i = 1; i <= m; i++)
        {   
            vertices.Add(i);
        }
        var memoTable = new List<DjikstraMemoRow>();
        memoTable.Add(new DjikstraMemoRow(IsRouteNode: true, key: s));
        foreach(var vertex in vertices.Where(x => x !=s))
        {
            memoTable.Add(new DjikstraMemoRow(key:vertex));
        }

        memoTable = Evaluate(s, memoTable, edges);
        var result = new List<int>();
        foreach(var distance in memoTable)
        {
            if(distance.shortestDistance == 0)
                continue;
            var toAdd = distance.shortestDistance == double.PositiveInfinity ? -1 : distance.shortestDistance;
            result.Add(Convert.ToInt32(toAdd));
        }
        return result.ToArray();

    }

    private static List<DjikstraMemoRow> Evaluate(int vertex, List<DjikstraMemoRow> memoTable, int[][] edges)
    {
        var edgeFrom = edges.Where(x => x[0] == vertex);
        foreach(var edge in edgeFrom)
        {  
            var currentCost = getCost(edge[0], memoTable);
                var toVertexCost = getCost(edge[1], memoTable);
                var tentativeCost = currentCost + 6;
                if( tentativeCost < toVertexCost)
                    memoTable =  SetShortestDistance(edge[1], tentativeCost, memoTable);
        }
        memoTable = SetAsVisited(vertex, memoTable);
        GetNextRowIfPossible(memoTable, out DjikstraMemoRow nextRow);
        if(nextRow != null)
            Evaluate(nextRow.Key, memoTable, edges);

        return memoTable;
    }

    private static DjikstraMemoRow getEntry(int key, List<DjikstraMemoRow> table) => table.Single(x => x.Key == key);
    private static List<DjikstraMemoRow> SetShortestDistance(int row, double cost, List<DjikstraMemoRow> table) {
         var entry = getEntry(row, table).shortestDistance = cost;
         return table;
    }
    private static List<DjikstraMemoRow> SetAsVisited(int row, List<DjikstraMemoRow> table)  {
        var entry = getEntry(row, table).isVisited = true;
        return table;
    }
    private static double getCost(int row, List<DjikstraMemoRow> table) => getEntry(row, table).shortestDistance;

    private static IEnumerable<DjikstraMemoRow> GetUnvisitedRows(List<DjikstraMemoRow> table)
    {
        return table.Where(x => !x.isVisited);
    }

    private static bool GetNextRowIfPossible(List<DjikstraMemoRow> table, out DjikstraMemoRow row)
    {
        var univsitedRows = GetUnvisitedRows(table);
        if(univsitedRows.Count() > 0){
            row = GetShortestDistance(univsitedRows);
            return true;
            }   
        row = null;
        return false;
    }

    private static DjikstraMemoRow GetShortestDistance(IEnumerable<DjikstraMemoRow> memoRows)
    {
        return memoRows.Aggregate((x, y) => {return x.shortestDistance < y.shortestDistance ? x : y;});
    }

    static void Main(String[] args) {
        int q = 1;
        var edges = new int[][]
        {
            new int[] {1,2},
            new int[] {1,3},
        };
        
        var m = 4;
        var n = 1;
        var s = 1;
        int[] result = bfs(n, m, edges, s);
         Console.WriteLine(String.Join(" ", result));
    }
}
