namespace PetFamily.Domain.Volunteers.ValueObjects;

public record BankRequisitesDetails
{
    public List<BankRequisite> BankRequisites { get; private set; }
}