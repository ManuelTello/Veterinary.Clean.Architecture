namespace Veterinary.Backend.WebAPI.Contracts
{
    public sealed class CreateOwnerContract
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        
        public string Identification { get; set; } = string.Empty;
    }
}