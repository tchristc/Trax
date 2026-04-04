namespace Trax.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Trax.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TraxDbContext>
{
    public TraxDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<DesignTimeDbContextFactory>()
            .AddEnvironmentVariables()
            .Build();

        var options = new DbContextOptionsBuilder<TraxDbContext>()
            .UseNpgsql(config.GetConnectionString("DefaultConnection"))
            .Options;

        return new TraxDbContext(options);
    }
}
