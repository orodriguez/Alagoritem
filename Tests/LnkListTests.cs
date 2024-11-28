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

    [Fact]
    public void Insert_Empty()
    {
        var l = new LnkList();
        
        l.Insert(0, 10);
        
        Assert.Equal(new[] { 10 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_OneElement()
    {
        var l = new LnkList(10);
        
        l.Insert(0, 20);
        
        Assert.Equal(new[] { 20, 10 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_InMiddle()
    {
        var l = new LnkList(10, 30, 40);
        
        l.Insert(1, 20);
        
        Assert.Equal(new[] { 10, 20, 30, 40 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_AtEnd()
    {
        var l = new LnkList(10, 20, 30);
        
        l.Insert(3, 40);
        
        Assert.Equal(new[] { 10, 20, 30, 40 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_NotFound()
    {
        var l = new LnkList();

        Assert.Throws<ArgumentOutOfRangeException>(() => l.Insert(3, 10));
    }

    [Fact]
    public void ToReversedArray_Empty()
    {
        var l = new LnkList();
        
        Assert.Equal(Array.Empty<int>(), l.ToReversedArray());
    }
    
    [Fact]
    public void ToReversedArray_One()
    {
        var l = new LnkList(10);
        
        Assert.Equal(new[] { 10 }, l.ToReversedArray());
    }
    
    [Fact]
    public void ToReversedArray_Many()
    {
        var l = new LnkList(10, 20, 30);
        
        Assert.Equal(new[] { 30, 20, 10 }, l.ToReversedArray());
    }
    
    [Fact]
    public void ValidParenthesis_EmptyString()
    {
        Assert.True(LnkList.ValidParenthesis(""));
    }

    [Fact]
    public void ValidParenthesis_Valid()
    {
        Assert.True(LnkList.ValidParenthesis("()[]{}"));
    }

    [Fact]
    public void ValidParenthesis_Invalid()
    {
        Assert.False(LnkList.ValidParenthesis("(]"));
    }
    
    
}