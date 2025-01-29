namespace PetFamily.Domain.Volunteers.ValueObjects;

public record SocialNetworkDetails
{
    public List<SocialNetwork> SocialNetworks { get; private set; }
}