using System.Net;
using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Day6;

enum Direction
{
    Up, Down, Left, Right, OffMap
}

public class Position(int row, int column)
{
    public int Row = row;
    public int Column = column;
    
    public string ToString() => $"({Row}, {Column})";
}

public class Day6(string[] readAllLines)
{
    private Position current = new Position(-1, -1);
    private char[,] map;
    
    public long SolvePart1()
    {
        this.map = new char[readAllLines.Length,readAllLines[0].Length];
        
        var direction = Direction.Up;
        for (int row = 0; row < readAllLines.Length; row++)
        {
            for (int column = 0; column < readAllLines[row].Length; column++)
            {
                if (readAllLines[row][column] == '^')
                {
                    current = new Position(row, column);
                }
            }
        }
        
        //Console.WriteLine($"Starting from ${current.ToString()}");

        while ((direction = moveOne(direction)) != Direction.OffMap)
        {
            SetChar(current,'X');
        }

        var countSquares = 0;
        for (int row = 0; row < readAllLines.Length; row++)
        {
            for (int column = 0; column < readAllLines[row].Length; column++)
            {
                if (map[row,column] == 'X')
                {
                    countSquares++;
                }
            }
        }
        return countSquares;
    }

    private void SetChar(Position position, char c)
    {
        map[position.Row,position.Column] = c;
    }

    private Direction moveOne(Direction direction)
    {
        var next = nextPosition(direction);
        
        try
        {
            var character = readAllLines[next.Row][next.Column];

            while (character == '#')
            {
                direction = rotateRight(direction);
                next = nextPosition(direction);
                //Console.WriteLine("Turning");
                character = readAllLines[next.Row][next.Column];
            }

            //Console.WriteLine(next.ToString());
            current = next;
        }
        catch (IndexOutOfRangeException ex)
        {
            direction = Direction.OffMap;
        }

        return direction;
    }

    private Direction rotateRight(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Right;
            case Direction.Right:
                return Direction.Down;
            case Direction.Down:
                return Direction.Left;
            case Direction.Left:
                return Direction.Up;
        }
        return Direction.OffMap;
    }

    private Position nextPosition(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Position(current.Row - 1, current.Column);
            case Direction.Right:
                return new Position(current.Row, current.Column + 1);
            case Direction.Down:
                return new Position(current.Row + 1, current.Column);
            case Direction.Left:
                return new Position(current.Row, current.Column - 1);
        }
        return new Position(-1, -1);
    }

    public long SolvePart2()
    {
        for (int extraBlockrow = 0; extraBlockrow < readAllLines.Length; extraBlockrow++)
        {
            for (int extraBlockColumn = 0; extraBlockColumn < readAllLines[extraBlockrow].Length; extraBlockColumn++)
            {
                this.map = new char[readAllLines.Length,readAllLines[0].Length];
                var direction = Direction.Up;
                for (int row = 0; row < map.Length; row++)
                {
                    for (int column = 0; column < readAllLines[row].Length; column++)
                    {
                        this.map[row, column] = readAllLines[row][column];
               
                        if (readAllLines[row][column] == '^')
                        {
                            current = new Position(row, column);
                        }
                    }
                }
                
                if (map[extraBlockrow,extraBlockColumn] == '#')
                {
                    continue;
                }

                if (map[extraBlockrow,extraBlockColumn] == '^')
                {
                    continue;
                }
                
                if (map[extraBlockrow,extraBlockColumn] == 'X')
                {
                    continue;
                }

                map[extraBlockrow, extraBlockColumn] = '#';

                for (var countSquares = 0; countSquares < 1000; countSquares++)
                {
                    direction = moveOne(direction);
                    if (direction == Direction.OffMap)
                    {
                        break;
                    }
                    SetChar(current,'X');
                }
                
            }
        }




    

        var successfulBlockers = 0;
        for (int row = 0; row < readAllLines.Length; row++)
        {
            for (int column = 0; column < readAllLines[row].Length; column++)
            {
                if (map[row,column] == 'X')
                {
                    successfulBlockers++;
                }
            }
        }
        return successfulBlockers;
    }
}