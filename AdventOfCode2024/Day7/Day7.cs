using System.Text;

namespace AdventOfCode2024.Day7;

public class Row
{
    public readonly long Result;
    private long[] _numbers;

    public Row(string line)
    {
        var parts = line.Split(':');
        Result = long.Parse(parts[0]);
        _numbers = parts[1].Trim().Split(' ').Select(long.Parse).ToArray();
    }

    public bool CanWork()
    {
        var max = Math.Pow(2, _numbers.Length - 1) - 1;
        var maxLength = Convert.ToString((int)max, 2).Length;
        
        for (var testSigns=0; testSigns<=max; testSigns++)
        {
            var binary = Convert.ToString(testSigns, 2).PadLeft(maxLength, '0');
            var total = CalcTotal(_numbers, binary);

            if (total == this.Result)
            {
                return true;
            }
        }

        return false;
    }
    
    private long CalcTotal(long[] numbers, string binary)
    {
        var total = numbers[0];
        var numbersPosition = 1;
        var binaryPosition = 0;

        while (numbersPosition < numbers.Length)
        {
            var value = numbers[numbersPosition];
            var signBinary = binary[binaryPosition];
            
            if (signBinary == '0')
            {
                total += value;
            }
            else if (signBinary == '1')
            {
                total *= value;
            }
            else
            {
                throw new Exception("Broken");
            }
            
            numbersPosition++;
            binaryPosition++;
        }

        return total;
    }
    
    public bool CanWorkWithConcat()
    {
        var max = Math.Pow(3, _numbers.Length - 1) - 1;
        var maxLength = ConvertIntToBase((int)max, 3).Length;
        
        for (var testSigns=0; testSigns<=max; testSigns++)
        {
            var trinary = ConvertIntToBase(testSigns, 3).PadLeft(maxLength, '0');
            var total = CalcTotalWithConcat(_numbers, trinary);

            if (total == this.Result)
            {
                return true;
            }
        }

        return false;
    }

    private const string Chars = "0123456789abcdefghijklmnopqrstuvwxyz";

    private static string ConvertIntToBase(int intToConvert, int baseNumber){
        StringBuilder builder = new StringBuilder();
        do{
            builder.Append(Chars[intToConvert % baseNumber]);
            intToConvert /= baseNumber;
        } while(intToConvert > 0);
        return new string(builder.ToString().Reverse().ToArray());
    }
    
    private long CalcTotalWithConcat(long[] numbers, string trinary)
    {
        var total = numbers[0];
        var numbersPosition = 1;
        var binaryPosition = 0;

        while (numbersPosition < numbers.Length)
        {
            var value = numbers[numbersPosition];
            var signBinary = trinary[binaryPosition];
            
            if (signBinary == '0')
            {
                total += value;
            }
            else if (signBinary == '1')
            {
                total *= value;
            }
            else if (signBinary == '2')
            {
                total = Convert.ToInt64(Convert.ToString(total) + Convert.ToString(value));
            }
            else
            {
                throw new Exception("Broken");
            }
            
            numbersPosition++;
            binaryPosition++;
        }

        return total;
    }
}

public class Day7(string[] readAllLines)
{
    private List<Row> _rows = [];
    
    public long SolvePart1()
    {
        foreach (var line in readAllLines)
        {
            var row = new Row(line);
            _rows.Add(row);
        }

        long result = 0;
        foreach (var row in _rows)
        {
            if (row.CanWork())
            {
                result += row.Result;
            }
        }

        return result;
    }

    public long SolvePart2()
    {
        foreach (var line in readAllLines)
        {
            var row = new Row(line);
            _rows.Add(row);
        }

        long result = 0;
        foreach (var row in _rows)
        {
            if (row.CanWork() || row.CanWorkWithConcat())
            {
                result += row.Result;
            }
        }

        return result;
    }
}