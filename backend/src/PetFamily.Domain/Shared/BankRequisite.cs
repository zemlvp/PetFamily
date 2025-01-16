namespace PetFamily.Domain.Shared;

/// <summary>
/// Банковские реквизиты 
/// </summary>
public record BankRequisite
{
    public string Name { get; set; } = default!;

    /// <summary>
    /// Описание, как сделать перевод
    /// </summary>
    public string Description { get; set; } = default!;
}