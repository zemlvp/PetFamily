using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.Volunters.Ids;
using PetFamily.Domain.Volunters.ValueObjects;

namespace PetFamily.Domain.Volunters.Entities;

public class Volunter : Entity<VolunterId>
{    
    // EF Core
    public Volunter() 
    {
    }

    private Volunter(
        VolunterId id, 
        string fullName, 
        Email email, 
        string description, 
        PhoneNumber phoneNumber, 
        int experienceYear,
        List<SocialNetwork> socialNetworks,
        List<BankRequisite> bankRequisites,
        List<Pet> pets) : base(id)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        PhoneNumber = phoneNumber;
        ExperienceYear = experienceYear;
        _socialNetworks = socialNetworks;
        _bankRequisites = bankRequisites;
        _pets = pets;
    }

    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; private set; } = default!;

    public Email Email { get; }

    /// <summary>
    /// Общее описание
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Опыт в годах
    /// </summary>
    public int ExperienceYear { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    
    private List<SocialNetwork> _socialNetworks = [];
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    
    private List<BankRequisite> _bankRequisites = [];
    public IReadOnlyList<BankRequisite> BankRequisites => _bankRequisites;


    private readonly List<Pet> _pets = [];
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

    public static Result<Volunter> Create(
        VolunterId volunterId, 
        string fullName, 
        Email email, 
        string description, 
        PhoneNumber phoneNumber,
        int experienceYear,
        List<SocialNetwork> socialNetworks,
        List<BankRequisite> bankRequisites,
        List<Pet> pets)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volunter>($"Full name is required");

        var volunter = new Volunter(volunterId, fullName, email, description, phoneNumber, experienceYear, socialNetworks, bankRequisites, pets);

        return Result.Success(volunter);
    }

    public void AddPet(Pet pet)
    {
        _pets.Add(pet);
    }
}