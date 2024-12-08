using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day6Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day6.Day6(File.ReadAllLines("../../../Inputs/Day6Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(41));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day6.Day6(File.ReadAllLines("../../../Inputs/Day6.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.GreaterThan(4938));
        Assert.That(result, Is.EqualTo(4939));
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day6.Day6(File.ReadAllLines("../../../Inputs/Day6Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day6.Day6(File.ReadAllLines("../../../Inputs/Day6.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}