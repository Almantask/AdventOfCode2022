using AdventOfCode.Common.Day;

namespace AdventOfCode.Day4
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 4;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var pairs = Camp.ParseElfPairsFromAssignments(input);
            return pairs.Count(pair => pair.IsFullOverlap);
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
