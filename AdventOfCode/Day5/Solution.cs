using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day5
{
    public class Solution : AdventOfCodeDay<Part1, Part2, string>
    {
        protected override int Day => 5;
    }

    public class Part1 : IPartSolution<string>
    {
        public string Solve(string input)
        {
            var split = input.SplitByDoubleEndOfLine();
            var cratesMap = CratesMap.Parse(split[0].SplitByEndOfLine()[..^1]);
            var crane = new Crane9000(cratesMap);

            var instructions = split[1].SplitByEndOfLine().Select(Crane.Instruction.Parse);
            foreach (var instruction in instructions)
            {
                crane.Move(instruction);
            }

            return crane.TopCrates;
        }
    }

    public class Part2 : IPartSolution<string>
    {
        public string Solve(string input)
        {
            return "";
        }
    }
}
