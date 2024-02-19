using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class SubStageUserConfiguration : IEntityTypeConfiguration<Domain.FileStatus>
{
    public void Configure(EntityTypeBuilder<Domain.FileStatus> builder)
    {
        builder.Property(type => type.Flag).HasDefaultValue(false);
    }
    
}