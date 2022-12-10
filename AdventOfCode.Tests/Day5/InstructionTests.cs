using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class InstructionTests
    {
        [Fact]
        public void Parse_ReturnsExpected()
        {
            const string instructionAsString = "move 2 from 2 to 8";

            var instruction = Crane.Instruction.Parse(instructionAsString);

            var expectedInstruction = new Crane.Instruction(2, 1, 7);
            instruction.Should().BeEquivalentTo(expectedInstruction);
        }
    }
}
