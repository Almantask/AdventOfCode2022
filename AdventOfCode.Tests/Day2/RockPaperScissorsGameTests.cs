using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class RockPaperScissorsGameTests
    {
        [Fact]
        public void TotalScore_ReturnsSumOfRoundScoreForPlayer2()
        {
            IEnumerable<RockPaperScissorsGame.Round> rounds = new[]
            {
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Scissors),
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Paper),
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock)
            };

            var game = new RockPaperScissorsGame(rounds);

            game.TotalScorePlayer2.Should().Be(6, "Total Score = Sum of all rounds; Round = Shape pts + Outcome points. (Lost all)");
        }
    }
}
