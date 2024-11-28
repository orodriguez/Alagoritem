namespace DataStructures;

internal class LnkListNode
{
    public int Value { get; }
    public LnkListNode? Next { get; set; }
    public LnkListNode? Previous { get; set; }
    
    public LnkListNode(int value, LnkListNode? next = null, LnkListNode? previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
    
    public int[] ToArray()
    {
        var result = new List<int>();
        var current = this;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }
        return result.ToArray();
    }

    public void Link(LnkListNode? node)
    {
        Next = node;
        if (node != null)
            node.Previous = this;
    }

    public int[] ToReversedArray()
    {
        var result = new List<int>();
        var current = this;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Previous;
        }
        
        return result.ToArray();
    }
}