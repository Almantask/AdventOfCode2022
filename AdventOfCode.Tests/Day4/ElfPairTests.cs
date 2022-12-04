using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4
{
    public class ElfPairTests
    {
        [Fact]
        public void IsFullOverlap_ReturnsTrueWhenFullOverlap()
        {
            var pair = new ElfPair(new SectionRange(1, 1), new SectionRange(1, 1));

            pair.IsFullOverlap.Should().BeTrue();
        }

        [Fact]
        public void IsFullOverlap_ReturnsFalseWhenNotFullOverlap()
        {
            var pair = new ElfPair(new SectionRange(1, 1), new SectionRange(2, 2));

            pair.IsFullOverlap.Should().BeFalse();
        }
    }
}
