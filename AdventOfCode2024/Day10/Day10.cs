using System.Diagnostics;
using System.Drawing;

namespace AdventOfCode2024.Day10;

public class TrailLocation(int row, int column, int height)
{
    public int Row { get; } = row;
    public int Column { get; } = column;
    public int Height { get; } = height;
}

public class TrailPath
{
    public List<TrailLocation> TrailLocations { get; } = [];

    public bool IsValid()
    {
        int position = 1;
        if (TrailLocations.Count != 8)
        {
            return false;
        }
        foreach (var location in TrailLocations)
        {
            if (location.Height != position)
            {
                return false;
            }

            position++;
        }

        return true;
    }
}

public class Trailhead(int row, int column, string[] map)
{
    public int Row { get; } = row;
    public int Column { get; } = column;

    private bool[,] NinesFoundOnMap = new bool[map.Length, map[0].Length];

    public int NinesFound { get; set; } = 0;
    public int RoutesFound { get; set; } = 0;
    
    readonly Point[] directions =
    [
        new(1, 0), new(0, 1), new(-1, 0), new(0, -1)
    ];

    public void CalculateScore()
    {
        CalculateScore(this.Row, this.Column);
    }
    
    private void CalculateScore(int row, int column)
    {
        if (map[row][column] == '9')
        {
            if (!NinesFoundOnMap[row, column])
            {
                NinesFoundOnMap[row, column] = true;
                NinesFound++;
            }

            RoutesFound++;
        }
        
        foreach (var direction in directions)
        {
            try
            {
                _ = map[row + direction.X][column + direction.Y];
            }
            catch (IndexOutOfRangeException e)
            {
                continue;
            }
            
            if (map[row + direction.X][column + direction.Y] == map[row][column] + 1)
            {
                CalculateScore(row + direction.X, column + direction.Y);
            }
        }
    }
}

public class Day10(string[] readAllLines)
{
    private readonly List<Trailhead> _trailheads = [];
    
    public long SolvePart1()
    {
        for (var row = 0; row < readAllLines.Length; row++)
        {
            for (var column = 0; column < readAllLines[row].Length; column++)
            {
                if (readAllLines[row][column] == '0')
                {
                    _trailheads.Add(new Trailhead(row, column, readAllLines));
                }
            }
        }

        long total = 0;
        foreach (var trailhead in _trailheads)
        {
            trailhead.CalculateScore();
            total += trailhead.NinesFound;
        }

        return total;
    }

    public long SolvePart2()
    {
        for (var row = 0; row < readAllLines.Length; row++)
        {
            for (var column = 0; column < readAllLines[row].Length; column++)
            {
                if (readAllLines[row][column] == '0')
                {
                    _trailheads.Add(new Trailhead(row, column, readAllLines));
                }
            }
        }

        long total = 0;
        foreach (var trailhead in _trailheads)
        {
            trailhead.CalculateScore();
            total += trailhead.RoutesFound;
        }

        return total;
    }
}