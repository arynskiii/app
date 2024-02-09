using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance.RoadmapCfg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Roadmap.Domain;


namespace Roadmap.Persistance;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IAppDbContext
{
    public DbSet<Domain.Category> Categories { get; set; }
    public DbSet<Domain.Roadmap> Roadmaps { get; set; } 
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoadmapConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
       
        
        base.OnModelCreating(builder);
    }
}