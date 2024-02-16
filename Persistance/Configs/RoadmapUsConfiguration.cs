using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class RoadmapUsConfiguration : IEntityTypeConfiguration<Domain.RoadmapUser>
{
    public void Configure(EntityTypeBuilder<Domain.RoadmapUser> builder)
    {
    }
    
}