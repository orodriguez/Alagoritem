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
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        var current = _head;
        int currentIndex = 0;

        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current == null)
            throw new ArgumentOutOfRangeException(nameof(index));

        var newNode = new LnkListNode(value, current.Next);
        if (current.Next != null)
            current.Next.Previous = newNode;

        current.Next = newNode;
        newNode.Previous = current;

        if (newNode.Next == null)
            _last = newNode; 
    }
    
    


    public IEnumerable<int> ToArray() => 
        _head == null ? Array.Empty<int>() : _head.ToArray();

    public int[] ToReversedArray()
    {
        if (_last == null)
            return Array.Empty<int>();

        var result = new List<int>();
        var current = _last;

        while (current != null)
        {
            result.Add(current.Value);
            current = current.Previous;
        }

        return result.ToArray();
    }
    
    public static bool ValidParenthesis(string s)
    {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0) return false;

                var top = stack.Pop();
                if ((ch == ')' && top != '(') ||
                    (ch == ']' && top != '[') ||
                    (ch == '}' && top != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    
    

}