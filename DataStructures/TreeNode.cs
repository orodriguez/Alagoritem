namespace DataStructures;

public class TreeNode<TValue>
{
    public TValue Value { get; set; }
    public TreeNode<TValue>? Parent { get; set; }
    public List<TreeNode<TValue>> Children { get; set; }

    public TreeNode(TValue value)
    {
        Value = value;
        Parent = null;
        Children = new List<TreeNode<TValue>>();
    }

    public void Add(TValue childValue) => 
        Children.Add(new TreeNode<TValue>(childValue));
}