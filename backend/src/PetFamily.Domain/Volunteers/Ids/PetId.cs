using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.Ids;

public class PetId : BaseClassId
{
    private PetId(Guid value) : base(value)
    {
    }
    
    public static PetId NewPetId()  => new(Guid.NewGuid());
    public static PetId Empty()  => new(Guid.Empty);
    
    public static PetId Create(Guid id) => new(id);
}