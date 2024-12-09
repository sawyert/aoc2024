namespace AdventOfCode2024.Day9;

public class Block(int id, bool free)
{
    public int Id { get; } = id;
    public bool Free { get; set; } = free;
}

public class BigBlock(long id, bool free, long size)
{
    public long Id { get; set; } = id;
    public bool Free { get; set; } = free;
    public long Size { get; set; } = size;
}

public class Day9(string[] readAllLines)
{
    public long SolvePart1()
    {
        var blocks = ParseInput();
        
        //Print(blocks);

        blocks = Defrag(blocks);
        
        //Print(blocks);

        long checksum = 0;
        for (var blockIndex=0; blockIndex < blocks.Count; blockIndex++)
        {
            checksum += blockIndex * blocks[blockIndex].Id;
        }

        return checksum;
    }

    private static void Print(List<Block> blocks)
    {
        foreach (var block in blocks)
        {
            if (block.Free)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write($"{block.Id}");
            }
        }
        Console.WriteLine();
    }

    private static List<Block> Defrag(List<Block> blocks)
    {
        List<Block> newBlocks = [];

        for (var eachBlockPosition = 0; eachBlockPosition < blocks.Count; eachBlockPosition++)
        {
            var block = blocks[eachBlockPosition];
            if (!block.Free)
            {
                newBlocks.Add(block);
            }
            else
            {
                var endBlock = LastBlock(eachBlockPosition, blocks);
                if (endBlock == null)
                {
                    break;
                }
                newBlocks.Add(new Block(endBlock.Id, false));
                endBlock.Free = true;
            }
        }
        
        return newBlocks;
    }

    private static Block? LastBlock(int index, List<Block> blocks)
    {
        for (var i = blocks.Count - 1; i > 0; i--)
        {
            if (i < index)
            {
                return null;
            }
            
            if (blocks[i].Free)
            {
                continue;
            }
            return blocks[i];
        }

        throw new Exception("Broken");
    }

    private List<Block> ParseInput()
    {
        var parsedBlocks = new List<Block>();
        var isFree = false;
        var blockIndex = 0;
        foreach (var eachBlock in readAllLines[0])
        {
            var count = int.Parse(eachBlock.ToString());
            for (var i = 0; i < count; i++)
            {
                parsedBlocks.Add(new Block(blockIndex, isFree));
            }
            
            isFree = !isFree;
            if (!isFree)
            {
                blockIndex += 1;
            }
        }

        return parsedBlocks;
    }
    
    public long SolvePart2()
    {
        var blocks = ParseInputBigBlocks();
        
        //Print(blocks);

        blocks = BigDefrag(blocks);
        
        //Print(blocks);

        var checksum = 0L;
        var position = 0L;
        foreach (var block in blocks)
        {
            for (var size = 1; size <= block.Size; size++)
            {
                if (!block.Free)
                {
                    checksum += position * block.Id;
                }
                position++;
            }
        }
        
        return checksum;
    }
    
    private List<BigBlock> ParseInputBigBlocks()
    {
        var parsedBlocks = new List<BigBlock>();
        var isFree = false;
        var blockIndex = 0;
        foreach (var eachBlock in readAllLines[0])
        {
            var count = long.Parse(eachBlock.ToString());
            parsedBlocks.Add(new BigBlock(blockIndex, isFree, count));

            isFree = !isFree;
            if (!isFree)
            {
                blockIndex += 1;
            }
        }

        return parsedBlocks;
    }
    
    private static List<BigBlock> BigDefrag(List<BigBlock> blocks)
    {
        List<BigBlock> newBlocks = [];
        newBlocks.AddRange(blocks);

        for (var i = blocks.Count - 1; i >= 0; i--)
        {
            if (blocks[i].Free)
            {
                continue;
            }
            
            var sizeToFit = blocks[i].Size;

            for (var j = 0; j < newBlocks.Count; j++)
            {
                if (j > i)
                {
                    break;
                }
                
                if (newBlocks[j].Free)
                {
                    var spaceToInsertInto = newBlocks[j].Size;
                    if (spaceToInsertInto >= sizeToFit)
                    {
                        
                        newBlocks[j] = new BigBlock(blocks[i].Id, false, sizeToFit);
                        blocks[i].Free = true;
                        blocks[i].Id = 0;
                        var spaceLeft = spaceToInsertInto - sizeToFit;
                        if (spaceLeft > 0)
                        {
                            newBlocks.Insert(j+1, new BigBlock(0, true, spaceLeft));
                        }
                        break;
                    }
                }
            }
            
            // Print(newBlocks);
        }
        
        return newBlocks;
    }
    
    private static void Print(List<BigBlock> blocks)
    {
        foreach (var block in blocks)
        {
            if (block.Free)
            {
                for (var i = 0; i < block.Size; i++)
                {
                    Console.Write(".");
                }
            }
            else
            {
                for (var i = 0; i < block.Size; i++)
                {
                    Console.Write($"{block.Id}");
                }
            }
        }
        Console.WriteLine();
    }
}