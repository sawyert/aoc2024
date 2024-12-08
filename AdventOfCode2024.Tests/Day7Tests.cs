using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day7Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day7.Day7(File.ReadAllLines("../../../Inputs/Day7Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(3749));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day7.Day7(File.ReadAllLines("../../../Inputs/Day7.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day7.Day7(File.ReadAllLines("../../../Inputs/Day7Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(11387));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day7.Day7(File.ReadAllLines("../../../Inputs/Day7.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}