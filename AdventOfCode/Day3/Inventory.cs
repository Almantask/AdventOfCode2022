using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day3
{
    public class Inventory
    {
        private static Dictionary<char, int> _priorities;

        static Inventory()
        {
            const int countOfaThroughZ = 52;
            _priorities = new Dictionary<char, int>();

            // Make sure a starts at 1 as int.
            const int nonCapitalEqualizer = -96;
            for (int i = 'a'; i < 'z' + 1; i++)
            {
                _priorities.Add((char)i, i + nonCapitalEqualizer);
            }

            // Make sure A starts at 27
            const int capitalEqualizer = -38;
            for (int i = 'A'; i < 'Z' + 1; i++)
            {
                _priorities.Add((char)i, i + capitalEqualizer);
            }
        }

        public IEnumerable<Rucksack> Rucksacks { get; }
        public int TotalPriorities { get; }

        public Inventory(IEnumerable<Rucksack> rucksacks)
        {
            Rucksacks = rucksacks;
            TotalPriorities = Rucksacks
                .Select(rucksack => rucksack.Overlap)
                .Sum(overlap => _priorities[overlap]);
        }

        public static Inventory Parse(string inventoryContent)
        {
            var rucksacks = inventoryContent
                .SplitByEndOfLine()
                .Select(x => new Rucksack(x))
                .ToArray();

            return new Inventory(rucksacks);
        }
    }
}
