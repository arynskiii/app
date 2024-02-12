using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class TemplateConfiguration : IEntityTypeConfiguration<Domain.Template>
{
    public void Configure(EntityTypeBuilder<Domain.Template> builder)
    {
        builder.HasKey(template => template.Id);
    }
    
}