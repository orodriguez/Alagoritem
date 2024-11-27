namespace DataStructures;

public class LnkList
{
    private LnkListNode? _head;
    private LnkListNode? _last;

    public LnkList()
    {
        _head = null;
        _last = null;
    }

    public LnkList(params int[] values)
    {
        foreach (var value in values) 
            Add(value);
    }

    // O(1)
    public void Prepend(int value)
    {
        if (_head == null)
        {
            _head = _last =  new LnkListNode(value);
            return;
        }

        _head = new LnkListNode(value, _head);
    }

    // O(1)
    public void Add(int value)
    {
        if (_head == null)
        {
            _head = _last =  new LnkListNode(value);
            return;
        }

        var node = new LnkListNode(value);
        node.Previous = _last;
        _last!.Next = node;
        _last = node;
    }
    
     public void Insert(int index, int value)
    {
        if (index < 0 || index > Count())
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        if (index == Count())
        {
            Add(value);
            return;
        }

        var current = _head;
        for (int i = 0; i < index - 1; i++)
        {
            current = current!.Next;
        }

        var newNode = new LnkListNode(value, current!.Next, current);
        if (current.Next != null)
            current.Next.Previous = newNode;

        current.Next = newNode;
    }

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        if (_head == null) return Array.Empty<int>();

        var result = new int[Count()];
        var current = _last;
        int index = 0;

        while (current != null)
        {
            result[index++] = current.Value;
            current = current.Previous;
        }

        return result;
    }

    private int Count()
    {
        int count = 0;
        var current = _head;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }
}