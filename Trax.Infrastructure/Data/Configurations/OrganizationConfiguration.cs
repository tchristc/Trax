namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("organizations");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(255);
        builder.Property(o => o.ContactName).HasMaxLength(255);
        builder.Property(o => o.Email).HasMaxLength(255);
        builder.Property(o => o.Phone).HasMaxLength(50);
        builder.Property(o => o.Address).HasMaxLength(500);
        builder.Property(o => o.Notes).HasMaxLength(1000);
    }
}
