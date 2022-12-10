using AdventOfCode.Day1;

namespace AdventOfCode.Tests.Day5
{
    public class Day5Tests
    {
        [Theory]
        [MemberData(nameof(Part1Expectation))]
        public void Part1_Solve_Returns_Expected(string calories, long expectedMax)
        {
            var part1 = new Part1();

            var measureIncreases = part1.Solve(calories);

            measureIncreases.Should().Be(expectedMax);
        }

        [Theory]
        [MemberData(nameof(Part2Expectation))]
        public void Part2_Solve_Returns_Expected(string calories, long expectedTop3Max)
        {
            var part2 = new Part2();

            var measureIncreases = part2.Solve(calories);

            measureIncreases.Should().Be(expectedTop3Max);
        }

        public static IEnumerable<object[]> Part1Expectation
        {
            get
            {
                yield return Expect(day: 1, file: "Example", result: 24000);
            }
        }

        public static IEnumerable<object[]> Part2Expectation
        {
            get
            {
                yield return Expect(day: 1, file: "Example", result: 45000);
            }
        }
    }
}
