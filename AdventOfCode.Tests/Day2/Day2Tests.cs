using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class Day2Tests
    {
        [Theory]
        [MemberData(nameof(Part1Expectation))]
        public void Part1_Solve_Returns_TotalScoreOfPlayer2(string strategyGuide, long expectedTotalScore)
        {
            var part1 = new Part1();

            var totalScore = part1.Solve(strategyGuide);

            totalScore.Should().Be(expectedTotalScore);
        }

        [Theory]
        [MemberData(nameof(Part2Expectation))]
        public void Part2_Solve_ReturnsTotalScoreOfPlayer2(string strategyGuide, long expectedTotalScore)
        {
            var part2 = new Part2();

            var measureIncreases = part2.Solve(strategyGuide);

            measureIncreases.Should().Be(expectedTotalScore);
        }

        public static IEnumerable<object[]> Part1Expectation
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 15);
            }
        }

        public static IEnumerable<object[]> Part2Expectation
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 12);
            }
        }
    }
}
