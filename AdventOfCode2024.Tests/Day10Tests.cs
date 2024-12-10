using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day10Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day10.Day10(File.ReadAllLines("../../../Inputs/Day10Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(36));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day10.Day10(File.ReadAllLines("../../../Inputs/Day10.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day10.Day10(File.ReadAllLines("../../../Inputs/Day10Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(81));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day10.Day10(File.ReadAllLines("../../../Inputs/Day10.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}