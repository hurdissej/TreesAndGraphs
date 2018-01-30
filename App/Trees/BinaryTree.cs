using System;

public class BinaryTree
{
    public int Value;
    public BinaryTree left;
    public BinaryTree right;

    public BinaryTree(int[] values): this(values, 0) {}
    
    BinaryTree(int[] values, int index)
    {
        CreateNode(this, values, index);
    }

    private void CreateNode(BinaryTree currentTree, int[] values, int index)
    {
        this.Value = values[index];
        // * by 2 to skip over each others value
        if(index * 2 + 1 < values.Length)
            this.left = new BinaryTree(values, index * 2 + 1);

        if(index * 2 + 2 < values.Length)
            this.right = new BinaryTree(values, index * 2 + 2);
    }

    
    public void Traverse(Node root)
    {
        
    }

}