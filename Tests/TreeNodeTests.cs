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

    [Fact]
    public void Level()
    {
        var goku = new TreeNode<string>("Goku");
        Assert.Equal(0, goku.Level);
        var gohan = goku.Add("Gohan");
        Assert.Equal(1, gohan.Level);
        var pan = gohan.Add("Pan");
        Assert.Equal(2, pan.Level);
    }

    [Fact]
    public void Height_Root()
    {
        var goku = new TreeNode<string>("Goku");
        Assert.Equal(0, goku.Height());
    }

    [Fact]
    public void Height()
    {
        var goku = new TreeNode<string>("Goku");
        goku
            .Add("Gohan")
            .Add("Pan");

        Assert.Equal(2, goku.Height());
    }

    [Fact]
    public void Search_Root()
    {
        var root = new TreeNode<string>("Goku");
        var node = root.Search("Goku");

        Assert.Equal("Goku", node.Value);
    }

    [Fact]
    public void Search_Child()
    {
        var root = new TreeNode<string>("Goku");
        root.Add("Gohan");
        var node = root.Search("Gohan");

        Assert.NotNull(node);
        Assert.Equal("Gohan", node.Value);
    }

    [Fact]
    public void Search_GrandChild()
    {
        var root = new TreeNode<string>("Goku");
        root.Add("Gohan").Add("Pan");
        var node = root.Search("Pan");

        Assert.NotNull(node);
        Assert.Equal("Pan", node.Value);
    }

    [Fact]
    public void Search_GrandChildNotFound()
    {
        var root = new TreeNode<string>("Goku");
        root
            .Add("Gohan")
            .Add("Pan");

        Assert.Null(root.Search("Unknown"));
    }

    [Fact]
    public void Search_PreOrderTraverse()
    {
        var bardock = new TreeNode<string>("Bardock");
        var goku = bardock.Add("Goku");

        goku.Add("Gohan")
            .Add("Pan");
        goku.Add("Goten");

        bardock
            .Add("Raditz");

        var list = new List<TreeNode<string>>();
        bardock.PreOrderTraverse(node => list.Add(node));

        Assert.Equal(new[]
            {
                "Bardock",
                "Goku",
                "Gohan",
                "Pan",
                "Goten",
                "Raditz"
            },
            list.Select(node => node.Value));
    }
    
    [Fact]
    public void Search_PostOrderTraverse()
    {
        var bardock = new TreeNode<string>("Bardock");
        var goku = bardock.Add("Goku");

        goku.Add("Gohan")
            .Add("Pan");
        goku.Add("Goten");

        bardock
            .Add("Raditz");

        var list = new List<TreeNode<string>>();
        bardock.PostOrderTraverse(node => list.Add(node));

        Assert.Equal(new[]
            {
                "Pan",
                "Gohan",
                "Goten",
                "Goku",
                "Raditz",
                "Bardock"
            },
            list.Select(node => node.Value));
    }
    
    [Fact(Skip = "Homework")]
    public void Search_LevelTraverse()
    {
        var bardock = new TreeNode<string>("Bardock");
        var goku = bardock.Add("Goku");

        goku.Add("Gohan")
            .Add("Pan");
        goku.Add("Goten");

        bardock
            .Add("Raditz");

        var list = new List<TreeNode<string>>();
        bardock.LevelTraverse(node => list.Add(node));

        Assert.Equal(new[]
            {
                "Bardock",
                "Goku",
                "Raditz",
                "Gohan",
                "Goten",
                "Pan"
            },
            list.Select(node => node.Value));
    }
}