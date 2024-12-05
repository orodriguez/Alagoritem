using DataStructures;

namespace Tests;

public class BSTreeNodeTests
{
    [Fact]
    public void Constructor()
    {
        var n = new BSTreeNode(1);
        
        Assert.Equal(1, n.Value);
        Assert.Null(n.Right);
        Assert.Null(n.Left);
    }
    
    [Fact]
    public void Add_AlreadyExist()
    {
        var n = new BSTreeNode(10);
        n.Add(10);
        
        Assert.Null(n.Left);
        Assert.Null(n.Right);
    }
    
    [Fact]
    public void Add_AlreadyExistInLeft()
    {
        var n = new BSTreeNode(10);
        n.Add(5);
        n.Add(5);
        
        Assert.NotNull(n.Left);
        Assert.Null(n.Left.Left);
    }
    
    [Fact]
    public void Add_LeftIsNull_AddLeft()
    {
        var n = new BSTreeNode(10);

        n.Add(5);
        
        Assert.NotNull(n.Left);
        Assert.Equal(5, n.Left.Value);
    }
    
    [Fact]
    public void Add_LeftIsNotNull_AddLeft()
    {
        var n = new BSTreeNode(10);

        n.Add(7);
        n.Add(6);
        n.Add(5);
                
        Assert.NotNull(n.Left);
        Assert.Equal(7, n.Left.Value);
        
        Assert.NotNull(n.Left.Left);
        Assert.Equal(6, n.Left.Left.Value);
        
        Assert.NotNull(n.Left.Left.Left);
        Assert.Equal(5, n.Left.Left.Left.Value);
    }
    
    [Fact]
    public void Add_RightIsNull_AddRight()
    {
        var n = new BSTreeNode(10);

        n.Add(15);
        
        Assert.NotNull(n.Right);
        Assert.Equal(15, n.Right.Value);
    }
    
    [Fact]
    public void Add_RightIsNotNull_AddRight()
    {
        var n = new BSTreeNode(10);

        n.Add(11);
        n.Add(12);
        n.Add(13);
                
        Assert.NotNull(n.Right);
        Assert.Equal(11, n.Right.Value);
        
        Assert.NotNull(n.Right.Right);
        Assert.Equal(12, n.Right.Right.Value);
        
        Assert.NotNull(n.Right.Right.Right);
        Assert.Equal(13, n.Right.Right.Right.Value);
    }

    [Fact]
    public void Contains_InRoot()
    {
        var n = new BSTreeNode(10);
        
        Assert.True(n.Contains(10));
    }
    
    [Fact]
    public void Contains_InLeft()
    {
        var n = new BSTreeNode(10, 5, 1);

        Assert.True(n.Contains(1));
    }
    
    [Fact]
    public void Contains_InLeft_NotFound()
    {
        var n = new BSTreeNode(10);

        Assert.False(n.Contains(5));
    }
    
    [Fact]
    public void Contains_InRight()
    {
        var n = new BSTreeNode(10, 15, 20);

        Assert.True(n.Contains(20));
    }
    
    [Fact]
    public void Contains_InRight_NotFound()
    {
        var n = new BSTreeNode(10);

        Assert.False(n.Contains(15));
    }
}