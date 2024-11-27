namespace DataStructures;

public class LnkListNode
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

}