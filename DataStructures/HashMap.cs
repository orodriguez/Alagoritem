using System.Collections;

namespace DataStructures;

public class HashMap<TValue>
{
    private readonly Bucket?[] _buckets;
    private readonly int _capacity;

    public HashMap(int capacity = 10)
    {
        _capacity = capacity;
        _buckets = new Bucket[capacity];
    }

    public TValue this[string key]
    {
        get => Get(key);
        set => Set(key, value);
    }

    public void Set(string key, TValue value)
    {
        var index = Hash(key);
        GetOrCreateBucket(index).Set(key, value);
    }

    public TValue Get(string key)
    {
        var index = Hash(key);
        return GetOrCreateBucket(index).Get(key);
    }

    public bool Remove(string key)
    {
        var index = Hash(key);
        return GetOrCreateBucket(index).Remove(key);
    }

    public IEnumerable<string> Keys() => 
        _buckets
            .Where(bucket => bucket != null)
            .SelectMany(bucket => bucket!.Keys());

    private Bucket GetOrCreateBucket(int index) => _buckets[index] ??= new Bucket();

    private int Hash(string key) => 
        Math.Abs(key.GetHashCode()) % _capacity;

    private sealed class Bucket
    {
        private readonly LinkedList<(string key, TValue value)> _list;

        public Bucket() =>
            _list = new LinkedList<(string key, TValue value)>();

        public void Set(string key, TValue value)
        {
            var keyValue = _list.FirstOrDefault(kv => kv.key == key);

            if (keyValue.key != null)
                _list.Remove(keyValue);

            _list.AddLast((key, value));
        }

        public TValue Get(string key)
        {
            var keyValue = _list.FirstOrDefault(kv => kv.key == key);

            if (keyValue.key == null)
                throw new KeyNotFoundException(key);
            
            return keyValue.value;
        }

        public bool Remove(string key)
        {
            var keyValue = _list.FirstOrDefault(kv => kv.key == key);
            return _list.Remove(keyValue);
        }

        public IEnumerable<string> Keys() => 
            _list.Select(kv => kv.key);
    }
}