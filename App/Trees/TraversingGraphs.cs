using System;
using System.Collections.Generic;

public static class TraversingGraphs
{
        public static void RunExperiment(int sampleSize){
            var size = sampleSize;
            var values = new int[size];
            var random = new Random();
            for(var i = 1; i< size; i++)
            {   
                values[i] = i;
            }
            BinaryTree RegulatTree = new BinaryTree(values);

            TraverseDepthFirst(RegulatTree);
            System.Console.WriteLine("-----------");
            TraverseBreadthFirst(RegulatTree);
        }

        private static void TraverseBreadthFirst(BinaryTree node)
        {
            var q = new Queue<BinaryTree>();
            BinaryTree thisNode = null;
            q.Enqueue(node);
            while(q.Count > 0)
            {
                thisNode = q.Dequeue();
                System.Console.WriteLine(thisNode.Value);
                if(thisNode.left != null){
                    q.Enqueue(thisNode.left);
                }
                if(thisNode.right != null)
                {
                    q.Enqueue(thisNode.right);
                }

            }
        }

        private static void TraverseDepthFirst(BinaryTree node)
        {
            var stack = new Stack<BinaryTree>();
            BinaryTree thisNode = null;
            stack.Push(node);
            while(stack.Count > 0)
            {
                thisNode = stack.Pop();
                System.Console.WriteLine(thisNode.Value);
                if(thisNode.right != null)
                {
                    stack.Push(thisNode.right);
                }
                if(thisNode.left != null){
                    stack.Push(thisNode.left);
                }
            }
        }

}