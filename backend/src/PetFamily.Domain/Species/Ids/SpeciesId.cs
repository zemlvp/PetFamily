using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species.Ids;

public class SpeciesId : ComparableValueObject
{
    public Guid Value { get; }
    
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    
    public static SpeciesId NewPetId()  => new(Guid.NewGuid());
    public static SpeciesId Empty()  => new(Guid.Empty);

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Value;
    }
}