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

        public IEnumerable<ISingleOverlap> Overlapables { get; }
        public int TotalPriorities { get; }

        public Inventory(IEnumerable<ISingleOverlap> overlapables)
        {
            Overlapables = overlapables;
            TotalPriorities = Overlapables
                .Select(rucksack => rucksack.Overlap)
                .Sum(overlap => _priorities[overlap]);
        }

        public static IEnumerable<Rucksack> ParseRucksacksFromContent(string inventoryContent)
        {
            var rucksacks = inventoryContent
                .SplitByEndOfLine()
                .Select(x => new Rucksack(x))
                .ToArray();

            return rucksacks;
        }

        public static IEnumerable<GroupOf3Rucksacks> ParseGroupsOf3FromContent(string inventoryContent)
        {
            var rucksacks = inventoryContent.SplitByEndOfLine().ToArray();
            var groups = new List<GroupOf3Rucksacks>();
            for (int i = 0; i < rucksacks.Length; i += 3)
            {
                var group = new GroupOf3Rucksacks(rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]);
                groups.Add(group);
            }

            return groups;
        }
    }
}
