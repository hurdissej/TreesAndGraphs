using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int[] bfs(int n, int m, int[][] edges, int s) {
        return new int[]{1};
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            int[][] edges = new int[m][];
            for(int edges_i = 0; edges_i < m; edges_i++){
               string[] edges_temp = Console.ReadLine().Split(' ');
               edges[edges_i] = Array.ConvertAll(edges_temp,Int32.Parse);
            }
            int s = Convert.ToInt32(Console.ReadLine());
            int[] result = bfs(n, m, edges, s);
            Console.WriteLine(String.Join(" ", result));


        }
    }
}
