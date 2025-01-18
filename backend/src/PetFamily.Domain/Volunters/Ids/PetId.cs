using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunters.Ids;

public class PetId : ComparableValueObject
{
    public Guid Value { get; }
    
    private PetId(Guid value)
    {
        Value = value;
    }
    
    public static PetId NewPetId()  => new(Guid.NewGuid());
    public static PetId Empty()  => new(Guid.Empty);

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}