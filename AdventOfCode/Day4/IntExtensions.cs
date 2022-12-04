using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode.Day4
{
    public static class IntExtensions
    {
        public static bool IsBetween(this int number, int start, int end) => 
            number >= start && number <= end ||
            number <= start && number >= end;

    }
}
