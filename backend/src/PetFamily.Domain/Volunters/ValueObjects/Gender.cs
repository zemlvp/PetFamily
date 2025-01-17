using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunters.ValueObjects
{
    public class Gender : ComparableValueObject
    {
        public static readonly Gender Male = new(nameof(Male));
        public static readonly Gender Female = new(nameof(Female));

        private static readonly Gender[] _all = [Male, Female];

        public string Value { get; }

        private Gender(string value)
        {
            Value = value;
        }

        public static Result<Gender> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Gender>("Gender cannot be null or empty");

            var gender = input.Trim().ToLower();

            if (_all.Any(g => g.Value.ToLower() == gender) == false)
                return Result.Failure<Gender>("Gender is invalid");

            return new Gender(gender);
            
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
