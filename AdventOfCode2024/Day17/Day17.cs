using System.Diagnostics.Metrics;
using System.Net;

namespace AdventOfCode2024.Day17;

public class Day17(string[] readAllLines)
{
    private long _registerA;
    private long _registerB;
    private long _registerC;
    private readonly List<long> _program = [];
    private string _fullProgramLine;

    public string SolvePart1()
    {
        ParseStart();

        return Execute();
    }
    
    private string Execute(string? checkAgainst = null)
    {
        var output = "";
        var instructionPointer = 0;
        
        while(instructionPointer < _program.Count)
        {
            var opcode = _program[instructionPointer];
            var operand = _program[instructionPointer + 1];

            switch (opcode)
            {
                case 0:
                    instructionPointer = Adv(instructionPointer, operand); break;
                case 1:
                    instructionPointer = Bxl(instructionPointer, operand); break;
                case 2:
                    instructionPointer = Bst(instructionPointer, operand); break;
                case 3:
                    instructionPointer = Jnz(instructionPointer, operand); break;
                case 4:
                    instructionPointer = Bxc(instructionPointer); break;
                case 5:
                    (instructionPointer, output) = Out(instructionPointer, operand, output); break;
                case 6:
                    instructionPointer = Bdv(instructionPointer, operand); break;
                case 7:
                    instructionPointer = Cdv(instructionPointer, operand); break;
            }

            if (checkAgainst == null) continue;
            if (checkAgainst.Length > _fullProgramLine.Length)
            {
                return "No solution";
            }

            if (_fullProgramLine.StartsWith(checkAgainst) == false)
            {
                return "No solution";
            }
        }

        return output;
    }

    private int Bxl(int instructionPointer, long operand)
    {
        var value = _registerB ^ operand;
        _registerB = value;
        
        return instructionPointer + 2;
    }

    private int Bst(int instructionPointer, long operand)
    {
        var value = Combo(operand) % 8;
        _registerB = value;
        
        return instructionPointer + 2;
    }

    private int Jnz(int instructionPointer, long operand)
    {
        if (_registerA == 0)
        {
            return instructionPointer + 2;
        }

        return Convert.ToInt16(operand);
    }

    private int Bxc(int instructionPointer)
    {
        var result = _registerB ^ _registerC;
        _registerB = result;
        
        return instructionPointer + 2;
    }

    private (int instructionPointer, string output) Out(int instructionPointer, long operand, string output)
    {
        var newOutput = output;

        var value = Combo(operand) % 8;
        if (newOutput.Length > 0)
        {
            newOutput += ",";
        }

        newOutput += value;
        
        return (instructionPointer + 2, newOutput);
    }

    private int Adv(int instructionPointer, long operand)
    {
        var comboOperand = Combo(operand);
        var numerator = _registerA;
        var denominator = Math.Pow(2, comboOperand);

        var value = numerator / denominator;
        _registerA = Convert.ToInt64(Math.Floor(value));

        return instructionPointer + 2;
    }
    
    private int Bdv(int instructionPointer, long operand)
    {
        var comboOperand = Combo(operand);
        var numerator = _registerA;
        var denominator = Math.Pow(2, comboOperand);

        var value = numerator / denominator;
        _registerB = Convert.ToInt64(Math.Floor(value));

        return instructionPointer + 2;
    }
    
    private int Cdv(int instructionPointer, long operand)
    {
        var comboOperand = Combo(operand);
        var numerator = _registerA;
        var denominator = Math.Pow(2, comboOperand);

        var value = numerator / denominator;
        _registerC = Convert.ToInt64(Math.Floor(value));

        return instructionPointer + 2;
    }

    private long Combo(long operandValue)
    {
        return operandValue switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            3 => 3,
            4 => _registerA,
            5 => _registerB,
            6 => _registerC,
            _ => throw new NotImplementedException()
        };
    }

    private void ParseStart()
    {
        _registerA = ParseRegister(readAllLines[0]);
        _registerB = ParseRegister(readAllLines[1]);
        _registerC = ParseRegister(readAllLines[2]);

        _fullProgramLine = readAllLines[4]["Program: ".Length..].Trim();
        var programString = _fullProgramLine.Split(",");
        foreach (var programLine in programString)
        {
            _program.Add(long.Parse(programLine));
        }
    }

    private long ParseRegister(string registerLine)
    {
        var value = registerLine["Register N: ".Length..];
        return long.Parse(value);
    }

    public long SolvePart2()
    {
        for (var counter = 1; counter < 1000000; counter++)
        {
            ParseStart();
            _registerA = counter;
            var result = Execute(_fullProgramLine);

            if (result.Equals(_fullProgramLine))
            {
                return counter;
            }

            counter++;
        }

        return -1;
    }
}