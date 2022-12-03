using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Execution;

namespace AdventOfCode.Tests.Day2
{
    public class RockPaperScissorsGameTests
    {
        // 1st col - What your opponent is going to play
        // A - Rock (1pt)
        // B - Paper (2pt)
        // C - Scissors (3pt)

        // 2nd - how to counter
        // X - Rock
        // Y - paper
        // Z - scissors

        // Wins with highest total score.

        // Score shape +:
        // Win = 6
        // Draw = 3
        // Loss = 0

        [Theory]
        [MemberData(nameof(PlaysWithExpectedProperties))]
        public void Play_MarkedAsExpected(RockPaperScissorsGame.Play play, int expectedPoints)
        {
            play.Points.Should().Be(expectedPoints);
        }

        [Theory]
        [MemberData(nameof(MatchupExpectations))]
        public void Play_AgainstAnotherPlay_ReturnsExpected(
            RockPaperScissorsGame.Play play1,
            RockPaperScissorsGame.Play play2,
            RockPaperScissorsGame.Play.Outcome expectedOutcome,
            string explanation)
        {
            var outcome = play1.Against(play2);

            outcome.Should().Be(expectedOutcome, explanation);
        }

        public static IEnumerable<object[]> PlaysWithExpectedProperties
        {
            get
            {
                yield return new object[] { RockPaperScissorsGame.Play.Rock, 1 };
                yield return new object[] { RockPaperScissorsGame.Play.Paper, 2 };
                yield return new object[] { RockPaperScissorsGame.Play.Scissors, 3 };
            }
        }

        public static IEnumerable<object[]> MatchupExpectations
        {
            get
            {
                // First vs Second plays.
                yield return new object[] { RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Outcome.Win, "Rock beats scissors" };
                yield return new object[] { RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Outcome.Loose, "Rock is beaten by paper" };
                yield return new object[] { RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Rock, RockPaperScissorsGame.Play.Outcome.Win, "Paper beats rock" };
                yield return new object[] { RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Paper, RockPaperScissorsGame.Play.Outcome.Win, "Scissors beat paper" };
                yield return new object[] { RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Scissors, RockPaperScissorsGame.Play.Outcome.Draw, "The same plays result in a draw" };
            }
        }
    }
}
