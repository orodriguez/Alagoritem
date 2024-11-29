namespace DataStructures;

public class Stk<TValue>
{
    private readonly LnkList<TValue> _list;

    public Stk()
    {
        _list = new LnkList<TValue>();
    }

    // O(1)
    public void Push(TValue s) => 
        _list.Add(s);

    // O(1)
    public TValue Pop()
    {
        var lastValue = _list.LastValue;
        _list.RemoveLast();
        return lastValue;
    }

    // O(1)
    public TValue Peek() => 
        _list.LastValue;

    public TValue[] ToArray() => 
        _list.ToArray();
}