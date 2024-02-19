using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class FileStatusConfiguration : IEntityTypeConfiguration<Domain.SubStage>
{

    public void Configure(EntityTypeBuilder<Domain.SubStage> builder)
    {
        builder.HasKey(subTemplate => subTemplate.Id);
       

    }
}