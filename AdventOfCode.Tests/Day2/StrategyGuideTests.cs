using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class StrategyGuideTests
    {
        [Fact]
        public void New_Returns_RoundsWithCounters()
        {
            string strategyGuide = @"A Y
B X
C Z";

            var guide = new RockPaperScissorsGame.StrategyGuideV1(strategyGuide);

            var expectedRounds = new RockPaperScissorsGame.Round[]
            {
                new(RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Paper),
                new(RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock),
                new(RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Scissors)
            };

            guide.Rounds.Should().BeEquivalentTo(expectedRounds);
        }

        [Fact]
        public void New_Returns_RoundsWithOutcomes()
        {
            string strategyGuide = @"A Y
B X
C Z";

            var guide = new RockPaperScissorsGame.StrategyGuideV2(strategyGuide);

            var expectedRounds = new RockPaperScissorsGame.Round[]
            {
                new(RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Rock),
                new(RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock),
                new(RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Rock)
            };

            guide.Rounds.Should().BeEquivalentTo(expectedRounds);
        }
    }
}
