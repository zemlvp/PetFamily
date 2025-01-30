using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.Entities;
using PetFamily.Domain.Volunteers.Ids;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.Property(v => v.FullName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(v => v.ExperienceYear)
            .IsRequired();
        
        builder.Property(v => v.PhoneNumber)
            .IsRequired()
            .HasMaxLength(PhoneNumber.MAX_LENGTH);

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");

        builder.OwnsOne(v  => v.SocialNetworkDetails, vb =>
        {
            vb.ToJson();

            vb.OwnsMany(s => s.SocialNetworks, sb =>
            {
                sb.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                sb.Property(s => s.Url)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });
        });
        
        builder.OwnsOne(v => v.BankRequisitesDetails, vb =>
        {
            vb.ToJson();

            vb.OwnsMany(b => b.BankRequisites, bb =>
            {
                bb.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                bb.Property(b => b.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });
        });
    }
}