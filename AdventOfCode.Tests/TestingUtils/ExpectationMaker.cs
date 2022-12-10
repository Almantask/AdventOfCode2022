namespace AdventOfCode.Tests.TestingUtils
{
    public static class ExpectationMaker
    {
        public static object[] Expect<T>(int day, string file, T result)
        {
            return new object[] { File.ReadAllText($"Input/Day{day}/{file}.txt"), result };
        }
    }
}
