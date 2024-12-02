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
    public void Get_OneElementExists()
    {
        var a = new HashMap<int>
        {
            ["a"] = 10
        };

        Assert.Equal(10, a["a"]);
    }
    
    [Fact]
    public void Set_Override()
    {
        var h = new HashMap<int>(capacity: 2)
        {
            ["a"] = 10
        };

        h["a"] = 20;

        Assert.Equal(20, h["a"]);
    }
    
    [Fact]
    public void Set_Collision()
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
}