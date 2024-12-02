using System.Collections;
using DataStructures;

namespace Tests;

public class HashMapTests
{
    [Fact]
    public void Empty_Get_KeyNotFound()
    {
        var h = new HashMap<string>();

        Assert.Throws<KeyNotFoundException>(() => h.Get("a"));
    }

    [Fact]
    public void Simple()
    {
        var a = new HashMap<int>
        {
            ["a"] = 10
        };

        var value = a["a"];
        
        Assert.Equal(10, value);
    }
    
    [Fact]
    public void Collision()
    {
        var a = new HashMap<int>(capacity: 2)
        {
            ["a"] = 10,
            ["b"] = 20,
            ["c"] = 30
        };

        Assert.Equal(10, a["a"]);
        Assert.Equal(20, a["b"]);
        Assert.Equal(30, a["c"]);
    }
    
    // TODO: this[key]
    // TODO: Test override value
}