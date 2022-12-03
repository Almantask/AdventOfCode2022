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

        [Fact]
        public void TotalPriorities_Returns_SumOfAllRucksackArrangementPriorities()
        {
            var inventory = new Inventory(new[] { new Rucksack("aa"), new Rucksack("bb") });

            inventory.TotalPriorities.Should().Be(3, "Overlaps at a and b. a = 1, b = 2. 1+2 = 3");
        }
    }
}
