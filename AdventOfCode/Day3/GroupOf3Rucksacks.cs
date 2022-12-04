using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    /// <summary>
    /// A group is formed from 3 rucksacks (3 lines of content).
    /// </summary>
    public class GroupOf3Rucksacks : ISingleOverlap
    {
        public char Overlap { get; }

        public GroupOf3Rucksacks(string rucksack1, string rucksack2, string rucksack3)
        {
            var rucksacks = new [] { rucksack1, rucksack2, rucksack3 }.Select(r => r.ToCharArray()).ToArray();

            IEnumerable<char> overlap = rucksacks[0];
            for (var index = 1; index < rucksacks.Length; index++)
            {
                var rucksack = rucksacks[index];
                overlap = overlap.Intersect(rucksack);
            }

            Overlap = overlap.Single();
        }
    }
}
