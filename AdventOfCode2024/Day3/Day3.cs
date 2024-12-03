using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public class Day3(string[] readAllLines)
{
    private const string Pattern1 = @"mul\(\d{1,3},\d{1,3}\)";
    private const string Pattern2 = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don\'t\(\)";
    
    public long SolvePart1()
    {
        var total = 0L;

        foreach (var line in readAllLines)
        {
            total += CountMuls1(line);
        }

        return total;
    }

    private static long CountMuls1(string line)
    {
        var total = 0L;
        
        var rg = new Regex(Pattern1);
        var matches = rg.Matches(line);

        for (int count = 0; count < matches.Count; count++)
        {
            var numbersString = matches[count].Value.Substring("mul(".Length);
            numbersString = numbersString.Substring(0, numbersString.Length - 1);
            var numbers = numbersString.Split(",");
            
            total += long.Parse(numbers[0]) * long.Parse(numbers[1]);
        }

        return total;
    }
    
    public long SolvePart2()
    {
        var total = 0L;

        var fullArray = "";
        
        foreach (var line in readAllLines)
        {
            fullArray += line;
        }

        total = CountMuls2(fullArray);

        return total;
    }

    private static long CountMuls2(string line)
    {
        var total = 0L;
        
        var rg = new Regex(Pattern2);
        var matches = rg.Matches(line);

        bool enabled = true;
        
        for (int count = 0; count < matches.Count; count++)
        {
            var match = matches[count];

            if (match.Value.StartsWith("mul") && enabled)
            {
               var numbersString = matches[count].Value.Substring("mul(".Length);
                numbersString = numbersString.Substring(0, numbersString.Length - 1);
                var numbers = numbersString.Split(",");

                total += long.Parse(numbers[0]) * long.Parse(numbers[1]);
            }

            if (match.Value.StartsWith("do()"))
            {
                enabled = true;
            }

            if (match.Value.StartsWith("don"))
            {
                enabled = false;
            }
        }

        return total;
    }
}