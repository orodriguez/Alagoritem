using System.Collections;

namespace DataStructures;

public class HashMap<TKey, TValue>
{
    private readonly Bucket?[] _buckets;
    private readonly int _capacity;

    public HashMap(int capacity = 10)
    {
        _capacity = capacity;
        _buckets = new Bucket[capacity];
    }

    public TValue this[TKey key]
    {
        get => Get(key);
        set => Set(key, value);
    }

    public void Set(TKey key, TValue value)
    {
        var index = Hash(key);
        GetOrCreateBucket(index).Set(key, value);
    }

    public TValue Get(TKey key)
    {
        var index = Hash(key);
        return GetOrCreateBucket(index).Get(key);
    }

    public bool Remove(TKey key)
    {
        var index = Hash(key);
        return GetOrCreateBucket(index).Remove(key);
    }

    public IEnumerable<TKey> Keys() => 
        _buckets
            .Where(bucket => bucket != null)
            .SelectMany(bucket => bucket!.Keys());

    public bool ContainsKey(TKey key)
    {
        var index = Hash(key);
        return GetOrCreateBucket(index).ContainsKey(key);
    }

    public IEnumerable<TValue> Values() =>
        _buckets
            .Where(bucket => bucket != null)
            .SelectMany(bucket => bucket!.Values());

    private Bucket GetOrCreateBucket(int index) => 
        _buckets[index] ??= new Bucket();

    private int Hash(TKey key)
    {
        if (Equals(key, default(TKey)))
            throw new ArgumentNullException(nameof(key));
        
        return Math.Abs(key!.GetHashCode()) % _capacity;
    }

    private sealed class Bucket
    {
        private readonly LinkedList<(TKey key, TValue value)> _list;

        public Bucket() =>
            _list = new LinkedList<(TKey key, TValue value)>();

        public void Set(TKey key, TValue value)
        {
            var keyValue = _list.FirstOrDefault(kv => Equals(kv.key, key));

            if (!Equals(keyValue.key, default(TKey)))
                _list.Remove(keyValue);

            _list.AddLast((key, value));
        }

        public TValue Get(TKey key)
        {
            var keyValue = _list.FirstOrDefault(kv => Equals(kv.key, key));

            if (Equals(keyValue.key, default(TKey)))
                throw new KeyNotFoundException(key?.ToString());
            
            return keyValue.value;
        }

        public bool Remove(TKey key)
        {
            var keyValue = _list.FirstOrDefault(kv => Equals(kv.key, key));
            return _list.Remove(keyValue);
        }

        public IEnumerable<TKey> Keys() => 
            _list.Select(kv => kv.key);

        public IEnumerable<TValue> Values() => 
            _list.Select(kv => kv.value);

        public bool ContainsKey(TKey key) => 
            _list.Any(kv => Equals(kv.key, key));
    }
}