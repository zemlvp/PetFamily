using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species.Ids;

public class BreedId : BaseClassId
{
    private BreedId(Guid value) : base(value)
    {
    }
    
    public static BreedId NewPetId()  => new(Guid.NewGuid());
    public static BreedId Empty()  => new(Guid.Empty);
    public static BreedId Create(Guid id) => new(id);
}