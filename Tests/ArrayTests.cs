namespace Tests;

public class ArrayTests
{
    [Fact]
    public void Static()
    {
        var a = new int[4];

        a[0] = 34;
        a[1] = 54;
        
        var expected = new[] { 34, 54, 0, 0 };
        
        Assert.Equal(expected, a);
        Assert.Throws<IndexOutOfRangeException>(() => a[4] = 34);
    }

    [Fact]
    public void Dynamic()
    {
        var a = new List<string>
        {
            "a", 
            "b",
            "c"
        };

        Assert.Equal(new[] { "a", "b", "c" }, a);
        Assert.Equal("a", a[0]);

        a[0] = "n";
        Assert.Equal("n", a[0]);
        
        a.Add("d");
        Assert.Equal(new[] { "n", "b", "c", "d" }, a);


        var l = new List<int>(2);
        
        l.Add(1);
        l.Add(2);
        
        Assert.Equal(2, l.Capacity);
        
        l.Add(3);
        
        Assert.Equal(4, l.Capacity);


        l.Remove(2);
        Assert.Equal(new[] { 1, 3 }, l);
        
        l.Insert(1, 2);
        Assert.Equal(new[] { 1, 2, 3 }, l);
    }
}