using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunters;

public class Volunter : Shared.Entity<VolunterId>
{
    private readonly List<Pet> _pets = [];

    // EF Core
    public Volunter(VolunterId id) : base(id)
    {
    }

    private Volunter(VolunterId volunterId, string fullName, string email) : base(volunterId)
    {
        FullName = fullName;
        Email = email;
    }

    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; private set; } = default!;

    public string Email { get; private set; } = default!;

    /// <summary>
    /// Общее описание
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Опыт в годах
    /// </summary>
    public int ExperienceYear { get; private set; }

    public string Phone { get; private set; } = default!;
    public List<SocialNetwork> SocialNetworks { get; private set; } = default!;
    public List<BankRequisite> BankDetails { get; private set; } = default!;
    public IReadOnlyList<Pet> Pets => _pets;

    public int GetNumberOfPets() => _pets.Count;

    /// <summary>
    /// Количество домашних животных, которые смогли найти дом
    /// </summary>
    public int GetPetsCountFoundHome() => Pets.Count(p => p.StatusAid == StatusAid.FoundHome);

    /// <summary>
    /// Количество домашних животных, которые ищут дом в данный момент времени 
    /// </summary>
    public int GetPetsCountLookingHome() => Pets.Count(p => p.StatusAid == StatusAid.LookingHome);

    /// <summary>
    /// Количество животных, которые сейчас находятся на лечении 
    /// </summary>
    public int GetPetsCountNeedsHelp() => Pets.Count(p => p.StatusAid == StatusAid.NeedsHelp);

    public static Result<Volunter> Create(VolunterId volunterId, string fullName, string email)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volunter>($"Full name is required");

        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Volunter>($"Email name is required");

        var volunter = new Volunter(volunterId, fullName, email);

        return Result.Success(volunter);
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}