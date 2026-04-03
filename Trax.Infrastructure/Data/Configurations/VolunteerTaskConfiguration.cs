namespace Trax.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trax.Domain.Entities;

public class VolunteerTaskConfiguration : IEntityTypeConfiguration<VolunteerTask>
{
    public void Configure(EntityTypeBuilder<VolunteerTask> builder)
    {
        builder.ToTable("volunteer_tasks");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Notes).HasMaxLength(1000);
    }
}
