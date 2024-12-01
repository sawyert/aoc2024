using System.Security.Principal;

namespace AdventOfCode2024.Day1;

public class Day1
{
    private string[] _input;
    private int[] _list1;
    private int[] _list2;
    
    public Day1(string[] input)
    {
        this._input = input;

        _list1 = new int[_input.Length];
        _list2 = new int[_input.Length];
        var position = 0;
        foreach (var line in _input)
        {
            var sections = line.Split("   ");

            _list1[position] = Convert.ToInt32(sections[0]);
            _list2[position] = Convert.ToInt32(sections[1]);
            
            position++;
        }
    }
    
    public long SolvePart1()
    {
        Array.Sort(_list1);
        Array.Sort(_list2);

        long total = 0;

        for (var i = 0; i < _list1.Length; i++)
        {
            var value1 = _list1[i];
            var value2 = _list2[i];
            var diff = Math.Abs(value1 - value2);
            
            total += diff;
        }

        return total;
    }

    public long SolvePart2()
    {
        long similarity = 0;

        for (var i = 0; i < _list1.Length; i++)
        {
            var value1 = _list1[i];
            var countInListTwo = this.countInstancesInList2(value1);

            similarity += value1 * countInListTwo;
        }

        return similarity;
    }

    private int countInstancesInList2(int value1)
    {
        var count = 0;
        
        for (var i = 0; i < _list2.Length; i++)
        {
            var value2 = _list2[i];
            if (value2 == value1)
            {
                count++;
            }
        }

        return count;

    }
}