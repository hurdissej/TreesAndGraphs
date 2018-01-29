using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
static class Experiment {
    public static void runExperiment(int sampleSize){
        // Create Values
        var n = sampleSize;

        var size = n;
        var values = new int[size];
        var random = new Random();
        for(var i = 0; i< size; i++){
            values[i] = random.Next(1000000);
        }
        values[size/2] = 10;
        values[size -1] = 90;

        
        var stopwatch = new Stopwatch();
        
        stopwatch.Start();
        // Create Tree
        Node node = null;
        BinarySearchTree SortedTree = new BinarySearchTree();
        for(var i = 0; i < values.Length; i++)
        {
            node = SortedTree.InsertNode(node, values[i]);
        }

        System.Console.WriteLine($"Binary tree created in: {stopwatch.ElapsedTicks}");
        // Create hashset
        
        stopwatch.Reset();
        stopwatch.Start();
        var dict = new HashSet<int>(values);
        System.Console.WriteLine($"Hashset created in: {stopwatch.ElapsedTicks}");

        //Get sizes of Objects
        using(Stream s = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(s, dict);
            System.Console.WriteLine($"Size of Hashset {s.Length}");
        }

        using(Stream s = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(s, node);
            System.Console.WriteLine($"Size of BST {s.Length}");
        }


        //Find in BST
        stopwatch.Reset();
        stopwatch.Start();
        var Does10Exist = SortedTree.FindValue(node, 10); 
        var Does90Exist = SortedTree.FindValue(node, 90); 
        var Does1000001Exist = SortedTree.FindValue(node, 1000001); 
        System.Console.WriteLine($"Values found in tree in: {stopwatch.ElapsedTicks}");

        //Find in Array
        stopwatch.Reset();
        stopwatch.Start();
        var index10 = Array.IndexOf(values, 10);
        var index90 = Array.IndexOf(values, 90); 
        var indexNotFound = Array.IndexOf(values, 1000001); 
        System.Console.WriteLine($"Values found in Array in: {stopwatch.ElapsedTicks}");

        //Find in HashSet
        stopwatch.Reset();
        stopwatch.Start();
        dict.TryGetValue(10, out int Value10); 
        dict.TryGetValue(90, out int Value90); 
        dict.TryGetValue(1000001, out int Value1000001); ;
        System.Console.WriteLine($"Values found in hashset in: {stopwatch.ElapsedTicks}");

        //Find in HashSet
        stopwatch.Reset();
        stopwatch.Start();
        var one = dict.Contains(10); 
        var two = dict.Contains(90);
        var three = dict.Contains(1000001); 
        System.Console.WriteLine($"Values found in hashset (contains) in: {stopwatch.ElapsedTicks}");
    }
}
    