namespace AdventOfCode.Day4;

public class ElfPair
{
    public bool IsFullOverlap { get; }

    public ElfPair(SectionRange elf1RangeToClean, SectionRange elf2RangeToClean)
    {
        IsFullOverlap = elf1RangeToClean.IsFullOverlapWith(elf2RangeToClean);
    }
}