using Day5;

namespace Day5Tests;

public class MapTests
{
    [Fact]
    public void DefaultMapReturnsTheSameNumber()
    {
        // Arrange
        var map = new Map();
        
        // Act
        var result = map.Get(5);
        
        // Assert
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void MapWithEntryReturnsTheMappedNumber()
    {
        // Arrange
        var map = new Map();
        map.Add(50, 98, 1);
        
        // Act
        var result = map.Get(98);
        
        // Assert
        Assert.Equal(50, result);
    }
    
    [Fact]
    public void MapWithEntryFromRangeReturnsTheMappedNumber()
    {
        // Arrange
        var map = new Map();
        map.Add(50, 98, 2);
        
        // Act
        var result = map.Get(99);
        
        // Assert
        Assert.Equal(51, result);
    }

    [Fact]
    public void MapWithEntryStillReturnsTheSameNumberIfNotFoundInTheMap()
    {
        // Arrange
        var map = new Map();
        map.Add(50, 98, 1);
        
        // Act
        var result = map.Get(99);
        
        // Assert
        Assert.Equal(99, result);
    }
}