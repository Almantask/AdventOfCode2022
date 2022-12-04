using AdventOfCode.Common.Extensions;

namespace AdventOfCode.Day4
{
    public static class Camp
    {
        public static IEnumerable<ElfPair> ParseElfPairsFromAssignments(string assignments)
        {
            return assignments
                .SplitByEndOfLine()
                .Select(ElfPairFromAssignment);
        }

        private static ElfPair ElfPairFromAssignment(string assignment)
        {
            var pairAssignments = assignment.Split(',');
            var range1 = FromIndividualAssignmentToSectionRange(pairAssignments[0]);
            var range2 = FromIndividualAssignmentToSectionRange(pairAssignments[1]);

            return new ElfPair(range1, range2);

            SectionRange FromIndividualAssignmentToSectionRange(string individualAssignment)
            {
                var individual1Range = individualAssignment
                    .Split('-')
                    .Select(bound => int.Parse(bound))
                    .ToArray();

                return new SectionRange(individual1Range[0], individual1Range[1]);
            }
        }
    }
}
