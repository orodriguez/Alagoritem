namespace DataStructures;
public class LnkListNode
{
    private int Value { get; } 
    public LnkListNode? Next { get; set; }
    public LnkListNode? Previous { get; set; }

    public LnkListNode(int value, LnkListNode? next = null, LnkListNode? previous = null)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
    
    public int GetValue() => Value;
    public LnkListNode? GetNext() => Next;
    public void SetNext(LnkListNode? next)
    {
        Next = next;
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