using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day8Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day8.Day8(File.ReadAllLines("../../../Inputs/Day8Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(14));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day8.Day8(File.ReadAllLines("../../../Inputs/Day8.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.LessThan(310));
        Assert.That(result, Is.GreaterThan(248));
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day8.Day8(File.ReadAllLines("../../../Inputs/Day8Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(34));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day8.Day8(File.ReadAllLines("../../../Inputs/Day8.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.GreaterThan(453));
        Console.WriteLine(result);
    }
}