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
        throw new NotImplementedException();
    }

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        throw new NotImplementedException();
    }
}