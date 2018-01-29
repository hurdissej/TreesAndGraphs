using System;

[Serializable]
public class Node
{
    public int? value;
    public Node left; 
    public Node right; 
}


public class BinarySearchTree 
{
    public BinarySearchTree()
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
        if(value < root.value && root.left != null)
            return FindValue(root.left, value);
        if(root.right != null)
            return FindValue(root.right, value);      
        return false;
    }
}
