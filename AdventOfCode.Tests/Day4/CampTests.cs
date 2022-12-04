using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class CampTests
    {
        [Fact]
        public void CountOfRangesWithFullOverlap_When1OverlappingPair_Returns1()
        {
            var pairs = new [] {
                // Overlapping
                new ElfPair(new SectionRange(1,1), new SectionRange(1,1)),
                // Not
                new ElfPair(new SectionRange(1, 1), new SectionRange(2, 2))
            };

            var camp = new Camp(pairs);

            camp.CountOfRangesWithFullOverlap.Should().Be(1);
        }

        [Fact]
        public void ParseElfPairsFromAssignments_FromAssignments_Returns_ElfPairs()
        {
            var assignments = @"1-1,1-1
1-1,2-2";

            var pairs = Camp.ParseElfPairsFromAssignments(assignments);

            var expectedPairs = new[] {
                // Overlapping
                new ElfPair(new SectionRange(1,1), new SectionRange(1,1)),
                // Not
                new ElfPair(new SectionRange(1, 1), new SectionRange(2, 2))
            };
            pairs.Should().BeEquivalentTo(expectedPairs);
        }
    }
}
