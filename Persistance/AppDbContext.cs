using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance.RoadmapCfg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Roadmap.Domain;


namespace Roadmap.Persistance;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IAppDbContext
{
   public DbSet<StageUser> StageUsers { get; set; }
   public DbSet<SubStageUser>SubStageUsers { get; set; }
    public DbSet<Domain.Category> Categories { get; set; }
    public DbSet<Domain.Stage> Stages { get; set; }
    public DbSet<Domain.Roadmap> Roadmaps { get; set; } 
    public DbSet<Domain.RoadmapUser>RoadmapUs { get; set; }
    
    public DbSet<SubStage> SubStages { get; set; }
    public     DbSet<FileStatus>FileStatus { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoadmapConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new TemplateConfiguration());
        
        base.OnModelCreating(builder);
    }
}