namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class DonationItemConfiguration : IEntityTypeConfiguration<DonationItem>
{
    public void Configure(EntityTypeBuilder<DonationItem> builder)
    {
        builder.ToTable("donation_items");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).IsRequired().HasMaxLength(255);
        builder.Property(i => i.Description).HasMaxLength(1000);
        builder.Property(i => i.Notes).HasMaxLength(1000);
        builder.HasOne(i => i.Category)
            .WithMany(c => c.DonationItems)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(i => i.ReservedForOrganization)
            .WithMany()
            .HasForeignKey(i => i.ReservedForOrganizationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
