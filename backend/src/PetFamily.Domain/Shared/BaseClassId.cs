using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public class BaseClassId : ComparableValueObject
{
    public Guid Value { get; }
    
    protected BaseClassId(Guid value)
    {
        Value = value;
    }
    
    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}