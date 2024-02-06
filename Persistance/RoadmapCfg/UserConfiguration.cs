using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Admin>
{
    public void Configure(EntityTypeBuilder<Domain.Admin> builder)
    {
        builder.HasKey(admin => admin.Id);
    }
    
}