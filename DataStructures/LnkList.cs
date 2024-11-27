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
        var node = new LnkListNode(value);
        
        if (_head == null && index == 0)
        {
            _head = _last = node;
            return;
        }

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
                return;
            }

            i++;
            current = current.Next;
        }

        if (index != i) throw new ArgumentOutOfRangeException(nameof(index));
        
        _last!.Link(node);
        _last = node;
    }

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        throw new NotImplementedException();
    }
}