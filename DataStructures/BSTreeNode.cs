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
        // O(1)
        if (value == Value)
            return true;
        
        // O(1)
        if (value < Value && Left == null)
            return false;
        
        // O(log n)
        if (value < Value && Left != null)
            return Left.Contains(value);
        
        return Right != null && Right.Contains(value);
    }

    // O(log n)
    public int Min() => Left?.Min() ?? Value;
    
    // O(log n)
    public int Max() => Right?.Max() ?? Value;

    public BSTreeNode? Delete(int value)
    {
        if (value < Value && Left != null)
        {
            Left = Left.Delete(value);
            return this;
        }
        
        if (value > Value && Right != null)
        {
            Right = Right.Delete(value);
            return this;
        }
    
        // Value == value
        
        if (Left == null && Right == null)
            return null;

        if (Left == null)
            return Right;

        if (Right == null)
            return Left;

        var minRight = Right.Min();
        return new BSTreeNode(minRight)
        {
            Left = Left,
            Right = Right.Delete(minRight)
        };
    }
}