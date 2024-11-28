namespace DataStructures;
public class LnkListNode
{
    private int Value { get; } 
    public LnkListNode? Next { get; set; }
    public LnkListNode? Previous { get; set; }

    public LnkListNode(int value, LnkListNode? next = null, LnkListNode? previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
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

}