namespace Tests;

public class QueueTests
{
    [Fact]
    public void Dequeue()
    {
        var q = new Queue<int>();
        
        q.Enqueue(10);
        q.Enqueue(20);
        Assert.Equal(10, q.Dequeue());
        Assert.Equal(20, q.Dequeue());
        Assert.Empty(q);
    }
    
    [Fact]
    public void Dequeue_Empty()
    {
        var q = new Queue<int>();
        Assert.Throws<InvalidOperationException>(() => q.Dequeue());
    }
    
    [Fact]
    public void Peek()
    {
        var q = new Queue<int>();
        q.Enqueue(10);
        Assert.Equal(10, q.Peek());
        Assert.Single(q);
    }
}