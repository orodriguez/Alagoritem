using DataStructures;

namespace Tests;

public class HashMapTests
{
    [Fact]
    public void Simple()
    {
        var a = new HashMap<int>();
        a.Set("a", 10);

        var value = a.Get("a");
        
        Assert.Equal(10, value);
    }
    
    [Fact]
    public void Collision()
    {
        var a = new HashMap<int>();
        a.Set("a", 10);
        a.Set("k", 20);

        var value = a.Get("a");
        
        Assert.Equal(10, value);
    }
}