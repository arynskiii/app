using Microsoft.EntityFrameworkCore;


namespace Roadmap.Application.Interfaces;

public interface IRoadmapDbContext
{
    DbSet<Domain.Roadmap> Roadmaps
    {
        get;
        set;
    }

    DbSet<Domain.Admin> Admins { get; set; }
    DbSet<Domain.Employe>Employes { get; set; }    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}