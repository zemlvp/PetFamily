using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.ValueObjects;

/// <summary>
/// Банковские реквизиты 
/// </summary>
public class BankRequisite : ComparableValueObject
{
    private BankRequisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; } = default!;

    /// <summary>
    /// Описание, как сделать перевод
    /// </summary>
    public string Description { get; } = default!;

    public static Result<BankRequisite> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<BankRequisite>($"'{nameof(name)}' is required");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<BankRequisite>($"'{nameof(description)}' is required");
        
        var bankRequisite = new BankRequisite(name, description);
        
        return Result.Success(bankRequisite);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Name;
        yield return Description;
    }
}