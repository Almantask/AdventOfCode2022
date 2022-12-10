using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class CratesMapTest
    {
        [Fact]
        public void Parse_ReturnsExpected()
        {
            var map = new[]
            {
                "[A]",
                "[C] [B]"
            };

            var crates = CratesMap.Parse(map);

            var expectedCrates = new char?[,] { { 'C', 'A' }, { 'B', null } };

            crates.Should().BeEquivalentTo(expectedCrates);
        }

        [Fact]
        public void Parse_WhenEmptySpace_ReturnsExpected()
        {
            var map = new[]
            {
                "    [A]",
                "[C] [B]"
            };

            var crates = CratesMap.Parse(map);

            var expectedCrates = new char?[,] { { 'C', null }, { 'B', 'A' } };

            crates.Should().BeEquivalentTo(expectedCrates);
        }
    }
}
