using System.Collections.Generic;
using System.Linq;

namespace TreesAndGraphs.App.Graphs
{
    public class BelmandFord
    {
        public Dictionary<string, double> Memo { get; set; }
        public string[] Vertices { get; set; }
        public List<Graph> Graphs { get; set; }

        public BelmandFord()
        {
            this.Vertices = new string[]{"S", "A", "B", "C", "D", "E"};
            this.Memo = new Dictionary<string, double>() 
            {
                {"S", 0},
                {"A", double.PositiveInfinity}, 
                {"B", double.PositiveInfinity},
                {"C", double.PositiveInfinity}, 
                {"D", double.PositiveInfinity}, 
                {"E", double.PositiveInfinity}
            };
            this.Graphs = new List<Graph> {
                new Graph("S", "A", 4),
                new Graph("S", "E", 5),
                new Graph("A", "C", 6),
                new Graph("E", "D", 8),
                new Graph("D", "A", 10),
                new Graph("D", "C", 3),
                new Graph("C", "B", 2),
                new Graph("B", "A", 3)};
        }

        public bool Iterate()
        {
            var doItAgin = false;
            foreach(var vertex in Vertices)
            {
                var edges = Graphs.Where(x => x.From == vertex);
                foreach(var edge in edges)
                {
                    var potentialCost = Memo[edge.From] + edge.Weighting;
                    if(potentialCost < Memo[edge.To]){
                        Memo[edge.To] = potentialCost;
                        doItAgin = true;
                    }
                }
            }
            if(doItAgin == false){
                foreach(var row in Memo)
                {
                    System.Console.WriteLine($"From S to {row.Key} is {row.Value}");
                }
                return doItAgin;
            }
            return Iterate();
        }

        

    } 
}
