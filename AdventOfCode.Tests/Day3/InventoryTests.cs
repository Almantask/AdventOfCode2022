using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day3;

namespace AdventOfCode.Tests.Day3
{
    public class InventoryTests
    {
        [Fact]
        public void Parse_ReturnsRucksackForEachLine()
        {
            var inventoryContent = @"aa
bb";
            var inventory = Inventory.Parse(inventoryContent);

            Rucksack[] expectedRucksacks = { new("aa"), new("bb") };

            inventory.Rucksacks.Should().BeEquivalentTo(expectedRucksacks);
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
