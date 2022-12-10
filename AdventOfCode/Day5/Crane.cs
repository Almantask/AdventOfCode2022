using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day5;

/// <summary>
/// Can lift only one crate at once.
/// </summary>
public class Crane9000: Crane
{
    public Crane9000(char?[,] cratesMap) : base(cratesMap)
    {
    }

    // TODO: Solve this design mistake. Abstract class shouldn't reference base members.
    public override void Move(Instruction instruction)
    {
        for (var i = 0; i < instruction.CountToMove; i++)
        {
            var crateToMove = CratesMap[instruction.From, CrateCountsPerColumn[instruction.From] - 1];
            CratesMap[instruction.From, CrateCountsPerColumn[instruction.From] - 1] = null;
            CratesMap[instruction.To, CrateCountsPerColumn[instruction.To]] = crateToMove;

            // If using string - it could simply be string length.
            CrateCountsPerColumn[instruction.From]--;
            CrateCountsPerColumn[instruction.To]++;
        }
    }
}

/// <summary>
/// Lifts all the crates it is instructed.
/// </summary>
public class Crane9001 : Crane
{
    public Crane9001(char?[,] cratesMap) : base(cratesMap)
    {
    }

    // TODO: Solve this design mistake. Abstract class shouldn't reference base members.
    public override void Move(Instruction instruction)
    {
        for (var i = 0; i < instruction.CountToMove; i++)
        {
            var crateToMove = CratesMap[instruction.From, CrateCountsPerColumn[instruction.From] - 1];
            // 3 boxes, lift 3
            // i = 2
            // Sequence: 0 1 2
            var boxInColumnFrom = CrateCountsPerColumn[instruction.From] - instruction.CountToMove + i;
            CratesMap[instruction.From, boxInColumnFrom] = null;
            CratesMap[instruction.To, CrateCountsPerColumn[instruction.To]] = crateToMove;

            // If using string - it could simply be string length.
            CrateCountsPerColumn[instruction.From]--;
            CrateCountsPerColumn[instruction.To]++;
        }
    }
}

public abstract class Crane
{
    public string TopCrates
    {
        get
        {
            var topCrates = new char?[CratesMap.GetLength(0)];
            for (int i = 0; i < CratesMap.GetLength(0); i++)
            {
                topCrates[i] = FindTopCrateInColumn(i);
            }

            return new string(
                topCrates
                    .Where(c => c.HasValue)
                    .Select(c => c.Value)
                    .ToArray()
                );
        }
    }

    private char? FindTopCrateInColumn(int column)
    {
        for (int j = CratesMap.GetLength(1) - 1; j >= 0; j--)
        {
            if (CratesMap[column, j] != null)
            {
                return CratesMap[column, j];
            }
        }

        return null;
    }

    public char?[,] CratesMap { get; }

    /// <summary>
    /// Last creat to move in each column.
    /// </summary>
    protected int[] CrateCountsPerColumn { get; }

    public Crane(char?[,] cratesMap)
    {
        CrateCountsPerColumn = new int[cratesMap.Length];

        for (var i = 0; i < cratesMap.GetLength(0); i++)
        {
            for (var j = 0; j < cratesMap.GetLength(1); j++)
            {
                if (cratesMap[i, j] != null)
                {
                    CrateCountsPerColumn[i]++;
                }
            }
        }

        // TODO: Could have been simplified using string.
        // Create creates map with the biggest possible 1st dimension.
        CratesMap = new char?[cratesMap.GetLength(0), CrateCountsPerColumn.Sum()];
        for (var i = 0; i < cratesMap.GetLength(0); i++)
        {
            for (var j = 0; j < cratesMap.GetLength(1); j++)
            {
                CratesMap[i, j] = cratesMap[i, j];
            }
        }
    }

    public abstract void Move(Instruction instruction);

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
            return new Instruction(int.Parse(parts[1]), int.Parse(parts[3])-1, int.Parse(parts[5])-1);
        }
    }
}