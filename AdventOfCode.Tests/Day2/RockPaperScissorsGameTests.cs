using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class RockPaperScissorsGameTests
    {
        [Fact]
        public void TotalScore_ReturnsSumOfRoundScoreForPlayer1()
        {
            IEnumerable<RockPaperScissorsGame.Round> rounds = new[]
            {
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Scissors),
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Paper),
                new RockPaperScissorsGame.Round(RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock)
            };

            var game = new RockPaperScissorsGame(rounds);

            game.TotalScorePlayer1.Should().Be(24, "Total Score = Sum of all rounds; Round = Shape pts + Outcome points");
        }
    }
}
