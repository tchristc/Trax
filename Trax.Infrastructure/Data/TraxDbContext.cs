namespace Trax.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Trax.Domain.Common;
using Trax.Domain.Entities;

public class TraxDbContext(DbContextOptions<TraxDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Donation> Donations => Set<Donation>();
    public DbSet<DonationItem> DonationItems => Set<DonationItem>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Volunteer> Volunteers => Set<Volunteer>();
    public DbSet<PickupDelivery> PickupDeliveries => Set<PickupDelivery>();
    public DbSet<VolunteerTask> VolunteerTasks => Set<VolunteerTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraxDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
