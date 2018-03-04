
    public class DjikstraMemoRow{       
         public DjikstraMemoRow(int key, bool IsRouteNode = false, bool isVisited = false)
        {
            this.Key = key;
            this.shortestDistance = IsRouteNode? 0 : double.PositiveInfinity;
            this.isVisited = isVisited;
        }
        public int Key { get; set; }
        public double shortestDistance { get; set; }
        public bool isVisited { get; set; }

    }