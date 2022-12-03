using AdventOfCode.Day2;
using Moq;

namespace AdventOfCode.Tests.Day2
{
    public class RoundTests
    {

        private readonly Mock<RockPaperScissorsGame.IPlay> _play1;
        private readonly Mock<RockPaperScissorsGame.IPlay> _play2;

        private const int Player1ShapePoints = 10;
        private const int Player2ShapePoints = 20;

        public RoundTests()
        {
            _play1 = new Mock<RockPaperScissorsGame.IPlay>();
            _play2 = new Mock<RockPaperScissorsGame.IPlay>();
        }

        [Theory]
        [MemberData(nameof(RoundExpectations))]
        public void Win_Returns_6Pts_Plus_ShapePoints(RockPaperScissorsGame.Play.Outcome roundOutcome, int expectedPlayer1Points, int expectedPlayer2Points)
        {
            _play1
                .Setup(play => play.Against(_play2.Object))
                .Returns(roundOutcome);

            _play1
                .SetupGet(play => play.Points)
                .Returns(Player1ShapePoints);

            _play2
                .SetupGet(play => play.Points)
                .Returns(Player2ShapePoints);

            var round = new RockPaperScissorsGame.Round(_play1.Object, _play2.Object);

            RockPaperScissorsGame.Round.Score expectedScore = new RockPaperScissorsGame.Round.Score(expectedPlayer1Points, expectedPlayer2Points);

            round.Points.Should().BeEquivalentTo(expectedScore);
        }

        public static IEnumerable<object[]> RoundExpectations
        {
            get
            {
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Win, 6 + Player1ShapePoints, 0 + Player2ShapePoints };
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Draw, 3 + Player1ShapePoints, 3 + Player2ShapePoints };
                yield return new object[] { RockPaperScissorsGame.Play.Outcome.Loose, 0 + Player1ShapePoints, 6 + Player2ShapePoints };
            }
        }
    }
}
