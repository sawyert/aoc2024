namespace AdventOfCode2024.Day4;

public class Position
{
    private readonly bool _outOfBounds;
    private readonly int _maxRow;
    private readonly int _maxColumn;
    
    public Position(int row, int column, int maxRow, int maxColumn)
    {
        Row = row;
        Column = column;
        _maxRow = maxRow;
        _maxColumn = maxColumn;
        
        if (row >= _maxRow || row < 0 || column >= _maxColumn || column < 0)
        {
            _outOfBounds = true;
        }
        else
        {
            _outOfBounds = false;
        }
    }
    
    public bool IsOutOfBounds() => _outOfBounds;
    
    public int Row { get; }
    public int Column { get; }
    public Position Up => Get(Row - 1, Column);
    public Position Down => Get(Row + 1, Column);
    public Position Left => Get(Row, Column - 1);
    public Position Right => Get(Row, Column + 1);
    public Position UpLeft => Get(Row - 1, Column - 1);
    public Position DownLeft => Get(Row + 1, Column - 1);
    public Position DownRight => Get(Row + 1, Column + 1);
    public Position UpRight => Get(Row - 1, Column + 1);

    private Position Get(int row, int column)
    {
        return new Position(row, column, _maxRow, _maxColumn);
    }
}

public class Day4(string[] input)
{
    public long SolvePart1()
    {
        var xPositions = new List<Position>();

        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                if (input[row][column] == 'X')
                {
                    xPositions.Add(new Position(row, column, input.Length, input[0].Length));
                }
            }
        }

        long xmasCount = 0;

        foreach (var position in xPositions)
        {
            xmasCount += FindWordsFrom(position, "XMAS");
        }
        
        return xmasCount;
    }

    private char GetCharAt(Position position)
    {
        return position.IsOutOfBounds() ? '_' : input[position.Row][position.Column];
    }

    private long FindWordsFrom(Position position, string word)
    {
        long wordsFound = 0;
        
        if (GetCharAt(position) != word[0])
        {
            throw new Exception($"Gone wrong {word[0]} {GetCharAt(position)} at position {position.Row}, {position.Column}");
        }

        if (GetCharAt(position.Up) == word[1])
        {
            if (GetCharAt(position.Up.Up) == word[2])
            {
                if (GetCharAt(position.Up.Up.Up) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.UpRight) == word[1])
        {
            if (GetCharAt(position.UpRight.UpRight) == word[2])
            {
                if (GetCharAt(position.UpRight.UpRight.UpRight) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.Right) == word[1])
        {
            if (GetCharAt(position.Right.Right) == word[2])
            {
                if (GetCharAt(position.Right.Right.Right) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.DownRight) == word[1])
        {
            if (GetCharAt(position.DownRight.DownRight) == word[2])
            {
                if (GetCharAt(position.DownRight.DownRight.DownRight) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.Down) == word[1])
        {
            if (GetCharAt(position.Down.Down) == word[2])
            {
                if (GetCharAt(position.Down.Down.Down) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.DownLeft) == word[1])
        {
            if (GetCharAt(position.DownLeft.DownLeft) == word[2])
            {
                if (GetCharAt(position.DownLeft.DownLeft.DownLeft) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.Left) == word[1])
        {
            if (GetCharAt(position.Left.Left) == word[2])
            {
                if (GetCharAt(position.Left.Left.Left) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        if (GetCharAt(position.UpLeft) == word[1])
        {
            if (GetCharAt(position.UpLeft.UpLeft) == word[2])
            {
                if (GetCharAt(position.UpLeft.UpLeft.UpLeft) == word[3])
                {
                    wordsFound++;
                }
            }
        }
        
        return wordsFound;
    }

    public long SolvePart2()
    {
        var aPositions = new List<Position>();

        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                if (input[row][column] == 'A')
                {
                    aPositions.Add(new Position(row, column, input.Length, input[0].Length));
                }
            }
        }

        long xmasCount = 0;

        foreach (var position in aPositions)
        {
            xmasCount += FindXFrom(position);
        }
        
        return xmasCount;
    }
    
    private long FindXFrom(Position position)
    {
        long xFound = 0;
        
        if (GetCharAt(position) != 'A')
        {
            throw new Exception($"Gone wrong A {GetCharAt(position)} at position {position.Row}, {position.Column}");
        }

        if (GetCharAt(position.UpLeft) == 'M')
        {
            if (GetCharAt(position.DownLeft) == 'M')
            {
                if (GetCharAt(position.UpRight) == 'S')
                {
                    if (GetCharAt(position.DownRight) == 'S')
                    {
                        xFound++;
                    }
                }
            }
        }
        
        if (GetCharAt(position.UpLeft) == 'S')
        {
            if (GetCharAt(position.DownLeft) == 'S')
            {
                if (GetCharAt(position.UpRight) == 'M')
                {
                    if (GetCharAt(position.DownRight) == 'M')
                    {
                        xFound++;
                    }
                }
            }
        }
        
        if (GetCharAt(position.UpLeft) == 'S')
        {
            if (GetCharAt(position.DownLeft) == 'M')
            {
                if (GetCharAt(position.UpRight) == 'S')
                {
                    if (GetCharAt(position.DownRight) == 'M')
                    {
                        xFound++;
                    }
                }
            }
        }
        
        if (GetCharAt(position.UpLeft) == 'M')
        {
            if (GetCharAt(position.DownLeft) == 'S')
            {
                if (GetCharAt(position.UpRight) == 'M')
                {
                    if (GetCharAt(position.DownRight) == 'S')
                    {
                        xFound++;
                    }
                }
            }
        }
        
        
        
        return xFound;
    }
}