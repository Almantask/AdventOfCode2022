using AdventOfCode.Day2;

namespace AdventOfCode.Tests.Day2
{
    public class Day2Tests
    {
        [Theory]
        [MemberData(nameof(Day1Part1MaxSumOfCalories))]
        public void Part1_Solve_Returns_TotalScoreOfPlayer2(string strategyGuide, long expectedTotalScore)
        {
            var part1 = new Part1();

            var totalScore = part1.Solve(strategyGuide);

            totalScore.Should().Be(expectedTotalScore);
        }

        [Theory]
        [MemberData(nameof(Day1Part2ExpectedSumOfTop3SumsOfCalories))]
        public void Part2_Solve_ReturnsTotalScoreOfPlayer2(string strategyGuide, long expectedTotalScore)
        {
            var part2 = new Part2();

            var measureIncreases = part2.Solve(strategyGuide);

            measureIncreases.Should().Be(expectedTotalScore);
        }

        public static IEnumerable<object[]> Day1Part1MaxSumOfCalories
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 15);
            }
        }

        public static IEnumerable<object[]> Day1Part2ExpectedSumOfTop3SumsOfCalories
        {
            get
            {
                yield return Expect(day: 2, file: "Example", result: 12);
            }
        }
    }
}
