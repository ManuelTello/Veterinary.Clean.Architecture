using Veterinary.Backend.Domain.ObjectValues;

namespace Veterinary.Backend.Domain.AggregateRoots.Owner
{
    public sealed class Owner
    {
        public Guid Id { get; private set; } 
        
        public Name Name { get; private set; }
        
        public Email Email { get; private set; }
        
        public PhoneNumber PhoneNumber { get; private set; }
        
        //public ICollection<Pet.Pet> Pets { get; private set; }
        
        public Owner(Guid id,Name name, Email email, PhoneNumber phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            //this.Pets = new List<Pet.Pet>();
        }
        
        private Owner(){}
    }
}

