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

        public static Name Create(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Name is required");
                //return Result.Fail<Name>("Name is required."); 
            }
            else if (!Validate().IsMatch(fullName))
            {
                throw new ArgumentException("Invalid name");
                //return Result.Fail<Name>("Invalid name");
            }
            else
            {
                var newName = new Name(fullName);
                return newName;
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}