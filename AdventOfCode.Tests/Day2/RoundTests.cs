using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AdventOfCode.Tests.Day2
{
    public class RoundTests
    {
        private readonly RockPaperScissorsGame.Round _round;
        
        private readonly Mock<RockPaperScissorsGame.IPlay> _play1;
        private readonly Mock<RockPaperScissorsGame.IPlay> _play2;

        public RoundTests()
        {
            _play1 = new Mock<RockPaperScissorsGame.IPlay>();
            _play2 = new Mock<RockPaperScissorsGame.IPlay>();

            _round = new RockPaperScissorsGame.Round(_play1.Object, _play2.Object);
        }

        [Theory]
        [MemberData(nameof(RoundExpectations))]
        public void Win_Returns_6Pts_Plus_ShapePoints(RockPaperScissorsGame.Play.Outcome roundOutcome, int expectedPlayer1Points, int expectedPlayer2Points)
        {
            _play1
                .Setup(play => play.Against(_play2.Object))
                .Returns(roundOutcome);

            RockPaperScissorsGame.Round.Score score = new RockPaperScissorsGame.Round.Score(expectedPlayer1Points, expectedPlayer2Points);

            score.Play1.Should().Be(expectedPlayer1Points);
            score.Play2.Should().Be(expectedPlayer2Points);
        }

        public static IEnumerable<object[]> RoundExpectations
        {
            get
            {
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Win, 6, 0 };
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Draw, 3, 3 };
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Loose, 0, 6 };
            }
        }
    }
}
