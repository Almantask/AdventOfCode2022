using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class InventoryTests
    {
        [Fact]
        public void ParseRucksacksFromContent_ReturnsRucksackForEachLine()
        {
            var inventoryContent = @"aa
bb";
            var rucksacks = Inventory.ParseRucksacksFromContent(inventoryContent);

            Rucksack[] expectedRucksacks = { new("aa"), new("bb") };

            rucksacks.Should().BeEquivalentTo(expectedRucksacks);
        }

        [Fact]
        public void ParseGroupsOf3FromContent_ReturnsGroupsOf3ForEvery3Lines()
        {
            var inventoryContent = @"aa
ab
ca
bb
ba
bz";
            var groupsOf3FromContent = Inventory.ParseGroupsOf3FromContent(inventoryContent);

            GroupOf3Rucksacks[] expectedGroups = { new("ab", "ca", "ba"), new("bb", "ba", "bz") };

            groupsOf3FromContent.Should().BeEquivalentTo(expectedGroups);
        }

        [Theory]
        [InlineData("aa", 1, "Overlaps at a = 1")]
        [InlineData("zz", 26, "Overlaps at z = 26")]
        [InlineData("AA", 27, "Overlaps at A = 27")]
        [InlineData("ZZ", 52, "Overlaps at Z = 52")]
        [InlineData("aa,bb", 3, "Overlaps at a and b. a = 1, B = 2. 1+2 = 3")]
        public void TotalPriorities_Returns_SumOfAllRucksackArrangementPriorities(string inventoryContent, int expectedTotalPriorities, string explanation)
        {
            var rucksacks = inventoryContent
                .Split(',')
                .Select(content => new Rucksack(content))
                .ToArray();

            var inventory = new Inventory(rucksacks);

            inventory.TotalPriorities.Should().Be(expectedTotalPriorities, explanation);
        }
    }
}
