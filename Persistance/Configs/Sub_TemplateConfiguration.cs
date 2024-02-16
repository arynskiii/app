using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class Sub_TemplateConfiguration : IEntityTypeConfiguration<Domain.Sub_Template>
{

    public void Configure(EntityTypeBuilder<Domain.Sub_Template> builder)
    {
        builder.HasKey(subTemplate => subTemplate.Id);
        builder.Property(subTempl => subTempl.Flag).HasDefaultValue(false);

    }
}