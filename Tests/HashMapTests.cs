using DataStructures;

namespace Tests;

public class HashMapTests
{
    [Fact]
    public void Empty_Get_KeyNotFound()
    {
        var h = new HashMap<string, string>();

        Assert.Throws<KeyNotFoundException>(() => h.Get("a"));
    }

    [Fact]
    public void Get_OneElementExists()
    {
        var a = new HashMap<string, int>
        {
            ["a"] = 10
        };

        Assert.Equal(10, a["a"]);
    }
    
    [Fact]
    public void Set_Override()
    {
        var h = new HashMap<string, int>(capacity: 2)
        {
            ["a"] = 10
        };

        h["a"] = 20;

        Assert.Equal(20, h["a"]);
    }
    
    [Fact]
    public void Set_Collision()
    {
        var a = new HashMap<string, int>(capacity: 2)
        {
            ["a"] = 10,
            ["b"] = 20,
            ["c"] = 30
        };

        Assert.Equal(10, a["a"]);
        Assert.Equal(20, a["b"]);
        Assert.Equal(30, a["c"]);
    }
    
    [Fact]
    public void Remove()
    {
        var h = new HashMap<string, int>
        {
            ["a"] = 1
        };
        
        Assert.True(h.Remove("a"));
        Assert.Empty(h.Keys());
    }
    
    [Fact]
    public void Remove_NotFound()
    {
        var h = new HashMap<string, int>();
        
        Assert.False(h.Remove("b"));
    }
    
    [Fact]
    public void ContainsKey_Empty()
    {
        var h = new HashMap<string, int>();
        
        Assert.False(h.ContainsKey("a"));
    }
    
    [Fact]
    public void ContainsKey()
    {
        var h = new HashMap<string, int>
        {
            ["a"] = 1
        };
        
        Assert.True(h.ContainsKey("a"));
    }
    
    [Fact]
    public void Values_Empty()
    {
        var h = new HashMap<string, int>();
        
        Assert.Empty(h.Values());
    }

    [Fact]
    public void Values_TwoElements()
    {
        var h = new HashMap<string, int>
        {
            ["a"] = 1,
            ["b"] = 2
        };
        
        Assert.Equal(new[] { 1, 2 }, h.Values().Order());
    }
}