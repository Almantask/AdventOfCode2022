namespace AdventOfCode.Day4;

public class ElfPair
{
    public bool IsFullOverlap => _elf1RangeToClean.IsFullOverlapWith(_elf2RangeToClean);
    public bool IsSomeOverlap => _elf1RangeToClean.IsOverlapWith(_elf2RangeToClean);

    private readonly SectionRange _elf1RangeToClean;
    private readonly SectionRange _elf2RangeToClean;

    public ElfPair(SectionRange elf1RangeToClean, SectionRange elf2RangeToClean)
    {
        _elf1RangeToClean = elf1RangeToClean;
        _elf2RangeToClean = elf2RangeToClean;
    }
}