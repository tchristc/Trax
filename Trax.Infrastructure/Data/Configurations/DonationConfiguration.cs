namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("donations");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.DonorName).IsRequired().HasMaxLength(255);
        builder.Property(d => d.DonorEmail).IsRequired().HasMaxLength(255);
        builder.Property(d => d.DonorPhone).HasMaxLength(50);
        builder.Property(d => d.PickupAddress).HasMaxLength(500);
        builder.Property(d => d.Notes).HasMaxLength(1000);
        builder.HasMany(d => d.Items)
            .WithOne(i => i.Donation)
            .HasForeignKey(i => i.DonationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
