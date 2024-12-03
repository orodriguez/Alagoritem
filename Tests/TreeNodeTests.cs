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
}