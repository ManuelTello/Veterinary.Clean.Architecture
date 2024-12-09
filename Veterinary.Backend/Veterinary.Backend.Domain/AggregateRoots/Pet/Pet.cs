namespace Veterinary.Backend.Domain.AggregateRoots.Pet
{
    public sealed class Pet
    {
        public Guid Id { get; private set; }

        public Pet(Guid id)
        {
            this.Id = id; 
        }
    }
}

