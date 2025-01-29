using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.Entities;
using PetFamily.Domain.Volunteers.Ids;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(p => p.Color)
            .IsRequired().HasMaxLength(Constants.TEXT_LENGTH_20);

        builder.Property(p => p.HealthInformation)
            .IsRequired(false)
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(p => p.Weight)
            .IsRequired(false);

        builder.Property(p => p.Height)
            .IsRequired(false);

        builder.Property(p => p.IsCastrated)
            .IsRequired(false);

        builder.Property(p => p.IsVaccinated)
            .IsRequired(false);

        builder.Property(p => p.Birthday)
            .IsRequired(false);
        
        builder.Property(p => p.StatusAid)
            .IsRequired();

        builder.Property(p => p.SpeciesId)
            .IsRequired(false);

        builder.Property(p => p.BreedId)
            .IsRequired(false);
        
        builder.Property(p => p.CreatedDate)
            .IsRequired();
    }
}