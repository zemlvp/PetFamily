using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Volunteers.Ids;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Domain.Volunteers.Entities;

public sealed class Volunteer : Entity<VolunteerId>
{   
    // EF Core
    public Volunteer(VolunteerId id): base(id) 
    {
    }

    private Volunteer(
        VolunteerId id, 
        string fullName, 
        string email, 
        string description, 
        string phoneNumber, 
        int experienceYear,
        SocialNetworkDetails socialNetworkDetails,
        BankRequisitesDetails bankRequisitesDetails,
        List<Pet> pets) : base(id)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        PhoneNumber = phoneNumber;
        ExperienceYear = experienceYear;
        SocialNetworkDetails = socialNetworkDetails;
        BankRequisitesDetails = bankRequisitesDetails;
        _pets = pets;
    }

    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; private set; } = default!;

    public string Email { get; }

    /// <summary>
    /// Общее описание
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Опыт в годах
    /// </summary>
    public int ExperienceYear { get; private set; }

    public string PhoneNumber { get; private set; }

    public SocialNetworkDetails? SocialNetworkDetails { get; private set; }

    public BankRequisitesDetails? BankRequisitesDetails { get; private set; }

    private readonly List<Pet> _pets = [];
    public IReadOnlyList<Pet> Pets => _pets;

    public int GetNumberOfPets() => _pets.Count;

    /// <summary>
    /// Количество домашних животных, которые смогли найти дом
    /// </summary>
    public int GetPetsCountFoundedHome() => Pets.Count(p => p.StatusAid == StatusAid.FoundHome);

    /// <summary>
    /// Количество домашних животных, которые ищут дом в данный момент времени 
    /// </summary>
    public int GetPetsCountLookingHome() => Pets.Count(p => p.StatusAid == StatusAid.LookingHome);

    /// <summary>
    /// Количество животных, которые сейчас находятся на лечении 
    /// </summary>
    public int GetPetsCountNeedsHelp() => Pets.Count(p => p.StatusAid == StatusAid.NeedsHelp);

    public static Result<Volunteer> Create(
        VolunteerId volunteerId, 
        string fullName, 
        string email, 
        string description, 
        string phoneNumber,
        int experienceYear,
        SocialNetworkDetails socialNetworksDetails,
        BankRequisitesDetails bankRequisitesDetails,
        List<Pet> pets)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volunteer>($"Full name is required");

        var volunteer = new Volunteer(volunteerId, fullName, email, description, phoneNumber, experienceYear, 
                                      socialNetworksDetails, bankRequisitesDetails, pets);

        return Result.Success(volunteer);
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}