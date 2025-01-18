using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species.Ids;

public class BreedId : ComparableValueObject
{
    public Guid Value { get; }
    
    private BreedId(Guid value)
    {
        Value = value;
    }
    
    public static BreedId NewPetId()  => new(Guid.NewGuid());
    public static BreedId Empty()  => new(Guid.Empty);

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}