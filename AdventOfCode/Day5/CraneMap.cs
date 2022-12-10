namespace AdventOfCode.Day5
{
    public static class CratesMap
    {
        public static char?[,] Parse(string[] map)
        {
            var lines = new List<char[]>();
            foreach (var line in map)
            {
                var cratesLevel = new List<char>();
                for (int i = 1; i < line.Length; i+=4)
                {
                    cratesLevel.Add(line[i]);
                }

                lines.Add(cratesLevel.ToArray());
            }

            var maxColumnHeight = lines.Max(l => l.Length);
            var crates = new char?[maxColumnHeight, lines.Count];
            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    crates[j, lines.Count - i - 1] = lines[i][j] == ' ' ? null : lines[i][j];
                }
            }

            return crates;
        }
    }
}
