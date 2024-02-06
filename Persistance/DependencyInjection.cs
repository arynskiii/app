using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roadmap.Application.Interfaces;
using Roadmap.Domain;


namespace Roadmap.Persistance;

public  static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<RoadmapDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IRoadmapDbContext>(provider => provider.GetRequiredService<RoadmapDbContext>());
        
        services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<RoadmapDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}