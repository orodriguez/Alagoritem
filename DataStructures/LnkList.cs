namespace DataStructures;

public class LnkList<TValue>
{
    private LnkListNode<TValue>? _head;
    private LnkListNode<TValue>? _last;
    private int _count;

    public LnkList()
    {
        _head = null;
        _last = null;
        _count = 0;
    }

    public LnkList(params TValue[] values)
    {
        foreach (var value in values) 
            Add(value);
    }

    public TValue LastValue
    {
        get
        {
            if (_last == null)
                throw new InvalidOperationException(
                    "Can not read last value from empty list");
            return _last.Value;
        }
    }

    // O(1)
    public void Prepend(TValue value)
    {
        _count++;
        
        if (_head == null)
        {
            _head = _last =  new LnkListNode<TValue>(value);
            return;
        }

        var node = new LnkListNode<TValue>(value);
        node.Link(_head);
        _head = node;
    }

    // O(1)
    public void Add(TValue value)
    {
        _count++;
        if (_head == null)
        {
            _head = _last =  new LnkListNode<TValue>(value);
            return;
        }

        var node = new LnkListNode<TValue>(value);
        node.Previous = _last;
        _last!.Next = node;
        _last = node;
    }

    public void Insert(int index, TValue value)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index));

        var node = new LnkListNode<TValue>(value);

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

    public TValue[] ToArray() => 
        _head == null ? Array.Empty<TValue>() : _head.ToArray();

    public TValue[] ToReversedArray() => 
        _last == null ? Array.Empty<TValue>() : _last.ToReversedArray();
    
    public int Count() => _count;

    public void Remove(TValue value)
    {
        if (_head == null)
            return;

        if (_head.Value!.Equals(value))
        {
            RemoveFirst();
            return;
        }

        if (_last!.Value!.Equals(value))
        {
            RemoveLast();
            return;
        }

        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
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
        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }
}