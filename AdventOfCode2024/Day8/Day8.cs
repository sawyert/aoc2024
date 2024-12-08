using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day8;

public class Location(int row, int column)
{
    public int Row { get; } = row;
    public int Column { get; } = column;
}
    

public class Day8(string[] readAllLines)
{
    public long SolvePart1()
    {
        var antennas = parseMap(readAllLines);

        var allLocations = Energise(antennas,false);

        var count = 0;
        foreach (var location in allLocations)
        {
            if (location.Column < 0 || location.Column > readAllLines[0].Length - 1)
            {
                continue;
            }
            if (location.Row < 0 || location.Row > readAllLines.Length - 1)
            {
                continue;
            }
            count++;
        }
        
        return count;
    }

    private List<Location> Energise(Dictionary<string, List<Location>> antennas, bool includeAntennas)
    {   
        var allAntiNodeLocations = new List<Location>();
        foreach (var key in antennas.Keys)
        {
            var listToAdd = Energise(key, antennas[key], includeAntennas);
            foreach (var newAntiNode in listToAdd)
            {
                var exists = false;
                foreach (var location in allAntiNodeLocations)
                {
                    if (location.Column == newAntiNode.Column && location.Row == newAntiNode.Row)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    allAntiNodeLocations.Add(newAntiNode);
                }
            }
        }
        
        return allAntiNodeLocations;
    }

    private List<Location> Energise(string antennaName, List<Location> antennas, bool includeAntennas)
    {
        var antiNodeLocations = new List<Location>();
        for (var outer = 0; outer < antennas.Count; outer++)
        {
            var outerAntenna = antennas[outer];
            for (var inner=outer+1; inner < antennas.Count; inner++)
            {
                var innerAntenna = antennas[inner];
                var antiNodes = BuildAntiNodes(outerAntenna, innerAntenna, includeAntennas);
                antiNodeLocations.AddRange(antiNodes);
            }
        }

        return antiNodeLocations;
    }

    private List<Location> BuildAntiNodes(Location firstAntenna, Location secondAntenna, bool includeAntennas)
    {
        var nodesList = new List<Location>();

        switch (includeAntennas)
        {
            // part1
            case false:
            {
                var antiNodeRow1 = secondAntenna.Row - (firstAntenna.Row - secondAntenna.Row);
                var antiNodeColumn1 = secondAntenna.Column - (firstAntenna.Column - secondAntenna.Column);
                var antiNodeLocation1 = new Location(antiNodeRow1, antiNodeColumn1);
                nodesList.Add(antiNodeLocation1);

                var antiNodeRow2 = firstAntenna.Row + (firstAntenna.Row - secondAntenna.Row);
                var antiNodeColumn2 = firstAntenna.Column + (firstAntenna.Column - secondAntenna.Column);
                var antiNodeLocation2 = new Location(antiNodeRow2, antiNodeColumn2);
                nodesList.Add(antiNodeLocation2);
                break;
            }
            // part2
            case true:
            {
                this.AddLocation(nodesList, firstAntenna.Row, firstAntenna.Column);
                this.AddLocation(nodesList, secondAntenna.Row, secondAntenna.Column);
                
                var row1 = secondAntenna.Row - (firstAntenna.Row - secondAntenna.Row);
                var col1 = secondAntenna.Column - (firstAntenna.Column - secondAntenna.Column);
                this.AddLocation(nodesList, row1, col1);

                var count1 = 0;
                while (count1 < 50)
                {
                    var newRow1 = row1 - (firstAntenna.Row - secondAntenna.Row);
                    var newCol1 = col1 - (firstAntenna.Column - secondAntenna.Column);
            
                    row1 = newRow1;
                    col1 = newCol1;

                    this.AddLocation(nodesList, row1, col1);
                    
                    count1++;
                }

                var row2 = firstAntenna.Row + (firstAntenna.Row - secondAntenna.Row);
                var col2 = firstAntenna.Column + (firstAntenna.Column - secondAntenna.Column);
                this.AddLocation(nodesList, row2, col2);
                
                var count2 = 0;
                while (count2 < 50)
                {
                    var newRow2 = row2 + (firstAntenna.Row - secondAntenna.Row);
                    var newCol2 = col2 + (firstAntenna.Column - secondAntenna.Column);

                    row2 = newRow2;
                    col2 = newCol2;

                    this.AddLocation(nodesList, row2, col2);
                    
                    count2++;
                }
                
                break;
            }
        }

        return nodesList;
    }

    private void AddLocation(List<Location> nodeList, int row, int col)
    {
        if (row >= 0 && row < readAllLines.Length && col >= 0 && col < readAllLines[0].Length)
        {
            nodeList.Add(new Location(row, col));
        }
    }

    private Dictionary<string, List<Location>> parseMap(string[] strings)
    {
        var antennaLocations = new Dictionary<string, List<Location>>();
        for (var row = 0; row < strings.Length; row++)
        {
            for (var column = 0; column < strings[row].Length; column++)
            {
                if (strings[row][column] == '.') continue;
                var letter = strings[row][column].ToString();
                if (!antennaLocations.ContainsKey(letter))
                {
                    antennaLocations[letter] = [];
                }
                antennaLocations[letter].Add(new Location(row, column));
            }
        }

        return antennaLocations;
    }

    public long SolvePart2()
    {
        var antennas = parseMap(readAllLines);

        var allLocations = Energise(antennas, true);

        var count = 0;
        foreach (var location in allLocations)
        {
            if (location.Column < 0 || location.Column > readAllLines[0].Length - 1)
            {
                continue;
            }
            if (location.Row < 0 || location.Row > readAllLines.Length - 1)
            {
                continue;
            }
            count++;
        }
        
        return count;
    }
}