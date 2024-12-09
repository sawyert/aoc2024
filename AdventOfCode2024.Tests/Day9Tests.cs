using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day9Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day9.Day9(File.ReadAllLines("../../../Inputs/Day9Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(1928));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day9.Day9(File.ReadAllLines("../../../Inputs/Day9.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day9.Day9(File.ReadAllLines("../../../Inputs/Day9Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(2858));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day9.Day9(File.ReadAllLines("../../../Inputs/Day9.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.LessThan(6238375797930));
        Console.WriteLine(result);
    }
}