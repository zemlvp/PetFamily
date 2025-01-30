using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Volunteers.ValueObjects
{
    public class PhoneNumber : ComparableValueObject
    {
        public const int MAX_LENGTH = 11;
        private const string PHONE_REGEX = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string Number { get;  }

        private PhoneNumber(string number)
        {
            Number = number;
        }

        public static Result<PhoneNumber> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return Result.Failure<PhoneNumber>($"'{nameof(number)}' can not be null or empty");

            if (Regex.IsMatch(number, PHONE_REGEX) == false)
                return Result.Failure<PhoneNumber>("Incorrect number format");

            var phoneNumber = new PhoneNumber(number);

            return Result.Success(phoneNumber);
        }        

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Number;
        }
    }
}
