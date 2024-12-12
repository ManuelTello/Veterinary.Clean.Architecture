using Veterinary.Backend.Domain.AggregateRoots.Owner;
using Veterinary.Backend.Domain.IRepositories;
using Veterinary.Backend.Infrastructure.Persistence.Context;

namespace Veterinary.Backend.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository:IOwnerRepository
    {
        private readonly VeterinaryContext _context;

        public OwnerRepository(VeterinaryContext context)
        {
            this._context = context; 
        }
        
        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync(); 
        }

        public async Task<Guid> Save(Owner owner, CancellationToken cancellationToken)
        {
            await this._context.Owners.AddAsync(owner);
            return owner.Id;
        }
    }
}

