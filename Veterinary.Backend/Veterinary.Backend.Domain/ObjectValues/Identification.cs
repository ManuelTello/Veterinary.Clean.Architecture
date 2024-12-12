using System.Text.RegularExpressions;
using FluentResults;

namespace Veterinary.Backend.Domain.ObjectValues
{
    public partial record Identification
    {
        private const string RegexPattern = "^([0-9])*$";
        
        private const int MaxLength = 250;
        
        private const int MinLength = 5;

        public string Value { get; init; }

        private Identification(string value)
        {
            this.Value = value;
        }

        public static Result<Identification> Create(string identification)
        {
            if (string.IsNullOrWhiteSpace(identification) || string.IsNullOrEmpty(identification))
            {
                return Result.Fail<Identification>(new Error("Field is required"));
            }
            else if (!Validate().IsMatch(identification))
            {
                return Result.Fail<Identification>(new Error("Identification is not valid"));
            }
            else if(identification.Length >= MaxLength)
            {
                return Result.Fail<Identification>(new Error("Identification is too long")); 
            }
            else if (identification.Length <= MinLength)
            {
                return Result.Fail<Identification>(new Error("Identification is too short"));
            }
            else
            {
                var newIdentification = new Identification(identification);
                return Result.Ok<Identification>(newIdentification);
            }
        }

        [GeneratedRegex(RegexPattern)]
        public static partial Regex Validate();
    }
}