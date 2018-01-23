using System;

public class BinarySearchTree 
{
    public int value;
    public BinarySearchTree left; 
    public BinarySearchTree right; 
    public BinarySearchTree(int[] values): this(values, 0){}

    BinarySearchTree(int[] values, int index)
    {
        CreateNode(this, index, values);
    }

    public void CreateNode(BinarySearchTree root, int index, int[] values)
    {
        this.value = values[index];
        if (index == values.Length-1)
            return;
        if (values[index + 1] < this.value)
        {
            this.left = new BinarySearchTree(values, index + 1);
        } 
        else 
        {
            this.right = new BinarySearchTree(values, index + 1);
        }
    }

}
