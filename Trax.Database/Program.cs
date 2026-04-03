using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trax.Infrastructure;
using Trax.Infrastructure.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
        services.AddInfrastructureServices(context.Configuration))
    .Build();

using var scope = host.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<TraxDbContext>();

Console.WriteLine("Applying migrations to Supabase (trax)...");
await db.Database.MigrateAsync();
Console.WriteLine("Seeding reference data...");
await DataSeeder.SeedAsync(db);
Console.WriteLine("Done.");
