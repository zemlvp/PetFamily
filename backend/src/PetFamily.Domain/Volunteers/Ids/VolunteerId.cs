using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.Ids;

public class VolunteerId : BaseClassId
{
    private VolunteerId(Guid value) : base(value)
    {
    }
    
    public static VolunteerId NewVolunterId()  => new(Guid.NewGuid());
    public static VolunteerId Empty()  => new(Guid.Empty);
    
    public static VolunteerId Create(Guid id) => new(id);
}