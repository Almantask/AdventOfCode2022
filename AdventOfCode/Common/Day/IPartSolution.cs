namespace AdventOfCode.Common.Day
{
    public interface IPartSolution<TResult>
    {
        TResult Solve(string input);
    }
}
