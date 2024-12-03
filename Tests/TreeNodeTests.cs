using System.Collections;
using DataStructures;

namespace Tests;

public class TreeNodeTests
{
    [Fact]
    public void Constructor()
    {
        var t = new TreeNode<string>("Root");
        Assert.Equal("Root", t.Value);
        Assert.Empty(t.Children);
        Assert.Null(t.Parent);
    }
    
    [Fact]
    public void Add()
    {
        var t = new TreeNode<string>("Goku");
        t.Add("Gohan");

        var child = Assert.Single(t.Children);
        Assert.Equal("Gohan", child.Value);
    }
    
    [Fact]
    public void Count_One()
    {
        var t = new TreeNode<string>("Goku");
        Assert.Equal(1, t.Count());
    }
    
    [Fact]
    public void Count_ManyChildren()
    {
        var t = new TreeNode<string>("Goku");
        t.Add("Gohan");
        t.Add("Goten");
        Assert.Equal(3, t.Count());
    }
    
    [Fact]
    public void Count_OneGrandChildren()
    {
        var t = new TreeNode<string>("Goku");
        var gohan = t.Add("Gohan");
        gohan.Add("Pan");
        
        t.Add("Goten");
        Assert.Equal(4, t.Count());
    }
}