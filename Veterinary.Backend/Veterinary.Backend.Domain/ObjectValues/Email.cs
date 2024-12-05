using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record Email
    {
        private const string RegexPattern = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        
        public string Value { get; init; }

        private Email(string value)
        {
            this.Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                return Result.Fail<Email>("Email is required");
            }
            else if(!Validate().IsMatch(email))
            {
                return Result.Fail<Email>("Email address is not valid"); 
            }
            else
            {
                var newEmail = new Email(email);
                return Result.Ok<Email>(newEmail);
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}

