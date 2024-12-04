namespace DataStructures;

using System.Collections.Generic;
using System.Linq;

public class TreeNode<TValue>
{
    public TValue Value { get; set; }
    public TreeNode<TValue>? Parent { get; set; }
    public List<TreeNode<TValue>> Children { get; set; }
    public int Level { get; private set; }

    public TreeNode(TValue value)
    {
        Value = value;
        Parent = null;
        Children = new List<TreeNode<TValue>>();
        Level = 0;
    }

    public TreeNode<TValue> Add(TValue childValue)
    {
        var node = new TreeNode<TValue>(childValue)
        {
            Parent = this,
            Level = Level + 1 
        };
        Children.Add(node);
        return node; 
    }
    public int Count() =>
        Children.Sum(child => child.Count()) + 1;

    public int Height()
    {
        if (!Children.Any())
            return 0;

        return Children.Max(child => child.Height()) + 1;
    }
}