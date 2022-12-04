namespace AdventOfCode.Day4;

public class SectionRange
{
    public int MiddlePoint => (IdFrom + IdTo) / 2;
    public int IdFrom { get; }
    public int IdTo { get; }

    public SectionRange(int idFrom, int idTo)
    {
        IdFrom = idFrom;
        IdTo = idTo;
    }

    public bool IsFullOverlapWith(SectionRange other)
    {
        SectionRange biggerRange;
        SectionRange rangeToFit;

        // Bigger range starts at the same place or earlier.
        if (this.IdFrom < other.IdFrom)
        {
            biggerRange = this;
            rangeToFit = other;
        }
        // In case both ranges start at the same place, the bigger one is the one that ends later.
        else if (this.IdFrom == other.IdFrom && this.IdTo >= other.IdTo)
        {
            biggerRange = this;
            rangeToFit = other;
        }
        else
        {
            biggerRange = other;
            rangeToFit = this;
        }

        return rangeToFit.IdFrom >= biggerRange.IdFrom &&
               rangeToFit.IdTo <= biggerRange.IdTo;
    }

    public bool IsOverlapWith(SectionRange other)
    {
        var isSomeOverlap = this.IdFrom.IsBetween(other.IdFrom, other.IdTo) ||
                            this.IdTo.IsBetween(other.IdFrom, other.IdTo) ||
                            MiddlePoint.IsBetween(other.IdFrom, other.IdTo) || // Either middle point inside;
                            other.MiddlePoint.IsBetween(this.IdFrom, this.IdTo); // Either middle point inside;
        return isSomeOverlap;
    }
}