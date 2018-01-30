
    public class DjikstraMemoRow{       
         public DjikstraMemoRow(string key, bool IsRouteNode, bool isVisited = false)
        {
            this.Key = key;
            this.shortestDistance = IsRouteNode? 0 : double.PositiveInfinity;
            this.isVisited = isVisited;
        }
        public string Key { get; set; }
        public double shortestDistance { get; set; }
        public bool isVisited { get; set; }

    }