using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    
    static void Main(String[] args) {
        var values = new int[]{ 32, 54, 22,10};
        BinarySearchTree SortedTree = new BinarySearchTree(values);
        BinaryTree RegulatTree = new BinaryTree(values);
        System.Console.WriteLine("Trees created");
    }
}