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

    DbSet<Template> Templates { get; set; }
    
    DbSet<RoadmapUser> RoadmapUs { get; set; }
    DbSet<Category> Categories { get; set; }

    DbSet<User> Users { get; set; }
    DbSet<TemplateUser>TemplateUsers { get; set; }
    
    DbSet<Sub_Template> SubTemplates { get; set; }
    DbSet<Sub_TemplateUser>SubTemplateUsers { get; set; }
    DbSet<FileStatus>FileStatus { get; set; }
   
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}