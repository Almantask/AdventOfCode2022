using AdventOfCode.Common.Day;

namespace AdventOfCode.Day2
{
    public class Solution : AdventOfCodeDay<Part1, Part2, long>
    {
        protected override int Day => 2;
    }

    public class Part1 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            var guide = new RockPaperScissorsGame.StrategyGuideV1(input);
            var game = new RockPaperScissorsGame(guide.Rounds);

            return game.TotalScorePlayer2;
        }
    }

    public class Part2 : IPartSolution<long>
    {
        public long Solve(string input)
        {
            var guide = new RockPaperScissorsGame.StrategyGuideV2(input);
            var game = new RockPaperScissorsGame(guide.Rounds);

            return game.TotalScorePlayer2;
        }
    }
}
