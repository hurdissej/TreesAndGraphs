using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using TreesAndGraphs.App.Graphs;

class Solution {
    
    static void Main(String[] args) {
        var BF = new BelmandFord();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        BF.Iterate();
        System.Console.WriteLine(stopwatch.ElapsedTicks);
        stopwatch.Stop();
        
    }
}