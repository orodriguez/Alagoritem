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

        var currentNode = _head;
        int currentIndex = 0;
        while (currentNode != null && currentIndex < index - 1)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode == null)
        {
            throw new ArgumentOutOfRangeException("El índice está fuera de los límites de la lista.");
        }

        var newNode = new LnkListNode(value);

        if (currentNode.Next == null)
        {
            currentNode.Next = newNode;
            newNode.Previous = currentNode;
            _last = newNode;
        }
        else
        {
            newNode.Next = currentNode.Next;
            newNode.Previous = currentNode;
            currentNode.Next.Previous = newNode;
            currentNode.Next = newNode;
        }
    }

    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        if (_head == null)
            return Array.Empty<int>();

        var nodoActual = _last;
        var result = new List<int>();

        while (nodoActual != null)
        {
            result.Add(nodoActual.Value);
            nodoActual = nodoActual.Previous;
        }
        return result.ToArray();
    }
}