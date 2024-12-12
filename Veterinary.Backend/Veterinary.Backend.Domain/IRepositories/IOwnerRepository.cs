using Veterinary.Backend.Domain.AggregateRoots.Owner;

namespace Veterinary.Backend.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        public Task SaveChangesAsync();
        
        public Task<Guid> Save(Owner owner, CancellationToken cancellationToken);
    }
}

