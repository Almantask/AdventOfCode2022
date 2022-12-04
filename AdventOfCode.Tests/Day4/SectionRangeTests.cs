using AdventOfCode.Day4;

namespace AdventOfCode.Tests.Day4;

public class SectionRangeTests
{
    [Theory]
    [InlineData(1, 1, 1, 1, true)]
    [InlineData(1, 2, 1, 1, true)]
    [InlineData(2, 2, 1, 1, false)]
    [InlineData(1, 1, 1, 2, true)]
    [InlineData(1, 2, 2, 3, false)]
    public void IsFullOverlapWith_Returns_Whether_EitherRange_CanFitFullyIntoOneAnother(int range1Start, int range1End, int range2Start, int range2End, bool expectedIsFullOverlap)
    {
        var range1 = new SectionRange(range1Start, range1End);
        var range2 = new SectionRange(range2Start, range2End);

        var isFullOverlap = range1.IsFullOverlapWith(range2);

        isFullOverlap.Should().Be(expectedIsFullOverlap);
    }

    [Theory]
    [InlineData(1, 1, 1, 1, true)]
    [InlineData(1, 2, 1, 1, true)]
    [InlineData(2, 2, 1, 1, false)]
    [InlineData(1, 1, 1, 2, true)]
    [InlineData(1, 2, 2, 3, true)]
    [InlineData(2, 3, 1, 2, true)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, true)]
    public void IsOverlapWith_Returns_Whether_BothRangesAreMutuallyExclusive(int range1Start, int range1End, int range2Start, int range2End, bool expectedIsFullOverlap)
    {
        var range1 = new SectionRange(range1Start, range1End);
        var range2 = new SectionRange(range2Start, range2End);

        var isFullOverlap = range1.IsOverlapWith(range2);

        isFullOverlap.Should().Be(expectedIsFullOverlap);
    }
}