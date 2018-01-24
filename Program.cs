using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    
    static void Main(String[] args) {
        var values = new int[]{ 32, 54, 22,10};

        Node node = null;
        BinarySearchTree SortedTree = new BinarySearchTree(node, values);
        for(var i = 0; i < values.Length; i++)
        {
            node = SortedTree.InsertNode(node, values[i]);
        }
        BinaryTree RegulatTree = new BinaryTree(values);

        var Does10Exist = SortedTree.FindValue(node, 10); // Should return true;
        var Does90Exist = SortedTree.FindValue(node, 90); // Should return False;
        System.Console.WriteLine("Trees created");
    }
}