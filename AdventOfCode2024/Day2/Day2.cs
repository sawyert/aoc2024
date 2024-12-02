using System.ComponentModel;

namespace AdventOfCode2024.Day2;

public class Day2(string[] readAllLines)
{
    public long SolvePart1()
    {
        var count = 0L;
        foreach (var line in readAllLines)
        {
            count += ProcessLinePart1(line);
        }

        return count;
    }
    
    private static int ProcessLinePart1(string line)
    {
        //Console.WriteLine(line);

        var decreasing = false;
        var increasing = false;
        
        var parts = line.Split(" ");
        for (var i = 0; i < parts.Length - 1; i++)
        {
            var thisNumber = Int32.Parse(parts[i]);
            var nextNumber = Int32.Parse(parts[i + 1]);

            if (thisNumber > nextNumber) increasing = true;
            if (thisNumber < nextNumber) decreasing = true;
            if (thisNumber == nextNumber)
            {
                //Console.WriteLine("Same number found");
                return 0;
            }

            if (Math.Abs(thisNumber - nextNumber) > 3)
            {
                //Console.WriteLine("Gap bigger than three");
                return 0;
            }
        }

        if (increasing && decreasing)
        {
            //Console.WriteLine("Both increasing and decreasing");
            return 0;
        }

        if (!increasing && !decreasing)
        {
            //Console.WriteLine("Neither increasing or decreasing");
            return 0;
        }

        //Console.WriteLine("Valid");
        return 1;
    }
    
    public long SolvePart2()
    {
        var count = 0L;
        foreach (var line in readAllLines)
        {
            var parts = line.Split(" ");
            var lineInts = parts.Select(int.Parse).ToList();
            if (ProcessLinePart2(lineInts))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsSafe(List<int> line)
    {
        var decreasing = false;
        var increasing = false;
        
        for (var i = 0; i < line.Count - 1; i++)
        {
            var thisNumber = line[i];
            var nextNumber = line[i + 1];

            if (thisNumber > nextNumber) increasing = true;
            if (thisNumber < nextNumber) decreasing = true;
            if (thisNumber == nextNumber)
            {
                //Console.WriteLine("Same number found");
                return false;
            }

            if (Math.Abs(thisNumber - nextNumber) > 3)
            {
                //Console.WriteLine("Gap bigger than three");
                return false;
            }
        }

        if (increasing && decreasing)
        {
            //Console.WriteLine("Both increasing and decreasing");
            return false;
        }

        if (!increasing && !decreasing)
        {
            //Console.WriteLine("Neither increasing or decreasing");
            return false;
        }

        //Console.WriteLine("Valid");
        return true;
    }

    private static bool ProcessLinePart2(List<int> line)
    {
        if (IsSafe(line))
        {
            return true;
        }

        for (var i = 0; i < line.Count; i++)
        {
            var partialLine = new List<int>(line);
            partialLine.RemoveAt(i);
            if (IsSafe(partialLine))
            {
                return true;
            }
        }

        return false;
    }
}