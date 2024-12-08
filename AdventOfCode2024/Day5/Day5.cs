using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2024.Day5;

class ComparePages(HashSet<(int, int)> rules) : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (rules.Contains((x, y))) return -1;
        if (rules.Contains((y, x))) return 1;
        return 0;
    }
}

public class Rule()
{
    public int LeftPage { get; set; }
    public int RightPage { get; set; }

    public Rule(string definition) : this()
    {
        var parts = definition.Split('|');
        LeftPage = int.Parse(parts[0]);
        RightPage = int.Parse(parts[1]);
    }
}

public class PageOrder()
{
    public List<int> PageOrders { get; set; } = new();

    public PageOrder(string definition) : this()
    {
        var parts = definition.Split(',');
        foreach (var part in parts)
        {
            PageOrders.Add(int.Parse(part));
        }
    }

    public long MiddleValue()
    {
        var middlePosition = (PageOrders.Count / 2);
        return PageOrders[middlePosition];
    }

    public bool Valid(List<Rule> rules)
    {
        foreach (var pageNumber in PageOrders)
        {
            List<Rule> matchingRules = new List<Rule>();
            foreach (var eachRule in rules)
            {
                if (pageNumber == eachRule.LeftPage || pageNumber == eachRule.RightPage)
                {
                    matchingRules.Add(eachRule);
                }
            }

            foreach (var matchingRule in matchingRules)
            {
                if (matchingRule.LeftPage == pageNumber)
                {
                    bool foundMatchingNumber = false;
                    foreach (var pageOrder in PageOrders)
                    {
                        if (pageOrder == pageNumber)
                        {
                            foundMatchingNumber = true;
                            continue;
                        }

                        if (pageOrder == matchingRule.RightPage)
                        {
                            if (foundMatchingNumber == false)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    // right page matches
                    bool foundMatchingNumber = false;
                    foreach (var pageOrder in PageOrders)
                    {
                        if (pageOrder == pageNumber)
                        {
                            foundMatchingNumber = true;
                            continue;
                        }

                        if (pageOrder == matchingRule.RightPage)
                        {
                            if (foundMatchingNumber == true)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        return true;
    }

    public void ReorderBasedOn(List<Rule> rules)
    {
        HashSet<(int, int)> relevantRules = new();
        foreach (var eachRule in rules)
        {
            if (PageOrders.Contains(eachRule.LeftPage) && PageOrders.Contains(eachRule.RightPage))
            {
                relevantRules.Add((eachRule.LeftPage, eachRule.RightPage));
            }
        }
        
        ComparePages compare = new(relevantRules);

        PageOrders.Sort(compare);
        
        // https://github.com/ryanheath/aoc2024/blob/main/Day5.cs
        // do reorder based on the rules
    }

    public void Print()
    {
        foreach (var page in PageOrders)
        {
            Console.Write(page);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

public class Day5(string[] readAllLines)
{
    private List<Rule> _rules = new();
    private List<PageOrder> _pageOrders = new();
    
    public long SolvePart1()
    {
        this.Read();

        var middleValues = 0L;

        foreach (var pageOrder in _pageOrders)
        {
            if (pageOrder.Valid(_rules))
            {
                var result = pageOrder.MiddleValue();
                middleValues += result;
            }
        }

        return middleValues;
    }
    
    public long SolvePart2()
    {
        this.Read();

        var middleValues = 0L;

        List<PageOrder> invalid = [];

        foreach (var pageOrder in _pageOrders)
        {
            if (pageOrder.Valid(_rules))
            {
                continue;
            }

            invalid.Add(pageOrder);
        }

        foreach (var pageOrder in invalid)
        {
            pageOrder.Print();
            pageOrder.ReorderBasedOn(_rules);
            if (!pageOrder.Valid(_rules))
            {
                pageOrder.Print();
                throw new Exception("Not valid after swaps");
            }
            
            var result = pageOrder.MiddleValue();
            middleValues += result;    
        }
        

        return middleValues;
    }

    private void Read()
    {
        bool firstSection = true;
        foreach (var line in readAllLines)
        {
            if (line.Length == 0)
            {
                firstSection = false;
                continue;
            }
            
            if (firstSection)
            {
                var rule = new Rule(line);
                _rules.Add(rule);
            }
            else
            {
                var pageOrder = new PageOrder(line);
                _pageOrders.Add(pageOrder);
            }
        }
    }


}