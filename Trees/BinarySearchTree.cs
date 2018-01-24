using System;

public class Node
{
    public int? value;
    public Node left; 
    public Node right; 
}

public class BinarySearchTree 
{

    public BinarySearchTree(Node node, int[] values)
    {

    }

    public Node InsertNode(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = InsertNode(root.left, v);
            }
            else
            {
                root.right = InsertNode(root.right, v);
            }

            return root;
        }

    public bool FindValue(Node root, int value)
    {
        if(root.value == value)
            return true;

        if(isLeaf(root))
            return false;

        if(value < root.value)
            return FindValue(root.left, value);
        
        return FindValue(root.right, value);
    }

    public bool isLeaf(Node root)
    {
        if(root.left == null && root.right == null)
            return true;

        return false;
    }

}
