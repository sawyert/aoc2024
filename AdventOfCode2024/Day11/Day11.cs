namespace AdventOfCode2024.Day11;

public class Day11(string[] readAllLines)
{
    public long Solve(int blinks)
    {
        var numbers = readAllLines[0].Split(" ").ToList();
        var stones = new Queue<(string id, long count)>(numbers.Select(x => (x, 1L)));
        var stonesCache = new Dictionary<string, long>();
        
        for (var i = 0; i < blinks; i++)
        {
            Blink(stones, stonesCache);
        }

        return stones.ToArray().Sum(x => x.count); 
    }

    private void Blink(Queue<(string id, long count)> stones, Dictionary<string, long> stonesCache)
    {
        while (stones.Count > 0)
        {
            var eachStone = stones.Dequeue();

            if (eachStone.id == "0")
            {
                AddStone(stonesCache, "1", eachStone.count);
            }
            else if (eachStone.id.Length % 2 == 0)
            {
                var leftNumber = eachStone.id[..(eachStone.id.Length / 2)];
                var rightNumber = eachStone.id[(eachStone.id.Length / 2)..];

                AddStone(stonesCache, Convert.ToString(Convert.ToInt64(leftNumber)), eachStone.count);
                AddStone(stonesCache, Convert.ToString(Convert.ToInt64(rightNumber)), eachStone.count);
            }
            else
            {
                AddStone(stonesCache, Convert.ToString(Convert.ToInt64(eachStone.id) * 2024), eachStone.count);
            }
        }
        
        foreach (var (id, count) in stonesCache)
        {
            stones.Enqueue((id, count));
        }
        stonesCache.Clear();
    }

    private static void AddStone(Dictionary<string, long> stonesCache, string id, long eachStoneCount)
    {
        if (stonesCache.TryGetValue(id, out var currentCount))
        {
            stonesCache[id] = currentCount + eachStoneCount;
        }
        else
        {
            stonesCache[id] = eachStoneCount;
        }
            
    }
}