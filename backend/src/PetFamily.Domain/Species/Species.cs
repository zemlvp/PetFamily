namespace PetFamily.Domain.Species;

/// <summary>
/// Вид животного
/// </summary>
public class Species
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<Breed> Breeds = [];
}