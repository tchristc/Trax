using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trax.Infrastructure;
using Trax.Infrastructure.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, config) => config.AddUserSecrets<Program>())
    .ConfigureServices((context, services) =>
        services.AddInfrastructureServices(context.Configuration))
    .Build();

using var scope = host.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<TraxDbContext>();
var connectionstring = db.Database.GetConnectionString();

Console.WriteLine("Applying migrations to Supabase (trax)...");
await db.Database.MigrateAsync();
Console.WriteLine("Seeding reference data...");
await DataSeeder.SeedAsync(db);
Console.WriteLine("Done.");

// To create a migration, use the following command:
// dotnet ef migrations add "initial database" --project Trax.Infrastructure --startup-project Trax.Database