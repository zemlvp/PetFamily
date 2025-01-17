using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.Ids;

namespace PetFamily.Domain.Species.Entities;

/// <summary>
/// Вид животного
/// </summary>
public class Species: Entity<SpeciesId>
{
    // EF Core
    public Species()
    {
    }
    
    private Species(SpeciesId id, string name, List<Breed> breeds) : base(id)
    {
        Name = name;
        Breeds = breeds;
    }
    
    public string Name { get; }

    public IReadOnlyList<Breed> Breeds { get; private set; }

    public static Result<Species> Create(SpeciesId id, string name, List<Breed> breeds)
    {
        if (string.IsNullOrEmpty(name))
            return Result.Failure<Species>("Name cannot be null or empty");

        var species = new Species(id, name, breeds);
        
        return Result.Success(species);
    }
}