namespace DataStructures;

public class BSTreeNode
{
    public int Value { get; set; }
    public BSTreeNode? Left { get; set; }
    public BSTreeNode? Right { get; set; }

    public BSTreeNode(params int[] values)
    {
        Value = values[0];
        Right = null;
        Left = null;

        foreach (var value in values.Skip(1)) 
            Add(value);
    }

    public void Add(int value)
    {
        if (value == Value)
            return;
        
        if (value < Value && Left == null)
        {
            Left = new BSTreeNode(value);
            return;
        }
        
        if (value < Value && Left != null)
        {
            Left.Add(value);
            return;
        }

        if (Right == null)
        {
            Right = new BSTreeNode(value);
            return;
        }

        Right.Add(value);
    }

    public bool Contains(int value)
    {
        if (value == Value)
            return true;

        if (value < Value && Left == null)
            return false;
        
        if (value < Value && Left != null)
            return Left.Contains(value);
        
        return Right != null && Right.Contains(value);
    }
}