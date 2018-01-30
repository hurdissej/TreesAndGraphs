using System.Collections.Generic;
using System.Linq;

namespace TreesAndGraphs.App.Graphs
{
    public class Djikstra
    {
        public List<DjikstraMemoRow> Memo { get; set; }
        public string[] Vertices { get; set; }
        public List<Graph> Graphs { get; set; }

        public Djikstra()
        {
            this.Vertices = new string[]{"S", "A", "B", "C", "D", "E"};
            this.Memo = new List<DjikstraMemoRow>() 
            {
                new DjikstraMemoRow(IsRouteNode:true, key:"S"),
                new DjikstraMemoRow(key:"A"),
                new DjikstraMemoRow(key:"B"),
                new DjikstraMemoRow(key:"C"),
                new DjikstraMemoRow(key:"D"),
                new DjikstraMemoRow(key:"E")
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
    } 
}
