namespace PetFamily.Domain.Shared;

public record SocialNetwork
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}