using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Roadmap.Persistance.RoadmapCfg;

public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Category> builder)
    {
        builder.HasKey(category => category.Id);
    }
    
}