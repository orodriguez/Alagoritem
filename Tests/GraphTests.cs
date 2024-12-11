using DataStructures;

namespace Tests;

public class GraphTests
{
    [Fact]
    public void Paths_StartDoesNotExist()
    {
        var g = new Graph<string>();

        var paths = g.Paths("A", "B");
        
        Assert.Empty(paths);
    }
    
    [Fact]
    public void Paths_StartEqualsEnd()
    {
        var g = new Graph<string>();

        g.Add("A", "B");

        var paths = g.Paths("A", "A");
        
        var path = Assert.Single(paths);
        
        Assert.Equal(new[] { "A" }, path);
    }
    
    [Fact]
    public void Paths_OneEdge()
    {
        var g = new Graph<string>();

        g.Add("A", "B");

        var paths = g.Paths("A", "B");
        
        var path = Assert.Single(paths);
        
        Assert.Equal(new[] { "A", "B" }, path);
    }
    
    [Fact]
    public void Paths_TwoConnected_Edges()
    {
        var g = new Graph<string>();

        g.Add("A", "B");
        g.Add("B", "C");

        var paths = g.Paths("A", "C");
        
        var path = Assert.Single(paths);
        
        Assert.Equal(new[] { "A", "B", "C" }, path);
    }
    
    [Fact]
    public void Paths_TwoPaths()
    {
        var g = new Graph<string>();

        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "D");
        
        g.Add("A", "C");

        var paths = g.Paths("A", "D");
        
        Assert.Equal(new[]
        {
            new[] { "A", "B", "C", "D" },
            new[] { "A", "C", "D" }
        }, paths);
    }
    
    [Fact]
    public void Paths_Circular()
    {
        var g = new Graph<string>();

        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "D");
        
        g.Add("C", "A");

        var paths = g.Paths("A", "D");
        
        Assert.Equal(new[]
        {
            new[] { "A", "B", "C", "D" }
        }, paths);
    }

    [Fact]
    public void Paths_Complex()
    {
        var g = new Graph<string>();
        
        g.Add("SD", "San Cristobal");
        g.Add("SD", "Monte Plata");
        g.Add("San Cristobal", "Bonao");
        g.Add("Monte Plata", "San Cristobal");
        g.Add("Monte Plata", "Bonao");
        g.Add("Monte Plata", "Cotui");
        g.Add("Bonao", "La Vega");
        g.Add("Cotui", "La Vega");
        g.Add("La Vega", "Santiago");

        var paths = g.Paths("SD", "Santiago");
        
        Assert.Equal(new[]
        {
            new[] { "SD", "San Cristobal", "Bonao", "La Vega", "Santiago" },
            new[] { "SD", "Monte Plata", "San Cristobal", "Bonao", "La Vega", "Santiago" },
            new[] { "SD", "Monte Plata", "Bonao", "La Vega", "Santiago" },
            new[] { "SD", "Monte Plata", "Cotui", "La Vega", "Santiago" },
        }, paths);
    }
}