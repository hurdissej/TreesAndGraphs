 public class Graph
    {
        public Graph(string from, string to, int weighting)
        {
            this.From = from;
            this.To = to;
            this.Weighting = weighting;
        }
        public string From { get; set; }
        public string To { get; set; }
        public int Weighting { get; set; }
    }