using Day8;

namespace Day8Tests;

public class MapTests
{
    [Fact]
    public void MapInitializedWithLRHas0And1Instructions()
    {
        // Arrange
        
        // Act
        var map = new Map(new string[]{"LR"});
        
        // Assert
        Assert.Equal(0, map.Instructions[0]);
        Assert.Equal(1, map.Instructions[1]);
    }
    
    [Fact]
    public void ExampleWith7CoordinatesHas7Coordinates()
    {
        // Arrange
        var testInput = new string[]
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)",
        };
        var map = new Map(testInput);
        
        // Act
        var coordinates = map.Coordinates;
        
        // Assert
        Assert.Equal(7, coordinates.Count);
    }

    [Fact]
    public void GoingFromAToZTakes2Steps()
    {
        // Arrange
        var testInput = new string[]
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)",
        };
        var map = new Map(testInput);
        
        // Act
        var steps = map.Traverse();
        
        // Assert
        Assert.Equal(2, steps);
    }

    [Fact]
    public void GoingFromAToZTakes6Steps()
    {
        // Arrange
        var testInput = new string[]
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        };
        var map = new Map(testInput);
        
        // Act
        var steps = map.Traverse();
        
        // Assert
        Assert.Equal(6, steps);
    }

    [Fact]
    public void GoingFromAllAsToAllZTakes6Steps()
    {
        // Arrange
        var testInput = new string[]
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
        };
        var map = new Map(testInput);
        
        // Act
        var steps = map.TraversePart2();
        
        // Assert
        Assert.Equal(6, steps);
    }
    
}