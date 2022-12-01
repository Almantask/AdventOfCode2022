namespace AdventOfCode.Common.Day
{
    public interface IAdventOfCodeDay
    {
        void Solve();
    }

    public abstract class AdventOfCodeDay<TPart1, TPart2> : IAdventOfCodeDay
        where TPart1 : class, IPartSolution, new()
        where TPart2 : class, IPartSolution, new()
    {
        protected abstract int Day { get; }

        public void Solve()
        {
            var input = ReadInputInAHackyWayWorkingForTests();


            var part1 = new TPart1();
            var part2 = new TPart2();

            Console.WriteLine($"Day{Day}, part1 answer: " + part1.Solve(input));
            Console.WriteLine($"Day{Day}, Part2 answer: " + part2.Solve(input));
        }

        /// <summary>
        /// Some tests runners copy the files from the bin of app under test, other don't.
        /// This is a workaround to cater for both scenarios.
        /// </summary>
        private string ReadInputInAHackyWayWorkingForTests()
        {
            string input;
            try
            {
                Directory.SetCurrentDirectory(@".\..\..\..\..\AdventOfCode.Exec\bin\Debug\net6.0");
                input = File.ReadAllText(@$"Days\{Day}.txt");
            }
            catch
            {
                Directory.SetCurrentDirectory(@".\..\..\..\..\AdventOfCode.Tests\bin\Debug\net6.0");
                input = File.ReadAllText(@$"Days\{Day}.txt");
            }

            return input;
        }
    }
}
