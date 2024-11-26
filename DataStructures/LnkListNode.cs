namespace DataStructures;

internal class LnkListNode
{
    private int Value { get; }
    private LnkListNode? Next { get; set; }
    
    public LnkListNode(int value, LnkListNode? next = null)
    {
        Value = value;
        Next = next;
    }
    
    public void Add(int value)
    {
        // O(n)
        var current = this;
        while (current.Next != null) 
            current = current.Next;

        current.Next = new LnkListNode(value);
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