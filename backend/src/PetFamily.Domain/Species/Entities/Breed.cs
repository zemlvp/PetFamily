using CSharpFunctionalExtensions;
using PetFamily.Domain.Species.Ids;

namespace PetFamily.Domain.Species.Entities;

/// <summary>
/// Порода
/// </summary>
public class Breed : Entity<BreedId>
{
    // EF Core
    public Breed(BreedId id): base(id)
    {
    }
    
    private Breed(BreedId id, string name) : base(id)
    {
        Name = name;
    }
    
    public string Name { get; }

    public static Result<Breed> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Name is empty");
        
        var breed  = new Breed(id, name);

        return Result.Success(breed);
    }
}