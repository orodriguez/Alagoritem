namespace DataStructures;

internal class LnkListNode
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
    
    public int GetValues() => Value;
    
    public int[] ToArray()
    {
        var result = new List<int>();
        var current = this;
        while (current != null)
        {
            result.Add(current.GetValues());
            current = current.Next;
        }
        return result.ToArray();
    }

}