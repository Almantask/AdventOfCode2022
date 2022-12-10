using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class CraneTests
    {
        [Theory]
        [MemberData(nameof(CraneInstructionExpectations))]
        public void Move_TakesAwaySpecifiedCountOfCratesFromOnePosition_AndAddsToAnother(int[] cratesMap, Crane.Instruction instruction, int[] expectedMapAfterMove)
        {
            var crane = new Crane(cratesMap);

            crane.Move(instruction);

            cratesMap.Should().BeEquivalentTo(expectedMapAfterMove);
        }

        public static IEnumerable<object[]> CraneInstructionExpectations
        {
            get
            {
                yield return new object[] { new[] { 0, 2 }, new Crane.Instruction(1, 1, 0), new[] { 1, 1 } };
                yield return new object[] { new[] { 2, 0 }, new Crane.Instruction(1, 0, 1), new[] { 1, 1 } };
                yield return new object[] { new[] { 2, 0 }, new Crane.Instruction(2, 0, 1), new[] { 0, 2 } };
            }
        }
    }
}
