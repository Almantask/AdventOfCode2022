namespace AdventOfCode.Common.Day
{
    public interface IAdventOfCodeDay
    {
        void Solve();
    }

    public abstract class AdventOfCodeDay<TPart1, TPart2, TResult> : IAdventOfCodeDay
        where TPart1 : class, IPartSolution<TResult>, new()
        where TPart2 : class, IPartSolution<TResult>, new()
    {
        protected abstract int Day { get; }

        public void Solve()
        {
            var input = File.ReadAllText(@$"Days/{Day}.txt");

            var part1 = new TPart1();
            var part2 = new TPart2();

            Console.WriteLine($"Day{Day}, part1 answer: {part1.Solve(input)}");
            Console.WriteLine($"Day{Day}, Part2 answer: {part2.Solve(input)}");
        }
    }
}
