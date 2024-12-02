namespace AdventOfCode2024.Tests;

public class Day2Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day2.Day2(File.ReadAllLines("../../../Inputs/Day2Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day2.Day2(File.ReadAllLines("../../../Inputs/Day2.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day2.Day2(File.ReadAllLines("../../../Inputs/Day2Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(4));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day2.Day2(File.ReadAllLines("../../../Inputs/Day2.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}