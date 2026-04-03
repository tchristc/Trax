namespace Trax.Application;

using Microsoft.Extensions.DependencyInjection;
using Trax.Application.Interfaces;
using Trax.Application.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDonationService, DonationService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IVolunteerService, VolunteerService>();
        services.AddScoped<ISchedulingService, SchedulingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        return services;
    }
}
