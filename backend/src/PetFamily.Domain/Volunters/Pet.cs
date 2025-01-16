using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunters;

public class Pet : Shared.Entity<PetId>
{
    // EF Core
    public Pet(PetId petId) : base(petId)
    {
    }

    private Pet(PetId petId, string name, string description, string color) :  base(petId)
    {
        Name = name;
        Description = description;
        Color = color;
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Color { get; private set; } = default!;

    public string HealthInformation { get; private set; } = default!;

    public string Address { get; private set; } = default!;
    public float Weight { get; private set; }
    public float Height { get; private set; }
    public bool IsCastrated { get; private set; }
    public bool IsVaccinated { get; private set; }
    public DateTime Birthday { get; private set; }
    public StatusAid StatusAid { get; private set; }

    public List<BankRequisite> BankDetails { get; private set; } = [];

    public Guid SpeciesId { get; private set; } = default!;
    public string BreedId { get; private set; } = default!;
    
    public DateTime CreatedAt { get; private set; }

    public static Result<Pet> Create(PetId petId, string name, string description, string color)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name is required");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description is required");
        
        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<Pet>("Color is required");
        
        var pet = new Pet(petId, name, description, color);

        return Result.Success(pet);
    }
}