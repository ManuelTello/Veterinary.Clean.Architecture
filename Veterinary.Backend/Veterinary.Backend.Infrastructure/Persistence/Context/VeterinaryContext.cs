using Microsoft.EntityFrameworkCore;

namespace Veterinary.Backend.Infrastructure.Persistence.Context
{
    public class VeterinaryContext:DbContext
    {
        public VeterinaryContext(DbContextOptions<VeterinaryContext> options):base (options){}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeterinaryContext).Assembly);
        }
    }
}

