namespace DataStructures;

public class LnkList
{
    private LnkListNode? _head;
    private LnkListNode? _last;
    private int _count;

    public LnkList()
    {
        _head = null;
        _last = null;
        _count = 0;
    }

    public LnkList(params int[] values)
    {
        foreach (var value in values)
            Add(value);
    }

    // O(1)
    public void Prepend(int value)
    {
        _count++;
        
        if (_head == null)
        {
            _head = _last = new LnkListNode(value);
            return;
        }

        var node = new LnkListNode(value);
        node.Link(_head);
        _head = node;
    }

    // O(1)
    public void Add(int value)
    {
        _count++;
        if (_head == null)
        {
            _head = _last = new LnkListNode(value);
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
            _head = new LnkListNode(value, _head);
            if (_last == null) _last = _head;
            return;
        }

        var current = _head;
        int currentIndex = 0;

        while (currentIndex < index - 1 && current != null)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current == null)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        var newNode = new LnkListNode(value, current.Next);
        current.Next = newNode;

        if (newNode.Next == null)
        {
            _last = newNode;
        }
    }

    public IEnumerable<int> ToArray() =>
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray() => 
        _last == null ? Array.Empty<int>() : _last.ToReversedArray();
    
    public int Count() => _count;

    public void Remove(int value)
    {
        if (_head == null)
            return;

        if (_head.Value == value)
        {
            RemoveFirst();
            return;
        }

        if (_last!.Value == value)
        {
            RemoveLast();
            return;
        }

        var current = _head;
        while (current != null)
        {
            if (current.Value == value)
            {
                var previous = current.Previous!;
                previous.Link(current.Next);
                _count--;
                return;
            }

            current = current.Next;
        }
    }

    public void RemoveFirst()
    {
        if (_head == null) return Array.Empty<int>();

        var result = new List<int>();
        var current = _head;

        while (current != null)
        {
            result.Insert(0, current.GetValue());  
            current = current.GetNext();         
        }

        return result.ToArray();
    }
}


