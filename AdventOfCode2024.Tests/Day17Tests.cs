namespace AdventOfCode2024.Tests;

public class Day17Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day17.Day17(File.ReadAllLines("../../../Inputs/Day17Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo("4,6,3,5,6,3,5,2,1,0"));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day17.Day17(File.ReadAllLines("../../../Inputs/Day17.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day17.Day17(File.ReadAllLines("../../../Inputs/Day17Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(117440));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day17.Day17(File.ReadAllLines("../../../Inputs/Day17.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}