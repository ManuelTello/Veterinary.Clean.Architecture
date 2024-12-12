using Veterinary.Backend.Domain.ObjectValues;

namespace Veterinary.Backend.Domain.AggregateRoots.Owner
{
    public sealed class Owner
    {
        public Guid Id { get; private set; } 
        
        public Name Name { get; private set; }
        
        public Email Email { get; private set; }
        
        public PhoneNumber PhoneNumber { get; private set; }
        
        public Identification Identification { get; private set; }
        
        public DateTime DateAddedToSystem { get; private set; }
        
        public Owner(Guid id,Name name, Email email, PhoneNumber phoneNumber,Identification identification ,DateTime dateAddedToSystem)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Identification = identification;
            this.DateAddedToSystem = dateAddedToSystem;
        }
        
        private Owner(){}
    }
}

