using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunters.Ids;

public class VolunterId : ComparableValueObject
{
    public Guid Value { get; }
    
    private VolunterId(Guid value)
    {
        Value = value;
    }
    
    public static VolunterId NewVolunterId()  => new(Guid.NewGuid());
    public static VolunterId Empty()  => new(Guid.Empty);
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}