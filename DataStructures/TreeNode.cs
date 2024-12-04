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

    public TreeNode<TValue> Add(TValue childValue)
    {
        var node = new TreeNode<TValue>(childValue);
        node.Parent = this;
        Children.Add(node);
        return node;
    }

    public int Count() =>
        Children.Sum(child => child.Count()) + 1;


    public int Level
    {
        get
        {
            if (Parent == null)
            {
                return 0; 
            }
            else
            {
                return Parent.Level + 1;
            }
        }
    }

    public int Height()
    {
        if (Children.Count == 0)
        {
            return 0;
        }

        return 1 + Children.Max(child => child.Height());
    }
}