using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class RucksackV1Tests
    {
        [Theory]
        [InlineData("aa", 'a')]
        [InlineData("abBb", 'b')]
        [InlineData("aBBb", 'B')]
        public void GetOverlap_Returns_ASingleMatchingCharacter(string rucksackContent, char expectedOverlap)
        {
            var rucksack = new Rucksack(rucksackContent);

            rucksack.Overlap.Should().Be(expectedOverlap);
        }
    }
}
