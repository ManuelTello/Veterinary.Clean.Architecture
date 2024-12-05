using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record PhoneNumber
    {
        private const string RegexPattern = @"^([0-9]{10})$";

        private const int MaxLength = 10;
        
        public string Value { get; init; }

        private PhoneNumber(string value)
        {
            this.Value = value; 
        }

        public static Result<PhoneNumber> Create(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Fail<PhoneNumber>("Phone number is required");
            }
            else if (phoneNumber.Length > MaxLength || phoneNumber.Length < 10)
            {
                return Result.Fail<PhoneNumber>("Phone number length is invalid"); 
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

