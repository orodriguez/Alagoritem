namespace DataStructures;

public class HashMap<TValue>
{
    private readonly TValue[] _values;
    private readonly int _capacity;

    public HashMap(int capacity = 10)
    {
        _capacity = capacity;
        _values = new TValue[capacity];
    }

    public void Set(string key, TValue value)
    {
        var index = Hash(key);
        _values[index] = value;
    }

    public TValue Get(string key)
    {
        var index = Hash(key);
        return _values[index];
    }

    private int Hash(string key)
    {
        var sum = 0;

        foreach (var chr in key)
        {
            sum += chr;
        }

        return sum % _capacity;
    }
}