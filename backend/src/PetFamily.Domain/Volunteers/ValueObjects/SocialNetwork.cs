using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class SocialNetwork : ComparableValueObject
{
    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }
    
    public string Name { get; }
    public string Url { get; } 
    
    public static Result<SocialNetwork> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<SocialNetwork>("Name is required");
        
        if (string.IsNullOrWhiteSpace(url))
            return Result.Failure<SocialNetwork>("Url is required");
        
        var socialNetwork = new SocialNetwork(name, url);
        
        return Result.Success(socialNetwork);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Name;
        yield return Url;
    }

}