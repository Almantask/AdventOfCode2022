using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class Day4Tests
    {
        // Line = 2 ranges of section ids
        // Ranges overlap
        // How many ranges fully contain each other?

        [Theory]
        [MemberData(nameof(Part1Expectation))]
        public void Part1_Solve_Returns_CountOfFullOverlapsInPairs(string calories, long expectedMax)
        {
            var part1 = new Part1();

            var overlaps = part1.Solve(calories);

            overlaps.Should().Be(expectedMax);
        }

        [Theory]
        [MemberData(nameof(Part2Expectation))]
        public void Part2_Solve_Returns_CountOfOverlapsInPairs(string calories, long expectedTop3Max)
        {
            var part2 = new Part2();

            var overlaps = part2.Solve(calories);

            overlaps.Should().Be(expectedTop3Max);
        }

        public static IEnumerable<object[]> Part1Expectation
        {
            get
            {
                yield return Expect(day: 4, file: "Example", result: 2);
            }
        }

        public static IEnumerable<object[]> Part2Expectation
        {
            get
            {
                yield return Expect(day: 4, file: "Example", result: 4);
            }
        }
    }
}
