using AdventOfCode.Day5;

namespace AdventOfCode.Tests.Day5
{
    public class CraneTests
    {
        [Theory]
        [MemberData(nameof(Crane9000InstructionExpectations))]
        public void Move_WhenCrane9000_MovesOneByOne(char?[,] cratesMap, Crane.Instruction instruction, char?[,] expectedMapAfterMove)
        {
            var crane = new Crane9000(cratesMap);

            crane.Move(instruction);

            crane.CratesMap.Should().BeEquivalentTo(expectedMapAfterMove);
        }

        [Theory]
        [MemberData(nameof(Crane9001InstructionExpectations))]
        public void Move_WhenCrane9001_AllSpecified(char?[,] cratesMap, Crane.Instruction instruction, char?[,] expectedMapAfterMove)
        {
            var crane = new Crane9001(cratesMap);

            crane.Move(instruction);

            crane.CratesMap.Should().BeEquivalentTo(expectedMapAfterMove);
        }

        [Fact]
        public void TopCrates_ReturnsLastCrateInEachColumn()
        {
            var map = new char?[,] { {'c', null}, {'a', 'b'} };

            var crane = new Crane9000(map);

            crane.TopCrates.Should().Be("cb");
        }

        public static IEnumerable<object[]> Crane9000InstructionExpectations
        {
            get
            {
                // Before:
                //   b
                //   a
                
                // After:
                // a b
                yield return new object[] { new char?[,] { {null, null}, {'a', 'b'}  }, new Crane.Instruction(1, 1, 0), new char?[,] { {'b', null}, {'a', null}  } };
                
                // Does reverse work?
                yield return new object[] { new char?[,] { {'a', 'b'}, { null, null } }, new Crane.Instruction(1, 0, 1), new char?[,] { {'a', null}, { 'b', null } } };

                // Before:
                //  b d
                //  a c

                // After:
                // a b
                //   d
                //   c
                yield return new object[] { new char?[,] { {'a', 'b'}, { 'c', 'd' } }, new Crane.Instruction(1, 0, 1), new char?[,] { {'a', null, null, null}, { 'c', 'd', 'b', null } } };

                // Before:
                // b d
                // a c

                // After:
                //   a
                //   b
                //   d
                //   c
                yield return new object[] { new char?[,] { {'a', 'b'}, { 'c', 'd' } }, new Crane.Instruction(2, 0, 1), new char?[,] { {null, null, null, null}, { 'c', 'd', 'b', 'a' } } };
            }
        }

        public static IEnumerable<object[]> Crane9001InstructionExpectations
        {
            get
            {
                // Before:
                //   b
                //   a

                // After:
                // a b
                yield return new object[] { new char?[,] { { null, null }, { 'a', 'b' } }, new Crane.Instruction(1, 1, 0), new char?[,] { { 'b', null }, { 'a', null } } };

                // Does reverse work?
                yield return new object[] { new char?[,] { { 'a', 'b' }, { null, null } }, new Crane.Instruction(1, 0, 1), new char?[,] { { 'a', null }, { 'b', null } } };

                // Before:
                //  b d
                //  a c

                // After:
                // a b
                //   d
                //   c
                yield return new object[] { new char?[,] { { 'a', 'b' }, { 'c', 'd' } }, new Crane.Instruction(1, 0, 1), new char?[,] { { 'a', null, null, null }, { 'c', 'd', 'b', null } } };

                // Before:
                // b d
                // a c

                // After:
                //   a
                //   b
                //   d
                //   c
                yield return new object[] { new char?[,] { { 'a', 'b' }, { 'c', 'd' } }, new Crane.Instruction(2, 0, 1), new char?[,] { { null, null, null, null }, { 'c', 'd', 'a', 'b' } } };
            }
        }
    }
}
