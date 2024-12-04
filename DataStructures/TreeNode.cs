namespace DataStructures;

public class TreeNode<TValue>
{
    public TValue Value { get; set; }
    public TreeNode<TValue>? Parent { get; set; }
    public List<TreeNode<TValue>> Children { get; set; }
    public int Level { get; set; }

    public TreeNode(TValue value, int level = 0)
    {
        Value = value;
        Parent = null;
        Children = new List<TreeNode<TValue>>();
        Level = level;
    }

    public TreeNode<TValue> Add(TValue childValue)
    {
        var node = new TreeNode<TValue>(childValue, Level + 1);
        Children.Add(node);
        return node;
    }

    public int Count() =>
        Children.Sum(child => child.Count()) + 1;

    public int Height() => 
        Children.Count == 0 
            ? 0 
            : 1 + Children.Max(child => child.Height());

    public TreeNode<TValue>? Search(TValue value)
    {
        // O(1)
        if (Equals(Value, value))
            return this;
        
        // O(n)
        return Children
            .Select(child => child.Search(value))
            .FirstOrDefault(node => node != null);
    }
}