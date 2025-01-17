using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Volunters.Ids;
using PetFamily.Domain.Volunters.ValueObjects;

namespace PetFamily.Domain.Volunters.Entities;

public class Pet : Entity<PetId>
{
    public const int MAX_NAME_LENGTH = 200;
    public const int MAX_DESCRIPTION_LENGTH = 3000;

    // EF Core
    public Pet()
    {
    }

    private Pet(PetId id,
                string name,
                string description,
                string color,      
                string healthInformation,
                Address address,
                float weight,
                float height,
                bool isCastrated,
                bool isVaccinated,
                DateTime birthDay,
                StatusAid statusAid) : base(id)
    {
        Name = name;
        Description = description;
        Color = color;
        HealthInformation = healthInformation;
        Address = address;
        Weight = weight;
        Height = height;
        IsCastrated = isCastrated;
        IsVaccinated = isVaccinated;
        Birthday = birthDay;
        StatusAid = statusAid;
    }

    public string Name { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public string Color { get; }
    public string HealthInformation { get; }

    public Address Address { get; }

    public float? Weight { get; }
    public float? Height { get; }
    public bool? IsCastrated { get; }
    public bool? IsVaccinated { get; }
    public DateTime? Birthday { get; }
    public StatusAid StatusAid { get; }

    public List<BankRequisite> BankRequisites { get; } = [];

    public Guid? SpeciesId { get; private set; }
    public string? BreedId { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public static Result<Pet> Create(
                PetId petId,
                string name,
                string description,
                string color,
                string healthInformation,
                Address address,
                float weight,
                float height,
                bool isCastrated,
                bool isVaccinated,
                DateTime birthDay,
                StatusAid statusAid)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>($"'{nameof(name)}' cannot be null or empty");

        if (name.Length > MAX_NAME_LENGTH)
            return Result.Failure<Pet>($"'{nameof(name)}' must be less than {MAX_NAME_LENGTH} symbols");        

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>($"'{nameof(description)}' cannot be null or empty");

        if (description.Length > MAX_DESCRIPTION_LENGTH)
            return Result.Failure<Pet>($"'{nameof(description)}' must be less than {MAX_DESCRIPTION_LENGTH} symbols");

        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<Pet>($"'{nameof(color)}' cannot be null or empty");

        var pet = new Pet(
                petId,
                name,
                description,
                color,
                healthInformation,
                address,
                weight,
                height,
                isCastrated,
                isVaccinated,
                birthDay,
                statusAid);

        return Result.Success(pet);
    }
}