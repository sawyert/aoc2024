namespace AdventOfCode2024.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day1Part1Example()
    {
        var day = new Day1.Day1(File.ReadAllLines("../../../Inputs/Day1Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(11));
    }
    
    [Test]
    public void Day1Part1()
    {
        var day = new Day1.Day1(File.ReadAllLines("../../../Inputs/Day1.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Day1Part2Example()
    {
        var day = new Day1.Day1(File.ReadAllLines("../../../Inputs/Day1Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(31));
    }
    
    [Test]
    public void Day1Part2()
    {
        var day = new Day1.Day1(File.ReadAllLines("../../../Inputs/Day1.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}