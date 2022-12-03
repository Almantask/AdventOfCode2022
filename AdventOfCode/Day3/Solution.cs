using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day3
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 3;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            return Inventory.Parse(input).TotalPriorities;
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            return 0;
        }
    }
}
