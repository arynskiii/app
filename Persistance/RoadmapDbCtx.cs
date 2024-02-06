using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance.RoadmapCfg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Roadmap.Domain;


namespace Roadmap.Persistance;

public class RoadmapDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IRoadmapDbContext
{
    public DbSet<Domain.Roadmap> Roadmaps { get; set; } 
    
    public RoadmapDbContext(DbContextOptions<RoadmapDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoadmapConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
       
        
        base.OnModelCreating(builder);
    }
}