using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day2;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day2
{
    public class StrategyGuideTests
    {
        [Fact]
        public void Parse()
        {
            string strategyGuide = @"A Y
B X
C Z";

            var rounds = RockPaperScissorsGame.StrategyGuide.ParseRoundsFrom(strategyGuide);

            var expectedRounds = new RockPaperScissorsGame.Round[]
            {
                new(RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Paper),
                new(RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock),
                new(RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Scissors)
            };

            rounds.Should().BeEquivalentTo(expectedRounds);
        }
    }
}
