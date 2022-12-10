using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day1
{
    public class Solution : AdventOfCodeDay<Part1, Part2, long>
    {
        protected override int Day => 1;
    }

    public class Part1 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            return Input
                .ToElves(input)
                .Max(e => e.TotalCalories);
        }
    }

    public class Part2 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            const int countOfElvesWithHighestCalories = 3;
            return Input
                .ToElves(input)
                .OrderByDescending(elf => elf.TotalCalories)
                .Take(countOfElvesWithHighestCalories)
                .Sum(elf => elf.TotalCalories);
        }
    }

    public static class Input
    {
        public static Elf[] ToElves(string input) => input
            .SplitByDoubleEndOfLine()
            .Select(elfWithCals => new Elf(elfWithCals.ToNumbersSplitByEndOfLine()))
            .ToArray();
    }

    public class Elf
    {
        public long TotalCalories { get; }

        public Elf(IEnumerable<long> foodCalories)
        {
            TotalCalories = foodCalories.Sum();
        }
    }
}
