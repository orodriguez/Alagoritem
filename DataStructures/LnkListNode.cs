namespace DataStructures;

internal class LnkListNode<TValue>
{
    public TValue Value { get; }
    public LnkListNode<TValue>? Next { get; set; }
    public LnkListNode<TValue>? Previous { get; set; }
    
    public LnkListNode(TValue value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
    
    public TValue[] ToArray()
    {
        var result = new List<TValue>();
        var current = this;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }
        return result.ToArray();
    }

    public void Link(LnkListNode<TValue>? node)
    {
        Next = node;
        if (node != null)
            node.Previous = this;
    }

    public TValue[] ToReversedArray()
    {
        var result = new List<TValue>();
        var current = this;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Previous;
        }
        
        return result.ToArray();
    }
}