namespace AdventOfCode.Day3;

public class Rucksack
{
    public char Overlap { get; }

    public Rucksack(string rucksackContent)
    {
        var mid = rucksackContent.Length / 2;
        var compartment1 = rucksackContent.Substring(mid).ToCharArray();
        var compartment2 = rucksackContent.Substring(0, mid).ToCharArray();

        Overlap = compartment1.Intersect(compartment2).First();
    }
}