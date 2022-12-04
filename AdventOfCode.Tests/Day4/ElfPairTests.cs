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

        [Fact]
        public void IsSomeOverlap_ReturnsFalseWhenNoOverlap()
        {
            var pair = new ElfPair(new SectionRange(1, 1), new SectionRange(2, 2));

            pair.IsSomeOverlap.Should().BeFalse();
        }

        [Fact]
        public void IsSomeOverlap_ReturnsTrueWhenSomeOverlap()
        {
            var pair = new ElfPair(new SectionRange(1, 2), new SectionRange(2, 3));

            pair.IsSomeOverlap.Should().BeTrue();
        }
    }
}
