using Microsoft.EntityFrameworkCore;
using Roadmap.Domain;


namespace Roadmap.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Domain.Roadmap> Roadmaps
    {
        get;
        set;
    }

    DbSet<Stage> Stages { get; set; }
    
    DbSet<RoadmapUser> RoadmapUs { get; set; }
    DbSet<Category> Categories { get; set; }

    DbSet<User> Users { get; set; }
    DbSet<StageUser>StageUsers { get; set; }
    
    DbSet<SubStage> SubStages { get; set; }
    DbSet<SubStageUser>SubStageUsers { get; set; }
    DbSet<FileStatus>FileStatus { get; set; }
   
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}