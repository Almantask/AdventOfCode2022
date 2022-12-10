using System.Reflection.Metadata.Ecma335;
using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day5
{
    public class Solution : AdventOfCodeDay<Part1, Part2, string>
    {
        protected override int Day => 5;
    }

    public abstract class PartSolution : IPartSolution<string>
    {
        public string Solve(string input)
        {
            var split = input.SplitByDoubleEndOfLine();
            var cratesMap = CratesMap.Parse(split[0].SplitByEndOfLine()[..^1]);
            var crane = BuildCrane(cratesMap);

            var instructions = split[1].SplitByEndOfLine().Select(Crane.Instruction.Parse);
            foreach (var instruction in instructions)
            {
                crane.Move(instruction);
            }

            return crane.TopCrates;
        }

        protected abstract Crane BuildCrane(char?[,] cratesMap);
    }

    public class Part1 : PartSolution
    {
        protected override Crane BuildCrane(char?[,] cratesMap) => new Crane9000(cratesMap);
    }

    public class Part2 : PartSolution
    {
        protected override Crane BuildCrane(char?[,] cratesMap) => new Crane9001(cratesMap);
    }
}
