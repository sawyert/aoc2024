namespace AdventOfCode2024.Tests;

public class Day4Tests
{
    [Test]
    public void Part1Example()
    {
        var day = new Day4.Day4(File.ReadAllLines("../../../Inputs/Day4Example.txt"));
        var result = day.SolvePart1();
        
        Assert.That(result, Is.EqualTo(18));
    }
    
    [Test]
    public void Part1()
    {
        var day = new Day4.Day4(File.ReadAllLines("../../../Inputs/Day4.txt"));
        var result = day.SolvePart1();
        
        Console.WriteLine(result);
    }
    
    [Test]
    public void Part2Example()
    {
        var day = new Day4.Day4(File.ReadAllLines("../../../Inputs/Day4Example.txt"));
        var result = day.SolvePart2();
        
        Assert.That(result, Is.EqualTo(9));
    }
    
    [Test]
    public void Part2()
    {
        var day = new Day4.Day4(File.ReadAllLines("../../../Inputs/Day4.txt"));
        var result = day.SolvePart2();
        
        Console.WriteLine(result);
    }
}