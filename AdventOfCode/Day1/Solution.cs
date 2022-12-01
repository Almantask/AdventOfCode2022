﻿using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day1
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 1;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            return Input
                .ToElves(input)
                .Max(e => e.Total);
        }
    }

    public class Part2 : IPartSolution
    {
        public long Solve(string input)
        {
            const int countOfElvesWithHighestCalories = 3;
            return Input
                .ToElves(input)
                .OrderByDescending(elf => elf.Total)
                .Take(countOfElvesWithHighestCalories)
                .Sum(elf => elf.Total);
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
        public long Total { get; }

        private readonly long[] Calories;

        public Elf(IEnumerable<long> calories)
        {
            Calories = calories.ToArray();
            Total = Calories.Sum();
        }
    }
}
