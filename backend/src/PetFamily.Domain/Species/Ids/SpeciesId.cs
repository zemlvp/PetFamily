using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species.Ids;

public class SpeciesId : BaseClassId
{
    private SpeciesId(Guid value) : base(value)
    {
    }
    
    public static SpeciesId NewPetId()  => new(Guid.NewGuid());
    public static SpeciesId Empty()  => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}