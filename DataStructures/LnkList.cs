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
        //Insert Empty
        if (_head == null)
        {
            _head = new LnkListNode(value);
            _last = _head;
        }
        else if (index == 0)
        {
            //Insert One
            var node = new LnkListNode(value);
            node.Next = _head;
            _head = node;
        }
        else
        {
            var node = new LnkListNode(value);
            LnkListNode c = _head;
            int i = 0;
            
            while (i < index - 1)
            {
                c = c.Next;
                i += 1;
                
            }

            node.Next = c.Next;
            c.Next = node;
            
        }
        
    }
    
    

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        return [];
    }
}
