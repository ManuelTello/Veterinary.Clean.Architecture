using Microsoft.EntityFrameworkCore;
using Veterinary.Backend.Domain.AggregateRoots.Owner;
using Veterinary.Backend.Domain.AggregateRoots.Pet;

namespace Veterinary.Backend.Infrastructure.Persistence.Context
{
    public class VeterinaryContext:DbContext
    {
        public VeterinaryContext(DbContextOptions<VeterinaryContext> options):base (options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeterinaryContext).Assembly);
        }
        
        public DbSet<Owner> Owners { get; set; }
        
        //public DbSet<Pet> Pets { get; set; }
    }
}

