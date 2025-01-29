using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Volunteers.ValueObjects
{
    public class Email : ComparableValueObject
    {
        private const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public string Value { get;  }

        private Email(string number)
        {
            Value = number;
        }

        public static Result<Email> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Email>($"Email can not be null or empty");

            if (Regex.IsMatch(input, EMAIL_REGEX) == false)
                return Result.Failure<Email>("Incorrect email format");

            var email = new Email(input);

            return Result.Success(email);
        }        

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
