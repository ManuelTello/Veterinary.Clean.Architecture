using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record Name
    {
        private const string RegexPattern = @"^([a-zA-Z]\s*)+$";

        public string Value { get; init; }

        private Name(string value)
        {
            this.Value = value;
        }

        public static Result<Name> Create(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrWhiteSpace(fullName))
            {
                return Result.Fail<Name>("Name is required."); 
            }
            else if (!Validate().IsMatch(fullName))
            {
                return Result.Fail<Name>("Invalid name");
            }
            else
            {
                var newName = new Name(fullName);
                return Result.Ok<Name>(newName);
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}