using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance.RoadmapCfg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Roadmap.Persistance;

public class RoadmapDbContext : DbContext, IRoadmapDbContext
    
{
    public DbSet<Domain.Admin> Admins { get; set; }
    public DbSet<Domain.Employe>Employes { get; set; }
    public DbSet<Domain.Roadmap> Roadmaps { get; set; } 
    
    public RoadmapDbContext(DbContextOptions<RoadmapDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoadmapConfiguration());
        base.OnModelCreating(builder);
    }
}