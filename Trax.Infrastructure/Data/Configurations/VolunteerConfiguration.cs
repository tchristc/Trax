namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(v => v.LastName).IsRequired().HasMaxLength(100);
        builder.Property(v => v.Email).IsRequired().HasMaxLength(255);
        builder.Property(v => v.Phone).HasMaxLength(50);
        builder.Property(v => v.Notes).HasMaxLength(1000);
        builder.HasOne(v => v.AppUser)
            .WithOne(u => u.Volunteer)
            .HasForeignKey<Volunteer>(v => v.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(v => v.Tasks)
            .WithOne(t => t.Volunteer)
            .HasForeignKey(t => t.VolunteerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
