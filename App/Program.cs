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
        BF.UpdateMemo();
    }
}