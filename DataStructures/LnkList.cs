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
            _head = _last =  new LnkListNode(value);
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
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        var node = new LnkListNode(value);

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        var current = _head;
        var i = 0;

        while (current != null)
        {
            if (index == i)
            {
                current.Previous!.Link(node);
                node.Link(current);
                _count++;
                return;
            }

            i++;
            current = current.Next;
        }

        _last!.Link(node);
        _last = node;
        _count++;
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
        if (_head == null)
            return;
        
        if (_head == _last)
        {
            _head = _last = null;
            _count = 0;
            return;
        }
        
        var next = _head.Next;
        next!.Previous = null;
        _head = next;
        _count--;
    }

    public void RemoveLast()
    {
        if (_last == null)
            return;

        if (_head == _last)
        {
            _head = _last = null;
            _count = 0;
            return;
        }

        var previous = _last.Previous;
        previous!.Link(null);
        _last = previous;
        _count--;
    }

    public bool Contains(int value)
    {
        throw new NotImplementedException();
    }
}