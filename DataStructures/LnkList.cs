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
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (_head == null)
        {
            if (index == 0)
            {
                _head = new LnkListNode(value);
                _last = _head;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
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
            LnkListNode current = _head;
            int i = 0;

            while (i < index - 1 && current.Next != null)
            {
                current = current.Next;
                i++;
            }

            if (i < index - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            node.Next = current.Next;
            current.Next = node;

            if (node.Next == null)
            {
                _last = node;
            }
        }
    }

    
    

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {

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
