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
        if (index == 0)
        {
            Prepend(value);
            return;
        }
        
        var current = _head;
        int currentIndex = 0;
        
        while (current != null && currentIndex < index)
        {
            if (currentIndex == index - 1)
            {
                var newNode = new LnkListNode(value);

                newNode.Next = current.Next;
                if (current.Next != null)
                    current.Next.Previous = newNode;

                newNode.Previous = current;
                current.Next = newNode;

                if (newNode.Next == null)
                    _last = newNode;

                return;
            }

            current = current.Next;
            currentIndex++;
        }
        
        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        if (_head == null)
        {
            return Array.Empty<int>();
        }
        
        var node = new List<int>();
        var current = _last;

        while (current != null)
        {
            node.Add(current.Value);
            current = current.Previous;
        }
        
        return node.ToArray();
    }
}