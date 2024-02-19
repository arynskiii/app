using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roadmap.Domain;

namespace Roadmap.Persistance.RoadmapCfg;

public class TemplateUserConfiguration : IEntityTypeConfiguration<StageUser>
{
    public void Configure(EntityTypeBuilder<StageUser> builder)
    {
        builder.HasKey(templateUser => templateUser.Id);
    }
}