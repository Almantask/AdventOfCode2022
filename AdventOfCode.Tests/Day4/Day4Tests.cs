using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class Day4Tests
    {
        // Line = 2 ranges of section ids
        // Ranges overlap
        // How many ranges fully contain each other?

        [Theory]
        [MemberData(nameof(Day1Part1MaxSumOfCalories))]
        public void Part1_Solve_Returns_CountOfFullOverlapsInPairs(string calories, long expectedMax)
        {
            var part1 = new Part1();

            var measureIncreases = part1.Solve(calories);

            measureIncreases.Should().Be(expectedMax);
        }

        [Theory]
        [MemberData(nameof(Day1Part2ExpectedSumOfTop3SumsOfCalories))]
        public void Part2_Solve_Returns_IncreasesCountOverAWindowOf3(string calories, long expectedTop3Max)
        {
            var part2 = new Part2();

            var measureIncreases = part2.Solve(calories);

            measureIncreases.Should().Be(expectedTop3Max);
        }

        public static IEnumerable<object[]> Day1Part1MaxSumOfCalories
        {
            get
            {
                yield return Expect(day: 4, file: "Example", result: 2);
            }
        }

        public static IEnumerable<object[]> Day1Part2ExpectedSumOfTop3SumsOfCalories
        {
            get
            {
                yield return Expect(day: 4, file: "Example", result: 45000);
            }
        }
    }
}
