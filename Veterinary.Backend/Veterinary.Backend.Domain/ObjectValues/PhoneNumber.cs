using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record PhoneNumber
    {
        private const string RegexPattern = $"^$";
        
        public string Value { get; init; } = string.Empty;

        private PhoneNumber(string phoneNumber)
        {
            this.Value = phoneNumber; 
        }

        public static Result<PhoneNumber> Create(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Fail<PhoneNumber>("Phone number is required");
            }
            else if (!Validate().IsMatch(phoneNumber))
            {
                return Result.Fail<PhoneNumber>("Phone number is invalid");
            }
            else
            {
                var newPhoneNumber = new PhoneNumber(phoneNumber); 
                return Result.Ok<PhoneNumber>(newPhoneNumber);
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}

