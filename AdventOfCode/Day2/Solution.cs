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
            var guide = new RockPaperScissorsGame.StrategyGuideV1(input);
            var game = new RockPaperScissorsGame(guide.Rounds);

            return game.TotalScorePlayer2;
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
