namespace Trax.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Trax.Domain.Entities;
using Trax.Domain.Enums;

public static class DataSeeder
{
    public static async Task SeedAsync(TraxDbContext context)
    {
        await SeedCategoriesAsync(context);
        await SeedSuperAdminAsync(context);
        await context.SaveChangesAsync();
    }

    private static async Task SeedCategoriesAsync(TraxDbContext context)
    {
        if (await context.ItemCategories.AnyAsync()) return;

        await context.ItemCategories.AddRangeAsync(
            new ItemCategory { Name = "Furniture" },
            new ItemCategory { Name = "Appliances" },
            new ItemCategory { Name = "Clothing" },
            new ItemCategory { Name = "Electronics" },
            new ItemCategory { Name = "Kitchenware" },
            new ItemCategory { Name = "Bedding" },
            new ItemCategory { Name = "Toys & Games" },
            new ItemCategory { Name = "Books" },
            new ItemCategory { Name = "Other" }
        );
    }

    private static async Task SeedSuperAdminAsync(TraxDbContext context)
    {
        const string superAdminEmail = "tom.c.christensen@gmail.com";
        if (await context.Users.AnyAsync(u => u.Email == superAdminEmail)) return;

        await context.Users.AddAsync(new AppUser
        {
            Email = superAdminEmail,
            DisplayName = "Tom Christensen",
            Role = UserRole.SuperAdmin
        });
    }
}
