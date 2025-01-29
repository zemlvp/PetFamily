using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class Address : ComparableValueObject
{
    public string City { get; }
    public string Street { get; }
    public string ZipCode { get; }

    private Address(string city, string street, string zipCode)
    {
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    public static Result<Address> Create(string city, string street, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>($"'{nameof(city)}' can not be null or empty");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>($"'{nameof(street)}' can not be null or empty");

        if (string.IsNullOrWhiteSpace(zipCode))
            return Result.Failure<Address>($"'{nameof(zipCode)}' can not be null or empty");

        var address = new Address(city, street, zipCode);

        return Result.Success(address);
    }

    protected override IEnumerable<IComparable> GetComparableEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return ZipCode;
    }
}