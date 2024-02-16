using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roadmap.Domain;

namespace Roadmap.Persistance.RoadmapCfg;

public class TemplateUserConfiguration : IEntityTypeConfiguration<TemplateUser>
{
    public void Configure(EntityTypeBuilder<TemplateUser> builder)
    {
        builder.HasKey(templateUser => templateUser.Id);
    }
}