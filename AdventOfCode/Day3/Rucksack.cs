namespace AdventOfCode.Day3;

/// <summary>
/// Rucksack with a single line content, split in two compartments
/// </summary>
public class Rucksack : ISingleOverlap
{
    public char Overlap { get; }

    public Rucksack(string rucksackContent)
    {
        var mid = rucksackContent.Length / 2;
        var compartment1 = rucksackContent.Substring(mid).ToCharArray();
        var compartment2 = rucksackContent.Substring(0, mid).ToCharArray();

        Overlap = compartment1.Intersect(compartment2).Single();
    }
}