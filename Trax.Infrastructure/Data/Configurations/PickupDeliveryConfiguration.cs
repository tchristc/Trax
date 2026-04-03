namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class PickupDeliveryConfiguration : IEntityTypeConfiguration<PickupDelivery>
{
    public void Configure(EntityTypeBuilder<PickupDelivery> builder)
    {
        builder.ToTable("pickup_deliveries");
        builder.HasKey(pd => pd.Id);
        builder.Property(pd => pd.Address).HasMaxLength(500);
        builder.Property(pd => pd.Notes).HasMaxLength(1000);
        builder.HasOne(pd => pd.Donation)
            .WithOne(d => d.PickupDelivery)
            .HasForeignKey<PickupDelivery>(pd => pd.DonationId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(pd => pd.Organization)
            .WithMany(o => o.Deliveries)
            .HasForeignKey(pd => pd.OrganizationId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(pd => pd.Tasks)
            .WithOne(t => t.PickupDelivery)
            .HasForeignKey(t => t.PickupDeliveryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
