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
    
    DbSet<Category> Categories { get; set; }

    DbSet<Domain.User> Users { get; set; }
   
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}