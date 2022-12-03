using AdventOfCode.Common.Day;
using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day2
{
    public class Solution : AdventOfCodeDay<Part1, Part2>
    {
        protected override int Day => 2;
    }

    public class Part1 : IPartSolution
    {
        public long Solve(string input)
        {
            var rounds = RockPaperScissorsGame.StrategyGuide.ParseRoundsFrom(input);
            var game = new RockPaperScissorsGame(rounds);

            return game.TotalScorePlayer1;
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
