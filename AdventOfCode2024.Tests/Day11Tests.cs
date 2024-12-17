using NuGet.Frameworks;

namespace AdventOfCode2024.Tests;

public class Day11Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day11.Day11(File.ReadAllLines("../../../Inputs/Day11Example.txt"));
        var result = day.Solve(25);
        
        Assert.That(result, Is.EqualTo(55312));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day11.Day11(File.ReadAllLines("../../../Inputs/Day11.txt"));
        var result = day.Solve(25);
        
        Assert.That(result, Is.EqualTo(198089));
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day11.Day11(File.ReadAllLines("../../../Inputs/Day11.txt"));
        var result = day.Solve(75);
        
        Console.WriteLine(result);
    }
}