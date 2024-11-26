using DataStructures;

namespace Tests;

public class LnkListTests
{
    [Fact]
    public void ToArray_HasOneElement()
    {
        var l = new LnkListNode(10);
        l.Add(30);
        
        Assert.Equal(new[] { 10, 30 }, l.ToArray());
    }
    
    [Fact]
    public void ToArray_HasTwoElements()
    {
        var l = new LnkListNode(10);
        l.Add(30);
        l.Add(40);
        
        Assert.Equal(new[] { 10, 30, 40 }, l.ToArray());
    }
    
    [Fact]
    public void ToArray_HasMany()
    {
        var l = new LnkListNode(10);
        l.Add(30);
        l.Add(40);
        l.Add(50);
        l.Add(60);
        
        Assert.Equal(new[] { 10, 30, 40, 50, 60 }, l.ToArray());
    }
}