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
        int i = 0;
        if (_head == null)
        {

            _head = new LnkListNode(value);
            _last = _head;
        }
        else if (index == 0)
        {
            var node = new LnkListNode(value);
            node.Next = _head;
            _head = node;
        }
        else
        {
            var node = new LnkListNode(value);
            LnkListNode valor = _head;
            
            
            while (i < index - 1)
            {
               valor = valor.Next;
               i += 1;
            }
            
            node.Next = valor.Next;
            valor.Next = node;
            
        }
        
        var length = 0;
        var current = _head;
        while (current != null)
        {
            length++;
            current = current.Next;
        }

        if (index > length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
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