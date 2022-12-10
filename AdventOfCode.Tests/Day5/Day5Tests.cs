using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class Day5Tests
    {
        [Theory]
        [MemberData(nameof(Part1Expectation))]
        public void Part1_Solve_Returns_Expected(string cratesMap, string expectedTopCrates)
        {
            var part1 = new Part1();

            var crates = part1.Solve(cratesMap);

            crates.Should().Be(expectedTopCrates);
        }

        [Theory]
        [MemberData(nameof(Part2Expectation))]
        public void Part2_Solve_Returns_Expected(string cratesMap, string expectedTopCrates)
        {
            var part2 = new Part2();

            var crates = part2.Solve(cratesMap);

            crates.Should().Be(expectedTopCrates);
        }

        public static IEnumerable<object[]> Part1Expectation
        {
            get
            {
                yield return Expect(day: 5, file: "Example", result: "CMZ");
            }
        }

        public static IEnumerable<object[]> Part2Expectation
        {
            get
            {
                yield return Expect(day: 5, file: "Example", result: "MCD");
            }
        }
    }
}
