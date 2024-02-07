using Microsoft.EntityFrameworkCore;


namespace Roadmap.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Domain.Roadmap> Roadmaps
    {
        get;
        set;
    }

    DbSet<Domain.User> Users { get; set; }
   
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}