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
                new Graph("S", "E", 2),
                new Graph("A", "D", 3),
                new Graph("A", "C", 6),
                new Graph("A", "B", 5),
                new Graph("B", "A", 3),
                new Graph("C", "B", 1),
                new Graph("D", "C", 3),
                new Graph("D", "A", 1),
                new Graph("E", "D", 1),
                };
        }

        public void startExperiment()
        {
            Evaluate("S");
            foreach(var item in Memo)
            {
                System.Console.WriteLine($"From S to {item.Key} is {item.shortestDistance}");
            }
        }

        private void Evaluate(string vertex)
        {
            var edges = Graphs.Where(x =>x.From == vertex);
            foreach(var edge in edges)
            {
                var currentCost = getCost(edge.From);
                var toVertexCost = getCost(edge.To);
                var tentativeCost = currentCost + edge.Weighting;
                if( tentativeCost < toVertexCost)
                    SetShortestDistance(edge.To, tentativeCost);
            }
            SetAsVisited(vertex);
            GetNextRowIfPossible(out DjikstraMemoRow nextRow);
            if(nextRow != null)
                Evaluate(nextRow.Key);
        }

        private DjikstraMemoRow getEntry(string key) => this.Memo.Single(x => x.Key == key);
        private void SetShortestDistance(string row, double cost) => getEntry(row).shortestDistance = cost;
        private void SetAsVisited(string row) => getEntry(row).isVisited = true;
        private double getCost(string row) => getEntry(row).shortestDistance;

        private IEnumerable<DjikstraMemoRow> GetUnvisitedRows()
        {
            return Memo.Where(x => !x.isVisited);
        }

        private bool GetNextRowIfPossible(out DjikstraMemoRow row)
        {
            var univsitedRows = GetUnvisitedRows();
            if(univsitedRows.Count() > 0){
                row = GetShortestDistance(univsitedRows);
                return true;
                }   
            row = null;
            return false;
        }

        private DjikstraMemoRow GetShortestDistance(IEnumerable<DjikstraMemoRow> memoRows)
        {
            // make it go top to bottom
            return memoRows.Aggregate((x, y) => {return x.shortestDistance < y.shortestDistance ? x : y;});
        }

    } 
}
