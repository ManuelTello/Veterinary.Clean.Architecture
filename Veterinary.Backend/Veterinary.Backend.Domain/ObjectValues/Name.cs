using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record Name
    {
        private const string RegexPattern = @"^$";

        public string Fullname { get; init; }

        private Name(string fullName)
        {
            this.Fullname = fullName;
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
                return Result.Ok(newName);
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}