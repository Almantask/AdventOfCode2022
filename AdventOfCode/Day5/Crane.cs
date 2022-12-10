namespace AdventOfCode.Day5;

public class Crane
{
    private readonly int[] _cratesMap;

    public Crane(int[] cratesMap)
    {
        _cratesMap = cratesMap;
    }

    public struct Instruction
    {
        public int CountToMove { get; }
        public int From { get; }
        public int To { get; }

        public Instruction(int countToMove, int from, int to)
        {
            CountToMove = countToMove;
            From = @from;
            To = to;
        }

        public static Instruction Parse(string instruction)
        {
            //           0   1   2  3  4 5
            // Example: move 2 from 2 to 8.
            var parts = instruction.Split(' ');
            return new Instruction(int.Parse(parts[1]), int.Parse(parts[3]), int.Parse(parts[5]));
        }
    }

    public void Move(Instruction instruction)
    {
        _cratesMap[instruction.From] -= instruction.CountToMove;
        _cratesMap[instruction.To] += instruction.CountToMove;
    }
}