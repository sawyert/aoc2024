namespace AdventOfCode2024.Tests;

public class Day3Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day3.Day3(File.ReadAllLines("../../../Inputs/Day3Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(161));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day3.Day3(File.ReadAllLines("../../../Inputs/Day3.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day3.Day3(File.ReadAllLines("../../../Inputs/Day3Example2.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(48));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day3.Day3(File.ReadAllLines("../../../Inputs/Day3.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}