namespace DataStructures;

internal class LnkListNode
{
    private int Value { get; }
    private LnkListNode? Next { get; set; }
    
    public LnkListNode(int value)
    {
        Value = value;
        Next = null;
    }
    
    public void Add(int value)
    {
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