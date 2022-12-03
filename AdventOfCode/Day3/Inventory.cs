using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day3
{
    public class Inventory
    {
        public IEnumerable<Rucksack> Rucksacks { get; }
        public int TotalPriorities { get; }

        public Inventory(IEnumerable<Rucksack> rucksacks)
        {
            Rucksacks = rucksacks;
            // Make sure a starts at 1 as int.
            const int equalizer = -96;
            TotalPriorities = rucksacks
                .Select(rucksack => rucksack.Overlap)
                .Sum(overlap => overlap + equalizer);
        }

        public static Inventory Parse(string inventoryContent)
        {
            var rucksacks = inventoryContent
                .SplitByEndOfLine()
                .Select(x => new Rucksack(x));

            return new Inventory(rucksacks);
        }
    }
}
