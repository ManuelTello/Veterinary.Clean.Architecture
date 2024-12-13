using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veterinary.Backend.Domain.AggregateRoots.Owner;
using Veterinary.Backend.Infrastructure.Persistence.Repositories;

namespace Veterinary.Backend.Infrastructure.Persistence.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("owners");

            builder.HasKey(owner => owner.Id);
            builder.Property(owner => owner.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("VARCHAR")
                .HasMaxLength(36);

            builder.OwnsOne(owner => owner.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(250);
            });

            builder.OwnsOne(owner => owner.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255);
            });

            builder.OwnsOne(owner => owner.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(e => e.Value)
                    .HasColumnName("phone_number")
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(10);
            });

            builder.OwnsOne(owner => owner.Identification, identification =>
            {
                identification.Property(i => i.Value)
                    .HasColumnName("identification")
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255);
            });

            builder.Property(owner => owner.DateAddedToSystem)
                .HasColumnName("date_added_to_system")
                .IsRequired()
                .HasColumnType("DATETIME");
        }
    }
}