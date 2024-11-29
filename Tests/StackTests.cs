using DataStructures;

namespace Tests;

public class StackTests
{
    [Fact]
    public void Pop_OneElement()
    {
        var s = new Stk<string>();
        s.Push("a");

        Assert.Equal("a", s.Pop());

        Assert.Empty(s.ToArray());
    }
    
    [Fact]
    public void Pop_Empty()
    {
        var s = new Stk<string>();
        Assert.Throws<InvalidOperationException>(
            () => s.Pop());
        
        s.Push("a");
        s.Pop();
        Assert.Throws<InvalidOperationException>(
            () => s.Pop());
    }
    
    [Fact]
    public void Peek()
    {
        var s = new Stk<int>();
        
        s.Push(1);
        Assert.Equal(1, s.Peek());
        Assert.Equal(new[] { 1 }, s.ToArray());
    }
    
    [Fact]
    public void Peek_Empty()
    {
        var s = new Stk<string>();
        Assert.Throws<InvalidOperationException>(
            () => s.Peek());
    }
}
