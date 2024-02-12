using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class TemplateConfiguration : IEntityTypeConfiguration<Domain.Template>
{
    public void Configure(EntityTypeBuilder<Domain.Template> builder)
    {
        builder.HasKey(template  => template.Id);
        builder.HasIndex(template => template.Id).IsUnique();
        builder.Property(template   => template.Title).IsRequired();
        builder.Property(template  => template.Description).IsRequired();
    }
    
}