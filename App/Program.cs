using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
class Solution {
    
    static void Main(String[] args) {
        // Create Values
        var size = 2000000;
        var values = new int[size];
        var random = new Random();
        for(var i = 0; i< size; i++){
            values[i] = random.Next(1000000);
        }
        values[size/2] = 10;
        values[size -1] = 90;


        // Create Tree
        Node node = null;
        BinarySearchTree SortedTree = new BinarySearchTree(node, values);
        for(var i = 0; i < values.Length; i++)
        {
            node = SortedTree.InsertNode(node, values[i]);
        }
        BinaryTree RegulatTree = new BinaryTree(values);

        // Create hashset
        var dict = new HashSet<int>(values);


        //Find in BST
        var stopwatch = new Stopwatch();
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
        System.Console.WriteLine($"Values found in hashset (sOrD) in: {stopwatch.ElapsedTicks}");
    }
}