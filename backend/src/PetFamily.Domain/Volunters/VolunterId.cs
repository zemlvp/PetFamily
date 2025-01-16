namespace PetFamily.Domain.Volunters;

public record VolunterId
{
    private VolunterId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    public static VolunterId NewVolunterId()  => new(Guid.NewGuid());
    public static VolunterId Empty()  => new(Guid.Empty);
}