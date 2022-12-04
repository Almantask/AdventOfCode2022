using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class GroupOf3RucksacksTests
    {
        [Fact]
        public void Overlap_ReturnsTheSameCharacterBetweenAll3()
        {
            var group = new GroupOf3Rucksacks("aa", "ba", "ab");

            group.Overlap.Should().Be('a');
        }
    }
}
