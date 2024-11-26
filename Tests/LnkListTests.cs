using DataStructures;

namespace Tests;

public class LnkListTests
{
    [Fact]
    public void ToArray_Empty()
    {
        var l = new LnkList();
        
        Assert.Equal(Array.Empty<int>(), l.ToArray());
    }
    
    [Fact]
    public void ToArray_HasOneElement()
    {
        var l = new LnkList(10, 30); 

        Assert.Equal(new[] { 10, 30 }, l.ToArray());
    }
    
    [Fact]
    public void ToArray_HasTwoElements()
    {
        var l = new LnkList(10, 30, 40);
        
        Assert.Equal(new[] { 10, 30, 40 }, l.ToArray());
    }
    
    [Fact]
    public void ToArray_HasMany()
    {
        var l = new LnkList(10, 30, 40, 50, 60);
        
        Assert.Equal(new[] { 10, 30, 40, 50, 60 }, l.ToArray());
    }
    
    [Fact]
    public void Add()
    {
        var l = new LnkList(10, 30);
        
        l.Add(40);
        
        Assert.Equal(new[] { 10, 30, 40 }, l.ToArray());
    }

    [Fact]
    public void Prepend()
    {
        var l = new LnkList();
        
        l.Prepend(55);
        
        Assert.Equal(new[] { 55 }, l.ToArray());
    }
    
    [Fact]
    public void Prepend_OneElement()
    {
        var l = new LnkList();
        
        l.Prepend(55);
        l.Prepend(77);
        
        Assert.Equal(new[] { 77, 55 }, l.ToArray());
    }
}