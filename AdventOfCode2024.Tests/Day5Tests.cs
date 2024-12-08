using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day5Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day5.Day5(File.ReadAllLines("../../../Inputs/Day5Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(143));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day5.Day5(File.ReadAllLines("../../../Inputs/Day5.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day5.Day5(File.ReadAllLines("../../../Inputs/Day5Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(123));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day5.Day5(File.ReadAllLines("../../../Inputs/Day5.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.LessThan(5536));
        Console.WriteLine(result);
    }
}